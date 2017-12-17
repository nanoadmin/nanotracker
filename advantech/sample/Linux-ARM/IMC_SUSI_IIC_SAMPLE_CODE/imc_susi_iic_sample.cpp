#include <stdio.h>
#include <unistd.h>

#include "SUSI_IMC.h"
#include "SUSI_IMC_Types.h"

int main(int argc, char** argv)
{
    int c;
    bool bHelp = false;
    bool bPrimary = false;
    bool bSMBus = false;    
    USHORT usRet;
    
    BYTE WriteBuf[1];
    BYTE ReadBuf[1];
    
    IMC_IIC_WRITE iic_write_data;
    IMC_IIC_READ iic_read_data;
    IMC_IIC_WRITE_READ_COMBINE iic_write_read_combine_data;
   
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
		printf("Usage: imc_susi_iic_demo");
		return true;
	}
    
    printf("========================================\n");
    printf("IMC SUSI IIC Demo Sample Code\n");
    
    printf("\nDemo Function : SUSI_IMC_CORE_Init\n");
    usRet = SUSI_IMC_CORE_Init();
    if (usRet !=IMC_ERR_NO_ERROR)
    {
		printf("SUSI_IMC_CORE_Init fail Error = 0x%x \n",usRet);
		
	}else{
		
		printf("SUSI_IMC_CORE_Init OK!\n");		
	}
	
    printf("\nDemo Function : SUSI_IMC_IIC_Available\n");
    usRet = SUSI_IMC_IIC_Available();
    switch (usRet)
    {
		case IMC_ERR_IIC_STATUS_OK_PLATFORM_SUPPORT:
			printf("SDK Support Primary mode and SMBus mode!\n");
			bPrimary = true;
			bSMBus = true;			
			break;
		case IMC_ERR_IIC_STATUS_OK_PLATFORM_ONLY_SUPPORT_PRIMARY:
			printf("SDK only Support Primary mode!\n");
			bPrimary = true;
			break;
		case IMC_ERR_IIC_STATUS_OK_PLATFORM_ONLY_SUPPORT_SMBUS:
			printf("SDK only Support SMBus mode\n!");
			bSMBus = true;	
			break;
		case IMC_ERR_IIC_STATUS_OK_PLATFORM_NOT_SUPPORT_ALL:
			printf("SDK not support all!\n");
			break;
		default:
			printf("SUSI_IMC_DISPLAY_Available fail Error = 0x%x \n",usRet);
	}

    printf("\nDemo Function : SUSI_IMC_IIC_Write\n");
    
    WriteBuf[0] = 0xF1;  // try to get name of platform from VPM.
    iic_write_data.IICType = 1;
    iic_write_data.SlaveAddress = 0xF0;
    iic_write_data.WriteBuf = WriteBuf;
    iic_write_data.WriteLen = 1;
    
    usRet = SUSI_IMC_IIC_Write(&iic_write_data);
    if (usRet !=IMC_ERR_NO_ERROR)
    {		
		printf("SUSI_IMC_IIC_Write fail Error = 0x%x \n",usRet);
		
	}else{
		
		printf("SUSI_IMC_IIC_Write OK! \n");		
	}
	
	printf("\nDemo Function : SUSI_IMC_IIC_Read\n");
	iic_read_data.IICType = 1;
    iic_read_data.SlaveAddress = 0xF1;
    iic_read_data.ReadBuf = ReadBuf;
    iic_read_data.ReadLen = 1;

    usRet = SUSI_IMC_IIC_Read(&iic_read_data);
    if (usRet !=IMC_ERR_NO_ERROR)
    {		
		printf("SUSI_IMC_IIC_Read fail Error = 0x%x \n",usRet);
		
	}else{
		
		printf("SUSI_IMC_IIC_Read OK! \n");		
	}
	
	printf("\nDemo Function : SUSI_IMC_IIC_WriteReadCombine\n");
	iic_write_read_combine_data.IICType = 1;
	iic_write_read_combine_data.SlaveAddress = 0xF0;
    iic_write_read_combine_data.WriteBuf = WriteBuf;
    iic_write_read_combine_data.WriteLen = 1;	
    iic_write_read_combine_data.ReadBuf = ReadBuf;
    iic_write_read_combine_data.ReadLen = 1;
    
    usRet = SUSI_IMC_IIC_WriteReadCombine(&iic_write_read_combine_data);
    if (usRet !=IMC_ERR_NO_ERROR)
    {		
		printf("SUSI_IMC_IIC_WriteReadCombine fail Error = 0x%x \n",usRet);
		
	}else{
		
		printf("SUSI_IMC_IIC_WriteReadCombine OK! \n");		
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
