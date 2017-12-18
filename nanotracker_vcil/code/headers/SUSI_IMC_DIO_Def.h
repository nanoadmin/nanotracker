#ifndef SUSI_IMC_DIO_DEF_H
#define SUSI_IMC_DIO_DEF_H

#include "SUSI_IMC_Types.h"

struct PIN_STATUS
{
	BOOL bPin0;		//	It used for input/output pin0 of TREK-674
	BOOL bPin1;		//	It used for input/output pin1 of TREK-674
	BOOL bPin2;		//	It used for input pin2 of TREK-674
	BOOL bPin3;		//	It used for input pin3 of TREK-674
};
typedef PIN_STATUS* PPIN_STATUS;

#define IMC_DIO_VOICE_SOURCE_BLUETOOTH   0
#define IMC_DIO_VOICE_SOURCE_MIC_IN      1

#define IMC_DIO_VOICE_MODULE_MX809X      0
#define IMC_DIO_VOICE_MODULE_MX73X4      1

#endif