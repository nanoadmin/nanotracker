#include <stdio.h>
#include <string.h>

#include "common.h"
#include "SUSI_IMC.h"

char library_version[18]={0};
IMC_CORE_GETPLATFORMNAME platform_name;

static const char *page_name[] = {
	"Firmware management",
	"Watchdog control",
	"Alarm Control",
	"Peripheral control",
	"Digital IO Control",
	"GSensor",
	"Power Management",
	"Battery Information"
};

static const int page_function_supported[] = {
	IVCP_SAMPLE_CODE_FUNCTION_FIRMWARE,
	IVCP_SAMPLE_CODE_FUNCTION_WATCHDOG,
	IVCP_SAMPLE_CODE_FUNCTION_ALARM,
	IVCP_SAMPLE_CODE_FUNCTION_PERIPHERAL_CONTROL,
	IVCP_SAMPLE_CODE_FUNCTION_DIGITAL_IO,
	IVCP_SAMPLE_CODE_FUNCTION_GSENSOR,
	IVCP_SAMPLE_CODE_FUNCTION_POWER_MANAGEMENT,
	IVCP_SAMPLE_CODE_FUNCTION_BATTARY,
	IVCP_SAMPLE_CODE_MAX_FUNCTION_PAGE
};

static void show_welcome_title(void)
{
	printf("IVCP SDK Sample -- library version:%s\n", library_version);
	printf("            -- platform:%s\n", platform_name.PlatformName);
	printf(">> Main Menu\n\n");
}

static void show_menu(void)
{
	printf("0) exit\n");
	
	for (int i = 0; i < IVCP_SAMPLE_CODE_MAX_FUNCTION_PAGE - 1; i++)
	{
		if (page_function_supported[i] >= 0)
			printf("%d) %s\n", i + 1, page_name[i]);
		else
			break;
	}
	
	printf("\nEnter your choice: ");
}

int main(int argc, char *argv[])
{
	USHORT result;
	int op;

	if( (result = SUSI_IMC_CORE_Init()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CORE_Init fail. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return -1;
	}
		
	if( (result = SUSI_IMC_CORE_GetLibVersion((BYTE *)library_version)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CORE_GetLibVersion fail. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return -1;
	}
	
	platform_name.PlatformName = new char[128];
	memset(platform_name.PlatformName, 0, 128);
	platform_name.size = new unsigned long;
	if( (result = SUSI_IMC_CORE_GetPlatformName(&platform_name)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CORE_GetPlatformName fail. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return -1;
	} 

	while(true)
	{
		CLEAR_SCREEN();
		show_welcome_title();
		show_menu();

		if( SCANF("%d", &op) <=0 )
			op = -1;

		WAIT_ENTER();

		if(op == 0)
			break;

		switch(op)
		{
			case IVCP_SAMPLE_CODE_FUNCTION_FIRMWARE:
				firmware_main();
				break;
			case IVCP_SAMPLE_CODE_FUNCTION_WATCHDOG:
				watchdog_main();
				break;
			case IVCP_SAMPLE_CODE_FUNCTION_ALARM:
				alarm_main();
				break;
			case IVCP_SAMPLE_CODE_FUNCTION_PERIPHERAL_CONTROL:
				peripheral_main();
				break;
			case IVCP_SAMPLE_CODE_FUNCTION_DIGITAL_IO:
				dio_main();
				break;
			case IVCP_SAMPLE_CODE_FUNCTION_GSENSOR:
				gsensor_main();
				break;
			case IVCP_SAMPLE_CODE_FUNCTION_POWER_MANAGEMENT:
				power_management_main();
				break;
			case IVCP_SAMPLE_CODE_FUNCTION_BATTARY:
				battery_main();
				break;				
			default:
				printf("Unknown choice!\n");
				printf("\nPress ENTER to continue. ");
				WAIT_ENTER();
				break;
		}
	}
	
	delete [] platform_name.PlatformName;
	delete platform_name.size;

	if( (result = SUSI_IMC_CORE_DeInit()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_CORE_DeInit. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return -1;
	}

	return 0;
}


