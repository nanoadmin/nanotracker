
#ifndef _SUSI_IMC_DEF_H
#define _SUSI_IMC_DEF_H

#ifndef IN
#define IN
#endif

#ifndef OUT
#define OUT
#endif

/*
	 1 1 1 1 1 1
	 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0
	+------------------------------+
	|   S    |   F   |      C      |
	+------------------------------+

	Sev(S) - It's severity code
		00 - Success
		01 - Informational
		10 - Warning
		11 - Error

	Facility(F) - The facility code
	Code(C) - The facility's status code
*/

//	Common error code definition
#define IMC_ERR_NO_ERROR                0xC000
#define IMC_ERR_INVALID_POINTER         0xC001
#define IMC_ERR_INVALID_ARGUMENT        0xC002
#define IMC_ERR_UNSUPPORT               0xC003
#define IMC_ERR_OUT_OF_MEMORY           0xC004
#define IMC_ERR_SDK_NOT_INIT            0xC005
#define IMC_ERR_OBJ_INIT_FAILED         0xC006
#define IMC_ERR_INVALID_SIZE            0xC007
#define IMC_ERR_TIMEOUT                 0xC008
#define IMC_ERR_FILE_OPEN               0xC009
#define IMC_ERR_OPERATION_FAILED        0xC00A
#define IMC_ERR_DRIVER_OPEN             0xC00B
#define IMC_ERR_UNKNOWN                 0xC00C
#define IMC_ERR_SUSI_API                0xC00D
#define IMC_ERR_FW_VERSION_TOO_OLD      0xC00E
#define IMC_ERR_INITIALIZED             0xC00F

#include "SUSI_IMC_CAN_Def.h"
#include "SUSI_IMC_J1939_Def.h"
#include "SUSI_IMC_J1587_Def.h"
#include "SUSI_IMC_J1708_Def.h"
#include "SUSI_IMC_OBD2_Def.h"
#include "SUSI_IMC_CORE_FUNCTION_Def.h"
#include "SUSI_IMC_DIO_Def.h"
#include "SUSI_IMC_DISPLAY_Def.h"
#include "SUSI_IMC_GSENSOR_Def.h"
#include "SUSI_IMC_IIC_Def.h"
#include "SUSI_IMC_EEPROM_Def.h"
#include "SUSI_IMC_PERIPHERALCTRL_Def.h"
#include "SUSI_IMC_VCIL_Def.h"
#include "SUSI_IMC_VPM_Def.h"
#include "SUSI_IMC_WATCH_DOG_Def.h"
#include "SUSI_IMC_CONTROLPANEL_Def.h"
#include "SUSI_IMC_BRIGHTNESS_Def.h"
#include "SUSI_IMC_HOTKEY_Def.h"

#endif