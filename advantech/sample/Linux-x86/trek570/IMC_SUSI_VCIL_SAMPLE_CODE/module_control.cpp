#include <stdio.h>

#include "common.h"
#include "SUSI_IMC.h"

enum firmware_function{
	MODULE_SET_MODE = 1
};

static void show_welcome_title(void)
{
	printf("VCIL SDK Sample -- library version:%s\n", library_version);
	printf(">> Module Control Menu\n\n");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) Set Mode\n", MODULE_SET_MODE);
		
	printf("\nEnter your choice: ");
}

void set_module_mode()
{
	USHORT result;
	VCIL_CAN_CHANNEL_MODE can_port0, can_port1;
	VCIL_J1708_CHANNEL_MODE j1708_port0;
	
	printf("CAN Port 0:\n");
	printf("0) CAN\n");
	printf("1) CAN using filter CAN ID+MASK\n");
	printf("2) J1939\n");
	printf("3) J1939 using filter PGN\n");
	printf("4) OBD2\n");
	printf("5) OBD2 using filter PID\n");
	unsigned int p0;
	scanf("%u", &p0);
	
	WAIT_ENTER();
	
	if( p0 > 5)
	{
		printf("Error range\n");
		return;
	}
		
	if(p0 == 0)
		can_port0 = VCIL_MODE_CAN;
	else if(p0 == 1)
		can_port0 = VCIL_MODE_CAN_WITH_MASK;
	else if(p0 == 2)
		can_port0 = VCIL_MODE_J1939;
	else if(p0 == 3)
		can_port0 = VCIL_MODE_J1939_WITH_FILTER;
	else if(p0 == 4)
		can_port0 = VCIL_MODE_OBD2;
	else
		can_port0 = VCIL_MODE_OBD2_WITH_FILTER;		
		
	printf("CAN Port 1:\n");
	printf("0) CAN\n");
	printf("1) CAN using filter CAN ID+MASK\n");
	printf("2) J1939\n");
	printf("3) J1939 using filter PGN\n");
	printf("4) OBD2\n");
	printf("5) OBD2 using filter PID\n");
	unsigned int p1;
	scanf("%u", &p1);
	
	WAIT_ENTER();
	
	if( p1 > 5)
	{
		printf("Error range\n");
		return;
	}
	
	if(p1 == 0)
		can_port1 = VCIL_MODE_CAN;
	else if(p1 == 1)
		can_port1 = VCIL_MODE_CAN_WITH_MASK;
	else if(p1 == 2)
		can_port1 = VCIL_MODE_J1939;
	else if(p1 == 3)
		can_port1 = VCIL_MODE_J1939_WITH_FILTER;
	else if(p1 == 4)
		can_port1 = VCIL_MODE_OBD2;
	else
		can_port1 = VCIL_MODE_OBD2_WITH_FILTER;
		
	printf("J1708 Port 0:\n");
	printf("0) J1708\n");
	printf("1) J1587\n");
	unsigned int j0;
	scanf("%u", &j0);
	
	WAIT_ENTER();
	
	if( j0 > 1)
	{
		printf("Error range\n");
		return;
	}
	
	if(j0 == 0)
		j1708_port0 = VCIL_MODE_J1708;
	else
		j1708_port0 = VCIL_MODE_J1587;
	

	if( (result = SUSI_IMC_VCIL_ModuleControl(can_port0,can_port1,j1708_port0)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VCIL_ModuleControl fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void module_control_main()
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
			case MODULE_SET_MODE:
				set_module_mode();
				break;
			default:
				printf("Unknown choice!\n");
				break;
		}

		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();

	}
}
