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
API_POST_TIMER = 5      # number of seconds between each post request to the api

CAN0_NAME = 'can0'
CAN0_BITRATE = 125000
CAN1_NAME = 'can1'
CAN1_BITRATE = 500000

REQUEST_HEADERS = {
    'cache-control': "no-cache",
    'Content-Type' : 'text/plain'
}

class NanoSoftReader:
    
    def __init__(self):
        # Create an event object used to send events to sub-threads
        self.event = threading.Event()
        self.event.set()
        
        #make sure the cache files are empty to start with (may not want to do this???)
        open(CAN_DATA_FILE, 'w').close()
        open(OTHER_DATA_FILE, 'w').close() 
        
        # Create the CAN Reader Threads
        self.can0 = CAN_reader.CANReceiver(CAN0_NAME, CAN0_BITRATE, self.event, 1)
        self.can0.start()    
        self.can1 = CAN_reader.CANReceiver(CAN1_NAME, CAN1_BITRATE, self.event, 1)
        self.can1.start()
    
        # Create the Temp Reader Thread
        self.temp = temp_reader.TempReader(self.event, 1)
        self.temp.start()
        
        # Create the Voltag Reader Thread
        self.volt = volt_reader.VoltReader(self.event, 1)
        self.volt.start()          
        
        
    #----------------------------------------------------------------------
    # Function to POST the CAN data to the API from the cache file.
    # Upon a 200 response, the file will be cleared.
    #----------------------------------------------------------------------
    def post_CAN_data(self, can_data_file):
        print('posting CAN Data')
        try :
            can_data_file.seek(0)
            data =  "deviceid:" + DEVICE_ID + "\n" + can_data_file.read()
            response = requests.post(CAN_RECEIVER_API, data=data, headers=REQUEST_HEADERS)
            
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
    # Function to POST the other data (temperature, voltage, [GPS,Accelerometer] to the API
    # Upon a 200 response, the file will be cleared.
    #----------------------------------------------------------------------
    def post_other_data(self, other_data_file):
        print('posting other data')
        try :
            other_data_file.seek(0)
            data = "deviceid:" + DEVICE_ID + "\n" + other_data_file.read()
            response = requests.post(DATA_RECEIVER_API, data=data, headers=REQUEST_HEADERS)
            
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
    # Function to fetch data messages from the sub-threads and write data to 
    # file for caching in case POST requests aren't succesful. 
    # @TODO: may need to implement some filesize management functionality in 
    #        case the API server goes down for a long period of time.
    #----------------------------------------------------------------------
    def cache_CAN_data(self, can_data_file):
        """Caches the data to file"""
        can0_messages = self.can0.read_messages()
        can1_messages = self.can1.read_messages()
        
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
    # Function to fetch data messages from the sub-threads and write data to 
    # file for caching in case POST requests aren't succesful.
    # @TODO: may need to implement some filesize management functionality in 
    #        case the API server goes down for a long period of time.
    #----------------------------------------------------------------------
    def cache_other_data(self, other_data_file):
        """Caches the data to file"""
        temp_messages = self.temp.read_messages()
        volt_messages = self.volt.read_messages()
                
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
    # Function to check if the sub threads are still alive and if not, 
    # recreate them.
    #----------------------------------------------------------------------
    def check_alive(self):
        if (not self.can0.is_alive()):
            print('ERROR: CAN0_reader not alive, restarting')
            self.event.set()
            self.can0 = CAN_reader.CANReceiver(CAN0_NAME, CAN0_BITRATE, self.event, 1)
            self.can0.start()
            
        if (not self.can1.is_alive()):
            print('ERROR: CAN1_reader not alive, restarting')
            self.event.set()
            self.can1 = CAN_reader.CANReceiver(CAN1_NAME, CAN1_BITRATE, self.event, 1)
            self.can1.start()
            
        if (not self.temp.is_alive()):
            print('ERROR: temp_reader thread not alive, restarting')
            self.event.set()
            self.temp = temp_reader.TempReader(self.event, 1)
            self.temp.start()     
            
        if (not self.volt.is_alive()):
            print('ERROR: voltage_reader not alive, restarting')
            self.event.set()
            self.volt = volt_reader.VoltReader(self.event, 1)
            self.volt.start()      
    
    #----------------------------------------------------------------------
    # Main application loop
    # 1. Checks if threads are alive
    # 2. Gets data from sub threads and save in cache files
    # 3. Posts data in cache files to API
    # 4. Repeat after API_POST_TIMER seconds 
    #----------------------------------------------------------------------
    def run(self):
    
        try:
            #c=0
            while 1:
                
                print('#####################')
                
                # check to see if threads are alive
                self.check_alive()
                
                # open the file with append mode and write CAN data to it
                can_data_file = open(CAN_DATA_FILE,'a+')
                self.cache_CAN_data(can_data_file)
    
                # open the file with append mode and write all other data to it
                other_data_file = open(OTHER_DATA_FILE,'a+')
                self.cache_other_data(other_data_file)  
           
                # post data from the cache files
                self.post_CAN_data(can_data_file)
                self.post_other_data(other_data_file)
                    
                #close the files
                can_data_file.close()
                other_data_file.close()
                
                #if c==4:
                    #print("stopping threads")
                    #self.event.clear()
                    #c=0
                
                #c += 1
                
                #sleep
                time.sleep(API_POST_TIMER)
                
                
        except KeyboardInterrupt:
            print("CTRL-C detected, attempting to close threads")
            
            self.event.clear()
            # Wait for other threads to finish
            self.can0.join()
            self.can1.join()
            self.temp.join()
            self.volt.join()
            
            print("threads closed")
            
        except:
            print("Unexpected error:", str(sys.exc_info()[0]))
            pass    
   
   
# Create the application   
app = NanoSoftReader()     

# dramatic pause!
time.sleep(1)

# Run the Application        
app.run()
