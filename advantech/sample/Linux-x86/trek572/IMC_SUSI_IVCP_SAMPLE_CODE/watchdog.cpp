#include <stdio.h>

#include "common.h"
#include "SUSI_IMC.h"

enum page_function{
	WATCHDOG_ENABLE = 1,
	WATCHDOG_DISABLE,
	WATCHDOG_GET_TIME,
	WATCHDOG_SET_TIME,
	WATCHDOG_GET_RANGE,
	WATCHDOG_TRIGGER
};

static void show_welcome_title(void)
{
	printf("IVCP SDK Sample -- library version:%s\n", library_version);
	printf(">> Watchdog Control Menu\n");
	printf(" (CAUTION if watchdog enable out of time to trigger, System will reboot)\n\n");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) Watchdog Enable\n", WATCHDOG_ENABLE);
	printf("%d) Watchdog Disable\n", WATCHDOG_DISABLE);
	printf("%d) Watchdog Get time\n", WATCHDOG_GET_TIME);
	printf("%d) Watchdog Set time\n", WATCHDOG_SET_TIME);
	printf("%d) Watchdog Get time range\n", WATCHDOG_GET_RANGE);
	printf("%d) Watchdog Trigger\n", WATCHDOG_TRIGGER);
		
	printf("\nEnter your choice: ");
}

void watchdog_enable()
{
	USHORT result;
	
	if( (result = SUSI_IMC_WD_Enabled(true)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_WD_Enabled fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void watchdog_disable()
{
	USHORT result;
	
	if( (result = SUSI_IMC_WD_Enabled(false)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_WD_Enabled fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void watchdog_trigger()
{
	USHORT result;
	
	if( (result = SUSI_IMC_WD_Trigger()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_WD_Trigger fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void watchdog_get_time()
{
	USHORT result;
	
	unsigned short countdown_time;
	
	if( (result = SUSI_IMC_WD_GetTime(&countdown_time)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_WD_GetTime fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("The watchdog time is %hu second.\n", countdown_time);
}

void watchdog_set_time()
{
	printf("Watchdog time (0-65535):");
	unsigned short s;
	scanf("%hu", &s);
	
	WAIT_ENTER();
	
	if( s > 65535)
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;

	if( (result = SUSI_IMC_WD_SetTime(s)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_WD_SetTime fail. error code=0x%04x\n", result);
		return;
	}


	printf("Success\n");
}

void watchdog_get_range()
{
	USHORT result;
	
	unsigned long mix_time;
	unsigned long max_time;
	
	if( (result = SUSI_IMC_WD_GetRange(&mix_time, &max_time)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_WD_GetRange fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("The watchdog time range is %lu-%lu second.\n", mix_time, max_time);
}

void watchdog_main()
{
	USHORT result;
	int op;
	
	if( (result = SUSI_IMC_WD_Initialize(VPM_PORT_NUMBER)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_WD_Initialize fail. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return;
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
			case WATCHDOG_ENABLE:
				watchdog_enable();
				break;
			case WATCHDOG_DISABLE:
				watchdog_disable();
				break;
			case WATCHDOG_GET_TIME:
				watchdog_get_time();
				break;
			case WATCHDOG_SET_TIME:
				watchdog_set_time();
				break;
			case WATCHDOG_TRIGGER:
				watchdog_trigger();
				break;
			case WATCHDOG_GET_RANGE:
				watchdog_get_range();
				break;
			default:
				printf("Unknown choice!\n");
				break;
		}

		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();

	}
	
	if( (result = SUSI_IMC_WD_Deinitialize()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_WD_Deinitialize. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return;
	}
}
