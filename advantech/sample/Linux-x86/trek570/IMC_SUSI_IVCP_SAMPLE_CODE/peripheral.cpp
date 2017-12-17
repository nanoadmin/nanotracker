#include <stdio.h>
#include <unistd.h>

#include "common.h"
#include "SUSI_IMC.h"

enum peripheral_function{
	GET_POWER_STATUS = 1,
	SET_POWER_STATUS,
	ENABLE_WWAN_WAKEUP,
	DISABLE_WWAN_WAKEUP,
	GET_WWAN_WAKEUP_STATUS,
	GET_SIM_STATUS,
	SET_SIM_STATUS,
	GET_REAR_VIEW,
	SET_REAR_VIEW,
	ENABLE_AUTO_REAR_VIEW,
	DISABLE_AUTO_REAR_VIEW,
	GET_AUTO_REAR_VIEW_STATUS
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
	printf("%d) Get SIM Status\n", GET_SIM_STATUS);
	printf("%d) Set SIM Status\n", SET_SIM_STATUS);
	printf("%d) Get Rearview Status\n", GET_REAR_VIEW);
	printf("%d) Set Rearview Status\n", SET_REAR_VIEW);
	printf("%d) Enable auto Rearview detection\n", ENABLE_AUTO_REAR_VIEW);
	printf("%d) Disable auto Rearview detection\n", DISABLE_AUTO_REAR_VIEW);
	printf("%d) Get auto Rearview detection status\n", GET_AUTO_REAR_VIEW_STATUS);

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

void get_sim()
{
	USHORT result;
	BOOL status;

	if( (result = SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl(PERIPHERAL_SIM0, &status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl fail. error code=0x%04x\n", result);
		return;
	}
	
	if( status == 1)
		printf("SIM 0 is select\r\n");
			
	if( (result = SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl(PERIPHERAL_SIM1, &status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl fail. error code=0x%04x\n", result);
		return;
	}

	if( status == 1)
		printf("SIM 1 is select\r\n");
}

void set_sim()
{
	printf("SIM :\n");
	printf("0) SIM0\n");
	printf("1) SIM1\n");

	int id;
	scanf("%d", &id);

	WAIT_ENTER();

	if( id <0 || id>1 )
	{
		printf("Error range\n");
		return;
	}

	USHORT result;
	
	SUSI_IMC_PERIPHERALCTRL_SetPeripheralControl(PERIPHERAL_SIM0, 0);
	SUSI_IMC_PERIPHERALCTRL_SetPeripheralControl(PERIPHERAL_SIM1, 0);

	if( id == 0)
		result = SUSI_IMC_PERIPHERALCTRL_SetPeripheralControl(PERIPHERAL_SIM0, 1);
	else
		result = SUSI_IMC_PERIPHERALCTRL_SetPeripheralControl(PERIPHERAL_SIM1, 1);
		
	if( result != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_SetPeripheralControl fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void get_rear_view()
{
	USHORT result;

	BYTE src;
	const char *src_string[] = { "Main","Ext1"};

	if( (result = SUSI_IMC_PERIPHERALCTRL_GetRearViewSource(&src)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_GetRearViewSource fail. error code=0x%04x\n", result);
		return;
	}

	printf("The Current view is %s\n", src_string[(int)src]);
}

void set_rear_view()
{
	printf("View ID :\n");
	printf("0) Main\n");
	printf("1) Externel1\n");
	printf("2) Externel1 (5 Second auto return main view)\n");

	int id;
	scanf("%d", &id);

	WAIT_ENTER();

	if( id <0 || id>2 )
	{
		printf("Error range\n");
		return;
	}

	USHORT result;

	bool auto_return_main_view = (id == 2 ? true : false);

	if( auto_return_main_view)
		id = 1;

	if( (result = SUSI_IMC_PERIPHERALCTRL_SetRearViewSource((BYTE)id)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_SetRearViewSource fail. error code=0x%04x\n", result);
		return;
	}

	if(auto_return_main_view)
	{
		int countdown_sec = 5;
		while(countdown_sec--)
		{
			printf("%d sec return main..\n", countdown_sec+1);
			usleep(1000000);
		}
		SUSI_IMC_PERIPHERALCTRL_SetRearViewSource(SUSI_REAR_VIEW_SRC_SYSTEM);
	}

	printf("Success\n");
}

void auto_rearview_enable()
{
	USHORT result;

	if( (result = SUSI_IMC_PERIPHERALCTRL_SetAutoRearView(true)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_SetAutoRearView fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void auto_rearview_disable()
{
	USHORT result;

	if( (result = SUSI_IMC_PERIPHERALCTRL_SetAutoRearView(false)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_SetAutoRearView fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void get_auto_rearview_status()
{
	USHORT result;

	BOOL status;

	if( (result = SUSI_IMC_PERIPHERALCTRL_GetAutoRearView(&status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_PERIPHERALCTRL_GetAutoRearView fail. error code=0x%04x\n", result);
		return;
	}

	printf("The Auto Rearview Detection is %s\n", status ? "Enable" : "Disable" );
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
			case GET_SIM_STATUS:
				get_sim();
				break;
			case SET_SIM_STATUS:
				set_sim();
				break;
			case GET_REAR_VIEW:
				get_rear_view();
				break;
			case SET_REAR_VIEW:
				set_rear_view();
				break;
			case ENABLE_AUTO_REAR_VIEW:
				auto_rearview_enable();
				break;
			case DISABLE_AUTO_REAR_VIEW:
				auto_rearview_disable();
				break;
			case GET_AUTO_REAR_VIEW_STATUS:
				get_auto_rearview_status();
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
