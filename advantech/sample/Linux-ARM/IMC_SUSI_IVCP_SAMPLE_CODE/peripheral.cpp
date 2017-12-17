#include <stdio.h>
#include <unistd.h>

#include "common.h"
#include "SUSI_IMC.h"

enum peripheral_function{
	GET_POWER_STATUS = 1,
	SET_POWER_STATUS,
	ENABLE_WWAN_WAKEUP,
	DISABLE_WWAN_WAKEUP,
	GET_WWAN_WAKEUP_STATUS
};

static const char *power_control_module_name[] = {
	"WWAN",
	"WIFI",
	"GPS"
};

static void show_welcome_title(void)
{
	printf("IVCP SDK Sample -- library version:%s\n", library_version);
	printf(">> Peripheral Control Menu\n\n");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) Get Module Power Status\n", GET_POWER_STATUS);
	printf("%d) Set Module Power Status\n", SET_POWER_STATUS);
	printf("%d) Enable WWAN Wakeup\n", ENABLE_WWAN_WAKEUP);
	printf("%d) Disable WWAN Wakeup\n", DISABLE_WWAN_WAKEUP);
	printf("%d) Get WWAN Wakueup Status\n", GET_WWAN_WAKEUP_STATUS);
	
	printf("\nEnter your choice: ");
}

void get_power_status()
{
	USHORT result;

	BOOL status;
	
	if( (result = SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl(PERIPHERAL_WWAN, &status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl fail. error code=0x%04x\n", result);
		return;
	}

	printf("WWAN: %s\n", status ? "ON" : "OFF" );
	
	
	if( (result = SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl(PERIPHERAL_WIFI, &status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl fail. error code=0x%04x\n", result);
		return;
	}

	printf("WIFI: %s\n", status ? "ON" : "OFF" );
	
	if( (result = SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl(PERIPHERAL_GPS, &status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl fail. error code=0x%04x\n", result);
		return;
	}

	printf("GPS: %s\n", status ? "ON" : "OFF" );
}

void set_power_status()
{
	USHORT result;

	printf("Select Module:\n");
	for(int i = 0; i < 3; i++)
		printf("%d) %s\n", (int)i, power_control_module_name[i]);
	printf("Enter you choice:");

	int id;
	scanf("%d", &id);

	WAIT_ENTER();

	if( id < 0 || id > 2)
	{
		printf("Error range\n");
		return;
	}

	int s;

	printf("Enable 1 ? Disable 0:");
	scanf("%d", &s);

	WAIT_ENTER();

	if( s < 0 || s >1)
	{
		printf("Error range\n");
		return;
	}

	if( (result = SUSI_IMC_PERIPHERALCTRL_SetPeripheralControl( (PERIPHERAL_TYPE)id , (BOOL)s )) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_SetPeripheralControl fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void wwan_wakeup_enable()
{
	USHORT result;

	if( (result = SUSI_IMC_VPM_SetWakeupSourceControlStatus(WAKEUP_SOURCE_WWAN, true)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetWakeupSourceControlStatus fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void wwan_wakeup_disable()
{
	USHORT result;

	if( (result = SUSI_IMC_VPM_SetWakeupSourceControlStatus(WAKEUP_SOURCE_WWAN, false)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetWakeupSourceControlStatus fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void get_wwan_wakeup_status()
{
	USHORT result;

	char status;

	if( (result = SUSI_IMC_VPM_GetWakeupSourceControlStatus(WAKEUP_SOURCE_WWAN, &status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetWakeupSourceControlStatus fail. error code=0x%04x\n", result);
		return;
	}

	printf("The WWAN Wakueup is %s\n", status ? "Enable" : "Disable" );
}

void peripheral_main()
{
	USHORT result;
	int op;
		
	if( (result = SUSI_IMC_PERIPHERALCTRL_Initialize()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_Initialize fail. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return;
	}
	
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
		page_menu();

		if( SCANF("%d", &op) <=0 )
			op = -1;

		WAIT_ENTER();

		if(op == 0)
			break;

		switch(op)
		{
			case GET_POWER_STATUS:
				get_power_status();
				break;
			case SET_POWER_STATUS:
				set_power_status();
				break;
			case ENABLE_WWAN_WAKEUP:
				wwan_wakeup_enable();
				break;
			case DISABLE_WWAN_WAKEUP:
				wwan_wakeup_disable();
				break;
			case GET_WWAN_WAKEUP_STATUS:
				get_wwan_wakeup_status();
				break;
			default:
				printf("Unknown choice!\n");
				break;
		}

		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();

	}
	
	if( (result = SUSI_IMC_PERIPHERALCTRL_Deinitialize()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_Deinitialize. error code=0x%04x\n", result);
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
