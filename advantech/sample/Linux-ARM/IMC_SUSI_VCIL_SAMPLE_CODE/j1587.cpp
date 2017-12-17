#include <stdio.h>

#include "common.h"
#include "pthread.h"
#include "SUSI_IMC.h"

#include <string.h>

static int polling_mode = 0;

#if defined (__linux__)
#include <unistd.h>
static pthread_t j1587_thread_handle = 0;
static int thread_enable = 0;
static pthread_cond_t j1587_rx_event;
static pthread_mutex_t j1587_rx_mutex;

static IMC_J1587_MSG_OBJECT last_j1587_message;
static bool is_set_j587_message = false;

static void *j1587_read_thread(void *p)
{
	while(thread_enable)
	{
		if( polling_mode )
		{
			usleep(100000);
		}
		else
		{
			pthread_mutex_lock(&j1587_rx_mutex);
			pthread_cond_wait(&j1587_rx_event, &j1587_rx_mutex);
			pthread_mutex_unlock(&j1587_rx_mutex);
		}

		USHORT result;
		IMC_J1587_MSG_OBJECT message;	
		while( (result = SUSI_IMC_J1587_Read(&message)) == IMC_ERR_NO_ERROR)
		{
			printf("<J1587,0>p=%d,mid=%x,pid=%x,",
			message.pri,
			message.mid,
			message.pid);
			printf("DLC=%d,", message.buf_len);
			for(int i=0;i<message.buf_len;i++)
				printf("%02x ",message.buf[i]);
			printf("\n");			
		}

		if( result != IMC_CAN_RX_NOT_READY )
		{
			printf("SUSI_IMC_J1587_Read fail. error code=0x%04x\n", result);
			continue;
		}
	
	}
	return 0;
}
#endif

enum page_function{
	J1587_READ_ENABLE = 1,
	J1587_READ_DISABLE,
	J1587_WRITE,
	J1587_QUICK_WRITE,
	J1587_GET_MASK,
	J1587_ADD_MASK,
	J1587_REMOVE_MASK,
	J1587_RESET_MASK,
	J1587_SET_READ_MODE
};

static void show_welcome_title(void)
{
	printf("VCIL SDK Sample -- library version:%s\n", library_version);
	printf(">> J1587 Menu Read=%s MODE = %s\n\n", thread_enable ? "Enable" : "Disable",
	polling_mode ? "Polling": "Event");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) J1587 Read Enable\n", J1587_READ_ENABLE);
	printf("%d) J1587 Read Disable\n", J1587_READ_DISABLE);
	printf("%d) J1587 Write\n", J1587_WRITE);
	printf("%d) J1587 Write last message\n", J1587_QUICK_WRITE);
	printf("%d) J1587 Get Mask\n", J1587_GET_MASK);
	printf("%d) J1587 Add Mask\n", J1587_ADD_MASK);
	printf("%d) J1587 Remove Mask\n", J1587_REMOVE_MASK);
	printf("%d) J1587 Reset Mask\n", J1587_RESET_MASK);
	printf("%d) J1587 Set Read Mode\n", J1587_SET_READ_MODE);
		
	printf("\nEnter your choice: ");
}

int j1587_read_enable()
{
	thread_enable = 1;
	
#if defined (__linux__)
	pthread_attr_t thread_attr;
	pthread_attr_init(&thread_attr);
	int ret = ::pthread_create(&j1587_thread_handle, &thread_attr, &j1587_read_thread, NULL);
	pthread_attr_destroy(&thread_attr);
	
	if( ret < 0)
	{
		printf("j1587 thread create fail.");
		return -1;
	}
#endif
	return 0;
}

