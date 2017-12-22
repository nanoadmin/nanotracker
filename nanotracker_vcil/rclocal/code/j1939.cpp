#include <stdio.h>

#include "common.h"
#include "pthread.h"
#include "SUSI_IMC.h"

#include <string.h>

static int polling_mode = 0;

#if defined (__linux__)
#include <unistd.h>
static pthread_t j1939_thread_handle = 0;
static int thread_enable = 0;
static pthread_cond_t j1939_rx_event;
static pthread_mutex_t j1939_rx_mutex;

static IMC_J1939_MSG_OBJECT last_j1939_message;
static bool is_set_j1939_message = false;

static void *j1939_read_thread(void *p)
{
	while(thread_enable)
	{
		if( polling_mode )
		{
			usleep(100000);
		}
		else
		{
			pthread_mutex_lock(&j1939_rx_mutex);
			pthread_cond_wait(&j1939_rx_event, &j1939_rx_mutex);
			pthread_mutex_unlock(&j1939_rx_mutex);
		}
			
		USHORT result;
		IMC_J1939_MSG_OBJECT message;	
		while( (result = SUSI_IMC_J1939_Read(&message)) == IMC_ERR_NO_ERROR)
		{
			printf("<J1939,%d>p=%d,pgn=%x,dst=%x,src=%x,",
			message.channel_number,
			message.pri,
			message.pgn,
			message.dst,
			message.src);
			printf("DLC=%d,", message.buf_len);
			for(int i=0;i<message.buf_len;i++)
				printf("%02x ",message.buf[i]);
			printf("\n");			
		}

		if( result != IMC_J1939_RX_NOT_READY )
		{
			printf("SUSI_IMC_J1939_Read fail. error code=0x%04x\n", result);
			continue;
		}
	
	}
	return 0;
}
#endif

enum page_function{
	J1939_READ_ENABLE = 1,
	J1939_READ_DISABLE,
	J1939_WRITE,
	J1939_QUICK_WRITE,
	J1939_GET_CONFIG,
	J1939_SET_CONFIG,
	J1939_GET_MASK,
	J1939_ADD_MASK,
	J1939_REMOVE_MASK,
	J1939_RESET_MASK,
	J1939_SET_READ_MODE
};

static void show_welcome_title(void)
{
	printf("VCIL SDK Sample -- library version:%s\n", library_version);
	printf(">> J1939 Menu Read=%s MODE = %s\n\n", thread_enable ? "Enable" : "Disable",
	polling_mode ? "Polling": "Event");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) J1939 Read Enable\n", J1939_READ_ENABLE);
	printf("%d) J1939 Read Disable\n", J1939_READ_DISABLE);
	printf("%d) J1939 Write\n", J1939_WRITE);
	printf("%d) J1939 Write last message\n", J1939_WRITE);
	printf("%d) J1939 Get Config\n", J1939_GET_CONFIG);
	printf("%d) J1939 Set Config\n", J1939_SET_CONFIG);
	printf("%d) J1939 Get Mask\n", J1939_GET_MASK);
	printf("%d) J1939 Add Mask\n", J1939_ADD_MASK);
	printf("%d) J1939 Remove Mask\n", J1939_REMOVE_MASK);
	printf("%d) J1939 Reset Mask\n", J1939_RESET_MASK);
	printf("%d) J1939 Set Read Mode\n", J1939_SET_READ_MODE);
		
	printf("\nEnter your choice: ");
}

int j1939_read_enable()
{
	thread_enable = 1;
	
#if defined (__linux__)
	pthread_attr_t thread_attr;
	pthread_attr_init(&thread_attr);
	int ret = ::pthread_create(&j1939_thread_handle, &thread_attr, &j1939_read_thread, NULL);
	pthread_attr_destroy(&thread_attr);
	
	if( ret < 0)
	{
		printf("j1939 thread create fail.");
		return -1;
	}
#endif
	return 0;
}

