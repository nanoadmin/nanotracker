#include <stdio.h>

#include "common.h"
#include "SUSI_IMC.h"

enum page_function{
	ALARM_GET_REAL_TIME = 1,
	ALARM_SET_REAL_TIME,
	ALARM_GET_WAKEUP_TIME,
	ALARM_SET_WAKEUP_TIME,
	ALARM_ENABLE_WAKEUP,
	ALARM_DISABLE_WAKEUP,
	ALARM_GET_WAKEUP_STATUS
};

static void show_welcome_title(void)
{
	printf("IVCP SDK Sample -- library version:%s\n", library_version);
	printf(">> Alarm Control Menu\n\n");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) Alarm Get Real Time\n", ALARM_GET_REAL_TIME);
	printf("%d) Alarm Set Real Time\n", ALARM_SET_REAL_TIME);
	printf("%d) Alarm Get Wakeup Time\n", ALARM_GET_WAKEUP_TIME);
	printf("%d) Alarm Set Wakeup Time\n", ALARM_SET_WAKEUP_TIME);
	printf("%d) Alarm Wakeup Enable\n", ALARM_ENABLE_WAKEUP);
	printf("%d) Alarm Wakeup Disable\n", ALARM_DISABLE_WAKEUP);
	printf("%d) Alarm Get Wakeup Status\n", ALARM_GET_WAKEUP_STATUS);
		
	printf("\nEnter your choice: ");
}

