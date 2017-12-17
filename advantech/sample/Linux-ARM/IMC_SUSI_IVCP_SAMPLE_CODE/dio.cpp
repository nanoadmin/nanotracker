#include <stdio.h>

#include "common.h"
#include "SUSI_IMC.h"

enum page_function{
	DIO_READ_INPUT = 1,
	DIO_WRITE_OUTPUT
};

static void show_welcome_title(void)
{
	printf("IVCP SDK Sample -- library version:%s\n", library_version);
	printf(">> Digital IO Control Menu\n\n");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) Read DI Status\n", DIO_READ_INPUT);
	printf("%d) Write DO Status\n", DIO_WRITE_OUTPUT);
		
	printf("\nEnter your choice: ");
}

void read_digital_input()
{
	USHORT result;
	
	PIN_STATUS status;
	
	if( (result = SUSI_IMC_DIO_ReadDIPin(status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_DIO_ReadDIPin fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("PIN0 = %s\n", status.bPin0 ? "ON" : "OFF" );
	printf("PIN1 = %s\n", status.bPin1 ? "ON" : "OFF" );	
}

void write_digital_output()
{	
	printf("Pin-0 On/Off (0-1):");
	int s0;
	scanf("%d", &s0);
	
	WAIT_ENTER();
	
	if( s0 < 0 || s0 >1)
	{
		printf("Error range\n");
		return;
	}
	
	printf("Pin-1 On/Off (0-1):");
	int s1;
	scanf("%d", &s1);
	
	WAIT_ENTER();
	
	if( s1 < 0 || s1 >1)
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;
	
	PIN_STATUS status;
	status.bPin0 = s0;
	status.bPin1 = s1;
	
	if( (result = SUSI_IMC_DIO_WriteDOPin(status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_DIO_WriteDOPin fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void dio_main()
{
	USHORT result;
	int op;
	
	if( (result = SUSI_IMC_DIO_Initialize()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_DIO_Initialize fail. error code=0x%04x\n", result);
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
			case DIO_READ_INPUT:
				read_digital_input();
				break;
			case DIO_WRITE_OUTPUT:
				write_digital_output();
				break;
			default:
				printf("Unknown choice!\n");
				break;
		}

		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();

	}
	
	if( (result = SUSI_IMC_DIO_Deinitialize()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_DIO_Deinitialize. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
	}
}
