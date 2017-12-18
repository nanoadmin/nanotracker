#ifndef SUSI_IMC_VCIL_API_H
#define SUSI_IMC_VCIL_API_H

DLLAPI USHORT SUSI_IMC_VCIL_Initialize ( IN char* port );
DLLAPI USHORT SUSI_IMC_VCIL_InitializeEx ( char* can_port, int baudrate );
DLLAPI USHORT SUSI_IMC_VCIL_Deinitialize ( void );
DLLAPI USHORT SUSI_IMC_VCIL_GetLibVersion ( OUT BYTE version[18] );
DLLAPI USHORT SUSI_IMC_VCIL_GetFWVersion ( OUT PBYTE version );
DLLAPI USHORT SUSI_IMC_VCIL_ResetModule ( void );
DLLAPI USHORT SUSI_IMC_VCIL_ModuleControl ( IN VCIL_CAN_CHANNEL_MODE can_channel_1, VCIL_CAN_CHANNEL_MODE can_channel_2, VCIL_J1708_CHANNEL_MODE j1708_channel );

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// function pointer
typedef USHORT (*PSUSI_IMC_VCIL_Initialize)(IN char* can_port);
typedef USHORT (*PSUSI_IMC_VCIL_InitializeEx)( char* can_port, int baudrate );
typedef USHORT (*PSUSI_IMC_VCIL_Deinitialize)( void );
typedef USHORT (*PSUSI_IMC_VCIL_GetLibVersion) ( OUT BYTE version[18] );
typedef USHORT (*PSUSI_IMC_VCIL_GetFWVersion) ( OUT PBYTE version );
typedef USHORT (*PSUSI_IMC_VCIL_ResetModule) ( void );
typedef USHORT (*PSUSI_IMC_VCIL_ModuleControl) ( IN VCIL_CAN_CHANNEL_MODE can_channel_1, VCIL_CAN_CHANNEL_MODE can_channel_2, VCIL_J1708_CHANNEL_MODE j1708_channel );
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#endif
