#include <stdio.h>
#include <string.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>

#include <string>
#include <iostream>
#include <sstream>

#include <net/if.h>
#include <sys/ioctl.h>
#include <sys/socket.h>

#include <linux/can.h>
#include <linux/can/raw.h>

#include "SUSI_IMC.h"
#include "common.h"
#include "pthread.h"
#include "lib.h"

static int polling_mode = 0;

#if defined (__linux__)
#include <unistd.h>
static pthread_t can_thread_handle = 0;
static int thread_enable = 0;
static pthread_cond_t can_rx_event;
static pthread_mutex_t can_rx_mutex;

static IMC_CAN_MSG_OBJECT last_can_message;
static bool is_set_last_can_message = false;

static void *can_read_thread(void *p)
{
	while(thread_enable)
	{
		if( polling_mode )
		{
			usleep(100000);
		}
		else
		{
			pthread_mutex_lock(&can_rx_mutex);
			pthread_cond_wait(&can_rx_event, &can_rx_mutex);
			pthread_mutex_unlock(&can_rx_mutex);
		}
		
		USHORT result;
		IMC_CAN_MSG_OBJECT message;
		while( (result = SUSI_IMC_CAN_Read(&message)) == IMC_ERR_NO_ERROR)
		{
			char can_cmd[200] = "":
			
			sprintf(can_cmd, "candump vcan%i %lx#",  (message.can_bus_number - 1), message.id);
			
			//can_cmd += strcat( message.id , "#");
			
			printf("<CAN,%d>id=%lx,", message.can_bus_number, message.id);
									
			if(message.message_type & CAN_MESSAGE_EXTENDED)
			{
				printf("EX,");
			}
			
			if(message.message_type & CAN_MESSAGE_RTR)
			{
				printf("RTR\n");
				continue;
			}			
			
			printf("DLC=%d,", message.buf_len);
			
			for(int i=0;i<message.buf_len;i++)
			{
				printf("%02x ",message.buf[i]);
				
				sprintf(can_cmd,"%s%02x",can_cmd,message.buf[i]);
				
				//std::string buffMsg = message.buf[i];
				//std:cout << buffMsg;
				//can_cmd += buffMsg;
			}
				
			printf("\n");
			//std:cout << can_cmd;
			printf("This is the value: %s",can_cmd);
		}

		if( result != IMC_CAN_RX_NOT_READY )
		{
			printf("SUSI_IMC_CAN_Read fail. error code=0x%04x\n", result);
			continue;
		}
	
	}
	return 0;
}
#endif

enum page_function{
	CAN_READ_ENABLE = 1,
	CAN_READ_DISABLE,
	CAN_WRITE,
	CAN_QUICK_WRITE,
	CAN_SET_SPEED,
	CAN_SET_SPEED_LISTEN_MODE,
	CAN_GET_SPEED,
	CAN_GET_ERROR_STATUS,
	CAN_GET_MASK,
	CAN_SET_MASK,
	CAN_REMOVE_MASK,
	CAN_RESET_MASK,
	CAN_SET_READ_MODE
};

static void show_welcome_title(void)
{
	printf("VCIL SDK Sample -- library version:%s\n", library_version);
	printf(">> CAN Menu Read=%s MODE = %s\n\n", thread_enable ? "Enable" : "Disable",
	polling_mode ? "Polling":"Event");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) CAN Read Enable\n", CAN_READ_ENABLE);
	printf("%d) CAN Read Disable\n", CAN_READ_DISABLE);
	printf("%d) CAN Write\n", CAN_WRITE);
	printf("%d) CAN Write last message\n", CAN_QUICK_WRITE);
	printf("%d) CAN Set Speed\n", CAN_SET_SPEED);
	printf("%d) CAN Set Speed (Listen mode)\n", CAN_SET_SPEED_LISTEN_MODE);
	printf("%d) CAN Get Speed\n", CAN_GET_SPEED);
	printf("%d) CAN Get Error Status\n", CAN_GET_ERROR_STATUS);	
	printf("%d) CAN Get Mask\n", CAN_GET_MASK);
	printf("%d) CAN Set Mask\n", CAN_SET_MASK);
	printf("%d) CAN Remove Mask\n", CAN_REMOVE_MASK);
	printf("%d) CAN Reset Mask\n", CAN_RESET_MASK);
	printf("%d) CAN Set Read Mode\n", CAN_SET_READ_MODE);
		
	printf("\nEnter your choice: ");
}

