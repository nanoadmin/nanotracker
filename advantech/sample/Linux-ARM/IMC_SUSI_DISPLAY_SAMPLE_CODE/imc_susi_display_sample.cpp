#include <stdio.h>
#include <unistd.h>

#include "SUSI_IMC.h"
#include "SUSI_IMC_Types.h"

#define MAX_IMAGE_INFO_LEN 128

int main(int argc, char** argv)
{
    int c;
    bool bHelp = false;
    bool bScreenControl = false;
    bool bBrightControl = false;
    USHORT usRet;
    
    BYTE bright_max = 0;
    BYTE bright_min = 0;
    BYTE bright_step = 0;
    BYTE bright_value = 0;
    
    IMC_DISPLAY_GET_BRIGHT_RANGE parm_bright_range;
    parm_bright_range.maximum = &bright_max;
    parm_bright_range.minimum = &bright_min;
    parm_bright_range.stepping = &bright_step;
    
    while((c=getopt(argc, argv, "h")) != -1)
	{
		switch(c)
		{
			case 'h':
				bHelp = true;
			break;
			default:
				printf("Bad command \n");
			break;
		}
	}
	
	if(bHelp)
	{
		printf("Usage: imc_susi_display_demo");
		return true;
	}
    
    printf("========================================\n");
    printf("IMC SUSI DISPLAY Demo Sample Code\n");
    
    printf("\nDemo Function : SUSI_IMC_CORE_Init\n");
    usRet = SUSI_IMC_CORE_Init();
    if (usRet !=IMC_ERR_NO_ERROR)
    {
		printf("SUSI_IMC_CORE_Init fail Error = 0x%x \n",usRet);
		
	}else{
		
		printf("SUSI_IMC_CORE_Init OK!\n");		
	}
	
    printf("\nDemo Function : SUSI_IMC_DISPLAY_Available\n");
    usRet = SUSI_IMC_DISPLAY_Available();
    switch (usRet)
    {
		case IMC_ERR_DISPLAY_FUNCTION_OK_SUPPORT:
			printf("SDK Support Screen on/off and Bright control!");
			bScreenControl = true;
			bBrightControl = true;			
			break;
		case IMC_ERR_DISPLAY_FUNCTION_OK_ONLY_SCREEN_CONTROL:
			printf("SDK only Support Screen on/off control!");
			bScreenControl = true;
			break;
		case IMC_ERR_DISPLAY_FUNCTION_OK_ONLY_BRIGHTNESS:
			printf("SDK only Support Bright control!");
			bBrightControl = true;	
			break;
		case IMC_ERR_DISPLAY_FUNCTION_OK_PLATFORM_NOT_SUPPORT_ALL:
			printf("SDK not support all!");
			break;
		default:
			printf("SUSI_IMC_DISPLAY_Available fail Error = 0x%x \n",usRet);
	}
	
	if (bScreenControl)
	{
		printf("\nDemo Function : SUSI_IMC_DISPLAY_ScreenOff\n");
		usRet = SUSI_IMC_DISPLAY_ScreenOff();
		if (usRet !=IMC_ERR_NO_ERROR)
		{
			printf("SUSI_IMC_DISPLAY_ScreenOff fail Error = 0x%x \n",usRet);
		
		}else{
		
			printf("SUSI_IMC_DISPLAY_ScreenOff OK! \n");		
		}
		
		printf("\nDemo Function : SUSI_IMC_DISPLAY_ScreenOn\n");
		usRet = SUSI_IMC_DISPLAY_ScreenOn();
		if (usRet !=IMC_ERR_NO_ERROR)
		{
			printf("SUSI_IMC_DISPLAY_ScreenOn fail Error = 0x%x \n",usRet);
		
		}else{
		
			printf("SUSI_IMC_DISPLAY_ScreenOn OK! \n");		
		}		
	}

	if (bBrightControl)
	{
		printf("\nDemo Function : SUSI_IMC_DISPLAY_GetBrightRange\n");
		usRet = SUSI_IMC_DISPLAY_GetBrightRange(&parm_bright_range);
		if (usRet !=IMC_ERR_NO_ERROR)
		{
			printf("SUSI_IMC_DISPLAY_GetBrightRange fail Error = 0x%x \n",usRet);
		
		}else{
		
			printf("Max Brightness  = %d\n",*parm_bright_range.maximum);
			printf("Min Brightness  = %d\n",*parm_bright_range.minimum);
			printf("Brightness control stepping = %d\n",*parm_bright_range.stepping);
		}

		printf("\nDemo Function : SUSI_IMC_DISPLAY_GetBright\n");
		usRet = SUSI_IMC_DISPLAY_GetBright(&bright_value);
		if (usRet !=IMC_ERR_NO_ERROR)
		{
			printf("SUSI_IMC_DISPLAY_GetBright fail Error = 0x%x \n",usRet);
		
		}else{
		
			printf("Brightness = %d\n",bright_value);
		}
		
		printf("\nDemo Function : SUSI_IMC_DISPLAY_SetBright\n");
		
		for (BYTE i=*parm_bright_range.maximum; i>0; i--)
		{
			usRet = SUSI_IMC_DISPLAY_SetBright(i);
			if (usRet !=IMC_ERR_NO_ERROR)
			{
				printf("SUSI_IMC_DISPLAY_SetBright fail Error = 0x%x \n",usRet);
				break;		
			}else{
		
				printf("Set brightness is %d OK! \n",i);
				usleep(1000 * 1000);
			}
			
		}
		
		usRet = SUSI_IMC_DISPLAY_SetBright(*parm_bright_range.maximum);
		if (usRet !=IMC_ERR_NO_ERROR)
		{
			printf("SUSI_IMC_DISPLAY_SetBright fail Error = 0x%x \n",usRet);
		
		}else{
		
			printf("Set brightness to Max OK! \n");
		}	
	}
    
    printf("\nDemo Function : SUSI_IMC_CORE_DeInit\n");
    usRet = SUSI_IMC_CORE_DeInit();
    if (usRet !=IMC_ERR_NO_ERROR)
    {		
		printf("SUSI_IMC_CORE_DeInit fail Error = 0x%x \n",usRet);
		
	}else{
		
		printf("SUSI_IMC_CORE_DeInit OK! \n");		
	}
	
	printf("========================================\n");
    return 0;
}
