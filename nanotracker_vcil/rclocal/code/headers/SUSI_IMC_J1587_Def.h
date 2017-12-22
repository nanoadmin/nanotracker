#ifndef _SUSI_IMC_J1587_DEF_H
#define _SUSI_IMC_J1587_DEF_H

#define	MAX_J1587_MESSAGE_BUFFER_SIZE			20

typedef struct
{
	UINT mid;
	UINT pid;
	BYTE pri;     								
	BYTE buf[MAX_J1587_MESSAGE_BUFFER_SIZE];
	BYTE buf_len;
} IMC_J1587_MSG_OBJECT, *PIMC_J1587_MSG_OBJECT;

#endif