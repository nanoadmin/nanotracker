#include <stdio.h>

#include "common.h"
#include "SUSI_IMC.h"

enum page_function{
	SENSOR_READ_CPU1 = 1,
	SENSOR_READ_CPU2,
	SENSOR_READ_SYS
};

static void show_welcome_title(void)
{
	printf("IVCP SDK Sample -- library version:%s\n", library_version);
	printf(">> Psensor Control Menu\n\n");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) Read CPU Core 1Temp\n", SENSOR_READ_CPU1);
	printf("%d) Read CPU Core 2Temp\n", SENSOR_READ_CPU2);
	printf("%d) Read Sys1 Temp\n", SENSOR_READ_SYS);
		
	printf("\nEnter your choice: ");
}

void read_cpu_temp(int core)
{
	USHORT result;
	
	BYTE temp;

	if(core == 1)
	{
		if( (result = SUSI_IMC_TEMPERATURESENSOR_GetCPUCore1Temperature( &temp )) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_TEMPERATURESENSOR_GetCPUCore1Temperature fail. error code=0x%04x\n", result);
			return;
		}
	}
	else
	{
		if( (result = SUSI_IMC_TEMPERATURESENSOR_GetCPUCore2Temperature( &temp )) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_TEMPERATURESENSOR_GetCPUCore2Temperature fail. error code=0x%04x\n", result);
			return;
		}
	}
	
	printf("The CPU Temp. is %d C\n", temp);
}

void read_sys1_temp()
{
	USHORT result;
	
	BYTE temp;

	if( (result = SUSI_IMC_TEMPERATURESENSOR_GetSystem1Temperature( &temp )) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_TEMPERATURESENSOR_GetSystem1Temperature fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("The Sys Temp. is %d C\n", temp);
}

void sensor_main()
{
	USHORT result;
	int op;

	if( (result = SUSI_IMC_TEMPERATURESENSOR_Initialize()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_TEMPERATURESENSOR_Initialize fail. error code=0x%04x\n", result);
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
			case SENSOR_READ_CPU1:
				read_cpu_temp(1);
				break;
			case SENSOR_READ_CPU2:
				read_cpu_temp(2);
				break;
			case SENSOR_READ_SYS:
				read_sys1_temp();
				break;
			default:
				printf("Unknown choice!\n");
				break;
		}

		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();

	}

	if( (result = SUSI_IMC_TEMPERATURESENSOR_Deinitialize()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_TEMPERATURESENSOR_Deinitialize. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
	}
}
