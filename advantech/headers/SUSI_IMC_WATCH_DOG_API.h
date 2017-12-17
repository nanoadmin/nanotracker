#ifndef _SUSI_IMC_WATCH_DOG_API_H
#define _SUSI_IMC_WATCH_DOG_API_H

#include "SUSI_IMC_Types.h"

DLLAPI USHORT SUSI_IMC_WD_Initialize(IN BYTE port_number);
DLLAPI USHORT SUSI_IMC_WD_Deinitialize();
DLLAPI USHORT SUSI_IMC_WD_Trigger(void);
DLLAPI USHORT SUSI_IMC_WD_Enabled(bool bActive);
DLLAPI USHORT SUSI_IMC_WD_GetTime(unsigned short* Time);
DLLAPI USHORT SUSI_IMC_WD_SetTime(unsigned short Time);
DLLAPI USHORT SUSI_IMC_WD_GetRange(DWORD *minimum, DWORD *maximum);
DLLAPI USHORT SUSI_IMC_WD_GetLibVersion( OUT BYTE version[18] );

#endif