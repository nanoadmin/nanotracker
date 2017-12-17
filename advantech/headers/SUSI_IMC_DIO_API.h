#ifndef _SUSI_IMC_DIO_API_H
#define _SUSI_IMC_DIO_API_H

#include "SUSI_IMC_Types.h"

DLLAPI USHORT SUSI_IMC_DIO_GetLibVersion( OUT BYTE version[18] );
DLLAPI USHORT SUSI_IMC_DIO_Initialize();
DLLAPI USHORT SUSI_IMC_DIO_Deinitialize();
DLLAPI USHORT SUSI_IMC_DIO_ReadDIPin(PIN_STATUS& PinStatus);
DLLAPI USHORT SUSI_IMC_DIO_WriteDOPin(const PIN_STATUS& PinStatus);
DLLAPI USHORT SUSI_IMC_DIO_GetVoiceSourceControlPin (OUT PINT PinStatus);
DLLAPI USHORT SUSI_IMC_DIO_SetVoiceSourceControlPin (IN INT PinStatus);
DLLAPI USHORT SUSI_IMC_DIO_GetBluetoothEnablePin (OUT PINT PinStatus);
DLLAPI USHORT SUSI_IMC_DIO_SetBluetoothEnablePin (IN INT PinStatus);
DLLAPI USHORT SUSI_IMC_DIO_GetVoiceModuleSelectPin (OUT PINT PinStatus);
DLLAPI USHORT SUSI_IMC_DIO_SetVoiceModuleSelectPin (IN INT PinStatus);

#endif