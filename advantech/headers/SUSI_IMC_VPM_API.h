#ifndef SUSI_IMC_VPM_API_H
#define SUSI_IMC_VPM_API_H

#include "SUSI_IMC_Types.h"

DLLAPI USHORT SUSI_IMC_VPM_Initialize(IN BYTE port_number);
DLLAPI USHORT SUSI_IMC_VPM_Deinitialize(void);
DLLAPI USHORT SUSI_IMC_VPM_GetFWVersion(OUT PVPM_FIRMWARE_INFO pVersion);
DLLAPI USHORT SUSI_IMC_VPM_GetLibVersion(OUT PBYTE pVersion);
DLLAPI USHORT SUSI_IMC_VPM_GetPlatformName(OUT PCHAR pName);

DLLAPI USHORT SUSI_IMC_VPM_SetIgnitionMode(IN IGNITION_MODE nMode);
DLLAPI USHORT SUSI_IMC_VPM_GetIgnitionMode(OUT PIGNITION_MODE pnMode);

DLLAPI USHORT SUSI_IMC_VPM_SetIgnOffEventDelay(IN USHORT usValue);
DLLAPI USHORT SUSI_IMC_VPM_GetIgnOffEventDelay(OUT PUSHORT pusValue);

DLLAPI USHORT SUSI_IMC_VPM_SetIgnHardOffDelay(IN USHORT usValue);
DLLAPI USHORT SUSI_IMC_VPM_GetIgnHardOffDelay(OUT PUSHORT pusValue);

DLLAPI USHORT SUSI_IMC_VPM_SetIgnSuspendHardOffDelay(IN USHORT usValue); 
DLLAPI USHORT SUSI_IMC_VPM_GetIgnSuspendHardOffDelay(OUT PUSHORT pusValue);

DLLAPI USHORT SUSI_IMC_VPM_SetForceShutDownDelay(IN USHORT usValue);
DLLAPI USHORT SUSI_IMC_VPM_GetForceShutDownDelay(OUT PUSHORT pusValue);

DLLAPI USHORT SUSI_IMC_VPM_SetPrePowerOffAlarmDelay(IN USHORT usValue);
DLLAPI USHORT SUSI_IMC_VPM_GetPrePowerOffAlarmDelay(OUT PUSHORT pusValue);

DLLAPI USHORT SUSI_IMC_VPM_SetPrePowerOffAlarm(IN BOOL bEnable);
DLLAPI USHORT SUSI_IMC_VPM_GetPrePowerOffAlarm(OUT PBOOL pbEnable);

DLLAPI USHORT SUSI_IMC_VPM_SetIgnPowerOffEvent ( void* hEvent );
DLLAPI USHORT SUSI_IMC_VPM_SetLBPPowerOffEvent ( void* hEvent );

DLLAPI USHORT SUSI_IMC_VPM_SetForceShutDown(IN BOOL bEnable);
DLLAPI USHORT SUSI_IMC_VPM_GetForceShutDown(OUT PBOOL pbEnable);

DLLAPI USHORT SUSI_IMC_VPM_SetIgnOnDelay(IN USHORT usValue);
DLLAPI USHORT SUSI_IMC_VPM_GetIgnOnDelay(OUT PUSHORT pusValue);

DLLAPI USHORT SUSI_IMC_VPM_SetLBPLowDelay(IN USHORT usValue);
DLLAPI USHORT SUSI_IMC_VPM_GetLBPLowDelay(OUT PUSHORT pusValue);

DLLAPI USHORT SUSI_IMC_VPM_SetLBPLowHardDelay(IN USHORT usValue);
DLLAPI USHORT SUSI_IMC_VPM_GetLBPLowHardDelay(OUT PUSHORT pusValue);

DLLAPI USHORT SUSI_IMC_VPM_SetLBPThresholdFor12VSystem(IN FLOAT fVoltage);
DLLAPI USHORT SUSI_IMC_VPM_GetLBPThresholdFor12VSystem(OUT PFLOAT pfVoltage);

DLLAPI USHORT SUSI_IMC_VPM_SetLBPThresholdFor24VSystem(IN FLOAT fVoltage);
DLLAPI USHORT SUSI_IMC_VPM_GetLBPThresholdFor24VSystem(OUT PFLOAT pfVoltage);

