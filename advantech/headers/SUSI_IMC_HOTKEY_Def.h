
#ifndef _SUSI_HOTKEY_DEF_H
#define _SUSI_HOTKEY_DEF_H

#include "SUSI_IMC_Types.h"

#define SUSI_HOTKEY_BUFFER_SIZE			7

typedef struct
{
	BYTE buf[SUSI_HOTKEY_BUFFER_SIZE];	/* data buffer of hotkey */

} IMC_HOTKEY_MSG_OBJECT, *PIMC_HOTKEY_MSG_OBJECT;

typedef void ( _stdcall *HOTKEY_OnPressAndRelease_Funptr ) ( OUT PIMC_HOTKEY_MSG_OBJECT object );

#endif