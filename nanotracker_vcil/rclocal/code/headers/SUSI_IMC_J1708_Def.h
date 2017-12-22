#ifndef _SUSI_IMC_J1708_DEF_H
#define _SUSI_IMC_J1708_DEF_H

#define	MAX_J1708_MESSAGE_BUFFER_SIZE			20

typedef struct
{
	UINT mid;
	UINT pid;
	BYTE pri;     								
	BYTE buf[MAX_J1708_MESSAGE_BUFFER_SIZE];
	BYTE buf_len;
} IMC_J1708_MSG_OBJECT, *PIMC_J1708_MSG_OBJECT;

#endif