void alarm_get_realtime()
{
	USHORT result;
		
	VPM_RTC_TIME real_time;
	
	if( (result = SUSI_IMC_VPM_GetRTCTime(&real_time)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetRTCTime fail. error code=0x%04x\n", result);
		return;
	}
	
	int YY=real_time.nYear, MM=real_time.nMonth, DD=real_time.nDay, HH=real_time.nHour, mm=real_time.nMinute, SS=real_time.nSecond, WW=real_time.nDayOfWeek;
	
	printf("The current time is %d/%d/%d - %d:%d:%d Week:%d (0=sunday)\n",YY+2000,MM,DD, HH,mm,SS, WW);
}

void alarm_set_realtime()
{

	printf("Real time Year (2000-2099):");
	unsigned short YY;
	scanf("%hu", &YY);
	
	WAIT_ENTER();
	
	if( YY < 2000 || YY > 2099 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Real time Month (1-12):");
	unsigned short MM;
	scanf("%hu", &MM);
	
	WAIT_ENTER();
	
	if( MM < 1 || MM > 12 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Real time Day (1-31):");
	unsigned short DD;
	scanf("%hu", &DD);
	
	WAIT_ENTER();
		
	switch(MM)
	{
		case 1:
		case 3:
		case 5:
		case 7:
		case 8:
		case 10:
		case 12:
			{
				if( DD < 1 || DD > 31 )
				{
					printf("Error range\n");
					return;
				}
			}
			break;
		case 4:
		case 6:
		case 9:
		case 11:
			{
				if( DD < 1 || DD > 30 )
				{
					printf("Error range\n");
					return;
				}
			}		
		case 2:
			{
				if( DD < 1 || DD > 29 )
				{
					printf("Error range\n");
					return;
				}
				
				if( YY%4 !=0 && DD == 29)
				{
					printf("Error range\n");
					return;
				}
			}
			break;
		default:
			printf("Error range\n");
			return;	
	}
	
	printf("Real time Hour(0-23):");
	unsigned short HH;
	scanf("%hu", &HH);
	
	WAIT_ENTER();
	
	if( HH > 23 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Real time Minute(0-59):");
	unsigned short mm;
	scanf("%hu", &mm);
	
	WAIT_ENTER();
	
	if( mm > 59 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Real time second(0-59):");
	unsigned short SS;
	scanf("%hu", &SS);
	
	WAIT_ENTER();
	
	if( SS > 59 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Real time week(0-6, 0=sunday) :");
	unsigned short WW;
	scanf("%hu", &WW);
	
	WAIT_ENTER();
	
	if( WW > 6 )
	{
		printf("Error range\n");
		return;
	}
	
	VPM_RTC_TIME real_time;
		
	USHORT result;
	
	real_time.nYear = (unsigned char)(YY-2000);		
	real_time.nMonth = (unsigned char)MM;
	real_time.nDay = (unsigned char)DD;
	real_time.nHour = (unsigned char)HH;
	real_time.nMinute= (unsigned char)mm;
	real_time.nSecond = (unsigned char)SS;
	real_time.nDayOfWeek = (unsigned char)WW;

	if( (result = SUSI_IMC_VPM_SetRTCTime(real_time)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetRTCTime fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void alarm_get_wakeup_time()
{
	USHORT result;
		
	VPM_ALARM_TIME wakeup_time;
	ALARM_MODE alarm_mode;
	
	if( (result = SUSI_IMC_VPM_GetAlarmTime(&alarm_mode, &wakeup_time)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetAlarmTime fail. error code=0x%04x\n", result);
		return;
	}
	
	int DoW=wakeup_time.nDayOfWeek, HH=wakeup_time.nHour, mm=wakeup_time.nMinute;
	
	printf("The wakeup time is Day of week= %d(0=sunday), Hour=%d, Minute=%d\n",DoW, HH, mm);
	
	if( alarm_mode == NO_ALARM )
		printf("The Alarm Wakeup Disable\n");
	else if( alarm_mode == HOURLY )
		printf("The Alarm Wakeup Enable by hourly\n");
	else if( alarm_mode == DAILY)
		printf("The Alarm Wakeup Enable by Daily\n");
	else if( alarm_mode == WEEKLY )
		printf("The Alarm Wakeup Enable by Weekly\n");
}

void alarm_set_wakeup_time()
{
	printf("Alarm Wakeup Mode:\n");
	printf("0) Horly:\n");
	printf("1) Daily:\n");
	printf("2) Weekly:\n");
	
	unsigned short mode;
	scanf("%hu", &mode);
	
	WAIT_ENTER();
	
	if( mode > 2 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Wakeup time Day of week (0-6, 0=sunday) :");
	unsigned short WW;
	scanf("%hu", &WW);
	
	WAIT_ENTER();
	
	if( WW > 6 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Wakeup time Hour(0-23):");
	unsigned short HH;
	scanf("%hu", &HH);
	
	WAIT_ENTER();
	
	if( HH > 23 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Wakeup time Minute(0-59):");
	unsigned short mm;
	scanf("%hu", &mm);
	
	WAIT_ENTER();
	
	if( mm > 59 )
	{
		printf("Error range\n");
		return;
	}

	VPM_ALARM_TIME wakeup_time;
		
	USHORT result;
	
	wakeup_time.nDayOfWeek = (unsigned char)WW;
	wakeup_time.nHour = (unsigned char)HH;
	wakeup_time.nMinute= (unsigned char)mm;
	
	if( (result = SUSI_IMC_VPM_SetAlarmTime((ALARM_MODE)mode,wakeup_time)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetAlarmTime fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void alarm_wakeup_disable()
{
	USHORT result;
	
	if( (result = SUSI_IMC_VPM_SetAlarmActive(false)) != IMC_ERR_NO_ERROR )
	{
		printf("iSUSI_IMC_VPM_SetAlarmActive fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void alarm_wakeup_enable()
{
	USHORT result;
	
	if( (result = SUSI_IMC_VPM_SetAlarmActive(true)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetAlarmActive fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void alarm_wakeup_get_status()
{
	USHORT result;
	
	BOOL status;
	
	if( (result = SUSI_IMC_VPM_GetAlarmActive(&status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetAlarmActive fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("The Alarm Wakeup is %s.\n", status ? "Enable" : "Disable" );
}

void alarm_main()
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
		page_menu();

		if( SCANF("%d", &op) <=0 )
			op = -1;

		WAIT_ENTER();

		if(op == 0)
			break;
	
		switch(op)
		{
			case ALARM_GET_REAL_TIME:
				alarm_get_realtime();
				break;
			case ALARM_SET_REAL_TIME:
				alarm_set_realtime();
				break;
			case ALARM_GET_WAKEUP_TIME:
				alarm_get_wakeup_time();
				break;
			case ALARM_SET_WAKEUP_TIME:
				alarm_set_wakeup_time();
				break;
			case ALARM_ENABLE_WAKEUP:
				alarm_wakeup_enable();
				break;
			case ALARM_DISABLE_WAKEUP:
				alarm_wakeup_disable();
				break;
			case ALARM_GET_WAKEUP_STATUS:
				alarm_wakeup_get_status();
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
