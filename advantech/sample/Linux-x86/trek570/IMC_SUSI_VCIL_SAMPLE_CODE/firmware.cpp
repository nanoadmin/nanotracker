#include <stdio.h>

#include "common.h"
#include "SUSI_IMC.h"

enum firmware_function{
	FIRMWARE_GET_VERSION = 1,
	FIRMWARE_RESET
};

static void show_welcome_title(void)
{
	printf("VCIL SDK Sample -- library version:%s\n", library_version);
	printf(">> Firmware Menu\n\n");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) Get firmware version\n", FIRMWARE_GET_VERSION);
	printf("%d) Reset firmware\n", FIRMWARE_RESET);
		
	printf("\nEnter your choice: ");
}

void get_firmware_version()
{
	USHORT result;
	BYTE fw_version[18];

	if( (result = SUSI_IMC_VCIL_GetFWVersion(fw_version)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VCIL_GetFWVersion fail. error code=0x%04x\n", result);
		return;
	}

	printf("Firmware version is: %d.%d\n", fw_version[0], fw_version[1]);
}

void reset_firmware()
{
	USHORT result;

	if( (result = SUSI_IMC_VCIL_ResetModule()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VCIL_ResetModule fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void firmware_main()
{
	int op;

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
			case FIRMWARE_GET_VERSION:
				get_firmware_version();
				break;
			case FIRMWARE_RESET:
				reset_firmware();
				break;
			default:
				printf("Unknown choice!\n");
				break;
		}

		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();

	}
}
