#ifndef _SUSI_IMC_IIC_DEF_H
#define _SUSI_IMC_IIC_DEF_H

typedef struct{
	DWORD IICType;
	BYTE SlaveAddress;
	BYTE *ReadBuf;
	DWORD ReadLen;
}IMC_IIC_READ,*PIMC_IIC_READ;

typedef struct{
	DWORD IICType;
	BYTE SlaveAddress;
	BYTE *WriteBuf;
	DWORD WriteLen;
}IMC_IIC_WRITE,*PIMC_IIC_WRITE;

typedef struct{
	DWORD IICType;
	BYTE SlaveAddress;
	BYTE *WriteBuf;
	DWORD WriteLen;
	BYTE *ReadBuf;
	DWORD ReadLen;
}IMC_IIC_WRITE_READ_COMBINE,*PIMC_IIC_WRITE_READ_COMBINE;

#endif