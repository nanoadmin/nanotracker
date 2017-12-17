
#ifndef _SUSI_IMC_CAN_DEF_H
#define _SUSI_IMC_CAN_DEF_H

#include "SUSI_IMC_Types.h"

#define IMC_CAN_STATUS_RX_OK					1
#define IMC_CAN_STATUS_RX_NOT_OK				0
#define IMC_CAN_STATUS_TX_EMPTY					0
#define IMC_CAN_STATUS_TX_NOT_EMPTY				1

enum CAN_SPEED
{
	CAN_SPEED_125K = 0,
    CAN_SPEED_250K = 1,
    CAN_SPEED_500K = 2,
    CAN_SPEED_1M   = 3,
    CAN_SPEED_200K = 4,
	CAN_SPEED_100K = 5,
	CAN_SPEED_INIT = 0xFE,
	CAN_SPEED_USER_DEFINE = 0xFF
};

enum CAN_BUS_MODE
{
	CAN_BUS_MODE_NORMAL = 0,
    CAN_BUS_MODE_SILENCE = 1,
    CAN_BUS_MODE_INIT = 2
};

enum CAN_MESSAGE_TYPE
{
	CAN_MESSAGE_STANDARD = 0x01, //CAN 2.0a
	CAN_MESSAGE_EXTENDED = 0x02, //CAN 2.0b
	CAN_MESSAGE_RTR      = 0x04,
	CAN_MESSAGE_STATUS   = 0x08
};

typedef struct
{
	int can_bus_number;
	ULONG id;
	CAN_MESSAGE_TYPE message_type;
	BYTE buf[8];
	BYTE buf_len;
} IMC_CAN_MSG_OBJECT, *PIMC_CAN_MSG_OBJECT;

typedef struct
{
	int can_bus_number;
	int mask_number;
	CAN_MESSAGE_TYPE message_type;
	ULONG id;
	ULONG mask;	
} IMC_CAN_MASK_OBJECT, *PIMC_CAN_MASK_OBJECT;

typedef struct
{
	int rec; // receive error counter
	int tec; // transmit error counter
	int last_error_code; // last error code
	int error_flag;
} IMC_CAN_ERROR_STATUS_OBJECT, *PIMC_CAN_ERROR_STATUS_OBJECT;

#endif
