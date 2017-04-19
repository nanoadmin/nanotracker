import threading
import time
import CAN_bus
import temp_reader

import sys


print (sys.version)

DEVICE_ID = "auto01"

#----------------------------------------------------------------------
def main():
    """Main Application"""
    
    event = threading.Event()
    event.set()
    
    can1 = CAN_bus.CANReceiver('can1', event, 1)
    can1.start()
    
    temp = temp_reader.TempReader(event, 1)
    temp.start()
    
    try:
        while 1:
            
            print('#####################')
            #print(temp.read_messages())
            #print(can1.read_messages())

            temp_messages = temp.read_messages()
            can_messages = can1.read_messages()
            
            # extract all the unique timestamps from each message dictionary
            timestamps = sorted(set(list(can_messages.keys()) + list(temp_messages.keys())))
                
            # create the string to post
            post_str = "deviceid:" + DEVICE_ID + "\n"
            for ts in timestamps:
                post_str += "time:" + ts + "\n"
                
                # check if there is a temp for this timestamp
                if ts in temp_messages:
                    post_str += "temp:" + str(temp_messages[ts]) + "\n"
                    
                # check if there is can data for this timestamp
                if ts in can_messages:
                    for msg in can_messages[ts]:
                        post_str += str(msg) + "\n"
                
            print(post_str)
            time.sleep(5)
            
    except KeyboardInterrupt:
        print("CTRL-C detected, attempting to close threads")
        
        event.clear()
        can1.join()
        temp.join()
        
        print("threads closed")
        
main();
    
    

#import CAN_receiver
#import socket
#import time
#import os


#print("app started")
#s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
#s.connect(("gmail.com",80))
#print("getting ip address")
#print(s.getsockname()[0])
#s.close()

#cr = CAN_receiver.CanReceiver('can1')

