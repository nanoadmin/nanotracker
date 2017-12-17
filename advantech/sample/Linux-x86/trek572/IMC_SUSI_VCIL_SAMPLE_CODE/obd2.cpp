#include <stdio.h>

#include "common.h"
#include "SUSI_IMC.h"
#include "pthread.h"

#include <string.h>

#define VCIL_OBD2_TYPE_PHYSICAL       218
#define VCIL_OBD2_TAPE_FUNCTIONAL     219

static int polling_mode = 0;

#if defined (__linux__)
#include <unistd.h>
static pthread_t obd2_thread_handle = 0;
static int thread_enable = 0;
static pthread_cond_t obd2_rx_event;
static pthread_mutex_t obd2_rx_mutex;

static IMC_OBD2_MSG_EX_OBJECT last_obd2_message;
static bool is_set_obd2_message = false;

static void *obd2_read_thread(void *p)
{
	while(thread_enable)
	{
		if( polling_mode )
		{
			usleep(100000);
		}
		else
		{
			pthread_mutex_lock(&obd2_rx_mutex);
			pthread_cond_wait(&obd2_rx_event, &obd2_rx_mutex);
			pthread_mutex_unlock(&obd2_rx_mutex);
		}

		USHORT result;
		IMC_OBD2_MSG_EX_OBJECT message;
    
		while( (result = SUSI_IMC_OBD2_ReadEx(&message)) == IMC_ERR_NO_ERROR)
		{
			printf("<OBD2,%d>%s,ID=%lX,",
			message.channel_number,
			message.type == 0 ? "STD":"EXT",
			message.id);
			printf("DLC=%d,", message.buf_len);
			for(int i=0;i<message.buf_len;i++)
				printf("%02x ",message.buf[i]);
			printf("\n");			
		}

		if( result != IMC_CAN_RX_NOT_READY )
		{
			printf("SUSI_IMC_OBD2_Read fail. error code=0x%04x\n", result);
			continue;
		}
	
	}
	return 0;
}
#endif

enum page_function{
	OBD2_READ_ENABLE = 1,
	OBD2_READ_DISABLE,
	OBD2_WRITE,
	OBD2_QUICK_WRITE,
	OBD2_GET_MASK,
	OBD2_ADD_MASK,
	OBD2_REMOVE_MASK,
	OBD2_RESET_MASK,
	OBD2_SET_READ_MODE
};

static void show_welcome_title(void)
{
	printf("VCIL SDK Sample -- library version:%s\n", library_version);
	printf(">> OBD2 Menu Read=%s MODE = %s\n\n", thread_enable ? "Enable" : "Disable",
	polling_mode ? "Polling": "Event");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) OBD2 Read Enable\n", OBD2_READ_ENABLE);
	printf("%d) OBD2 Read Disable\n", OBD2_READ_DISABLE);
	printf("%d) OBD2 Write\n", OBD2_WRITE);
	printf("%d) OBD2 Write last message\n", OBD2_QUICK_WRITE);
	printf("%d) OBD2 Get Mask\n", OBD2_GET_MASK);
	printf("%d) OBD2 Add Mask\n", OBD2_ADD_MASK);
	printf("%d) OBD2 Remove Mask\n", OBD2_REMOVE_MASK);
	printf("%d) OBD2 Reset Mask\n", OBD2_RESET_MASK);
	printf("%d) OBD2 Set Read Mode\n", OBD2_SET_READ_MODE);
		
	printf("\nEnter your choice: ");
}

int obd2_read_enable()
{
	thread_enable = 1;
	
#if defined (__linux__)
	pthread_attr_t thread_attr;
	pthread_attr_init(&thread_attr);
	int ret = ::pthread_create(&obd2_thread_handle, &thread_attr, &obd2_read_thread, NULL);
	pthread_attr_destroy(&thread_attr);
	
	if( ret < 0)
	{
		printf("obd2 thread create fail.");
		return -1;
	}
#endif
	return 0;
}

