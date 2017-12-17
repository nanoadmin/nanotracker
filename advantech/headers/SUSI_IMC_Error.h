#ifndef _SUSI_IMC_ERROR_H
#define _SUSI_IMC_ERROR_H

//	Related the CAN BUS API error code set.
#define IMC_CAN_SET_BIT_TIMING_ERROR                                 0xC010
#define IMC_CAN_RX_NOT_READY                                         0xC012
#define IMC_CAN_TX_WRITE_ERR                                         0xC014


//	Related the J1939 API error code set.
#define IMC_J1939_TX_REQUEST_NOT_OK                                  0xC020
#define IMC_J1939_RX_NOT_READY                                       0xC021
#define IMC_J1939_CONTAINER_EMPTY                                    0xC022

//	Related the HotKey API error code set.
#define IMC_HOTKEY_NON_ANY_KEY_PRESS                                 0xC030

//	Related the VPM API error code set.
#define IMC_ERR_VPM_NOT_SET_ALARM                                    0xC040  // The RTC alarm not set.
#define IMC_ERR_VPM_COMPORT_BUSY                                     0xC041  // COM port is currently busy, try later.
#define IMC_ERR_VPM_ERROR_WAKEUPSOURCE_FROM_VPM                      0xC043  // Error last wakeup source from VPM.
#define IMC_ERR_VPM_OPEN_VPM_COM_FAIL                                0xC044  // Open com of VPM fail.
#define IMC_ERR_VPM_UNKNOW_RETURN_VALUE_FROM_VPM                     0xC045  // Unknow return value form VPM.
#define IMC_ERR_VPM_COMPORT_COMMAND_FAIL                             0xC046  // Send or receive cmd fail with VPM.
#define IMC_ERR_VPM_WAKEUP_SOURCE_NOT_SUPPORT                        0xC047  // This platform didn't to support this wakeup source.
#define IMC_ERR_VPM_NO_RESPONSE                                      0xC048  // This VPM repsone timeout.

//	Related the Light Sensor API error code set.
#define IMC_READ_LIGHT_SENSOR_DATA_ERROR                             0xC060  // Fails to read the data of the Light Sensor.

//	Related the G Sensor API error code set.
#define IMC_ERR_GSENSOR_READ_DATA_ERROR                              0xC070  // Fails to read the data since gsenosr not ready.
#define IMC_ERR_GSENSOR_DATA_INTERNAL_ERROR                          0xC071
#define IMC_ERR_GSENSOR_ALARM_MONITOR_ALREADY_ACTIVE_ERROR           0xC072
#define IMC_ERR_GSENSOR_DATA_NOT_READY                               0xC073
#define IMC_ERR_GSENSOR_ANDROID_JNI_ALARM_THREAD_CREATE_FAILED       0xC074

#define IMC_ERR_SMBUS_BUS_IS_BUSY                                    0xC0C2
#define IMC_ERR_SMBUS_BUS_TIMEOUT                                    0xC0C3

#define IMC_ERR_DISPLAY_FUNCTION_OK_PLATFORM_NOT_SUPPORT_ALL         0xC0D0
#define IMC_ERR_DISPLAY_FUNCTION_OK_ONLY_BRIGHTNESS                  0xC0D1
#define IMC_ERR_DISPLAY_FUNCTION_OK_ONLY_SCREEN_CONTROL              0xC0D2
#define IMC_ERR_DISPLAY_FUNCTION_OK_SUPPORT                          0xC0D3

#define IMC_ERR_IIC_STATUS_OK_PLATFORM_NOT_SUPPORT_ALL               0xC0E0
#define IMC_ERR_IIC_STATUS_OK_PLATFORM_ONLY_SUPPORT_PRIMARY          0xC0E1
#define IMC_ERR_IIC_STATUS_OK_PLATFORM_ONLY_SUPPORT_SMBUS            0xC0E2
#define IMC_ERR_IIC_STATUS_OK_PLATFORM_SUPPORT                       0xC0E3


//Reserve 0xC100 ~ 0xC10F for Android JNI Error
#define IMC_ERR_ANDROID_JNI_EVENT_INIT_FAILED                        0xC100
#define IMC_ERR_ANDROID_JNI_EVENT_DEINIT_FAILED                      0xC101
#define IMC_ERR_ANDROID_JNI_EVENT_LISTENING_THREAD_CREATE_FAILED     0xC102
#define IMC_ERR_ANDROID_JNI_EVENT_LISTENING_THREAD_ALREADY_RUNNING   0xC103
#define IMC_ERR_ANDROID_JNI_NULL_POINTER                             0xC104

//Reserve 0xC110 ~ 0xC11F for Android Service Error
#define IMC_ERR_ANDROID_SERVICE_NULL_POINTER                         0xC110
#define IMC_ERR_ANDROID_SERVICE_UNKNWON_EXCEPTION                    0xC111
#define IMC_ERR_ANDROID_SERVICE_REMOTE_CALLBACK_LIST_NOT_FOUND       0xC112
#define IMC_ERR_ANDROID_SERVICE_REMOTE_CALLBACK_REGISTER_FAILED      0xC113
#define IMC_ERR_ANDROID_SERVICE_REMOTE_CALLBACK_UNREGISTER_FAILED    0xC114
#define IMC_ERR_ANDROID_SERVICE_REMOTE_CALLBACK_UPDATE_FAILED        0xC115

//Reserve 0xC120 ~ 0xC12F for Android Service Client Error
#define IMC_ERR_ANDROID_CLIENT_NULL_POINTER                          0xC120
#define IMC_ERR_ANDROID_CLIENT_FAILED_TO_BIND_SERVICE                0xC121
#define IMC_ERR_ANDROID_CLIENT_SERVICE_ALREADY_CONNECTED             0xC122
#define IMC_ERR_ANDROID_CLIENT_SERVICE_DISCONNECTED                  0xC123
#define IMC_ERR_ANDROID_CLIENT_REMOTE_EXCEPTION                      0xC124
#define IMC_ERR_ANDROID_CLIENT_FAILED_TO_UNBIND_SERVICE              0xC125

//Reserve 0xC200 ~ 0xC2FF for IVCP Service Client Error
#define IMC_ERR_SVC_SERVICE_NO_ERROR 								 0xC200
#define IMC_ERR_SVC_SERVICE_SOCKET_ClOSE							 0xC205
#define IMC_ERR_SVC_SERVICE_NOT_INIT								 0xC206
#define IMC_ERR_SVC_SERVICE_DELAY_TYPE								 0xC207
#define IMC_ERR_SVC_SERVICE_SOCKET_ERROR							 0xC210
#define IMC_ERR_SVC_SERVICE_INITIALIZED								 0xC20F

#endif	//_SUSI_IMC_ERROR_H