#ifndef _SUSI_IMC_CORE_FUNCTION_DEF_H
#define _SUSI_IMC_CORE_FUNCTION_DEF_H

typedef struct
{
	DWORD dwOPFlag;
	BOOL  isRunning;
	BOOL  isAutorun;
	DWORD dwTimeContinual;
	DWORD dwTimeTotal;

}IMC_SSCORE_RUNTIMER, *PIMC_SSCORE_RUNTIMER;

typedef struct{
	DWORD mode;
	DWORD OPFlag;
	BOOL *enable;
	DWORD *value;
}IMC_CORE_ACCESS_BOOTCOUNTER,*PIMC_CORE_ACCESS_BOOTCOUNTER;

typedef struct{
	DWORD mode;
	PIMC_SSCORE_RUNTIMER pRunTimer;
}IMC_CORE_ACCESS_RUN_TIMER,*PIMC_CORE_ACCESS_RUN_TIMER;

typedef struct{
	TCHAR *BIOSVersion;
	DWORD *size;
}IMC_CORE_GETBIOSVERSION,*PIMC_CORE_GETBIOSVERSION;

typedef struct{
	TCHAR *PlatformName;
	DWORD *size;
}IMC_CORE_GETPLATFORMNAME,*PIMC_CORE_GETPLATFORMNAME;

typedef struct{
	HANDLE proc_handle; 
	unsigned char cpu_index; 
	unsigned char step;
}IMC_CORE_CPU_SET_ON_DT,*PIMC_CORE_CPU_SET_ON_DT;

typedef struct{
	HANDLE proc_handle; 
	unsigned char cpu_index; 
	unsigned char * step;
}IMC_CORE_CPU_GET_ON_DT,*PIMC_CORE_CPU_GET_ON_DT;

typedef struct{
	BYTE ACPolicy; 
	BYTE DCPolicy;
}IMC_CORE_SPEED_WRITE,*PIMC_CORE_SPEED_WRITE;

typedef struct{
	BYTE *ACPolicy; 
	BYTE *DCPolicy;
}IMC_CORE_SPEED_READ,*PIMC_CORE_SPEED_READ;

#define IMC_CORE_MAX_IMAGE_INFO_STRING_LEN 128

#if defined (WIN32) || defined (WINCE)
typedef struct
{
 TCHAR *WinCEImageVersion;
 TCHAR *WinCEBuiltDate;
 TCHAR *BootloaderVersion;
 TCHAR *BootloaderDate;
}IMC_IMGINFO, *PIMC_IMGINFO;

#elif defined (__linux__) || defined (ANDROID)

typedef struct
{
 TCHAR *AndroidVersion;
 TCHAR *AndroidBuiltDate;
 TCHAR *KernelVersion;
 TCHAR *KernelBuiltDate;
}IMC_IMGINFO, *PIMC_IMGINFO;
#endif
#endif
