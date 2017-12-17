#include <stdio.h>

#include "common.h"
#include "pthread.h"
#include "SUSI_IMC.h"

enum page_function{
	GSENSOR_READ = 1,
	GET_GSENSOR_RESOLUTION,
	SET_GSENSOR_RESOLUTION,
	GSENSOR_WAKEUP_ENABLE,
	GSENSOR_WAKEUP_DISABLE,
	GET_GSENSOR_WAKEUP_STATUS,
	GET_GSENSOR_WAKEUP_THRESHOLD,
	SET_GSENSOR_WAKEUP_THRESHOLD,
	GET_GSENSOR_ALARM_THRESHOLD,
	SET_GSENSOR_ALARM_THRESHOLD,
	GSENSOR_ALARM_ENABLE,
	GSENSOR_ALARM_DISABLE,
};

static void show_welcome_title(void)
{
	printf("IVCP SDK Sample -- library version:%s\n", library_version);
	printf(">> Gsensor Control Menu\n\n");
}

static void page_menu()
{
	printf("0) back\n");
	
	printf("%d) Read Gsensor Value\n", GSENSOR_READ);
	printf("%d) Get Gsensor Resolution\n", GET_GSENSOR_RESOLUTION);
	printf("%d) Set Gsensor Resolution\n",SET_GSENSOR_RESOLUTION);
	printf("%d) Enable Gsensor Wakeup\n", GSENSOR_WAKEUP_ENABLE);
	printf("%d) Disable Gsensor Wakeup\n", GSENSOR_WAKEUP_DISABLE);
	printf("%d) Get Gsensor Wakeup Status\n", GET_GSENSOR_WAKEUP_STATUS);
	printf("%d) Get Gsensor Wakeup Threshold\n", GET_GSENSOR_WAKEUP_THRESHOLD);
	printf("%d) Set Gsensor Wakeup Threshold\n",SET_GSENSOR_WAKEUP_THRESHOLD);
	printf("%d) Get Gsensor Alarm Threshold\n", GET_GSENSOR_ALARM_THRESHOLD);
	printf("%d) Set Gsensor Alarm Threshold\n",SET_GSENSOR_ALARM_THRESHOLD);
	printf("%d) Enable Gsensor Alarm\n", GSENSOR_ALARM_ENABLE);
	printf("%d) Disable Gsensor Alarm\n", GSENSOR_ALARM_DISABLE);
		
	printf("\nEnter your choice: ");
}

static pthread_t gsensor_thread_handle = 0;
static int thread_enable = 0;
static pthread_mutex_t gsensor_alarm_mutex;
static pthread_cond_t gsensor_alarm_event;

static void *gsensor_alarm_read_thread(void *p)
{
	thread_enable = true;
	
	while(thread_enable)
	{
		pthread_mutex_lock(&gsensor_alarm_mutex);
		pthread_cond_wait(&gsensor_alarm_event, &gsensor_alarm_mutex);
		pthread_mutex_unlock(&gsensor_alarm_mutex);

		USHORT result;
		IMC_GSENSOR_DATA value;
		while( (result = SUSI_IMC_GSENSOR_GetAlarmData(&value)) == IMC_ERR_NO_ERROR)
		{
			printf("The Gsensor Alarm Trigger Value is x=%d, y=%d,z=%d mg\n", value.x_mg, value.y_mg, value.z_mg);
		}

		if( result != IMC_ERR_GSENSOR_DATA_NOT_READY )
		{
			printf("SUSI_IMC_GSENSOR_GetAlarmData fail. error code=0x%04x\n", result);
			continue;
		}
	
	}
	return 0;
}