void j1939_read_disable()
{
	if(!thread_enable)
		return;
	thread_enable = 0;
	
#if defined (__linux__)
	pthread_mutex_lock(&j1939_rx_mutex);
	pthread_cond_broadcast(&j1939_rx_event);
	pthread_mutex_unlock(&j1939_rx_mutex);
	
	::pthread_join(j1939_thread_handle, NULL);
	j1939_thread_handle = 0;
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
	pthread_cond_init ( &j1939_rx_event, &cond_attr );
	
	pthread_mutexattr_t attr;
	pthread_mutexattr_init (&attr);
	pthread_mutexattr_settype (&attr, PTHREAD_MUTEX_RECURSIVE);
	pthread_mutex_init (&j1939_rx_mutex, &attr);
#endif

	USHORT result;
	
	if( (result = SUSI_IMC_J1939_SetEvent(&j1939_rx_event)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1939_SetEvent fail. error code=0x%04x\n", result);
		return -1;
	}
	
	init_once = 1;

	return 0;
}

void j1939_write()
{
	IMC_J1939_MSG_OBJECT message;
	
	printf("Port (1-2):");
	unsigned int p;
	scanf("%u", &p);
	
	WAIT_ENTER();
	
	if( p > 1)
	{
		printf("Error range\n");
		return;
	}
	message.channel_number = p;
	
	printf("Priority (0-7):");
	unsigned int pri;
	scanf("%u", &pri);
	
	WAIT_ENTER();
	
	if( pri > 7 )
	{
		printf("Error range\n");
		return;
	}
	
	message.pri = pri;
		
	printf("PGN (Hex):");
	unsigned int pgn;
	scanf("%x", &pgn);
	
	WAIT_ENTER();
	
	if( pgn > 0x1FFFF )
	{
		printf("Error range\n");
		return;
	}
	
	message.pgn = pgn;
	
	printf("DST (Hex 00-FF) <Note FF=boardcast address FE=null address>:");
	unsigned int dst;
	scanf("%x", &dst);
	
	WAIT_ENTER();
	
	if( dst > 0xFF )
	{
		printf("Error range\n");
		return;
	}
	
	message.dst = dst;
	
	printf("SRC (Hex 00-FD):" );
	unsigned int src;
	scanf("%x", &src);
	
	WAIT_ENTER();
	
	if( src > 0xFF )
	{
		printf("Error range\n");
		return;
	}
	
	message.src = src;
	
	printf("DLC (Max. buffer %d):", MAX_J1939_MESSAGE_BUFFER_SIZE);
	unsigned int dlc;
	scanf("%u", &dlc);
	
	WAIT_ENTER();
	
	if( dlc > MAX_J1939_MESSAGE_BUFFER_SIZE)
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

	if( (result = SUSI_IMC_J1939_Write(&message)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1939_Write fail. error code=0x%04x\n", result);
		return;
	}
	
	memcpy(&last_j1939_message, &message, sizeof(IMC_J1939_MSG_OBJECT) );
	is_set_j1939_message = true;

	printf("Success\n");
}

void j1939_quick_send()
{
	if(!is_set_j1939_message)
		return;
	
	USHORT result;

	if( (result = SUSI_IMC_J1939_Write(&last_j1939_message)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1939_Write fail. error code=0x%04x\n", result);
		return;
	}
}

void get_j1939_mask()
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
	if( (result = SUSI_IMC_J1939_GetMessageFilter(p, &total_mask, NULL)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1939_GetMessageFilter fail. error code=0x%04x\n", result);
		return;
	}
	
	if(total_mask == 0)
	{
		printf("There no mask exist.\n");
		return;
	}
	
	unsigned int mask_pgn[128];
	
	if( (result = SUSI_IMC_J1939_GetMessageFilter(p, &total_mask, mask_pgn)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1939_GetMessageFilter fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Mask PGN:\n");
	for(unsigned int i = 0; i<total_mask;i++)
		printf("%x,",mask_pgn[i]);
	printf("\b \n");	
}

void add_j1939_mask()
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
		
	printf("PGN (Hex):");
	unsigned int pgn;
	scanf("%x", &pgn);
	
	WAIT_ENTER();
	
	if( pgn > 0x1FFFF )
	{
		printf("Error range\n");
		return;
	}
			
	if( (result = SUSI_IMC_J1939_AddMessageFilter(p, pgn)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1939_AddMessageFilter fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void remove_j1939_mask()
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
	
	printf("PGN (Hex):");
	unsigned int pgn;
	scanf("%x", &pgn);
	
	WAIT_ENTER();
	
	if( pgn > 0x1FFFF )
	{
		printf("Error range\n");
		return;
	}
			
	if( (result = SUSI_IMC_J1939_RemoveMessageFilter(p, pgn)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1939_RemoveMessageFilter fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void reset_j1939_mask()
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
	
	if( (result = SUSI_IMC_J1939_RemoveAllMessageFilter(p)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1939_RemoveAllMessageFilter fail. error code=0x%04x\n", result);
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
	pthread_mutex_lock(&j1939_rx_mutex);
	pthread_cond_broadcast(&j1939_rx_event);
	pthread_mutex_unlock(&j1939_rx_mutex);
#endif

	printf("Success\n");
}

void get_j1939_config()
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
	
	IMC_J1939_TRANSMIT_CONFIG config;
	config.channel_number = p;
	
	if( (result =  SUSI_IMC_J1939_GetTransmitConfig(&config)) != IMC_ERR_NO_ERROR )
	{
		printf(" SUSI_IMC_J1939_GetTransmitConfig. error code=0x%04x\n", result);
		return;
	}

	printf("J1939 Port%d Config:\n", p);
	printf("Address:%x\n", config.source_address);
	printf("NAME[8]=");
	for(int i=0;i<8;i++)
		printf("%02X ", config.source_name[i]);

}

void set_j1939_config()
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
		
	IMC_J1939_TRANSMIT_CONFIG config;
	
	config.channel_number = p;
	
	printf("Address (Hex 00-FD):");
	unsigned int address;
	scanf("%x", &address);
	
	WAIT_ENTER();
	
	if(address > 0xFF)
	{
		printf("Error range\n");
		return;
	}
	
	config.source_address = address;
	
	for(int i =0; i < 8 ;i++)
	{
		printf("NAME[%d](Hex):", i);
		unsigned int data;
		scanf("%x", &data);
		config.source_name[i] = data;
				
		WAIT_ENTER();
	}
	
	if( (result = SUSI_IMC_J1939_SetTransmitConfig(config)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_J1939_SetTransmitConfig. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void j1939_main()
{
	int op;
	
	if( page_init() < 0 )
		return ;
		
	if( j1939_read_enable() < 0)
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
			case J1939_READ_ENABLE:
				j1939_read_enable();
				break;
			case J1939_READ_DISABLE:
				j1939_read_disable();
				break;
			case J1939_WRITE:
				j1939_write();
				break;
			case J1939_QUICK_WRITE:
				j1939_quick_send();
				break;
			case J1939_GET_CONFIG:
				get_j1939_config();
				break;
			case J1939_SET_CONFIG:
				set_j1939_config();
				break;
			case J1939_GET_MASK:
				get_j1939_mask();
				break;
			case J1939_ADD_MASK:
				add_j1939_mask();
				break;
			case J1939_REMOVE_MASK:
				remove_j1939_mask();
				break;
			case J1939_RESET_MASK:
				reset_j1939_mask();
				break;
			case J1939_SET_READ_MODE:
				set_read_mode();
				break;
			default:
				printf("Unknown choice!\n");
				break;
		}

		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();

	}
	
	j1939_read_disable();	
}
