#!/usr/bin/python3

import sys
import can
import time
import os
import traceback
import requests

import itertools

from threading import Thread


PID_REQUEST         = 0x1CEA0000
PID_REPLY           = 0x7E8

time.sleep(0.33)
print('Ready')

try:
    bus = can.interface.Bus(channel='can0', bustype='socketcan_native')
except OSError:
    print('Cannot find PiCAN board.')
    exit()


while True:   

    # Main loop
    try:
        
        bus = can.interface.Bus(channel='can0', bustype='socketcan_native')

        SEND_REQUESTS = {
            0x1CEA0000: [[0xA4,0xFE,0x00],[0xDF,0xFE,0x00],[0xE5,0xFE,0x00],[0xE7,0xFE,0x00],[0xEE,0xFE,0x00]]
        }

        while True:

            for element in itertools.cycle(SEND_REQUESTS[PID_REQUEST]):

                msg = can.Message(arbitration_id=PID_REQUEST,data=element,extended_id=True)
                bus.send(msg)

                time.sleep(0.3)


    except KeyboardInterrupt:
        #Catch keyboard interrupt
        #os.system("sudo /sbin/ip link set can0 down")
        print('\n\rKeyboard interrtupt')
        return        
        
    except:
        print "Unexpected error:", sys.exc_info()[0]


        
        