DLLAPI USHORT SUSI_IMC_VPM_SetPrebootThresholdFor12VSystem(IN FLOAT fVoltage);
DLLAPI USHORT SUSI_IMC_VPM_GetPrebootThresholdFor12VSystem(OUT PFLOAT pfVoltage);

DLLAPI USHORT SUSI_IMC_VPM_SetPrebootThresholdFor24VSystem(IN FLOAT fVoltage);
DLLAPI USHORT SUSI_IMC_VPM_GetPrebootThresholdFor24VSystem(OUT PFLOAT pfVoltage);

DLLAPI USHORT SUSI_IMC_VPM_GetLBPThresholdInfo(IN CAR_BATTERY_MODE nCarBatteryMode, OUT PBATTERY_INFO pnBatteryInfo);

DLLAPI USHORT SUSI_IMC_VPM_GetIgnitionStatus(OUT PBOOL bIngON);
DLLAPI USHORT SUSI_IMC_VPM_GetCarBatteryVoltage(OUT PFLOAT pfVoltage);

DLLAPI USHORT SUSI_IMC_VPM_GetCurrentCarBatteryMode(PCAR_BATTERY_MODE pnCarBatterMode);
DLLAPI USHORT SUSI_IMC_VPM_SetCurrentCarBatteryMode(CAR_BATTERY_MODE nCarBatterMode);

DLLAPI USHORT SUSI_IMC_VPM_SetLBPStatus(IN BOOL bEnable);
DLLAPI USHORT SUSI_IMC_VPM_GetLBPStatus(OUT PBOOL pbEnable);

DLLAPI USHORT SUSI_IMC_VPM_SetPrebootLBPStatus(IN BOOL bEnable);
DLLAPI USHORT SUSI_IMC_VPM_GetPrebootLBPStatus(OUT PBOOL pbEnable);

DLLAPI USHORT SUSI_IMC_VPM_SetATMode(IN BOOL bEnable);
DLLAPI USHORT SUSI_IMC_VPM_GetATMode(OUT PBOOL pbEnable);

DLLAPI USHORT SUSI_IMC_VPM_SetKeepAliveMode(IN BOOL bEnable);
DLLAPI USHORT SUSI_IMC_VPM_GetKeepAliveMode(OUT PBOOL pbEnable);

DLLAPI USHORT SUSI_IMC_VPM_SetWakeupSourceControlStatus(IN WAKEUP_SOURCE wakeup_source, IN BOOL bEnable);
DLLAPI USHORT SUSI_IMC_VPM_GetWakeupSourceControlStatus(IN WAKEUP_SOURCE wakeup_source, OUT PBOOL pbEnable);
DLLAPI USHORT SUSI_IMC_VPM_GetLastWakeupSource(OUT PWAKEUP_SOURCE pWakeup_source);

DLLAPI USHORT SUSI_IMC_VPM_SetShutdownSourceControlStatus(IN SHUTDOWN_SOURCE shutdown_source, IN BOOL bEnable);
DLLAPI USHORT SUSI_IMC_VPM_GetShutdownSourceControlStatus(IN SHUTDOWN_SOURCE shutdown_source, OUT PBOOL pbEnable);

DLLAPI USHORT SUSI_IMC_VPM_LoadDefaultValue();

DLLAPI USHORT SUSI_IMC_VPM_ForceShutdown();

DLLAPI USHORT SUSI_IMC_VPM_SetRTCTime(IN VPM_RTC_TIME nRTC_time);
DLLAPI USHORT SUSI_IMC_VPM_GetRTCTime(OUT PVPM_RTC_TIME pnRTC_time);

DLLAPI USHORT SUSI_IMC_VPM_SetAlarmActive(IN BOOL bActive);
DLLAPI USHORT SUSI_IMC_VPM_GetAlarmActive(OUT PBOOL pbActive);
DLLAPI USHORT SUSI_IMC_VPM_SetAlarmTime(IN ALARM_MODE nAlarm_mode, IN VPM_ALARM_TIME nAlarm_time);
DLLAPI USHORT SUSI_IMC_VPM_GetAlarmTime(OUT PALARM_MODE pnAlarm_mode, OUT PVPM_ALARM_TIME pnAlarm_time);

