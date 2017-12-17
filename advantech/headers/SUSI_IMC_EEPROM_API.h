#ifndef SUSI_IMC_EEPROM_API_H
#define SUSI_IMC_EEPROM_API_H

#include "SUSI_IMC_Types.h"

DLLAPI USHORT SUSI_IMC_EEPROM_GetLibVersion(PBYTE pVersion);
DLLAPI USHORT SUSI_IMC_EEPROM_Initialize();
DLLAPI USHORT SUSI_IMC_EEPROM_Deinitialize();
DLLAPI USHORT SUSI_IMC_EEPROM_GetEEPROMSize(UINT* pROMSize);
DLLAPI USHORT SUSI_IMC_EEPROM_ReadByte(BYTE byStartAddr, BYTE* pbyData);
DLLAPI USHORT SUSI_IMC_EEPROM_WriteByte(BYTE byStartAddr, BYTE byData);
DLLAPI USHORT SUSI_IMC_EEPROM_ReadMultiByte(BYTE byStartAddr, BYTE bySize, BYTE* pbyDataArray, BYTE* pbyRealSize);
DLLAPI USHORT SUSI_IMC_EEPROM_WriteMultiByte(BYTE byStartAddr, BYTE bySize, BYTE* pbyDataArray, BYTE* pbyRealSize);

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// function pointers
typedef USHORT (*PSUSI_IMC_EEPROM_GetLibVersion)(PBYTE pVersion);
typedef USHORT (*PSUSI_IMC_EEPROM_Initialize)();
typedef USHORT (*PSUSI_IMC_EEPROM_Deinitialize)();
typedef USHORT (*PSUSI_IMC_EEPROM_GetEEPROMSize)(UINT* pROMSize);
typedef USHORT (*PSUSI_IMC_EEPROM_ReadByte)(UINT byStartAddr, BYTE* pbyData);
typedef USHORT (*PSUSI_IMC_EEPROM_WriteByte)(UINT byStartAddr, BYTE byData);
typedef USHORT (*PSUSI_IMC_EEPROM_ReadMultiByte)(BYTE byStartAddr, BYTE bySize, BYTE* pbyDataArray, BYTE* pbyRealSize);
typedef USHORT (*PSUSI_IMC_EEPROM_WriteMultiByte)(BYTE byStartAddr, BYTE bySize, BYTE* pbyDataArray, BYTE* pbyRealSize);

#endif