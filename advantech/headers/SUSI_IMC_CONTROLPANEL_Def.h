
#ifndef _SUSI_CONTROLPANEL_DEF_H
#define _SUSI_CONTROLPANEL_DEF_H

#include "SUSI_IMC_Types.h"

#define	SUSI_RESET_INTO_NORMAL_MODE				0
#define	SUSI_RESET_INTO_BOOT_LOADER_MODE		1
#define SUSI_COM1								1

typedef struct
{
	BYTE version[3];
	BYTE model_name[20];

} IMC_CONTROLPANEL_FIRMWARE_INFO, *PIMC_CONTROLPANEL_FIRMWARE_INFO;

#endif