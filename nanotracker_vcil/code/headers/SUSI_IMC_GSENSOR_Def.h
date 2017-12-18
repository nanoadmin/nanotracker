#ifndef _SUSI_GSENSOR_DEF_H
#define _SUSI_GSENSOR_DEF_H

#include "SUSI_IMC_Types.h"

typedef struct
{
	int x_mg;		
	int y_mg;		
	int z_mg;
} IMC_GSENSOR_DATA, *PIMC_GSENSOR_DATA;

enum IMC_GSENSOR_RES
{
   IMC_GSENSOR_RES_2G = 0,
   IMC_GSENSOR_RES_4G,
   IMC_GSENSOR_RES_8G,
   IMC_GSENSOR_RES_16G
};

#endif