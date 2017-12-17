#include <stdio.h>
#include <unistd.h>

#include "SUSI_IMC.h"
#include "SUSI_IMC_Types.h"

#define MAX_IMAGE_INFO_LEN 128

int main(int argc, char** argv)
{
    int c;
    bool bHelp = false;
    USHORT usRet;
    WORD wLux_value = 0;
    
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
		printf("Usage: imc_susi_lightsensor_demo");
		return true;
	}
    
    printf("========================================\n");
    printf("IMC SUSI LIGHTSENSOR Demo Sample Code\n");
    
    printf("\nDemo Function : SUSI_IMC_CORE_Init\n");
    usRet = SUSI_IMC_CORE_Init();
    if (usRet !=IMC_ERR_NO_ERROR)
    {
		printf("SUSI_IMC_CORE_Init fail Error = 0x%x \n",usRet);
		
	}else{
		
		printf("SUSI_IMC_CORE_Init OK!\n");		
	}

    printf("\nDemo Function : SUSI_IMC_LIGHTSENSOR_GetStatus\n");
    usRet = SUSI_IMC_LIGHTSENSOR_GetStatus(&wLux_value);
    if (usRet !=IMC_ERR_NO_ERROR)
    {
		printf("SUSI_IMC_LIGHTSENSOR_GetStatus fail Error = 0x%x \n",usRet);
		
	}else{
		
		printf("Lux is %d\n",wLux_value);
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
