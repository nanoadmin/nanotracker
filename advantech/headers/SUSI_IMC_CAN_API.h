#ifndef _SUSI_IMC_CAN_API_H
#define _SUSI_IMC_CAN_API_H

DLLAPI USHORT SUSI_IMC_CAN_Read ( OUT PIMC_CAN_MSG_OBJECT object );
DLLAPI USHORT SUSI_IMC_CAN_Write ( IN PIMC_CAN_MSG_OBJECT object );
DLLAPI USHORT SUSI_IMC_CAN_GetBusErrorStatus ( IN UINT can_bus_number, OUT PIMC_CAN_ERROR_STATUS_OBJECT object );
DLLAPI USHORT SUSI_IMC_CAN_SetEvent ( void* hEvent );
DLLAPI USHORT SUSI_IMC_CAN_SetBitTiming ( IN UINT can_bus_number, IN CAN_SPEED bit_rate );
DLLAPI USHORT SUSI_IMC_CAN_GetBitTiming ( IN UINT can_bus_number, OUT CAN_SPEED *bit_rate, OUT CAN_BUS_MODE *mode );
DLLAPI USHORT SUSI_IMC_CAN_SetBitTimingSilence ( IN UINT can_bus_number, IN CAN_SPEED bit_rate );
DLLAPI USHORT SUSI_IMC_CAN_SetMessageMask ( IN PIMC_CAN_MASK_OBJECT mask_object);
DLLAPI USHORT SUSI_IMC_CAN_GetMessageMask ( OUT PIMC_CAN_MASK_OBJECT pmask_object);
DLLAPI USHORT SUSI_IMC_CAN_RemoveMessageMask ( IN UINT can_bus_number, IN int mask_number );
DLLAPI USHORT SUSI_IMC_CAN_ResetMessageMask ( IN UINT can_bus_number );
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// function pointer
typedef USHORT (*PSUSI_IMC_CAN_Read) ( OUT PIMC_CAN_MSG_OBJECT object );
typedef USHORT (*PSUSI_IMC_CAN_Write) ( IN PIMC_CAN_MSG_OBJECT object );
typedef USHORT (*PSUSI_IMC_CAN_BlockingWrite) ( IN PIMC_CAN_MSG_OBJECT object );
typedef USHORT (*PSUSI_IMC_CAN_GetBusErrorStatus) ( OUT PIMC_CAN_ERROR_STATUS_OBJECT object );
typedef USHORT (*PSUSI_IMC_CAN_SetEvent) ( void* hEvent );
typedef USHORT (*PSUSI_IMC_CAN_SetBitTiming) ( IN UINT can_bus_number, IN CAN_SPEED bit_rate );
typedef USHORT (*PSUSI_IMC_CAN_GetBitTiming) ( IN UINT can_bus_number, OUT CAN_SPEED *bit_rate, OUT CAN_BUS_MODE *mode );
typedef USHORT (*PSUSI_IMC_CAN_SetBitTimingSilence) ( IN UINT can_bus_number, IN CAN_SPEED bit_rate );
typedef USHORT (*PSUSI_IMC_CAN_SetMessageMask) ( IN PIMC_CAN_MASK_OBJECT mask_object);
typedef USHORT (*PSUSI_IMC_CAN_GetMessageMask) ( OUT PIMC_CAN_MASK_OBJECT pmask_object);
typedef USHORT (*PSUSI_IMC_CAN_RemoveMessageMask) ( IN UINT can_bus_number, IN int mask_number );
typedef USHORT (*PSUSI_IMC_CAN_ResetMessageMask) ( IN UINT can_bus_number );
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#endif
