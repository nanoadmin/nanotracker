#include <stdio.h>

#include "common.h"
#include "function.h"
#include "pthread.h"

#include "SUSI_IMC.h"


int can_read_enable()
{
	thread_enable = 1;
	
#if defined (__linux__)
	pthread_attr_t thread_attr;
	pthread_attr_init(&thread_attr);
	int ret = ::pthread_create(&can_thread_handle, &thread_attr, &can_read_thread, NULL);
	pthread_attr_destroy(&thread_attr);
	
	if( ret < 0)
	{
		printf("can thread create fail.");
		return -1;
	}
#endif
	return 0;
}




int main(int argc, char *argv[])
{
   
  char path[256] = "/dev/ttyA0";
 
 if(argc > 1)
	{
		sprintf(path, "%s", argv[1]);
	}
 
 if( (result = SUSI_IMC_VCIL_InitializeEx(path, 921600)) != IMC_ERR_NO_ERROR )
	{
   printf("SUSI_IMC_VCIL_Initialize. error code=0x%04x\n", result);
   printf("\nUsage: %s [path...]\r\n", argv[0]);
   printf("\nPress ENTER to continue.\n");   
   return -1;
	}
 
  /**/
  if( page_init() < 0 )
		return ;
		
	 if( can_read_enable() < 0)
		return;
 
  /*set the can speed to 125K for the can1 and 500k for can2*/
  if( (result = SUSI_IMC_CAN_SetBitTimingSilence(1, CAN_SPEED_125K)) != IMC_ERR_NO_ERROR )
		{
			printf("SUSI_IMC_CAN_SetBitTimingSilence fail. error code=0x%04x\n", result);
			return;
		}
 
   /*set the can speed to 125K for the can1 and 500k for can2*/
   if( (result = SUSI_IMC_CAN_SetBitTimingSilence(2, CAN_SPEED_500K)) != IMC_ERR_NO_ERROR )
   {
    printf("SUSI_IMC_CAN_SetBitTimingSilence fail. error code=0x%04x\n", result);
    return;
   }
 
}
