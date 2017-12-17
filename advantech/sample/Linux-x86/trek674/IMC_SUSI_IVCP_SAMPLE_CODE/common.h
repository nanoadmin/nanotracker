#ifndef _IVCP_SAMPLE_CODE_COMMON_H
#define _IVCP_SAMPLE_CODE_COMMON_H

#include <stdlib.h>

#define VPM_PORT_NUMBER 4

extern char library_version[];

void firmware_main();
void watchdog_main();
void peripheral_main();
void dio_main();
void alarm_main();
void storage_main();
void gsensor_main();
void power_management_main();
void sensor_main();

enum
{
	IVCP_SAMPLE_CODE_FUNCTION_FIRMWARE = 1,
	IVCP_SAMPLE_CODE_FUNCTION_WATCHDOG,
	IVCP_SAMPLE_CODE_FUNCTION_ALARM,
	IVCP_SAMPLE_CODE_FUNCTION_PERIPHERAL_CONTROL,
	IVCP_SAMPLE_CODE_FUNCTION_DIGITAL_IO,
	IVCP_SAMPLE_CODE_FUNCTION_STORAGE,
	IVCP_SAMPLE_CODE_FUNCTION_GSENSOR,
	IVCP_SAMPLE_CODE_FUNCTION_POWER_MANAGEMENT,
	IVCP_SAMPLE_CODE_FUNCTION_TEMPERATURE_SENSOR,
	IVCP_SAMPLE_CODE_MAX_FUNCTION_PAGE
};

#define WAIT_ENTER() while( getchar()!='\n') {};

#if defined(WIN32) && !defined(WINCE) || defined(_WIN64)
	#define CLEAR_SCREEN() system("cls");
	#define SCANF(format, pvalue) scanf_s(format, pvalue)
#else
	#define CLEAR_SCREEN() system("clear");
	#define SCANF(format, pvalue) scanf(format, pvalue)
#endif

#endif