int can_read_enable()
{
	thread_enable = 1;
	
#if defined (__linux__)
	pthread_attr_t thread_attr;
	pthread_attr_init(&thread_attr);
	int ret = ::pthread_create(&can_thread_handle, &thread_attr, &can_read_thread, NULL);
	pthread_attr_destroy(&thread_attr);
	
	if( ret < 0)
	{
		printf("can thread create fail.");
		return -1;
	}
#endif
	return 0;
}

void can_read_disable()
{
	if(!thread_enable)
		return;
	thread_enable = 0;
	
#if defined (__linux__)
	pthread_mutex_lock(&can_rx_mutex);
	pthread_cond_broadcast(&can_rx_event);
	pthread_mutex_unlock(&can_rx_mutex);
	
	::pthread_join(can_thread_handle, NULL);
	can_thread_handle = 0;
#endif
	return;
}

static int page_init()
{	
	static int init_once = 0;
	
	if(init_once)
		return 0;
				
#if defined (__linux__)
	pthread_condattr_t cond_attr;
	pthread_condattr_init ( &cond_attr );
	pthread_cond_init ( &can_rx_event, &cond_attr );
	
	pthread_mutexattr_t attr;
	pthread_mutexattr_init (&attr);
	pthread_mutexattr_settype (&attr, PTHREAD_MUTEX_RECURSIVE);
	pthread_mutex_init (&can_rx_mutex, &attr);
#endif

	USHORT result;
	
	if( (result = SUSI_IMC_CAN_SetEvent(&can_rx_event)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CAN_SetEvent fail. error code=0x%04x\n", result);
		return -1;
	}
	
	init_once = 1;

	return 0;
}

void can_write()
{
	IMC_CAN_MSG_OBJECT message;
	
	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if( p > 2 || p < 0)
	{
		printf("Error range\n");
		return;
	}
		
	message.can_bus_number = p;
	
	printf("Frame type:\n");
	printf("0) 2.0A\n");
	printf("1) 2.0B\n");
	printf("2) Remote Request 2.0A\n");
	printf("3) Remote Request 2.0B\n");
	unsigned int t;
	scanf("%u", &t);
	
	WAIT_ENTER();
	
	if( t > 3)
	{
		printf("Error range\n");
		return;
	}
	
	if( t %2 == 1)
		message.message_type = CAN_MESSAGE_EXTENDED;
	else
		message.message_type = CAN_MESSAGE_STANDARD;
	
	if(t>1)
		message.message_type = (CAN_MESSAGE_TYPE)(message.message_type | CAN_MESSAGE_RTR);
		
	printf("ID (Hex):");
	unsigned int id;
	scanf("%x", &id);
	
	WAIT_ENTER();
	
	if( (t % 2 == 0 && id > 0x7FF) ||
	(t %2 == 1 && id > 0x1FFFFFFF) )
	{
		printf("Error range\n");
		return;
	}
	
	message.id = id;
	
	printf("DLC (Max. 8):");
	unsigned int dlc;
	scanf("%u", &dlc);
	
	WAIT_ENTER();
	
	if( dlc > 8)
	{
		printf("Error range\n");
		return;
	}
	
	message.buf_len = dlc;
	
	for(unsigned int i = 0;i<dlc;i++)
	{
		printf("Data[%u] (Hex):", i);
		unsigned int data;
		scanf("%x", &data);
	
		WAIT_ENTER();
	
		if( data > 0xFF)
		{
			printf("Error range\n");
			return;
		}
		message.buf[i] = data;
	}
	
	USHORT result;

	if( (result = SUSI_IMC_CAN_Write(&message)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CAN_Write fail. error code=0x%04x\n", result);
		return;
	}

	memcpy(&last_can_message, &message, sizeof(IMC_CAN_MSG_OBJECT));
	is_set_last_can_message = true;

	printf("Success\n");
}

void quick_send()
{
	if(!is_set_last_can_message)
	{
		printf("CAN message need setup.\n");
		return;
	}
		
	USHORT result;

	if( (result = SUSI_IMC_CAN_Write(&last_can_message)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CAN_Write fail. error code=0x%04x\n", result);
		return;
	}
}

void set_can_speed(int listen_only)
{
	USHORT result;
	
	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if( p > 2 || p < 0)
	{
		printf("Error range\n");
		return;
	}

	CAN_SPEED bitrate;
		
	printf("Speed:\n");
	printf("0) 125K\n");
	printf("1) 250K\n");
	printf("2) 500K\n");
	printf("3) 1M\n");	
	printf("4) 200K\n");
	printf("5) 100K\n");
		
	unsigned int s;
	scanf("%u", &s);
	
	WAIT_ENTER();
	
	switch(s)
	{
		case 0:
			bitrate = CAN_SPEED_125K;
			break;
		case 1:
			bitrate = CAN_SPEED_250K;
			break;
		case 2:
			bitrate = CAN_SPEED_500K;
			break;
		case 3:
			bitrate = CAN_SPEED_1M;
			break;			
		case 4:
			bitrate = CAN_SPEED_200K;
			break;
		case 5:
			bitrate = CAN_SPEED_100K;
			break;
		default:
			printf("Error range\n");
			return;
	}
	
	if( listen_only != 0 )
	{
		if( (result = SUSI_IMC_CAN_SetBitTiming(p, bitrate)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_CAN_SetBitTiming fail. error code=0x%04x\n", result);
			return;
		}
	}
	else
	{
		if( (result = SUSI_IMC_CAN_SetBitTimingSilence(p, bitrate)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_CAN_SetBitTimingSilence fail. error code=0x%04x\n", result);
			return;
		}
	}
	
	printf("Success\n");
}

void get_can_speed()
{
	USHORT result;
	
	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if(  p > 2 || p < 0)
	{
		printf("Error range\n");
		return;
	}
	
	CAN_SPEED bitrate;
	CAN_BUS_MODE mode;
			
	if( (result = SUSI_IMC_CAN_GetBitTiming(p, &bitrate, &mode)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CAN_GetBitTiming fail. error code=0x%04x\n", result);
		return;
	}
	
	switch(mode)
	{
		case CAN_BUS_MODE_NORMAL:
			printf("Normal mode ");
			break;
		case CAN_BUS_MODE_SILENCE:
			printf("Silence mode ");
			break;
		case CAN_BUS_MODE_INIT:
			printf("CAN bus not initialization");
			return;
		default:
			break;
	}
		
	switch(bitrate)
	{
		case CAN_SPEED_125K:
			printf("125K\n");
			break;
		case CAN_SPEED_250K:
			printf("250K\n");
			break;
		case CAN_SPEED_500K:
			printf("500K\n");
			break;
		case CAN_SPEED_1M:
			printf("1M\n");
			break;			
		case CAN_SPEED_200K:
			printf("200K\n");
			break;
		case CAN_SPEED_100K:
			printf("100K\n");
			break;
		case CAN_SPEED_USER_DEFINE:
			printf("User define, some bitrate may user define by library. The firmware not native support");
			break;
		default:
			printf("Error range\n");
			return;
	}
}

void get_can_error_status()
{
	USHORT result;
	
	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if(  p > 2 || p < 0)
	{
		printf("Error range\n");
		return;
	}
	
	IMC_CAN_ERROR_STATUS_OBJECT es;
			
	if( (result = SUSI_IMC_CAN_GetBusErrorStatus(p, &es)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CAN_GetBusErrorStatus fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Receive error counter:%u\n", es.rec);
	printf("Transmit error counter:%u\n", es.tec);
	
	switch(es.last_error_code)
	{
		case 0:
			printf("No error\n");
			break;
		case 1:
			printf("Stuff Error\n");
			break;
		case 2:
			printf("Form Error\n");
			break;
		case 3:
			printf("Acknowledgment Error\n");
			break;
		case 4:
			printf("Bit recessive Error\n");
			break;
		case 5:
			printf("Bit dominant Error\n");
			break;
		case 6:
			printf("CRC Error\n");
			break;
		case 7:
			printf("Set by software\n");
			break;			
	}
	
	if( es.error_flag & 0x01)
		printf("Error warning flag\n");
		
	if( es.error_flag & 0x02)
		printf("Error passive flag\n");
		
	if( es.error_flag & 0x04)
		printf("Bus-off flag\n");
}

void get_can_mask()
{
	USHORT result;
	
	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if(  p > 2 || p < 0)
	{
		printf("Error range\n");
		return;
	}
	
	printf("Bank (0-13):");
	unsigned int b;
	scanf("%u", &b);
	
	WAIT_ENTER();
	
	if( b > 13)
	{
		printf("Error range\n");
		return;
	}
	
	IMC_CAN_MASK_OBJECT mask;
	mask.can_bus_number = p;
	mask.mask_number = b;
		
	if( (result = SUSI_IMC_CAN_GetMessageMask(&mask)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CAN_GetMessageMask fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Mask:\n");
	printf("Mask Type:%X\n", mask.message_type);
	if(mask.message_type & CAN_MESSAGE_EXTENDED)
		printf("Frame Type:2.0B");
	else
		printf("Frame Type:2.0A");
	if(mask.message_type & CAN_MESSAGE_RTR)
		printf("+RTR\n");
	else
		printf("\n");
	printf("ID(Hex):%lx\n", mask.id);
	printf("MASK(Hex):%lx\n", mask.mask);
}

void set_can_mask()
{
	USHORT result;
	IMC_CAN_MASK_OBJECT mask;
	memset(&mask, 0, sizeof(IMC_CAN_MASK_OBJECT));
	
	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if(  p > 2 || p < 0 )
	{
		printf("Error range\n");
		return;
	}
	
	mask.can_bus_number = p;
	
	printf("Bank (0-13):");
	unsigned int b;
	scanf("%u", &b);
	
	WAIT_ENTER();
	
	if( b > 13)
	{
		printf("Error range\n");
		return;
	}
	
	printf("Frame type:\n");
	printf("0) 2.0A\n");
	printf("1) 2.0B\n");
	printf("2) Remote Request 2.0A\n");
	printf("3) Remote Request 2.0B\n");
	unsigned int t;
	scanf("%u", &t);
	
	WAIT_ENTER();
	
	if( t > 3)
	{
		printf("Error range\n");
		return;
	}
	
	if( t %2 == 1)
		mask.message_type = CAN_MESSAGE_EXTENDED;
	else
		mask.message_type = CAN_MESSAGE_STANDARD;
	
	if(t>1)
		mask.message_type = (CAN_MESSAGE_TYPE)(mask.message_type | CAN_MESSAGE_RTR);
	
	printf("ID (Hex):");
	unsigned int id;
	scanf("%x", &id);
	
	WAIT_ENTER();
	
	if( (t % 2 == 0 && id > 0x7FF) ||
	(t %2 == 0 && id > 0x1FFFFFFF) )
	{
		printf("Error range\n");
		return;
	}
	mask.id = id;
	
	printf("Mask (Hex):");
	unsigned int m;
	scanf("%x", &m);
	
	WAIT_ENTER();
	
	if( (t % 2 == 0 && m > 0x7FF) ||
	(t %2 == 0 && m > 0x1FFFFFFF) )
	{
		printf("Error range\n");
		return;
	}
	mask.mask = m;	
	mask.mask_number = b;
		
	if( (result = SUSI_IMC_CAN_SetMessageMask (&mask)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CAN_SetMessageMask fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void remove_can_mask()
{
	USHORT result;

	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if(  p > 2 || p < 0 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Bank (0-13):");
	unsigned int b;
	scanf("%u", &b);
	
	WAIT_ENTER();
	
	if( b > 13)
	{
		printf("Error range\n");
		return;
	}
			
	if( (result = SUSI_IMC_CAN_RemoveMessageMask(p, b)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CAN_RemoveMessageMask fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void reset_can_mask()
{
	USHORT result;
	
	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if(  p > 2 || p < 0 )
	{
		printf("Error range\n");
		return;
	}
	
	if( (result = SUSI_IMC_CAN_ResetMessageMask(p)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CAN_ResetMessageMask fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

static void set_read_mode()
{
	printf("Mode:\n");
	printf("0) Event trigger\n");
	printf("1) Polling\n");
	unsigned int m;
	scanf("%u", &m);
	
	WAIT_ENTER();
	
	if( m > 1)
	{
		printf("Error range\n");
		return;
	}
	
	polling_mode = m;
	
#if defined (__linux__)
	pthread_mutex_lock(&can_rx_mutex);
	pthread_cond_broadcast(&can_rx_event);
	pthread_mutex_unlock(&can_rx_mutex);
#endif

	printf("Success\n");
}

int main(int argc, char *argv[])
{
		
	printf("VCIL SDK Sample -- library version:%s\n", library_version);
	
	printf("alter permissions on ttyA0");
	
	system("sudo chmod 777 /dev/ttyA0");
	
	printf("bring up modprobe and vcan0 + vcan1");
	
	system("sudo modprobe vcan");
	system("sudo ip link add dev vcan0 type vcan");
	system("sudo ip link set up vcan0");

	USHORT result;
	int op;

	char path[256] = "/dev/ttyA0";
	
	if(argc > 1)
	{
		sprintf(path, "%s", argv[1]);
	}
	printf("Open path:%s\n", path);

	if( (result = SUSI_IMC_VCIL_InitializeEx(path, 921600)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VCIL_Initialize. error code=0x%04x\n", result);
		printf("\nUsage: %s [path...]\r\n", argv[0]);
		printf("\nPress ENTER to continue.\n");
		WAIT_ENTER();
		return -1;
	}

	if( (result = SUSI_IMC_VCIL_GetLibVersion((BYTE *)library_version)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VCIL_GetLibVersion fail. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return -1;
	}	
	
	printf("initiating CAN connection\n\n");
		
	if( page_init() < 0 )
		return 0;
		
	if( can_read_enable() < 0)
		return 0;
	
	printf("setting CAN speeds\n\n");
	
	if( (result = SUSI_IMC_CAN_SetBitTimingSilence(1, CAN_SPEED_125K)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CAN_SetBitTimingSilence fail. error code=0x%04x\n", result);
		return 0;
	}

	if( (result = SUSI_IMC_CAN_SetBitTimingSilence(2, CAN_SPEED_125K)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CAN_SetBitTimingSilence fail. error code=0x%04x\n", result);
		return 0;
	}	

	while(true)
	{
		CLEAR_SCREEN();
		show_welcome_title();
		page_menu();

		if( SCANF("%d", &op) <=0 )
			op = -1;

		WAIT_ENTER();

		if(op == 0)
			break;
			
		switch(op)
		{
			case CAN_READ_ENABLE:
				can_read_enable();
				break;
			case CAN_READ_DISABLE:
				can_read_disable();
				break;
			case CAN_WRITE:
				can_write();
				break;
			case CAN_QUICK_WRITE:
				quick_send();
				break;
			case CAN_SET_SPEED:
				set_can_speed(1);
				break;
			case CAN_SET_SPEED_LISTEN_MODE:
				set_can_speed(0);
				break;
			case CAN_GET_SPEED:
				get_can_speed();
				break;
			case CAN_GET_ERROR_STATUS:
				get_can_error_status();
				break;
			case CAN_GET_MASK:
				get_can_mask();
				break;
			case CAN_SET_MASK:
				set_can_mask();
				break;
			case CAN_REMOVE_MASK:
				remove_can_mask();
				break;
			case CAN_RESET_MASK:
				reset_can_mask();
				break;
			case CAN_SET_READ_MODE:
				set_read_mode();
				break;
			default:
				printf("Unknown choice!\n");
				break;
		}

		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();

	}
	
	can_read_disable();	

	return 0;
}
