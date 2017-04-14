import threading
import time
import CAN_bus

#----------------------------------------------------------------------
def main():
    """Main Application"""
    
    event = threading.Event()
    event.set()
    
    can1 = CAN_bus.CANReceiver('can1', event, 2)
    can1.start()
    
    try:
        while 1:
            print('-',can1.read_messages())
            time.sleep(5)
    except KeyboardInterrupt:
        print("CTRL-C detected, attempting to close threads")
        
        event.clear()
        can1.join()
        
        print("threads closed")
        
main();
    
    

#import CAN_receiver
#import socket
#import time
#import os
#import sys


#print (sys.version)


#print("app started")
#s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
#s.connect(("gmail.com",80))
#print("getting ip address")
#print(s.getsockname()[0])
#s.close()

#cr = CAN_receiver.CanReceiver('can1')

