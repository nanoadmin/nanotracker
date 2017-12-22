
#ifndef _SUSI_BRIGHTNESS_DEF_H
#define _SUSI_BRIGHTNESS_DEF_H

#include "SUSI_IMC_Types.h"

#define SUSI_BRIGHTNESS_NON_CHANGE				31

typedef struct
{
	BYTE maximum;
	BYTE minimum;
	BYTE current;

} IMC_BRIGHTNESS_LEVEL, *PIMC_BRIGHTNESS_LEVEL;

#endif