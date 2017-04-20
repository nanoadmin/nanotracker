import threading
import time
import CAN_bus
import temp_reader
import requests

import sys


print (sys.version)

DEVICE_ID = "auto01"
CAN_DATA_FILE = DEVICE_ID + "_can_data.txt"
CAN_RECEIVER_API = "http://demo.nanosoft.com.au:8082/api/canreceiver"

request_headers = {
    'cache-control': "no-cache",
    'Content-Type' : 'text/plain'
}


#----------------------------------------------------------------------
def main():
    """Main Application"""
    
    event = threading.Event()
    event.set()
    
    can0 = CAN_bus.CANReceiver('can1', event, 1)
    can0.start()    
    can1 = CAN_bus.CANReceiver('can1', event, 1)
    can1.start()
    
    #temp = temp_reader.TempReader(event, 1)
    #temp.start()
    
    #make sure the cache files are empty to start with (may not want to do this???)
    open(CAN_DATA_FILE, 'w').close()
    
    #dramatic pause!
    time.sleep(1)
    
    #toggle to post data. In this application posting data occurs every second
    #cycle. Unless a post failed then will retry every cycle until success
    post_data = False
    
    try:
        while 1:
            
            print('#####################')
            
            can_data_file = open(CAN_DATA_FILE,'a+')

            #temp_messages = temp.read_messages()
            can0_messages = can0.read_messages()
            can1_messages = can1.read_messages()
            
            # extract all the unique timestamps from each message dictionary
            timestamps = sorted(set(
                #list(can0_messages.keys()) + 
                list(can1_messages.keys())))
            
            #write data to file
            for ts in timestamps:
                
                can_data_file.write("time:" + ts + "\n")
                
                # check if there is can0 data for this timestamp
                if ts in can0_messages:
                    for msg in can0_messages[ts]:
                        can_data_file.write("can0 " + str(msg) + "\n")  
                        
                # check if there is can1 data for this timestamp
                if ts in can1_messages:
                    for msg in can1_messages[ts]:
                        can_data_file.write("can1 " + str(msg) + "\n")                         
            
            
            
            if post_data:
                print('posting')
                can_data_file.seek(0)
                data = can_data_file.read()
                response = requests.post(CAN_RECEIVER_API, data=data, headers=request_headers)
                
                if (response.status_code == 200):
                    print(' - success')
                    #clear the file if successful post
                    open(CAN_DATA_FILE, 'w').close()
                    #set the post toggle not to post
                    post_data = not post_data
                else:
                    print(' - failed')
                    print('status code: ', response.status_code)
                    #don't clear the file
                    #leave the post toggle 
            else:
                print('not posting')
                #set the post toggle not to post
                post_data = not post_data
                
            #close the file
            can_data_file.close()
            
            ## extract all the unique timestamps from each message dictionary
            #timestamps = sorted(set(list(can_messages.keys()) + list(temp_messages.keys())))
                
            ## create the string to post
            #post_str = "deviceid:" + DEVICE_ID + "\n"
            #for ts in timestamps:
                #post_str += "time:" + ts + "\n"
                
                ## check if there is a temp for this timestamp
                #if ts in temp_messages:
                    #post_str += "temp:" + str(temp_messages[ts]) + "\n"
                    
                ## check if there is can data for this timestamp
                #if ts in can_messages:
                    #for msg in can_messages[ts]:
                        #post_str += str(msg) + "\n"
                
            #print(post_str)
            time.sleep(5)
            
    except KeyboardInterrupt:
        print("CTRL-C detected, attempting to close threads")
        
        event.clear()
        can0.join()
        can1.join()
        #temp.join()
        
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

