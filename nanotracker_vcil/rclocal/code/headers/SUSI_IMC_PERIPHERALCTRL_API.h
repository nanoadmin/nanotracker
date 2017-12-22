#ifndef SUSI_IMC_PERIPHERALCTRL_API_H
#define SUSI_IMC_PERIPHERALCTRL_API_H

#include "SUSI_IMC_Types.h"

DLLAPI USHORT SUSI_IMC_PERIPHERALCTRL_Initialize();
DLLAPI USHORT SUSI_IMC_PERIPHERALCTRL_Deinitialize();
DLLAPI USHORT SUSI_IMC_PERIPHERALCTRL_GetLibVersion( OUT BYTE version[18] );
DLLAPI USHORT SUSI_IMC_PERIPHERALCTRL_SetPeripheralControl(IN PERIPHERAL_TYPE nType, IN BOOL bEnable);
DLLAPI USHORT SUSI_IMC_PERIPHERALCTRL_GetPeripheralControl(IN PERIPHERAL_TYPE nType, OUT PBOOL pbEnable);
DLLAPI USHORT SUSI_IMC_PERIPHERALCTRL_SetRearViewSource (IN BYTE source);
DLLAPI USHORT SUSI_IMC_PERIPHERALCTRL_GetRearViewSource (OUT PBYTE source);
DLLAPI USHORT SUSI_IMC_PERIPHERALCTRL_SetAutoRearView (IN BOOL bEnable);
DLLAPI USHORT SUSI_IMC_PERIPHERALCTRL_GetAutoRearView (OUT PBOOL bEnable);

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// function pointer
typedef USHORT (*PSUSI_IMC_PERIPHERALCTRL_Initialize)();
typedef USHORT (*PSUSI_IMC_PERIPHERALCTRL_Deinitialize)();
typedef USHORT (*PSUSI_IMC_PERIPHERALCTRL_GetLibVersion)(OUT PBYTE pVersion);
typedef USHORT (*PSUSI_IMC_PERIPHERALCTRL_SetPeripheralControl)(IN PERIPHERAL_TYPE nType, IN BOOL bEnable);
typedef USHORT (*PSUSI_IMC_PERIPHERALCTRL_GetPeripheralControl)(IN PERIPHERAL_TYPE nType, OUT PBOOL pbEnable);
typedef USHORT (*PSUSI_IMC_PERIPHERALCTRL_SetRearViewSource) (IN BYTE source);
typedef USHORT (*PSUSI_IMC_PERIPHERALCTRL_GetRearViewSource) (OUT PBYTE source);
typedef USHORT (*PSUSI_IMC_PERIPHERALCTRL_SetAutoRearView) (IN BOOL bEnable);
typedef USHORT (*PSUSI_IMC_PERIPHERALCTRL_GetAutoRearView) (OUT PBOOL bEnable);
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#endif