DLLAPI USHORT SUSI_IMC_VPM_GetBackupBatteryVoltage(OUT PFLOAT pfVoltage);
DLLAPI USHORT SUSI_IMC_VPM_GetBackupBatteryRemainingCapacity(OUT PINT piValue);
DLLAPI USHORT SUSI_IMC_VPM_GetBackupBatteryPercentageOfCharge(OUT PINT piValue);
DLLAPI USHORT SUSI_IMC_VPM_GetBackupBatteryTemperture(OUT PFLOAT pfTemperture);
DLLAPI USHORT SUSI_IMC_VPM_GetBackupBatteryRemainingTime(OUT PINT piTime);
DLLAPI USHORT SUSI_IMC_VPM_GetBackupBatteryTimeToFull(OUT PINT piTime);

DLLAPI USHORT SUSI_IMC_VPM_GetBackupBatteryInfo(PBACKUP_BATTERY_INFO pnBackup_battery_info);

/////////////////////


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// function pointer

typedef USHORT (*PSUSI_IMC_VPM_Initialize)(IN BYTE port_number);
typedef USHORT (*PSUSI_IMC_VPM_Deinitialize)(void);

typedef USHORT (*PSUSI_IMC_VPM_GetFWVersion)(OUT PVPM_FIRMWARE_INFO pVersion);
typedef USHORT (*PSUSI_IMC_VPM_GetLibVersion)(OUT PBYTE pVersion);

typedef USHORT (*PSUSI_IMC_VPM_SetIgnitionMode)(IN IGNITION_MODE nMode);
typedef USHORT (*PSUSI_IMC_VPM_GetIgnitionMode)(OUT PIGNITION_MODE pnMode);

typedef USHORT (*PSUSI_IMC_VPM_SetIgnOffEventDelay)(IN USHORT usValue);
typedef USHORT (*PSUSI_IMC_VPM_GetIgnOffEventDelay)(OUT PUSHORT pusValue);

typedef USHORT (*PSUSI_IMC_VPM_SetIgnHardOffDelay)(IN USHORT usValue);
typedef USHORT (*PSUSI_IMC_VPM_GetIgnHardOffDelay)(OUT PUSHORT pusValue);

typedef USHORT (*PSUSI_IMC_VPM_SetIgnSuspendHardOffDelay)(IN USHORT usValue); 
typedef USHORT (*PSUSI_IMC_VPM_GetIgnSuspendHardOffDelay)(OUT PUSHORT pusValue);

typedef USHORT (*PSUSI_IMC_VPM_SetForceShutDownDelay)(IN USHORT usValue);
typedef USHORT (*PSUSI_IMC_VPM_GetForceShutDownDelay)(OUT PUSHORT pusValue);

typedef USHORT (*PSUSI_IMC_VPM_SetPrePowerOffAlarmDelay)(IN USHORT usValue);
typedef USHORT (*PSUSI_IMC_VPM_GetPrePowerOffAlarmDelay)(OUT PUSHORT pusValue);

typedef USHORT (*PSUSI_IMC_VPM_SetPrePowerOffAlarm)(IN BOOL bEnable);
typedef USHORT (*PSUSI_IMC_VPM_GetPrePowerOffAlarm)(OUT PBOOL pbEnable);

typedef USHORT (*PSUSI_IMC_VPM_SetIgnPowerOffEvent) ( void* hEvent );
typedef USHORT (*PSUSI_IMC_VPM_SetLBPPowerOffEvent) ( void* hEvent );

typedef USHORT (*PSUSI_IMC_VPM_SetIgnOnDelay)(IN USHORT usValue);
typedef USHORT (*PSUSI_IMC_VPM_GetIgnOnDelay)(OUT PUSHORT pusValue);

typedef USHORT (*PSUSI_IMC_VPM_SetLBPLowDelay)(IN USHORT usValue);
typedef USHORT (*PSUSI_IMC_VPM_GetLBPLowDelay)(OUT PUSHORT pusValue);

typedef USHORT (*PSUSI_IMC_VPM_SetLBPLowHardDelay)(IN USHORT usValue);
typedef USHORT (*PSUSI_IMC_VPM_GetLBPLowHardDelay)(OUT PUSHORT pusValue);

