#include <stdio.h>
#include <stdlib.h>
#include <string.h>
//#include <susi.h>
#include "SUSI_IMC.h"

//#define CALLBACK_MODE

void HotKeyCallback(PIMC_HOTKEY_MSG_OBJECT pMsgObj);

int main()
{
   const int nLibVersionSize = 17;
   const int nModelNameSize = 20;

   int i;
   BYTE byPortNo = 1;
   USHORT usRes = IMC_ERR_NO_ERROR;
   BYTE byDutyCycle;
   IMC_BRIGHTNESS_LEVEL BrightnessLevel;
   WORD wLightValue;

   PIMC_CONTROLPANEL_FIRMWARE_INFO pControPanelFirmwareInfo = new IMC_CONTROLPANEL_FIRMWARE_INFO();
   BYTE* pLibVersion = new BYTE[nLibVersionSize];

   printf("\n\n");

// Initialization
   usRes = SUSI_IMC_CONTROLPANEL_Initialize(byPortNo);
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_CONTROLPANEL_Initialize() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }
// Get Library Version
   usRes = SUSI_IMC_CONTROLPANEL_GetVersion(pLibVersion);
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_CONTROLPANEL_GetVersion() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }
   printf("Library Version : ");
   for(i = 0 ; i < nLibVersionSize ; i++)
   {
      putchar(pLibVersion[i]);
   }
   printf("\n");

// Get Firmware Version
   usRes = SUSI_IMC_CONTROLPANEL_GetFirmwareInformation(pControPanelFirmwareInfo);
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_CONTROLPANEL_GetFirmwareInformation() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }
   printf("Firmware Version : %d.%d.%d\n", 
      pControPanelFirmwareInfo->version[0], 
      pControPanelFirmwareInfo->version[1], 
      pControPanelFirmwareInfo->version[2]
      );
   printf("Model Name : ");
   for(i = 0 ; i < nModelNameSize ; i++)
   {
      if(pControPanelFirmwareInfo->model_name[i] == '\0')
         break;
      putchar(pControPanelFirmwareInfo->model_name[i]);
   }
   printf("\n");

// Get Brightness Level
   memset(&BrightnessLevel, 0, sizeof(BrightnessLevel));
   usRes = SUSI_IMC_BRIGHTNESS_GetLevel(&BrightnessLevel);
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_BRIGHTNESS_GetLevel() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }

// Set Brightness Level
   usRes = SUSI_IMC_BRIGHTNESS_SetLevel(&BrightnessLevel);
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_BRIGHTNESS_GetLevel() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }
   printf("Bright Level => Min : %d, Max : %d, Cur : %d\n", 
      BrightnessLevel.minimum, 
      BrightnessLevel.maximum, 
      BrightnessLevel.current
      );
   printf("\n");

// Get Brightness Duty Cycle
   usRes = SUSI_IMC_BRIGHTNESS_GetDutyCycle(1, &byDutyCycle);
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_BRIGHTNESS_GetDutyCycle() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }
   printf("Brightness Duty Cycle : %d\n", byDutyCycle);

// Set Brightness Duty Cycle
   usRes = SUSI_IMC_BRIGHTNESS_SetDutyCycle(1, byDutyCycle);
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_BRIGHTNESS_SetDutyCycle() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }
   printf("Set Brightness Duty Cycle...... SUCCESS !\n");
   printf("\n");

// Get LED Brightness Duty Cycle
   usRes = SUSI_IMC_HOTKEY_GetLedDutyCycle(&byDutyCycle);
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_BRIGHTNESS_GetLedDutyCycle() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }
   printf("LED Brightness Duty Cycle : %d\n", byDutyCycle);

// Set LED Brightness Duty Cycle
   usRes = SUSI_IMC_HOTKEY_SetLedDutyCycle(byDutyCycle);
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_BRIGHTNESS_SetLedDutyCycle() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }
   printf("Set LED Brightness Duty Cycle...... SUCCESS !\n");
   printf("\n");

// Get Light Sensor Value
   usRes = SUSI_IMC_LIGHTSENSOR_GetStatus(&wLightValue);
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_LIGHTSENSOR_GetStatus() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }
   printf( "Light Value : %d\n", wLightValue);
   printf("\n");


	float temp_val;
   usRes =    SUSI_IMC_CONTROLPANEL_TEMPERATURE_GetValue(&temp_val);
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_CONTROLPANEL_TEMPERATURE_GetValue() fails. Error Code : 0x%x\n", usRes);
      //exit(EXIT_FAILURE);
   }
   printf( "Temp Value : %f\n", temp_val);
   printf("\n");
      


   printf("Start to test hot key......\n");

// Register the callback function of hot key
   usRes = SUSI_IMC_HOTKEY_RegisterOnPressAndReleaseEventMonitor(HotKeyCallback);
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_HOTKEY_RegisterOnPressAndReleaseEventMonitor() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }
// Enable the hot key callback function
   usRes = SUSI_IMC_HOTKEY_EnableEventMonitor();
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_HOTKEY_EnableEventMonitor() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }

// Press any key to terminate the demo...
   getchar();

// Disable the hot key callback function
   usRes = SUSI_IMC_HOTKEY_DisableEventMonitor();
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_HOTKEY_DisableEventMonitor() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }   

// Rlease the library.
   usRes = SUSI_IMC_CONTROLPANEL_Deinitialize();
   if(usRes != IMC_ERR_NO_ERROR)
   {
      fprintf(stderr, "SUSI_IMC_CONTROLPANEL_Deinitialize() fails. Error Code : 0x%x\n", usRes);
      exit(EXIT_FAILURE);
   }

   if(pControPanelFirmwareInfo != NULL)
   {
      delete[] pControPanelFirmwareInfo;
      pControPanelFirmwareInfo = NULL;
   }
   if(pLibVersion != NULL)
   {
      delete[] pLibVersion;
      pLibVersion = NULL;
   }
   exit(EXIT_SUCCESS);
}

void HotKeyCallback(PIMC_HOTKEY_MSG_OBJECT pMsgObj)
{
   if(pMsgObj != NULL)
   {
      for(unsigned idx = 0 ; idx < SUSI_HOTKEY_BUFFER_SIZE ; ++idx)
      {
         printf("Key%d = %d ", idx, pMsgObj->buf[idx]);
      }
      printf("\n");
   }
}

