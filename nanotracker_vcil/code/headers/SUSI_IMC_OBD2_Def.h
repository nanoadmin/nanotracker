#ifndef _SUSI_IMC_OBD2_DEF_H
#define _SUSI_IMC_OBD2_DEF_H

#ifndef MAX_OBD2_MESSAGE_BUFFER_SIZE
#define	MAX_OBD2_MESSAGE_BUFFER_SIZE 64
#endif

/* Deprecated! only for 15765-4 29-bits message */
typedef struct
{
    BYTE channel_number;
    BYTE dst;              /* destination address */
    BYTE src;              /* source address */
    BYTE pri;              /* priority */
    BYTE tat;              /* target address type */
    BYTE buf[MAX_OBD2_MESSAGE_BUFFER_SIZE];
    USHORT buf_len;
} IMC_OBD2_MSG_OBJECT, *PIMC_OBD2_MSG_OBJECT;

typedef struct
{
    BYTE channel_number;
	BYTE type;              /* 0: 11-bits or  1:  29 bits */
    DWORD id;               /* OBD2 15765-4 CAN ID */
	USHORT buf_len;
    BYTE buf[MAX_OBD2_MESSAGE_BUFFER_SIZE];    
} IMC_OBD2_MSG_EX_OBJECT, *PIMC_OBD2_MSG_EX_OBJECT;

#endif