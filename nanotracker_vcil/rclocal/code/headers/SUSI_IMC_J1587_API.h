#ifndef _SUSI_IMC_J1587_API_H
#define _SUSI_IMC_J1587_API_H

DLLAPI USHORT SUSI_IMC_J1587_Read( OUT PIMC_J1587_MSG_OBJECT object );
DLLAPI USHORT SUSI_IMC_J1587_Write( IN PIMC_J1587_MSG_OBJECT object );
DLLAPI USHORT SUSI_IMC_J1587_SetEvent( void* hEvent );
DLLAPI USHORT SUSI_IMC_J1587_AddMessageFilter( IN UINT pid );
DLLAPI USHORT SUSI_IMC_J1587_GetMessageFilter( OUT UINT *total, OUT UINT* pid );
DLLAPI USHORT SUSI_IMC_J1587_RemoveMessageFilter( IN UINT pid );
DLLAPI USHORT SUSI_IMC_J1587_RemoveAllMessageFilter ( void );

#endif