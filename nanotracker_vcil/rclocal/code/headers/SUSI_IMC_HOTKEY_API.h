
#ifndef _SUSI_IMC_HOTKEY_API_H
#define _SUSI_IMC_HOTKEY_API_H

#include "SUSI_IMC_Types.h"

DLLAPI USHORT SUSI_IMC_HOTKEY_Read ( OUT PIMC_HOTKEY_MSG_OBJECT object );
DLLAPI USHORT SUSI_IMC_HOTKEY_RegisterOnPressAndReleaseEventMonitor ( IN HOTKEY_OnPressAndRelease_Funptr fptr );
DLLAPI USHORT SUSI_IMC_HOTKEY_ClearOnPressEventMonitor ( void );
DLLAPI USHORT SUSI_IMC_HOTKEY_EnableEventMonitor ( void );
DLLAPI USHORT SUSI_IMC_HOTKEY_DisableEventMonitor ( void );
DLLAPI USHORT SUSI_IMC_HOTKEY_SetLedDutyCycle ( IN BYTE duty_cycle );
DLLAPI USHORT SUSI_IMC_HOTKEY_GetLedDutyCycle ( OUT PBYTE duty_cycle );
DLLAPI USHORT SUSI_IMC_HOTKEY_SetGPIO ( IN BYTE port, IN BYTE number, IN BYTE data );

#endif