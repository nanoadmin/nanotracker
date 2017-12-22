#ifndef SUSI_IMC_TYPES_H
#define SUSI_IMC_TYPES_H 

#if defined (WIN32) || defined (WINCE)
#include <windows.h>

/*
#ifdef  UNICODE                     
#define snprintf _snwprintf
#else                
#define snprintf _snprintf
#endif
*/
typedef HANDLE					TRUMB;
#elif defined (__linux__) || defined (ANDROID)
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// type definition
typedef void*                 HANDLE;
typedef char                 CHAR;
typedef char*                PCHAR;
typedef char                 BOOL;
typedef char                 *PBOOL;
typedef unsigned char        UCHAR;
typedef unsigned char        BYTE;
typedef unsigned char        *PBYTE;
typedef unsigned short       WORD;
typedef unsigned short       *PWORD;
typedef unsigned short       USHORT;
typedef unsigned short       *PUSHORT;
typedef float                FLOAT;
typedef float                *PFLOAT;
typedef int                  INT;
typedef int                  *PINT;
typedef int                  TRUMB;
typedef unsigned int         UINT;
typedef unsigned int         *PUINT;
typedef long                 LONG;
typedef long                 *LPLONG;
typedef unsigned long        DWORD;
typedef unsigned long        *PDWORD;
typedef unsigned long        ULONG;
typedef unsigned long        *PULONG;
typedef unsigned long        *LPDWORD;
typedef unsigned long long   UINT64;
typedef long                 HRESULT;
typedef void                 *LPVOID;
typedef const void           *LPCVOID;

typedef wchar_t WCHAR;
#ifdef  UNICODE                     
typedef wchar_t TCHAR;
#else                
typedef char TCHAR;
#endif
typedef WCHAR *LPWSTR;
typedef TCHAR *LPTSTR;
typedef const WCHAR *LPCWSTR;
typedef const TCHAR *LPCTSTR;
typedef const CHAR *LPCSTR, *PCSTR;
typedef CHAR *NPSTR, *LPSTR, *PSTR;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// definition
#define	INVALID_HANDLE_VALUE	0

#ifndef NULL
#define NULL    ((void *)0)
#endif

#ifndef FALSE
#define FALSE               0
#endif

#ifndef TRUE
#define TRUE                1
#endif

#ifndef _stdcall
#define _stdcall
#endif

#define WINAPI

typedef struct _GUID 
{
	unsigned long  Data1;
	unsigned short Data2;
	unsigned short Data3;
	unsigned char  Data4[ 8 ];
} GUID;

#ifdef  UNICODE                     
#define __TEXT(quote) L##quote      
#else   /* UNICODE */               
#define __TEXT(quote) quote         
#endif /* UNICODE */                
#define TEXT(quote) __TEXT(quote)      

#define S_OK            ((HRESULT)0L)
#define STRSAFE_E_INSUFFICIENT_BUFFER           ((HRESULT)0x8007007AL)  // 0x7A = 122L = ERROR_INSUFFICIENT_BUFFER
#define STRSAFE_E_INVALID_PARAMETER             ((HRESULT)0x80070057L)  // 0x57 =  87L = ERROR_INVALID_PARAMETER

#define SUCCEEDED(hr)   (((HRESULT)(hr)) >= 0)
#define FAILED(hr)      (((HRESULT)(hr)) < 0)

#define MAX_PATH          260

#else
#error:Unknown OS
#endif

#endif
