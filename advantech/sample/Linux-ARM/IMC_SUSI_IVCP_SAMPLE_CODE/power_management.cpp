#include <stdio.h>

#include "common.h"

#include "pthread.h"
#include "SUSI_IMC.h"

enum page_function{
	GET_IGNITION_STATUS = 1,
	IGNITION_WAKEUP_ENABLE,
	IGNITION_WAKEUP_DISABLE,
	GET_IGNITION_WAKEUP_STATUS,
	GET_IGNITION_MODE,
	SET_IGNITION_MODE,
	GET_VOLTAGE,
	GET_KEEP_ALIVEMODE,
	SET_KEEP_ALIVEMODE,
	GET_AT_MODE,
	SET_AT_MODE,
	GET_EVENT_DELAY,
	SET_EVENT_DELAY,
	GET_LAST_WAKEUP_SOURCE,
	GET_LOW_POWER_PROTECTION_STATUS,
	SET_LOW_POWER_PROTECTION,
	GET_LOW_POWER_PROTECTION_THRESHOLD,
	SET_LOW_POWER_PROTECTION_THRESHOLD,
	RESET_LOW_POWER_PROTECTION_THRESHOLD,
	GET_POWER_MODE,
	SET_POWER_MODE,
	GET_SHUTDOWN_MASK,
	SET_SHUTDOWN_MASK,
	GET_FORCE_SHUTDOWN,
	FORCE_SHUTDOWN_ENABLE,
	FORCE_SHUTDOWN_DISABLE,
	GET_PRE_POWER_OFF_ALARM,
	SET_PRE_POWER_OFF_ALARM,
	ENABLE_RECV_POWER_OFF_EVENT,
	DISABLE_RECV_POWER_OFF_EVENT
};

static const char *wakeup_source_string[] = {
	"Power Button",
	"Ignition",
	"WWAN",
	"Gsensor",
	"DI1",
	"DI2",
	"Alarm",
	"Hotkey",
	"DI3",
	"DI4",
	"Reset"
};

static void show_welcome_title(void)
{
	printf("IVCP SDK Sample -- library version:%s\n", library_version);
	printf(">> Power Management Menu\n\n");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) Get Ignition Status\n", GET_IGNITION_STATUS);
	printf("%d) Enable Ignition Wakeup\t", IGNITION_WAKEUP_ENABLE);
	printf("%d) Disable Ignition Wakeup\n", IGNITION_WAKEUP_DISABLE);
	printf("%d) Get Ignition Wakeup Status\n", GET_IGNITION_WAKEUP_STATUS);	
	printf("%d) Get Ignition mode\t", GET_IGNITION_MODE);
	printf("%d) Set Ignition mode\n", SET_IGNITION_MODE);	
	printf("%d) Get Current Voltage\n", GET_VOLTAGE);
	printf("%d) Get Keep-Alive Mode Status\t", GET_KEEP_ALIVEMODE);
	printf("%d) Set Keep-Alive Mode\n",SET_KEEP_ALIVEMODE);
	printf("%d) Get AT Mode Status\t", GET_AT_MODE);
	printf("%d) Set AT Mode Status\n", SET_AT_MODE);
	printf("%d) Get Event Delay Time\t", GET_EVENT_DELAY);
	printf("%d) Set Event Delay Time\n", SET_EVENT_DELAY);
	printf("%d) Get Last Wakeup Source\n",GET_LAST_WAKEUP_SOURCE);
	printf("%d) Get Low Power Protection Status\n",GET_LOW_POWER_PROTECTION_STATUS);
	printf("%d) Set Low Power Protection\n",SET_LOW_POWER_PROTECTION);
	printf("%d) Get Low Power Protection Threshold\t",GET_LOW_POWER_PROTECTION_THRESHOLD);
	printf("%d) Set Low Power Protection Threshold\n",SET_LOW_POWER_PROTECTION_THRESHOLD);
	printf("%d) Reset Low Power Protection Threshold\n",RESET_LOW_POWER_PROTECTION_THRESHOLD);	
	printf("%d) Get Power Mode\t", GET_POWER_MODE);
	printf("%d) Set Power Mode(12V,24V,48V)\n", SET_POWER_MODE);
	printf("%d) Get Shutdown Mask\t", GET_SHUTDOWN_MASK);
	printf("%d) Set Shutdown Mask\n", SET_SHUTDOWN_MASK);
	printf("%d) Get Force Shutdown Status\t", GET_FORCE_SHUTDOWN);
	printf("%d) Enable Force Shutdonw\t", FORCE_SHUTDOWN_ENABLE);
	printf("%d) Disable Force Shutdonw\n", FORCE_SHUTDOWN_DISABLE);
	printf("%d) Get pre PowerOFF Alarm Status\t", GET_PRE_POWER_OFF_ALARM);
	printf("%d) Set pre PowerOFF Alarm Status\n", SET_PRE_POWER_OFF_ALARM);
	printf("%d) Enable Recv Power Off event\t", ENABLE_RECV_POWER_OFF_EVENT);
	printf("%d) Disable Recv Power Off event\n", DISABLE_RECV_POWER_OFF_EVENT);	
	
	printf("\nEnter your choice: ");
}

