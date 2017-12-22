#ifndef _SUSI_IMC_OBD2_API_H
#define _SUSI_IMC_OBD2_API_H


/*deprecated! replace SUSI_IMC_OBD2_Read with SUSI_IMC_OBD2_ReadEx */
DLLAPI USHORT SUSI_IMC_OBD2_Read( OUT PIMC_OBD2_MSG_OBJECT object ); 

/*deprecated! replace SUSI_IMC_OBD2_Write with SUSI_IMC_OBD2_WriteEx */
DLLAPI USHORT SUSI_IMC_OBD2_Write( IN PIMC_OBD2_MSG_OBJECT object );

DLLAPI USHORT SUSI_IMC_OBD2_SetEvent( void* hEvent );
DLLAPI USHORT SUSI_IMC_OBD2_AddMessageFilter(IN BYTE channel_number, UINT pid );
DLLAPI USHORT SUSI_IMC_OBD2_GetMessageFilter(OUT UINT channel_number, UINT* total, UINT* pid );
DLLAPI USHORT SUSI_IMC_OBD2_RemoveMessageFilter( IN BYTE channel_number, IN UINT pid );
DLLAPI USHORT SUSI_IMC_OBD2_RemoveAllMessageFilter ( IN BYTE channel_number );
DLLAPI USHORT SUSI_IMC_OBD2_ReadEx( OUT PIMC_OBD2_MSG_EX_OBJECT object );
DLLAPI USHORT SUSI_IMC_OBD2_WriteEx( IN PIMC_OBD2_MSG_EX_OBJECT object );

#endif