import threading
import time
import CAN_reader
import temp_reader
import volt_reader
import requests

import sys


print (sys.version)

DEVICE_ID = "auto01"
CAN_DATA_FILE = "/home/pi/Desktop/Zagro/" + DEVICE_ID + "_can_data.txt"
OTHER_DATA_FILE = "/home/pi/Desktop/Zagro/" + DEVICE_ID + "_other_data.txt"
#CAN_RECEIVER_API = "http://demo.nanosoft.com.au:8082/api/canreceiver"
CAN_RECEIVER_API = "http://188.166.243.212:1234/api/canreceiver"
DATA_RECEIVER_API = "http://188.166.243.212:1234/api/datareceiver"

request_headers = {
    'cache-control': "no-cache",
    'Content-Type' : 'text/plain'
}


#----------------------------------------------------------------------
def post_CAN_data(can_data_file):
    print('posting CAN Data')
    try :
        can_data_file.seek(0)
        data =  "deviceid:" + DEVICE_ID + "\n" + can_data_file.read()
        response = requests.post(CAN_RECEIVER_API, data=data, headers=request_headers)
        
        if (response.status_code == 200):
            print(' - success')
            #clear the file if successful post
            open(CAN_DATA_FILE, 'w').close()
        else:
            print(' - failed')
            print('status code: ', response.status_code)
            #don't clear the file
            
    except:
        print(' - failed')
        print("Unexpected error:", sys.exc_info()[0])
        pass    # don't stop script
        
        
#----------------------------------------------------------------------
def post_other_data(other_data_file):
    print('posting other data')
    try :
        other_data_file.seek(0)
        data = "deviceid:" + DEVICE_ID + "\n" + other_data_file.read()
        response = requests.post(DATA_RECEIVER_API, data=data, headers=request_headers)
        
        if (response.status_code == 200):
            print(' - success')
            #clear the file if successful post
            open(OTHER_DATA_FILE, 'w').close()

        else:
            print(' - failed')
            print('status code: ', response.status_code)
            #don't clear the file
            #leave the post toggle 
    except:
        print(' - failed')
        print("Unexpected error:", sys.exc_info()[0])
        pass    # don't stop script
    
    
#----------------------------------------------------------------------
def cache_CAN_data(can_data_file, can0, can1):
    """Caches the data to file"""
    can0_messages = can0.read_messages()
    can1_messages = can1.read_messages()
    
    # extract all the unique timestamps from each message dictionary
    timestamps = sorted(set(
        list(can0_messages.keys()) + 
        list(can1_messages.keys())))
    
    #write data to file
    for ts in timestamps:
        
        can_data_file.write("time:" + ts + "\n")
        
        # check if there is can0 data for this timestamp
        if ts in can0_messages:
            can_data_file.write("can:Zagro125\n")
            for msg in can0_messages[ts]:
                can_data_file.write(str(msg) + "\n")  
                
        # check if there is can1 data for this timestamp
        if ts in can1_messages:
            can_data_file.write("can:Zagro500\n")
            for msg in can1_messages[ts]:
                can_data_file.write(str(msg) + "\n")             
    
    
#----------------------------------------------------------------------
def cache_other_data(other_data_file, temp, volt):
    """Caches the data to file"""
    temp_messages = temp.read_messages()
    volt_messages = volt.read_messages()
            
    # extract all the unique timestamps from each message dictionary
    timestamps = sorted(set(
        list(volt_messages.keys()) + 
        list(temp_messages.keys())))
    
    for ts in timestamps:
        other_data_file.write("time:" + ts + "\n")
        
        # check if there is a temp for this timestamp
        if ts in temp_messages:   
            other_data_file.write("temp:" + str(temp_messages[ts]) + "\n") 
    
        # check if there is a volt for this timestamp
        if ts in volt_messages:   
            other_data_file.write("volt:" + str(volt_messages[ts]) + "\n")             


#----------------------------------------------------------------------
def main():
    """Main Application"""
    
    global post_data
    
    event = threading.Event()
    event.set()
    
    #make sure the cache files are empty to start with (may not want to do this???)
    open(CAN_DATA_FILE, 'w').close()
    open(OTHER_DATA_FILE, 'w').close()    
    
    # Create the CAN Reader Threads
    can0 = CAN_reader.CANReceiver('can0', '125000', event, 1)
    can0.start()    
    can1 = CAN_reader.CANReceiver('can1', '500000', event, 1)
    can1.start()

    # Create the Temp Reader Thread
    temp = temp_reader.TempReader(event, 1)
    temp.start()
    
    # Create the Voltag Reader Thread
    volt = volt_reader.VoltReader(event, 1)
    volt.start()    

    #dramatic pause!
    time.sleep(1)
    
    try:
        while 1:
            
            print('#####################')
            
            # open the file with append mode and write CAN data to it
            can_data_file = open(CAN_DATA_FILE,'a+')
            cache_CAN_data(can_data_file, can0, can1)

            # open the file with append mode and write all other data to it
            other_data_file = open(OTHER_DATA_FILE,'a+')
            cache_other_data(other_data_file, temp, volt)  
       
            # post data from the cache files
            post_CAN_data(can_data_file)
            post_other_data(other_data_file)
                
            #close the files
            can_data_file.close()
            other_data_file.close()
                
            #sleep
            time.sleep(5)
            
    except KeyboardInterrupt:
        print("CTRL-C detected, attempting to close threads")
        
        event.clear()
        can0.join()
        can1.join()
        temp.join()
        volt.join()
        
        print("threads closed")
        
    except:
        print("Unexpected error:", sys.exc_info()[0])
        pass    
        
# Run the Application        
main()
    


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

