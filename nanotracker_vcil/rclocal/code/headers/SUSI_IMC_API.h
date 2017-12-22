
#ifndef _SUSI_IMC_API_H
#define _SUSI_IMC_API_H

#ifndef DLLAPI
#if defined (WIN32) || defined (WINCE)
#ifdef IMC_EXPORTS
#define DLLAPI __declspec( dllexport )
#else
#define DLLAPI __declspec( dllimport )
#endif
	#elif defined (__linux__) || defined (ANDROID)
#define DLLAPI __attribute__ ((visibility ("default")))
#else
#error:Unknown OS
#endif
#endif

#ifdef __cplusplus
extern "C"
{
#endif

#include "SUSI_IMC_VCIL_API.h"
#include "SUSI_IMC_CAN_API.h"
#include "SUSI_IMC_J1939_API.h"
#include "SUSI_IMC_J1708_API.h"
#include "SUSI_IMC_J1587_API.h"
#include "SUSI_IMC_OBD2_API.h"
#include "SUSI_IMC_CORE_FUNCTION_API.h"
#include "SUSI_IMC_DIO_API.h"
#include "SUSI_IMC_DISPLAY_API.h"
#include "SUSI_IMC_GSENSOR_API.h"
#include "SUSI_IMC_IIC_API.h"
#include "SUSI_IMC_EEPROM_API.h"
#include "SUSI_IMC_LIGHTSENSOR_API.h"
#include "SUSI_IMC_PERIPHERALCTRL_API.h"
#include "SUSI_IMC_VPM_API.h"
#include "SUSI_IMC_WATCH_DOG_API.h"
#include "SUSI_IMC_CONTROLPANEL_API.h"
#include "SUSI_IMC_BRIGHTNESS_API.h"
#include "SUSI_IMC_HOTKEY_API.h"
#include "SUSI_IMC_TEMPERATURE_SENSOR_API.h"

#ifdef __cplusplus
}
#endif

#endif
