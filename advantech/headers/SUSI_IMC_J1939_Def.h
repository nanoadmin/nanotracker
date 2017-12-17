
#ifndef _ADV_J1939_DEF_H
#define _ADV_J1939_DEF_H

#include "SUSI_IMC_Types.h"

#define	MAX_J1939_MESSAGE_BUFFER_SIZE			64
#define	J1939_TRANSMIT_CONFIG_NAME_LEN          8

typedef struct
{
	BYTE channel_number;
	UINT pgn;     								/* parameter group number. */
	BYTE dst;      								/* destination of message. */
	BYTE src;      								/* source of message. */
	BYTE pri;      								/* priority of message. */
	BYTE buf[MAX_J1939_MESSAGE_BUFFER_SIZE];	/* data buffer. */
	USHORT buf_len;								/* size of data. */

} IMC_J1939_MSG_OBJECT, *PIMC_J1939_MSG_OBJECT;

typedef struct
{
	BYTE channel_number;
    BYTE source_address;
    BYTE source_name[J1939_TRANSMIT_CONFIG_NAME_LEN];

} IMC_J1939_TRANSMIT_CONFIG, *PIMC_J1939_TRANSMIT_CONFIG;

#endif