static pthread_t poweroff_notify_thread_handle = 0;
static int thread_enable = 0;
static pthread_mutex_t poweroff_alarm_mutex;
static pthread_cond_t poweroff_alarm_event;

static void *poweroff_alarm_handle_thread(void *p)
{
	thread_enable = true;
	
	while(thread_enable)
	{
		pthread_mutex_lock(&poweroff_alarm_mutex);
		pthread_cond_wait(&poweroff_alarm_event, &poweroff_alarm_mutex);
		pthread_mutex_unlock(&poweroff_alarm_mutex);
		
		if(thread_enable)
		{
			printf("Receive Power OFF Event..\r\n");
			break;
		}
	}
	return 0;
}

void get_ignition_status()
{
	USHORT result;
	
	BOOL status;
	
	if( (result = SUSI_IMC_VPM_GetIgnitionStatus( &status )) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetIgnitionStatus. error code=0x%04x\n", result);
		return;
	}
	
	printf("The Ignition is %s\n", status ? "ON" : "OFF");
}

void ignition_wakeup_enable()
{
	USHORT result;
	
	if( (result = SUSI_IMC_VPM_SetWakeupSourceControlStatus(WAKEUP_SOURCE_IGNITION, true)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetWakeupSourceControlStatus fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void ignition_wakeup_disable()
{
	USHORT result;
	
	if( (result = SUSI_IMC_VPM_SetWakeupSourceControlStatus(WAKEUP_SOURCE_IGNITION, false)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetWakeupSourceControlStatus fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void get_ignition_wakeup_status()
{
	USHORT result;
	
	BOOL status;
	
	if( (result = SUSI_IMC_VPM_GetWakeupSourceControlStatus(WAKEUP_SOURCE_IGNITION, &status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetWakeupSourceControlStatus fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("The Ignition Wakeup is %s\n", status ? "Enable" : "Disable" );
}

void get_ignition_mode()
{
	USHORT result;

	IGNITION_MODE mode;
		
	if( (result = SUSI_IMC_VPM_GetIgnitionMode(&mode)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetIgnitionMode fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Ignition Mode is %s\n", mode == 1 ? "Power Off" : "Suspend" );
}

void set_ignition_mode()
{
	printf("Mode:\n");
	printf("0) Poweroff\n");
	printf("1) Suspend\n");

	int m;
	scanf("%d", &m);
	
	WAIT_ENTER();
	
	if( m <0 || m>1 )
	{
		printf("Error range\n");
		return;
	}
		
	USHORT result;

	if( (result = SUSI_IMC_VPM_SetIgnitionMode((IGNITION_MODE)(m+1))) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetIgnitionMode fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void get_voltage()
{
	USHORT result;
	
	float vol;
	
	if( (result = SUSI_IMC_VPM_GetCarBatteryVoltage( &vol )) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetCarBatteryVoltage. error code=0x%04x\n", result);
		return;
	}
	
	printf("The Current voltage is %.2f volt\n", vol);
}

void get_keep_alive_mode()
{
	USHORT result;

	BOOL mode;
	
	if( (result = SUSI_IMC_VPM_GetKeepAliveMode(&mode)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetKeepAliveMode fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Keep Alive Mode is %s\n", mode ? "Enable" : "Disable" );
}

void set_keep_alive_mode()
{
	printf("Mode:\n");
	printf("0) Disable\n");
	printf("1) Enable\n");

	int m;
	scanf("%d", &m);
	
	WAIT_ENTER();
	
	if( m <0 || m>1 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;

	if( (result = SUSI_IMC_VPM_SetKeepAliveMode((BOOL)m)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetKeepAliveMode fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void get_at_mode()
{
	USHORT result;

	BOOL mode;
	
	if( (result = SUSI_IMC_VPM_GetATMode(&mode)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetATMode fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("AT Mode is %s\n", mode ? "Enable" : "Disable" );
}

void set_at_mode()
{
	printf("Mode:\n");
	printf("0) Disable\n");
	printf("1) Enable\n");

	int m;
	scanf("%d", &m);
	
	WAIT_ENTER();
	
	if( m <0 || m>1 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;

	if( (result = SUSI_IMC_VPM_SetATMode((BOOL)m)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetATMode fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void get_event_delay()
{
	printf("Event:\n");
	printf("0) Low Voltage\n");
	printf("1) Low Voltage Hard\n");
	printf("2) Ignition ON\n");
	printf("3) Ignotion OFF to Power OFF\n");
	printf("4) Ignotion OFF Hard\n");
	printf("5) Ignotion OFF to Suspend\n");
	printf("6) Force shutdown\n");
	printf("7) Pre Power OFF Alarm\n");
	
	int e;
	scanf("%d", &e);
	
	WAIT_ENTER();
	
	if( e <0 || e>7 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;
	USHORT second;
	
	switch(e)
	{
		case 0:
		result = SUSI_IMC_VPM_GetLBPLowDelay(&second);
		break;
		
		case 1:
		result = SUSI_IMC_VPM_GetLBPLowHardDelay(&second);
		break;
		
		case 2:
		result = SUSI_IMC_VPM_GetIgnOnDelay(&second);
		break;
		
		case 3:
		result = SUSI_IMC_VPM_GetIgnOffEventDelay(&second);
		break;
		
		case 4:
		result = SUSI_IMC_VPM_GetIgnHardOffDelay(&second);
		break;
		
		case 5:
		result = SUSI_IMC_VPM_GetIgnSuspendHardOffDelay(&second);
		break;
		
		case 6:
		result = SUSI_IMC_VPM_GetForceShutDownDelay(&second);
		break;
		
		case 7:
		result = SUSI_IMC_VPM_GetPrePowerOffAlarmDelay(&second);
		break;
		
		default:
		return;
	}
	
	const char *delay_api_string[] = {
		"SUSI_IMC_VPM_GetLBPLowDelay",
		"SUSI_IMC_VPM_GetLBPLowHardDelay",
		"SUSI_IMC_VPM_GetIgnOnDelay",
		"SUSI_IMC_VPM_GetIgnOffEventDelay",
		"SUSI_IMC_VPM_GetIgnHardOffDelay",
		"SUSI_IMC_VPM_GetIgnSuspendHardOffDelay",
		"SUSI_IMC_VPM_GetForceShutDownDelay",
		"SUSI_IMC_VPM_GetPrePowerOffAlarmDelay"
	};
	
	if( result!= IMC_ERR_NO_ERROR )
	{
		printf("%s fail. error code=0x%04x\n", delay_api_string[e], result);
		return;
	}
	
	printf("The Delay Time is %hu second", second);
}

void set_event_delay()
{
	USHORT result;
	
	printf("Event:\n");
	printf("0) Low Voltage\n");
	printf("1) Low Voltage Hard\n");
	printf("2) Ignition ON\n");
	printf("3) Ignotion OFF to Power OFF\n");
	printf("4) Ignotion OFF Hard\n");
	printf("5) Ignotion OFF to Suspend\n");
	printf("6) Force shutdown\n");
	printf("7) Pre Power OFF Alarm\n");
	
	int e;
	scanf("%d", &e);
	
	WAIT_ENTER();
	
	if( e <0 || e>7 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Delay time(second):");
	USHORT s;
	scanf("%hd", &s);
	
	WAIT_ENTER();
	
	switch(e)
	{
		case 0:
		result = SUSI_IMC_VPM_SetLBPLowDelay(s);
		break;
		
		case 1:
		result = SUSI_IMC_VPM_SetLBPLowHardDelay(s);
		break;
		
		case 2:
		result = SUSI_IMC_VPM_SetIgnOnDelay(s);
		break;
		
		case 3:
		result = SUSI_IMC_VPM_SetIgnOffEventDelay(s);
		break;
		
		case 4:
		result = SUSI_IMC_VPM_SetIgnHardOffDelay(s);
		break;
		
		case 5:
		result = SUSI_IMC_VPM_SetIgnSuspendHardOffDelay(s);
		break;
		
		case 6:
		result = SUSI_IMC_VPM_SetForceShutDownDelay(s);
		break;
		
		case 7:
		result = SUSI_IMC_VPM_SetPrePowerOffAlarmDelay(s);
		break;
		
		default:
		return;
	}
	
	const char *delay_api_string[] = {
		"SUSI_IMC_VPM_SetLBPLowDelay",
		"SUSI_IMC_VPM_SetLBPLowHardDelay",
		"SUSI_IMC_VPM_SetIgnOnDelay",
		"SUSI_IMC_VPM_SetIgnOffEventDelay",
		"SUSI_IMC_VPM_SetIgnHardOffDelay",
		"SUSI_IMC_VPM_SetIgnSuspendHardOffDelay",
		"SUSI_IMC_VPM_SetForceShutDownDelay",
		"SUSI_IMC_VPM_SetPrePowerOffAlarmDelay"
	};
		
	if( result != IMC_ERR_NO_ERROR )
	{
		printf("%s fail. error code=0x%04x\n", delay_api_string[e], result);
		return;
	}
	
	printf("Success\n");
}

void get_last_wakeup_source()
{
	USHORT result;
	
	WAKEUP_SOURCE source;
	
	if( (result = SUSI_IMC_VPM_GetLastWakeupSource(&source)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetLastWakeupSource fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("The Last Wakeup Source from %s\n", wakeup_source_string[(int)source]);
}

void get_lvp_status()
{
	printf("Type :\n");
	printf("0) Pre-boot\n");
	printf("1) Post\n");
	
	int t;
	scanf("%d", &t);
	
	WAIT_ENTER();
	
	if( t <0 || t>1 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;
	BOOL status;

	if( t )
	{
		if( (result = SUSI_IMC_VPM_GetPrebootLBPStatus(&status)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_VPM_GetPrebootLBPStatus fail. error code=0x%04x\n", result);
			return;
		}
	}
	else
	{
		if( (result = SUSI_IMC_VPM_GetLBPStatus(&status)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_VPM_GetLBPStatus fail. error code=0x%04x\n", result);
			return;
		}
	}

	printf("The %s Low Power Protection is %s\n", t ? "Post-boot" : "Pre-boot",  status ? "Enable" : "Disable");
}

void set_lvp_status()
{
	printf("Type :\n");
	printf("0) Pre-boot\n");
	printf("1) Post\n");
	
	int t;
	scanf("%d", &t);
	
	WAIT_ENTER();
	
	if( t <0 || t>1 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;
	int s;
	printf("0) Disable\n");
	printf("1) Enable\n");
	scanf("%d", &s);
	
	WAIT_ENTER();
	
	if( s <0 || s>1 )
	{
		printf("Error range\n");
		return;
	}

	if( t )
	{
		if( (result = SUSI_IMC_VPM_SetLBPStatus((BOOL)s)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_VPM_SetLBPStatus fail. error code=0x%04x\n", result);
			return;
		}
	}
	else
	{
		if( (result = SUSI_IMC_VPM_SetPrebootLBPStatus((BOOL)s)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_VPM_SetPrebootLBPStatus fail. error code=0x%04x\n", result);
			return;
		}
	}

	printf("Success\n");
}

void get_lvp_threshold()
{
	printf("Type :\n");
	printf("0) Pre-boot\n");
	printf("1) Post\n");
	
	int t;
	scanf("%d", &t);
	
	WAIT_ENTER();
	
	if( t <0 || t>1 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Voltage Mode :\n");
	printf("0) 12V\n");
	printf("1) 24V\n");
	
	int vm;
	scanf("%d", &vm);
	
	WAIT_ENTER();
	
	if( vm <0 || vm>1 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;
	float vol;
	
	if( t )
	{
		if( vm == 0)
		{		
			if( (result = SUSI_IMC_VPM_GetPrebootThresholdFor12VSystem(&vol)) != IMC_ERR_NO_ERROR )
			{
				printf("SUSI_IMC_VPM_GetPrebootThresholdFor12VSystem fail. error code=0x%04x\n", result);
				return;
			}
		}
		else
		{
			if( (result = SUSI_IMC_VPM_GetPrebootThresholdFor24VSystem(&vol)) != IMC_ERR_NO_ERROR )
			{
				printf("SUSI_IMC_VPM_GetPrebootThresholdFor24VSystem fail. error code=0x%04x\n", result);
				return;
			}		
		}
	}
	else
	{
		if( vm == 0)
		{		
			if( (result = SUSI_IMC_VPM_GetLBPThresholdFor12VSystem(&vol)) != IMC_ERR_NO_ERROR )
			{
				printf("SUSI_IMC_VPM_GetLBPThresholdFor12VSystem fail. error code=0x%04x\n", result);
				return;
			}
		}
		else
		{
			if( (result = SUSI_IMC_VPM_GetLBPThresholdFor24VSystem(&vol)) != IMC_ERR_NO_ERROR )
			{
				printf("SUSI_IMC_VPM_GetLBPThresholdFor24VSystem fail. error code=0x%04x\n", result);
				return;
			}		
		}
	}

	printf("The %s Low Power Protection is %.2f volt\n", t ? "Post-boot" : "Pre-boot", vol);
}

static BATTERY_INFO battery_info_12v;
static BATTERY_INFO battery_info_24v;

int get_lvp_range()
{
	static int init_once = 0;
	
	if( init_once )
		return 0;
	
	USHORT result;
		
	if( (result = SUSI_IMC_VPM_GetLBPThresholdInfo(CAR_BATTERY_12V, &battery_info_12v)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetLBPThresholdInfo fail. error code=0x%04x\n", result);
		return -1;
	}
	
	if( (result = SUSI_IMC_VPM_GetLBPThresholdInfo(CAR_BATTERY_24V, &battery_info_24v)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetLBPThresholdInfo fail. error code=0x%04x\n", result);
		return -1;
	}
	
	init_once = 1;
	
	return 0;
}

void set_lvp_threshold()
{
	if(get_lvp_range())
		return;
	
	printf("Type :\n");
	printf("0) Pre-boot\n");
	printf("1) Post\n");
	
	int t;
	scanf("%d", &t);
	
	WAIT_ENTER();
	
	if( t <0 || t>1 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Voltage Mode :\n");
	printf("0) 12V\n");
	printf("1) 24V\n");
	
	int vm;
	scanf("%d", &vm);
	
	WAIT_ENTER();
	
	if( vm <0 || vm>1 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;
	float v;		
	float voltage_range_min;
	float voltage_range_max;
	if(vm == 0)
	{
		voltage_range_min = battery_info_12v.fBatteryMinVoltage;
		voltage_range_max = battery_info_12v.fBatteryMaxVoltage;
		printf("Threshold (min:%.2f max:%.2f default:%.2f):",voltage_range_min ,voltage_range_max ,battery_info_12v.fBatteryDefVoltage);
	}
	else
	{
		voltage_range_min = battery_info_24v.fBatteryMinVoltage;
		voltage_range_max = battery_info_24v.fBatteryMaxVoltage;
		printf("Threshold (min:%.2f max:%.2f default:%.2f):",voltage_range_min ,voltage_range_max ,battery_info_24v.fBatteryDefVoltage);
	}
	scanf("%f", &v);
	
	WAIT_ENTER();
	
	if( v < voltage_range_min || v>voltage_range_max )
	{
		printf("Error range\n");
		return;
	}

	if( t )
	{
		if( vm )
		{
			if( (result = SUSI_IMC_VPM_SetLBPThresholdFor24VSystem(v)) != IMC_ERR_NO_ERROR )
			{
				printf("SUSI_IMC_VPM_SetLBPThresholdFor24VSystem fail. error code=0x%04x\n", result);
				return;
			}
		}
		else
		{
			if( (result = SUSI_IMC_VPM_SetLBPThresholdFor12VSystem(v)) != IMC_ERR_NO_ERROR )
			{
				printf("SUSI_IMC_VPM_SetLBPThresholdFor12VSystem fail. error code=0x%04x\n", result);
				return;
			}
		}
	}
	else
	{
		if( vm )
		{
			if( (result = SUSI_IMC_VPM_SetPrebootThresholdFor24VSystem(v)) != IMC_ERR_NO_ERROR )
			{
				printf("SUSI_IMC_VPM_SetPrebootThresholdFor24VSystem fail. error code=0x%04x\n", result);
				return;
			}
		}
		else
		{
			if( (result = SUSI_IMC_VPM_SetPrebootThresholdFor12VSystem(v)) != IMC_ERR_NO_ERROR )
			{
				printf("SUSI_IMC_VPM_SetPrebootThresholdFor12VSystem fail. error code=0x%04x\n", result);
				return;
			}
		}
	}

	printf("Success\n");
}

void reset_lvp_threshold()
{
	if(get_lvp_range())
		return;
	
	USHORT result;
	
	CAR_BATTERY_MODE mode;
		
	if( (result = SUSI_IMC_VPM_GetCurrentCarBatteryMode(&mode)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetCurrentCarBatteryMode fail. error code=0x%04x\n", result);
		return;
	}
	
	if( mode == CAR_BATTERY_12V )
	{
		if( (result = SUSI_IMC_VPM_SetLBPThresholdFor12VSystem(battery_info_12v.fBatteryDefVoltage)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_VPM_SetLBPThresholdFor12VSystem fail. error code=0x%04x\n", result);
			return;
		}
		if( (result = SUSI_IMC_VPM_SetPrebootThresholdFor12VSystem(battery_info_12v.fBatteryDefPrebootVoltage)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_VPM_SetPrebootThresholdFor12VSystem fail. error code=0x%04x\n", result);
			return;
		}
	}
	else
	{
		if( (result = SUSI_IMC_VPM_SetLBPThresholdFor24VSystem(battery_info_24v.fBatteryDefVoltage)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_VPM_SetLBPThresholdFor24VSystem fail. error code=0x%04x\n", result);
			return;
		}
		if( (result = SUSI_IMC_VPM_SetPrebootThresholdFor24VSystem(battery_info_24v.fBatteryDefPrebootVoltage)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_VPM_SetPrebootThresholdFor24VSystem fail. error code=0x%04x\n", result);
			return;
		}
	}
	
	printf("Success\n");
}

void get_power_mode()
{
	USHORT result;

	CAR_BATTERY_MODE mode;
		
	if( (result = SUSI_IMC_VPM_GetCurrentCarBatteryMode(&mode)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetCurrentCarBatteryMode fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Power Mode is %s\n", mode == CAR_BATTERY_48V ? "48V" : (mode == CAR_BATTERY_24V ? "24V" : "12V") );
}

void set_power_mode()
{
	printf("Mode:\n");
	printf("2) 24V\n");
	printf("3) 12V\n");

	int m;
	scanf("%d", &m);
	
	WAIT_ENTER();
	
	if( m <2 || m>3 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;

	if( (result = SUSI_IMC_VPM_SetCurrentCarBatteryMode((CAR_BATTERY_MODE)m)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetCurrentCarBatteryMode fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void get_shutdown_mask()
{
	USHORT result;
	
	BOOL status;
		
	printf("Select Mask:\n");
	printf("0) Power Button\n");
	printf("1) Ignition\n");

	int m;
	scanf("%d", &m);
	
	WAIT_ENTER();
	
	if( m <0 || m>1 )
	{
		printf("Error range\n");
		return;
	}
			
	if( (result = SUSI_IMC_VPM_GetShutdownSourceControlStatus((SHUTDOWN_SOURCE)m, &status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetShutdownSourceControlStatus fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Shutdown mask status is %s\n", status == 0 ? "Disable" : "Enable");
}

void set_shutdown_mask()
{
	printf("Select Mask:\n");
	printf("0) Power Button\n");
	printf("1) Ignition\n");

	int m;
	scanf("%d", &m);
	
	WAIT_ENTER();
	
	if( m <0 || m>1 )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Mode:\n");
	printf("0) Disable\n");
	printf("1) Enable\n");

	int s;
	scanf("%d", &s);
	
	WAIT_ENTER();
	
	if( s <0 || s>1 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;
	
	if( (result = SUSI_IMC_VPM_SetShutdownSourceControlStatus((SHUTDOWN_SOURCE)m, (BOOL)s)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetShutdownSourceControlStatus fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void force_shutdown_enable()
{
	USHORT result;
	
	if( (result = SUSI_IMC_VPM_SetForceShutDown(true)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetForceShutDown fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void force_shutdown_disable()
{
	USHORT result;
	
	if( (result = SUSI_IMC_VPM_SetForceShutDown(false)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetForceShutDown fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void get_force_shutdown_status()
{
	USHORT result;
	
	BOOL status;
	
	if( (result = SUSI_IMC_VPM_GetForceShutDown(&status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetForceShutDown fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("The Force shutdown is %s\n", status ? "Enable" : "Disable" );
}

void get_pre_power_off_alarm()
{
	USHORT result;

	BOOL mode;
	
	if( (result = SUSI_IMC_VPM_GetPrePowerOffAlarm(&mode)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetPrePowerOffAlarm fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Pre Power-OFF Alarm is %s\n", mode ? "Enable" : "Disable" );
}

void set_pre_power_off_alarm()
{
	printf("Alarm:\n");
	printf("0) Disable\n");
	printf("1) Enable\n");

	int m;
	scanf("%d", &m);
	
	WAIT_ENTER();
	
	if( m <0 || m>1 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;

	if( (result = SUSI_IMC_VPM_SetPrePowerOffAlarm((BOOL)m)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetPrePowerOffAlarm fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void enable_receive_poweroff_alarm()
{
	if(thread_enable)
		return;
		
	static int init_once = 0;
	
	USHORT result;
	
	if(!init_once)
	{	
		pthread_condattr_t cond_attr;
		pthread_condattr_init ( &cond_attr );
		pthread_cond_init ( &poweroff_alarm_event, &cond_attr );
	
		pthread_mutexattr_t attr;
		pthread_mutexattr_init (&attr);
		pthread_mutexattr_settype (&attr, PTHREAD_MUTEX_RECURSIVE);
		pthread_mutex_init (&poweroff_alarm_mutex, &attr);
		if( (result = SUSI_IMC_VPM_SetIgnPowerOffEvent(&poweroff_alarm_event)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_VPM_SetIgnPowerOffEvent fail. error code=0x%04x\n", result);
			return;
		}
	
		if( (result = SUSI_IMC_VPM_SetLBPPowerOffEvent(&poweroff_alarm_event)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_VPM_SetLBPPowerOffEvent fail. error code=0x%04x\n", result);
			return;
		}
		
		init_once = 1;
	}
	
	pthread_attr_t thread_attr;
	pthread_attr_init(&thread_attr);
	int ret = ::pthread_create(&poweroff_notify_thread_handle, &thread_attr, &poweroff_alarm_handle_thread, NULL);
	pthread_attr_destroy(&thread_attr);
	
	if( ret < 0)
	{
		printf("power-off alarm thread create fail.");
		return;
	}
	
	printf("Success\n");
}

void disable_receive_poweroff_alarm()
{
	if(!thread_enable)
		return;
	thread_enable = 0;
	
	pthread_mutex_lock(&poweroff_alarm_mutex);
	pthread_cond_broadcast(&poweroff_alarm_event);
	pthread_mutex_unlock(&poweroff_alarm_mutex);
		
	pthread_join(poweroff_notify_thread_handle, NULL);
	poweroff_notify_thread_handle = 0;
}

void power_management_main()
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
			case GET_IGNITION_STATUS:
				get_ignition_status();
				break;
			case IGNITION_WAKEUP_ENABLE:
				ignition_wakeup_enable();
				break;
			case IGNITION_WAKEUP_DISABLE:
				ignition_wakeup_disable();
				break;
			case GET_IGNITION_WAKEUP_STATUS:
				get_ignition_wakeup_status();
				break;
			case GET_IGNITION_MODE:
				get_ignition_mode();
				break;
			case SET_IGNITION_MODE:
				set_ignition_mode();
				break;
			case GET_VOLTAGE:
				get_voltage();
				break;
			case GET_KEEP_ALIVEMODE:
				 get_keep_alive_mode();
				break;
			case SET_KEEP_ALIVEMODE:
				set_keep_alive_mode();
				break;
			case GET_AT_MODE:
				get_at_mode();
				break;
			case SET_AT_MODE:
				set_at_mode();
				break;
			case GET_EVENT_DELAY:
				get_event_delay();
				break;
			case SET_EVENT_DELAY:
				set_event_delay();
				break;
			case GET_LAST_WAKEUP_SOURCE:
				get_last_wakeup_source();
				break;
			case GET_LOW_POWER_PROTECTION_STATUS:
				get_lvp_status();
				break;
			case SET_LOW_POWER_PROTECTION:
				set_lvp_status();
				break;
			case GET_LOW_POWER_PROTECTION_THRESHOLD:
				get_lvp_threshold();
				break;
			case SET_LOW_POWER_PROTECTION_THRESHOLD:
				set_lvp_threshold();
				break;
			case RESET_LOW_POWER_PROTECTION_THRESHOLD:
				reset_lvp_threshold();
				break;
			case GET_POWER_MODE:
				get_power_mode();
				break;
			case SET_POWER_MODE:
				set_power_mode();
				break;
			case GET_SHUTDOWN_MASK:
				get_shutdown_mask();
				break;
			case SET_SHUTDOWN_MASK:
				set_shutdown_mask();
				break;
			case GET_FORCE_SHUTDOWN:
				get_force_shutdown_status();
				break;
			case FORCE_SHUTDOWN_ENABLE:
				force_shutdown_enable();
				break;
			case FORCE_SHUTDOWN_DISABLE:
				force_shutdown_disable();
				break;
			case GET_PRE_POWER_OFF_ALARM:
				get_pre_power_off_alarm();
				break;
			case SET_PRE_POWER_OFF_ALARM:
				set_pre_power_off_alarm();
				break;
			case ENABLE_RECV_POWER_OFF_EVENT:
				enable_receive_poweroff_alarm();
				break;
			case DISABLE_RECV_POWER_OFF_EVENT:
				disable_receive_poweroff_alarm();
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