void read_gsensor()
{
	USHORT result;
	
	IMC_GSENSOR_DATA value;
	
	if( (result = SUSI_IMC_GSENSOR_GetData( &value )) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_GSENSOR_GetData fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("The Gsensor Value is x=%d, y=%d,z=%d mg\n", value.x_mg, value.y_mg, value.z_mg);
}

void gsensor_get_resolution()
{
	USHORT result;
	
	IMC_GSENSOR_RES res;
	const char *res_string[] = { "2"," 4", "8", "16",};
	
	if( (result = SUSI_IMC_GSENSOR_GetResolution(&res)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_GSENSOR_GetResolution fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("The Current Gsensor Resolution is %sG\n", res_string[(int)res]);
}

void gsensor_set_resolution()
{
	printf("Resolution :\n");
	printf("0) 2G\n");
	printf("1) 4G\n");
	printf("2) 8G\n");
	printf("3) 16G\n");
	
	int r;
	scanf("%d", &r);
	
	WAIT_ENTER();
	
	if( r <0 || r>3 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;

	if( (result = SUSI_IMC_GSENSOR_SetResolution((IMC_GSENSOR_RES)r)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_GSENSOR_SetResolution fail. error code=0x%04x\n", result);
		return;
	}


	printf("Success\n");
}

void gsensor_wakeup_enable()
{
	USHORT result;
	
	if( (result = SUSI_IMC_VPM_SetWakeupSourceControlStatus(WAKEUP_SOURCE_GSENSOR, true)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetWakeupSourceControlStatus fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void gsensor_wakeup_disable()
{
	USHORT result;
	
	if( (result = SUSI_IMC_VPM_SetWakeupSourceControlStatus(WAKEUP_SOURCE_GSENSOR, false)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_SetWakeupSourceControlStatus fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void get_gsensor_wakeup_status()
{
	USHORT result;
	
	BOOL status;
	
	if( (result = SUSI_IMC_VPM_GetWakeupSourceControlStatus(WAKEUP_SOURCE_GSENSOR, &status)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_VPM_GetWakeupSourceControlStatus fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("The Gsensor Wakeup is %s\n", status ? "Enable" : "Disable" );
}

void gsensor_get_wakeup_threshold()
{
	USHORT result;
	
	int mg;
		
	if( (result = SUSI_IMC_GSENSOR_GetWakeupThreshold(&mg)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_GSENSOR_GetWakeupThreshold fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("The Current Gsensor Wakeup Threshold is %d mg\n", mg);
}

void gsensor_set_wakeup_threshold()
{
	printf("Threshold (mg) :");	
	int mg;
	scanf("%d", &mg);
	
	WAIT_ENTER();
	
	if( mg <0 || mg>16000 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;

	if( (result = SUSI_IMC_GSENSOR_SetWakeupThreshold(mg)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_GSENSOR_SetWakeupThreshold fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void gsensor_get_alarm_threshold()
{
	USHORT result;
	
	int mg;
		
	if( (result = SUSI_IMC_GSENSOR_GetAlarmThreshold(&mg)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_GSENSOR_GetAlarmThreshold fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("The Current Gsensor Wakeup Threshold is %d mg\n", mg);
}

void gsensor_set_alarm_threshold()
{
	printf("Threshold (mg) :");	
	int mg;
	scanf("%d", &mg);
	
	WAIT_ENTER();
	
	if( mg <2000 || mg>15000 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;

	if( (result = SUSI_IMC_GSENSOR_SetAlarmThreshold(mg)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_GSENSOR_SetAlarmThreshold fail. error code=0x%04x\n", result);
		return;
	}

	printf("Success\n");
}

void gsensor_alarm_enable()
{
	USHORT result;

	pthread_condattr_t cond_attr;
	pthread_condattr_init ( &cond_attr );
	pthread_cond_init ( &gsensor_alarm_event, &cond_attr );
	
	pthread_mutexattr_t attr;
	pthread_mutexattr_init (&attr);
	pthread_mutexattr_settype (&attr, PTHREAD_MUTEX_RECURSIVE);
	pthread_mutex_init (&gsensor_alarm_mutex, &attr);
	
	if( (result = SUSI_IMC_GSENSOR_SetAlarmEvent(&gsensor_alarm_event)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_GSENSOR_SetAlarmEvent fail. error code=0x%04x\n", result);
		return;
	}
	
	pthread_attr_t thread_attr;
	pthread_attr_init(&thread_attr);
	int ret = ::pthread_create(&gsensor_thread_handle, &thread_attr, &gsensor_alarm_read_thread, NULL);
	pthread_attr_destroy(&thread_attr);
	
	if( ret < 0)
	{
		printf("gsensor alarm thread create fail.");
		return;
	}
	
	if( (result = SUSI_IMC_GSENSOR_AlarmEnabled(true)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_GSENSOR_AlarmEnabled fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void gsensor_alarm_disable()
{
	if(!thread_enable)
		return;
	thread_enable = 0;
	
	pthread_mutex_lock(&gsensor_alarm_mutex);
	pthread_cond_broadcast(&gsensor_alarm_event);
	pthread_mutex_unlock(&gsensor_alarm_mutex);
		
	pthread_join(gsensor_thread_handle, NULL);
	gsensor_thread_handle = 0;

	USHORT result;
		
	if( (result = SUSI_IMC_GSENSOR_AlarmEnabled(false)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_GSENSOR_AlarmEnabled fail. error code=0x%04x\n", result);
		return;
	}
	
	printf("Success\n");
}

void gsensor_main()
{
	USHORT result;
	int op;
	
	if( (result = SUSI_IMC_GSENSOR_Initialize(VPM_PORT_NUMBER)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_GSENSOR_Initialize fail. error code=0x%04x\n", result);
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
			case GSENSOR_READ:
				read_gsensor();
				break;				
			case GET_GSENSOR_RESOLUTION:
				gsensor_get_resolution();
				break;
			case SET_GSENSOR_RESOLUTION:
				gsensor_set_resolution();
				break;
			case GSENSOR_WAKEUP_ENABLE:
				gsensor_wakeup_enable();
				break;
			case GSENSOR_WAKEUP_DISABLE:
				gsensor_wakeup_disable();
				break;
			case GET_GSENSOR_WAKEUP_STATUS:
				get_gsensor_wakeup_status();
				break;
			case GET_GSENSOR_WAKEUP_THRESHOLD:
				gsensor_get_wakeup_threshold();
				break;
			case SET_GSENSOR_WAKEUP_THRESHOLD:
				gsensor_set_wakeup_threshold();
				break;
			case GET_GSENSOR_ALARM_THRESHOLD:
				gsensor_get_alarm_threshold();
				break;
			case SET_GSENSOR_ALARM_THRESHOLD:
				gsensor_set_alarm_threshold();
				break;
			case GSENSOR_ALARM_ENABLE:
				gsensor_alarm_enable();
				break;
			case GSENSOR_ALARM_DISABLE:
				gsensor_alarm_disable();
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
	}
	
	if( (result = SUSI_IMC_GSENSOR_Deinitialize()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_GSENSOR_Deinitialize. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return;
	}
}
