#include <stdio.h>

#include "common.h"
#include "function.h"
#include "SUSI_IMC.h"

#if defined (__linux__)
#include <pthread.h>
#endif

char library_version[18]={0};

static const char *page_name[] = {
	"Firmware management",
	"Module Control",
	"CAN",
	"J1939",
	"OBD2",
	"J1708",
	"J1587"
};

static const int page_function_supported[] = {
	VCIL_SAMPLE_CODE_FUNCTION_FIRMWARE,
	VCIL_SAMPLE_CODE_FUNCTION_MODULE_CONTROL,
	VCIL_SAMPLE_CODE_FUNCTION_CAN,
	VCIL_SAMPLE_CODE_FUNCTION_J1939,
	VCIL_SAMPLE_CODE_FUNCTION_OBD2,
	VCIL_SAMPLE_CODE_FUNCTION_J1708,
	VCIL_SAMPLE_CODE_FUNCTION_J1587,
	VCIL_SAMPLE_CODE_MAX_FUNCTION_PAGE
};

static void show_welcome_title(void)
{
	printf("VCIL SDK Sample -- library version:%s\n", library_version);
	printf(">> Main Menu\n\n");
}

static void show_menu(void)
{
	printf("0) exit\n");

	for (int i = 0; i < VCIL_SAMPLE_CODE_MAX_FUNCTION_PAGE - 1; i++)
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
			case VCIL_SAMPLE_CODE_FUNCTION_FIRMWARE:
				firmware_main();
				break;
			case VCIL_SAMPLE_CODE_FUNCTION_MODULE_CONTROL:
				module_control_main();
				break;
			case VCIL_SAMPLE_CODE_FUNCTION_CAN:
				can_main();
				break;
			case VCIL_SAMPLE_CODE_FUNCTION_J1939:
				j1939_main();
				break;
			case VCIL_SAMPLE_CODE_FUNCTION_OBD2:
				obd2_main();
				break;
			case VCIL_SAMPLE_CODE_FUNCTION_J1708:
				j1708_main();
				break;
			case VCIL_SAMPLE_CODE_FUNCTION_J1587:
				j1587_main();
				break;
			default:
				printf("Unknown choice!\n");
				printf("\nPress ENTER to continue. ");
				WAIT_ENTER();
				break;
		}
	}

	if( (result = SUSI_IMC_VCIL_Deinitialize()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VCIL_Deinitialize. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return -1;
	}

	return 0;
}