void j1587_read_disable()
{
	if(!thread_enable)
		return;
	thread_enable = 0;
	
#if defined (__linux__)
	pthread_mutex_lock(&j1587_rx_mutex);
	pthread_cond_broadcast(&j1587_rx_event);
	pthread_mutex_unlock(&j1587_rx_mutex);
	
	::pthread_join(j1587_thread_handle, NULL);
	j1587_thread_handle = 0;
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
	pthread_cond_init ( &j1587_rx_event, &cond_attr );
	
	pthread_mutexattr_t attr;
	pthread_mutexattr_init (&attr);
	pthread_mutexattr_settype (&attr, PTHREAD_MUTEX_RECURSIVE);
	pthread_mutex_init (&j1587_rx_mutex, &attr);
#endif

	USHORT result;
	
	if( (result = SUSI_IMC_J1587_SetEvent(&j1587_rx_event)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1587_SetEvent fail. error code=0x%04x\n", result);
		return -1;
	}
	
	init_once = 1;

	return 0;
}

void j1587_write()
{
	IMC_J1587_MSG_OBJECT message;

	printf("Priority (1-8):");
	unsigned int pri;
	scanf("%u", &pri);
	
	WAIT_ENTER();
	
	if( pri > 8 || pri < 1 )
	{
		printf("Error range\n");
		return;
	}
	
	message.pri = pri;
			
	printf("MID (Hex 00-FF):");
	unsigned int mid;
	scanf("%x", &mid);
	
	WAIT_ENTER();
	
	if( mid > 0xFF )
	{
		printf("Error range\n");
		return;
	}
	
	message.mid = mid;
	
	printf("PID (Hex 00-FF):");
	unsigned int pid;
	scanf("%x", &pid);
	
	WAIT_ENTER();
	
	if( pid > 0x1FF )
	{
		printf("Error range\n");
		return;
	}
	
	message.pid = pid;
		
	printf("DLC (Max. buffer %d):", MAX_J1587_MESSAGE_BUFFER_SIZE);
	unsigned int dlc;
	scanf("%u", &dlc);
	
	WAIT_ENTER();
	
	if( dlc > MAX_J1587_MESSAGE_BUFFER_SIZE)
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

	if( (result = SUSI_IMC_J1587_Write(&message)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1587_Write fail. error code=0x%04x\n", result);
		return;
	}

	memcpy(&last_j1587_message, &message, sizeof(IMC_J1587_MSG_OBJECT));
	is_set_j587_message = true;

	printf("Success\n");
}

void j1587_quick_send()
{
	if(!is_set_j587_message)
		return;
		
	USHORT result;

	if( (result = SUSI_IMC_J1587_Write(&last_j1587_message)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1587_Write fail. error code=0x%04x\n", result);
		return;
	}
}

void get_j1587_mask()
{
	USHORT result;

	unsigned int total_mask = 0;
	if( (result = SUSI_IMC_J1587_GetMessageFilter(&total_mask, NULL)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1587_GetMessageFilter fail. error code=0x%04x\n", result);
		return;
	}
	
	if(total_mask == 0)
	{
		printf("There no mask exist.\n");
		return;
	}
	
	unsigned int mask_pid[256];
	
	if( (result = SUSI_IMC_J1587_GetMessageFilter(&total_mask, mask_pid)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1587_GetMessageFilter fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Mask PID:\n");
	for(unsigned int i = 0; i<total_mask;i++)
		printf("%x,",mask_pid[i]);
	printf("\b \n");	
}

void add_j1587_mask()
{
	USHORT result;
			
	printf("PID (Hex 00-FF):");
	unsigned int pid;
	scanf("%x", &pid);
	
	WAIT_ENTER();
	
	if( pid > 0x1FF )
	{
		printf("Error range\n");
		return;
	}
			
	if( (result = SUSI_IMC_J1587_AddMessageFilter(pid)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1587_AddMessageFilter fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void remove_j1587_mask()
{
	USHORT result;

	printf("PID (Hex 00-FF):");
	unsigned int pid;
	scanf("%x", &pid);
	
	WAIT_ENTER();
	
	if( pid > 0x1FF )
	{
		printf("Error range\n");
		return;
	}
			
	if( (result = SUSI_IMC_J1587_RemoveMessageFilter(pid)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1587_RemoveMessageFilter fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void reset_j1587_mask()
{
	USHORT result;
		
	if( (result = SUSI_IMC_J1587_RemoveAllMessageFilter()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1587_RemoveAllMessageFilter fail. error code=0x%04x\n", result);
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
	pthread_mutex_lock(&j1587_rx_mutex);
	pthread_cond_broadcast(&j1587_rx_event);
	pthread_mutex_unlock(&j1587_rx_mutex);
#endif

	printf("Success\n");
}

void j1587_main()
{
	int op;
	
	if( page_init() < 0 )
		return ;
		
	if( j1587_read_enable() < 0)
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
			case J1587_READ_ENABLE:
				j1587_read_enable();
				break;
			case J1587_READ_DISABLE:
				j1587_read_disable();
				break;
			case J1587_WRITE:
				j1587_write();
				break;
			case J1587_QUICK_WRITE:
				j1587_quick_send();
				break;
			case J1587_GET_MASK:
				get_j1587_mask();
				break;
			case J1587_ADD_MASK:
				add_j1587_mask();
				break;
			case J1587_REMOVE_MASK:
				remove_j1587_mask();
				break;
			case J1587_RESET_MASK:
				reset_j1587_mask();
				break;
			case J1587_SET_READ_MODE:
				set_read_mode();
				break;
			default:
				printf("Unknown choice!\n");
				break;
		}

		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();

	}
	
	j1587_read_disable();	
}