void obd2_read_disable()
{
	if(!thread_enable)
		return;
	thread_enable = 0;
	
#if defined (__linux__)
	pthread_mutex_lock(&obd2_rx_mutex);
	pthread_cond_broadcast(&obd2_rx_event);
	pthread_mutex_unlock(&obd2_rx_mutex);
	
	::pthread_join(obd2_thread_handle, NULL);
	obd2_thread_handle = 0;
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
	pthread_cond_init ( &obd2_rx_event, &cond_attr );
	
	pthread_mutexattr_t attr;
	pthread_mutexattr_init (&attr);
	pthread_mutexattr_settype (&attr, PTHREAD_MUTEX_RECURSIVE);
	pthread_mutex_init (&obd2_rx_mutex, &attr);
#endif

	USHORT result;
	
	if( (result = SUSI_IMC_OBD2_SetEvent(&obd2_rx_event)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_OBD2_SetEvent fail. error code=0x%04x\n", result);
		return -1;
	}
	
	init_once = 1;

	return 0;
}

void obd2_write()
{
	IMC_OBD2_MSG_EX_OBJECT message;
	
	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if( p < 0 || p > 2)
	{
		printf("Error range\n");
		return;
	}
	message.channel_number = p;

	printf("Message Type (0-1) 0:11-bits  1:29-bits:");
	unsigned int t;
	scanf("%u", &t);
	
	WAIT_ENTER();
	
	if( t < 0 || t > 1)
	{
		printf("Error range\n");
		return;
	}
	message.type = t;

	unsigned int dst;
	unsigned int tat;
	unsigned int src;

	if(message.type == 1)
	{					
		printf("Type:\n");
		printf("0) PHYSICAL:\n");
		printf("1) FUNCTIONAL:\n");
		
		scanf("%u", &tat);		
		WAIT_ENTER();		
		if( tat > 1 )
		{
			printf("Error range\n");
			return;
		}

		tat = (tat == 0 ? 0xDA : 0xDB);
		
		printf("DST (Hex 00-FF):");		
		scanf("%x", &dst);		
		WAIT_ENTER();		
		if( dst > 0xFF )
		{
			printf("Error range\n");
			return;
		}
		
		printf("SRC (Hex 00-FF):" );		
		scanf("%x", &src);
		
		WAIT_ENTER();
		
		if( src > 0xFF )
		{
			printf("Error range\n");
			return;
		}
		
		// Default Pri 6
		message.id = (6<<26) | (tat<<16) | (dst<<8) | src;
	}
	else
	{
		message.id = 0x7DF;		
	}
	
	printf("DLC (Max. buffer %d):", MAX_OBD2_MESSAGE_BUFFER_SIZE);
	unsigned int dlc;
	scanf("%u", &dlc);
	
	WAIT_ENTER();
	
	if( dlc > MAX_OBD2_MESSAGE_BUFFER_SIZE)
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

	if( (result = SUSI_IMC_OBD2_WriteEx(&message)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_OBD2_WriteEx fail. error code=0x%04x\n", result);
		return;
	}

	memcpy(&last_obd2_message, &message, sizeof(IMC_OBD2_MSG_OBJECT));
	is_set_obd2_message = true;
	
	printf("Success\n");
}

void obd2_quick_send()
{
	if(!is_set_obd2_message)
		return;
		
	USHORT result;

	if( (result = SUSI_IMC_OBD2_WriteEx(&last_obd2_message)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_OBD2_WriteEx fail. error code=0x%04x\n", result);
		return;
	}
}

void get_obd2_mask()
{
	USHORT result;
	
	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if( p < 0 || p > 2 )
	{
		printf("Error range\n");
		return;
	}

	unsigned int total_mask = 0;
	if( (result = SUSI_IMC_OBD2_GetMessageFilter(p, &total_mask, NULL)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_OBD2_GetMessageFilter fail. error code=0x%04x\n", result);
		return;
	}
	
	if(total_mask == 0)
	{
		printf("There no mask exist.\n");
		return;
	}
	
	unsigned int mask_pid[128];
	
	if( (result = SUSI_IMC_OBD2_GetMessageFilter(p, &total_mask, mask_pid)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_OBD2_GetMessageFilter fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Mask PID:\n");
	for(unsigned int i = 0; i<total_mask;i++)
		printf("%x,",mask_pid[i]);
	printf("\b \n");	
}

void add_obd2_mask()
{
	USHORT result;
	
	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if( p < 0 || p > 2 )
	{
		printf("Error range\n");
		return;
	}
		
	printf("PID (Hex 00-FF):");
	unsigned int pid;
	scanf("%x", &pid);
	
	WAIT_ENTER();
	
	if( pid > 0xFF )
	{
		printf("Error range\n");
		return;
	}
			
	if( (result = SUSI_IMC_OBD2_AddMessageFilter(p, pid)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_OBD2_AddMessageFilter fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void remove_obd2_mask()
{
	USHORT result;

	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if( p < 0 || p > 2 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("PID (Hex 00-FF):");
	unsigned int pid;
	scanf("%x", &pid);
	
	WAIT_ENTER();
	
	if( pid > 0xFF )
	{
		printf("Error range\n");
		return;
	}
			
	if( (result = SUSI_IMC_OBD2_RemoveMessageFilter(p, pid)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_OBD2_RemoveMessageFilter fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void reset_obd2_mask()
{
	USHORT result;
	
	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if( p < 0 || p > 2 )
	{
		printf("Error range\n");
		return;
	}
	
	if( (result = SUSI_IMC_OBD2_RemoveAllMessageFilter(p)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_OBD2_RemoveAllMessageFilter fail. error code=0x%04x\n", result);
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
	pthread_mutex_lock(&obd2_rx_mutex);
	pthread_cond_broadcast(&obd2_rx_event);
	pthread_mutex_unlock(&obd2_rx_mutex);
#endif

	printf("Success\n");
}

void obd2_main()
{
	int op;
	
	if( page_init() < 0 )
		return ;
		
	if( obd2_read_enable() < 0)
		return;

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
			case OBD2_READ_ENABLE:
				obd2_read_enable();
				break;
			case OBD2_READ_DISABLE:
				obd2_read_disable();
				break;
			case OBD2_WRITE:
				obd2_write();
				break;
			case OBD2_QUICK_WRITE:
				obd2_quick_send();
				break;
			case OBD2_GET_MASK:
				get_obd2_mask();
				break;
			case OBD2_ADD_MASK:
				add_obd2_mask();
				break;
			case OBD2_REMOVE_MASK:
				remove_obd2_mask();
				break;
			case OBD2_RESET_MASK:
				reset_obd2_mask();
				break;
			case OBD2_SET_READ_MODE:
				set_read_mode();
				break;
			default:
				printf("Unknown choice!\n");
				break;
		}

		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();

	}
	
	obd2_read_disable();	
}
