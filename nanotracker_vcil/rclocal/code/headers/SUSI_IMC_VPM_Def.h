#ifndef SUSI_VPM_DEF_H
#define SUSI_VPM_DEF_H

#define SUSI_COM4								4

enum CAR_BATTERY_MODE
{
    CAR_BATTERY_UNKNOWN = -1,
    CAR_BATTERY_DEFAULT = 0,
    CAR_BATTERY_48V = 1,
    CAR_BATTERY_24V = 2,
    CAR_BATTERY_12V = 3,
    CAR_BATTERY_SIZE = 4
};
typedef CAR_BATTERY_MODE* PCAR_BATTERY_MODE;

enum IGNITION_MODE
{
	IGNITION_NONE = 0,
	IGNITION_POWEROFF = 1,
	IGNITION_SUSPEND = 2,
	IGNITION_SIZE = 3
};
typedef IGNITION_MODE* PIGNITION_MODE;

enum WAKEUP_SOURCE
{
	WAKEUP_SOURCE_NONE = -1,
	WAKEUP_SOURCE_POWER_BUTTON = 0,
	WAKEUP_SOURCE_IGNITION,
	WAKEUP_SOURCE_WWAN,
	WAKEUP_SOURCE_GSENSOR,
	WAKEUP_SOURCE_D0,
	WAKEUP_SOURCE_D1,
	WAKEUP_SOURCE_ALARM,
	WAKEUP_SOURCE_HOT_KEY,
	WAKEUP_SOURCE_D2,
	WAKEUP_SOURCE_D3,
	WAKEUP_SOURCE_RESET
};
typedef WAKEUP_SOURCE* PWAKEUP_SOURCE;

enum SHUTDOWN_SOURCE
{
	SHUTDOWN_SOURCE_POWER_BUTTON = 0,
	SHUTDOWN_SOURCE_IGNITION
};
typedef SHUTDOWN_SOURCE* PSHUTDOWN_SOURCE;
typedef SHUTDOWN_SOURCE SHUTDOWN_SOURCE;

enum ALARM_MODE
{
	NO_ALARM = -1,
	HOURLY = 0,
	DAILY  = 1,
	WEEKLY = 2
};
typedef ALARM_MODE* PALARM_MODE;

struct BATTERY_INFO
{
// DO NOT change the order of the member variable in this structure. Check the variable in CVPMMgr before modification
	float fBatteryMaxVoltage;
	float fBatteryMinVoltage;
	float fBatteryDefVoltage;
	float fBatteryDefPrebootVoltage;
};
typedef BATTERY_INFO* PBATTERY_INFO;

struct BACKUP_BATTERY_FLAG_INFO
{
	bool DSG;
	bool SOCF;
	bool SOC1;
	bool OCVTAKEN;
	bool CHG;
	bool FC;
	bool XCHG;
	bool CHG_INH;
	bool OTD;
	bool OTC;
};
typedef BACKUP_BATTERY_FLAG_INFO* PBACKUP_BATTERY_FLAG_INFO;

struct BACKUP_BATTERY_INFO
{
	int iMaxCapacity;
	int iCycleCount;
	BACKUP_BATTERY_FLAG_INFO BattryFlag;
};
typedef BACKUP_BATTERY_INFO* PBACKUP_BATTERY_INFO;

// Keep track of the RTC time.
struct VPM_RTC_TIME
{
	unsigned char nYear;
	unsigned char nMonth;
	unsigned char nDay;
	unsigned char nDayOfWeek;
	unsigned char nHour;
	unsigned char nMinute;
	unsigned char nSecond;
};
typedef VPM_RTC_TIME* PVPM_RTC_TIME;

struct VPM_ALARM_TIME
{
	unsigned char nDayOfWeek;
	unsigned char nHour;
	unsigned char nMinute;
};
typedef VPM_ALARM_TIME* PVPM_ALARM_TIME;

struct VPM_FIRMWARE_INFO
{
	unsigned char byVersion[32];
};
typedef VPM_FIRMWARE_INFO* PVPM_FIRMWARE_INFO;

#endif