typedef USHORT (*PSUSI_IMC_VPM_SetLBPThresholdFor12VSystem)(IN FLOAT fVoltage);
typedef USHORT (*PSUSI_IMC_VPM_GetLBPThresholdFor12VSystem)(OUT PFLOAT pfVoltage);

typedef USHORT (*PSUSI_IMC_VPM_SetLBPThresholdFor24VSystem)(IN FLOAT fVoltage);
typedef USHORT (*PSUSI_IMC_VPM_GetLBPThresholdFor24VSystem)(OUT PFLOAT pfVoltage);

typedef USHORT (*PSUSI_IMC_VPM_SetPrebootThresholdFor12VSystem)(IN FLOAT fVoltage);
typedef USHORT (*PSUSI_IMC_VPM_GetPrebootThresholdFor12VSystem)(OUT PFLOAT pfVoltage);

typedef USHORT (*PSUSI_IMC_VPM_SetPrebootThresholdFor24VSystem)(IN FLOAT fVoltage);
typedef USHORT (*PSUSI_IMC_VPM_GetPrebootThresholdFor24VSystem)(OUT PFLOAT pfVoltage);

typedef USHORT (*PSUSI_IMC_VPM_GetLBPThresholdInfo)(IN CAR_BATTERY_MODE nCarBatteryMode, OUT PBATTERY_INFO pnBatteryInfo);

typedef USHORT (*PSUSI_IMC_VPM_GetIgnitionStatus)(OUT PBOOL bIngON);
typedef USHORT (*PSUSI_IMC_VPM_GetCarBatteryVoltage)(OUT PFLOAT pfVoltage);

typedef USHORT (*PSUSI_IMC_VPM_GetCurrentCarBatteryMode)(PCAR_BATTERY_MODE pnCarBatterMode);

typedef USHORT (*PSUSI_IMC_VPM_SetLBPStatus)(IN BOOL bEnable);
typedef USHORT (*PSUSI_IMC_VPM_GetLBPStatus)(OUT PBOOL pbEnable);

typedef USHORT (*PSUSI_IMC_VPM_SetATMode)(IN BOOL bEnable);
typedef USHORT (*PSUSI_IMC_VPM_GetATMode)(OUT PBOOL pbEnable);

typedef USHORT (*PSUSI_IMC_VPM_SetKeepAliveMode)(IN BOOL bEnable);
typedef USHORT (*PSUSI_IMC_VPM_GetKeepAliveMode)(OUT PBOOL pbEnable);

typedef USHORT (*PSUSI_IMC_VPM_LoadDefaultValue)();

typedef USHORT (*PSUSI_IMC_VPM_SetAlarmActive)(IN BOOL bActive);
typedef USHORT (*PSUSI_IMC_VPM_GetAlarmActive)(OUT PBOOL pbActive);
typedef USHORT (*PSUSI_IMC_VPM_SetAlarmTime)(IN ALARM_MODE nAlarm_mode, IN VPM_ALARM_TIME nAlarm_time);
typedef USHORT (*PSUSI_IMC_VPM_GetAlarmTime)(OUT PALARM_MODE pnAlarm_mode, OUT PVPM_ALARM_TIME pnAlarm_time);

typedef USHORT (*PSUSI_IMC_VPM_GetBackupBatteryVoltage)(OUT PFLOAT pfVoltage);
typedef USHORT (*PSUSI_IMC_VPM_GetBackupBatteryRemainingCapacity)(OUT PINT piValue);
typedef USHORT (*PSUSI_IMC_VPM_GetBackupBatteryPercentageOfCharge)(OUT PINT piValue);
typedef USHORT (*PSUSI_IMC_VPM_GetBackupBatteryTemperture)(OUT PFLOAT pfTemperture);
typedef USHORT (*PSUSI_IMC_VPM_GetBackupBatteryRemainingTime)(OUT PINT piTime);
typedef USHORT (*PSUSI_IMC_VPM_GetBackupBatteryTimeToFull)(OUT PINT piTime);

typedef USHORT (*PSUSI_IMC_VPM_GetBackupBatteryInfo)(PBACKUP_BATTERY_INFO pnBackup_battery_info);
#endif