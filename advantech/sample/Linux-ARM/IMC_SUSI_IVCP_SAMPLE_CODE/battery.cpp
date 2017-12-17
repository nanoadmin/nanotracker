#include <stdio.h>

#include "common.h"
#include "SUSI_IMC.h"
#include <string.h>

enum firmware_function{
	BATTERY_GET_VOLTAGE = 1,
	BATTERY_GET_REMAINING_CAP,
	BATTERY_GET_PERCENTAGE_OF_CHARGE,
	BATTERY_GET_TEMP,
	BATTERY_GET_REMAINING_TIME,
	BATTERY_GET_TIME_TO_FULL,
	BATTERY_GET_INFO
};

static void show_welcome_title(void)
{
	printf("IVCP SDK Sample -- library version:%s\n", library_version);
	printf(">> Firmware Menu\n\n");
}

void battery_menu()
{
	printf("0) back\n");
	
	printf("%d) Get Battery Voltage\n", BATTERY_GET_VOLTAGE);
	printf("%d) Get Battery Remaining Capacity\n", BATTERY_GET_REMAINING_CAP);
	printf("%d) Get Battery Percentage of charge\n", BATTERY_GET_PERCENTAGE_OF_CHARGE);
	printf("%d) Get Battery Temperture\n", BATTERY_GET_TEMP);
	printf("%d) Get Battery Remaining time\n", BATTERY_GET_REMAINING_TIME);
	printf("%d) Get Battery Time to full\n", BATTERY_GET_TIME_TO_FULL);
	printf("%d) Get Battery Info\n", BATTERY_GET_INFO);
		
	printf("\nEnter your choice: ");
}

void get_battery_voltage()
{
	USHORT result;
	FLOAT vol;	

	if( (result = SUSI_IMC_VPM_GetBackupBatteryVoltage(&vol)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetBackupBatteryVoltage fail. error code=0x%04x\n", result);
		return;
	}

	printf("Battery Voltage is: %0.2gv\n", vol);
}

void get_battery_remaining_capacity()
{
	USHORT result;
	INT rem_cap;	

	if( (result = SUSI_IMC_VPM_GetBackupBatteryRemainingCapacity(&rem_cap)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetBackupBatteryRemainingCapacity fail. error code=0x%04x\n", result);
		return;
	}

	printf("Battery Remaining Capacity is: %dmAh\n", rem_cap);
}

void get_battery_percentage_of_charge()
{
	USHORT result;
	INT per_ch;	

	if( (result = SUSI_IMC_VPM_GetBackupBatteryPercentageOfCharge(&per_ch)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetBackupBatteryPercentageOfCharge fail. error code=0x%04x\n", result);
		return;
	}

	printf("Battery percentage of charge is: %d%%\n", per_ch);
}

void get_battery_temperture()
{
	USHORT result;
	FLOAT temp;	

	if( (result = SUSI_IMC_VPM_GetBackupBatteryTemperture(&temp)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetBackupBatteryTemperture fail. error code=0x%04x\n", result);
		return;
	}

	printf("Battery temperture is: %0.2g\n", temp);
}

void get_battery_remaining_time()
{
	USHORT result;
	INT ts;	

	if( (result = SUSI_IMC_VPM_GetBackupBatteryRemainingTime(&ts)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetBackupBatteryRemainingTime fail. error code=0x%04x\n", result);
		return;
	}

	printf("Battery remaining time: %d\n", ts);
}

void get_battery_time_to_full()
{
	USHORT result;
	INT ts;	

	if( (result = SUSI_IMC_VPM_GetBackupBatteryTimeToFull(&ts)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetBackupBatteryTimeToFull fail. error code=0x%04x\n", result);
		return;
	}

	printf("Battery time to full is: %d\n", ts);
}

void get_battery_info()
{
	USHORT result;
	BACKUP_BATTERY_INFO info;
	memset(&info, 0 , sizeof(BACKUP_BATTERY_INFO));

	if( (result = SUSI_IMC_VPM_GetBackupBatteryInfo(&info)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetBackupBatteryInfo fail. error code=0x%04x\n", result);
		return;
	}

	printf("Battery max capacity is: %d mAh\n", info.iMaxCapacity);
	// printf("Battery cycle count is: %d\n", info.iCycleCount); // Reserved no use
	printf("Battery Discharging detected : %s\n", info.BattryFlag.DSG ? "Yes":"No");
	printf("Battery State-of_Charge Threshold final reached: %s\n", info.BattryFlag.SOCF ? "Yes" : "No");
	printf("Battery State-of_Charge Threshold 1 reached flag: %s\n", info.BattryFlag.SOC1 ? "Yes" : "No");
	printf("Battery OCV measurement is performed: %s\n", info.BattryFlag.OCVTAKEN ? "Yes" : "No");
	printf("Battery (Fast) charging allowed: %s\n", info.BattryFlag.CHG?"Yes":"No");
	printf("Battery Fill-chared is detected: %s\n", info.BattryFlag.FC?"Yes":"No");
	printf("Battery Charge suspend alert: %s\n", info.BattryFlag.XCHG?"Yes":"No");
	printf("Battery Charge inhibit: %s\n", info.BattryFlag.CHG_INH?"Yes":"No");
	printf("Battery Over-Temperature in DisCharge condition is detected: %s\n", info.BattryFlag.OTD?"Yes":"No");
	printf("Battery Over-Temperature in Charge condition is detected: %s\n", info.BattryFlag.OTC?"Yes":"No");
}

void battery_main()
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
		battery_menu();

		if( SCANF("%d", &op) <=0 )
			op = -1;

		WAIT_ENTER();

		if(op == 0)
			break;

		switch(op)
		{
			case BATTERY_GET_VOLTAGE:
				get_battery_voltage();
				break;
			case BATTERY_GET_REMAINING_CAP:
				get_battery_remaining_capacity();
				break;
			case BATTERY_GET_PERCENTAGE_OF_CHARGE:
				get_battery_percentage_of_charge();
				break;
			case BATTERY_GET_TEMP:
				get_battery_temperture();
				break;
			case BATTERY_GET_REMAINING_TIME:
				get_battery_remaining_time();
				break;
			case BATTERY_GET_TIME_TO_FULL:
				get_battery_time_to_full();
				break;
			case BATTERY_GET_INFO:
				get_battery_info();
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
