#include <stdio.h>

#include "common.h"
#include "SUSI_IMC.h"

enum firmware_function{
	FIRMWARE_GET_VERSION = 1,
	FIRMWARE_LOAD_DEFAULT,
	FIRMWARE_FORCE_SHUTDOWN
};

static void show_welcome_title(void)
{
	printf("IVCP SDK Sample -- library version:%s\n", library_version);
	printf(">> Firmware Menu\n\n");
}

void firmware_menu()
{
	printf("0) back\n");

	printf("%d) Get firmware version\n", FIRMWARE_GET_VERSION);
	printf("%d) Load configure to default\n", FIRMWARE_LOAD_DEFAULT);
	printf("%d) Force shutdown computer\n", FIRMWARE_FORCE_SHUTDOWN);
		
	printf("\nEnter your choice: ");
}

void get_firmware_version()
{
	USHORT result;
	VPM_FIRMWARE_INFO fw_version;
	

	if( (result = SUSI_IMC_VPM_GetFWVersion(&fw_version)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetFWVersion fail. error code=0x%04x\n", result);
		return;
	}

	printf("Firmware version is: %s\n", (char *)fw_version.byVersion);
}

void load_default_config()
{
	USHORT result;

	if( (result = SUSI_IMC_VPM_LoadDefaultValue()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_LoadDefaultValue fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void force_shutdown()
{
	USHORT result;

	if( (result = SUSI_IMC_VPM_ForceShutdown()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_ForceShutdown fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void firmware_main()
{
	USHORT result;
	int op;
	
	if( (result = SUSI_IMC_VPM_Initialize(VPM_PORT_NUMBER)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_Initialize fail. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return;
	}

	while(true)
	{
		CLEAR_SCREEN();
		show_welcome_title();
		firmware_menu();

		if( SCANF("%d", &op) <=0 )
			op = -1;

		WAIT_ENTER();

		if(op == 0)
			break;

		switch(op)
		{
			case FIRMWARE_GET_VERSION:
				get_firmware_version();
				break;
			case FIRMWARE_LOAD_DEFAULT:
				load_default_config();
				break;
			case FIRMWARE_FORCE_SHUTDOWN:
				force_shutdown();
				break;
			default:
				printf("Unknown choice!\n");
				break;
		}

		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();

	}
	
	if( (result = SUSI_IMC_VPM_Deinitialize()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_Deinitialize. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return;
	}
}
