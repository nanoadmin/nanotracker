#include <stdio.h>

#include "common.h"
#include "SUSI_IMC.h"

enum page_function{
	DIO_READ_INPUT = 1,
	DIO_WRITE_OUTPUT,
	SET_VOICE_SOURCE,
	GET_VOICE_SOURCE,
	SET_BLUETOOTH_ENABLE_PIN,
	GET_BLUETOOTH_DISABLE_PIN
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
	printf("%d) Set Voice-call Source\n", SET_VOICE_SOURCE);
	printf("%d) Get Voice-call Source status\n", GET_VOICE_SOURCE);
	printf("%d) Set Bluetooth Enable\n", SET_BLUETOOTH_ENABLE_PIN);
	printf("%d) Get Bluetooth Enable status\n", GET_BLUETOOTH_DISABLE_PIN);
		
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
	printf("PIN2 = %s\n", status.bPin2 ? "ON" : "OFF" );
	printf("PIN3 = %s\n", status.bPin3 ? "ON" : "OFF" );
	
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
	
	printf("Pin-2 On/Off (0-1):");
	int s2;
	scanf("%d", &s2);
	
	WAIT_ENTER();
	
	if( s2 < 0 || s2 >1)
	{
		printf("Error range\n");
		return;
	}
	
	printf("Pin-3 On/Off (0-1):");
	int s3;
	scanf("%d", &s3);
	
	WAIT_ENTER();
	
	if( s3 < 0 || s3 >1)
	{
		printf("Error range\n");
		return;
	}
		
	USHORT result;
	
	PIN_STATUS status;
	status.bPin0 = s0;
	status.bPin1 = s1;
	status.bPin2 = s2;
	status.bPin3 = s3;
	
	if( (result = SUSI_IMC_DIO_WriteDOPin(status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_DIO_WriteDOPin fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void get_voice_input()
{
	USHORT result;

	int src;
	const char *type_string[] = { "Bluetooth", "MIC-IN"};

	if( (result = SUSI_IMC_DIO_GetVoiceSourceControlPin(&src)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_DIO_GetVoiceSourceControlPin fail. error code=0x%04x\n", result);
		return;
	}

	printf("The Current Voice Input is %s\n", type_string[src]);
}

void set_voice_input()
{
	printf("Voice Input :\n");
	printf("0) Bluetooth\n");
	printf("1) MIC-IN\n");
	
	int id;
	scanf("%d", &id);

	WAIT_ENTER();

	if( id <0 || id>1 )
	{
		printf("Error range\n");
		return;
	}

	USHORT result;

	if( (result = SUSI_IMC_DIO_SetVoiceSourceControlPin(id)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_DIO_SetVoiceSourceControlPin fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void get_bluetooth_enable_pin()
{
	USHORT result;

	int status;

	if( (result = SUSI_IMC_DIO_GetBluetoothEnablePin(&status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_DIO_GetBluetoothEnablePin fail. error code=0x%04x\n", result);
		return;
	}

	printf("The bluetooth pin is %s\n", status ? "Enable":"Disable");
}

void set_bluetooth_enable_pin()
{
	printf("Bluetooth Pin:\n");
	printf("0) Disable\n");
	printf("1) Enable\n");
	
	int e;
	scanf("%d", &e);

	WAIT_ENTER();

	if( e <0 || e > 1 )
	{
		printf("Error range\n");
		return;
	}

	USHORT result;

	if( (result = SUSI_IMC_DIO_SetBluetoothEnablePin(e)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_DIO_SetBluetoothEnablePin fail. error code=0x%04x\n", result);
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
			case SET_VOICE_SOURCE:
				set_voice_input();
				break;
			case GET_VOICE_SOURCE:
				get_voice_input();
				break;
			case SET_BLUETOOTH_ENABLE_PIN:
				set_bluetooth_enable_pin();
				break;
			case GET_BLUETOOTH_DISABLE_PIN:
				get_bluetooth_enable_pin();
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
