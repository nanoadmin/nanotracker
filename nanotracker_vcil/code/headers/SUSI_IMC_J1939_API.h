#ifndef _SUSI_IMC_J1939_API_H
#define _SUSI_IMC_J1939_API_H

#include "SUSI_IMC_Types.h"

DLLAPI USHORT SUSI_IMC_J1939_Read ( OUT PIMC_J1939_MSG_OBJECT object );
DLLAPI USHORT SUSI_IMC_J1939_Write ( IN PIMC_J1939_MSG_OBJECT object );
DLLAPI USHORT SUSI_IMC_J1939_SetEvent( void* hEvent );
DLLAPI USHORT SUSI_IMC_J1939_AddMessageFilter(IN BYTE channel_number, UINT pgn );
DLLAPI USHORT SUSI_IMC_J1939_GetMessageFilter(IN BYTE channel_number, OUT UINT* total, UINT* pgn );
DLLAPI USHORT SUSI_IMC_J1939_RemoveMessageFilter(IN BYTE channel_number, UINT pgn );
DLLAPI USHORT SUSI_IMC_J1939_RemoveAllMessageFilter ( IN BYTE channel_number );
DLLAPI USHORT SUSI_IMC_J1939_SetTransmitConfig(IN IMC_J1939_TRANSMIT_CONFIG transmit_config);
DLLAPI USHORT SUSI_IMC_J1939_GetTransmitConfig(OUT PIMC_J1939_TRANSMIT_CONFIG ptransmit_config);

#endif