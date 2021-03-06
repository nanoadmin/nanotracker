

import sys
#print the python version (more needed for troubleshooting with WINGED IDE)
print ("Python Version: {0}".format(str(sys.version)))


#imported libs
import threading
import time
import os
import traceback
import requests

#import custom libs

from  sensors import CAN_reader
from  sensors import temp_reader
from  sensors import volt_reader
from  sensors import acc_reader
from  sensors import gps_reader


import nanotracker_config as config

class NanoSoftReader:
    def __init__(self):              
        
        #this is a test comment for github branch management
        
        # Create an event object used to send events to sub-threads
        self.event = threading.Event()
        self.event.set()

        # make sure the cache files are empty to start with (may not want to do this???)
        open(config.CAN_DATA_FILE, 'w').close()
        open(config.OTHER_DATA_FILE, 'w').close()
        open(config.GPS_DATA_FILE, 'w').close()

        # Create the CAN Reader Threads
        self.can0 = CAN_reader.CANReceiver(config.CAN0_NAME, config.CAN0_BITRATE, self.event, 1,True)#can0 is always active
        self.can0.start()
        self.can1 = CAN_reader.CANReceiver(config.CAN1_NAME, config.CAN1_BITRATE, self.event, 1, config.IS_DUAL_CAN)
        self.can1.start()
        
        #TODO: uncomment outr below
        # Create the Temp Reader Threadssh pi
        self.temp = temp_reader.TempReader(self.event, 1)
        self.temp.start()

        # Create the Voltage Reader Thread
        self.volt = volt_reader.VoltReader(self.event, 1,config.VOLTFACTOR_BATTERY,config.VOLTFACTOR_PI)
        self.volt.start()

        # Create the accelerometer Reader Thread
        self.acc = acc_reader.AccReader(self.event, 1, config.ACC_READER_ADDRESS)
        self.acc.start()
        
        # Create the GPS Reader Thread
        self.gps = gps_reader.GpsReader(self.event, 1, not config.IS_DUAL_CAN)
        self.gps.start()        
        
        self.lastRestartTime = int(time.time())

    
    
    
    # ----------------------------------------------------------------------
    # Function to POST the CAN data to the API from the cache file.
    # Upon a 200 response, the file will be cleared.
    # @TODO: Set a limit on the length of the file to read in case 
    #        the file is too large
    # ----------------------------------------------------------------------
    def post_CAN_data(self):
        
        print('reading CAN Data')

        # Get the messages from the sub threads
        can0_messages = self.can0.read_messages()
        can1_messages = self.can1.read_messages()
        
        print('\'{0}\' has {1} values \n\'{2}\' has {3} values'.format(self.can0.channel, len(can0_messages) 
                                                                     ,self.can1.channel, len(can1_messages) ))        
        
        #if it has been more than X seconds since the last can restart then we
        #would restart the can interface if there are no values AND the other can device is returning values
        secondsSinceLastRestart = int(time.time()) - self.lastRestartTime
        deadCanbusGracePeriodExceeded = secondsSinceLastRestart >= 10
        
        if config.IS_DUAL_CAN:            
        
            #if one CANbus has messages but the other does not, then the bus may be down
            can0HasMessages = len(can0_messages) > 0
            can1HasMessages = len(can1_messages) > 0
            
            if can0HasMessages and not can1HasMessages and deadCanbusGracePeriodExceeded:
                self.can1.ReEstablishConnection()
                
            if can1HasMessages and not can0HasMessages and deadCanbusGracePeriodExceeded:
                self.can0.ReEstablishConnection()              
        

        # extract all the unique timestamps from each message dictionary
        timestamps = sorted(set(
            list(can0_messages.keys()) +
            list(can1_messages.keys())))

        # construct the message string
        new_msg_string = ""
        for ts in timestamps:

            new_msg_string += "time:" + ts + "\n"

            # check if there is can0 data for this timestamp
            if ts in can0_messages:
                new_msg_string += "can:{0}\n".format(config.CAN0_STANDARD)
                for msg in can0_messages[ts]:
                    new_msg_string += str(msg) + "\n"

                    # check if there is can1 data for this timestamp
            if ts in can1_messages:                
                new_msg_string += "can:{0}\n".format(config.CAN1_STANDARD)
                for msg in can1_messages[ts]:
                    new_msg_string += str(msg) + "\n"

        # Check to see if there is anything in the cache file
        if os.stat(config.CAN_DATA_FILE).st_size > 0:
            print("Data already exists in cache file")
            lines_to_read = []

            # Data exists in the cache file, add the new_message_string to the end of it
            self.cache_CAN_data(new_msg_string)

            # Now read N lines of data from the beginning of the file, and remove those lines
            with open(config.CAN_DATA_FILE) as f, open(config.CACHE_FILE_PATH + 'tmp_can_cache.txt', 'w') as out:

                # read the top MAX_CACHE_READ_LINES to array
                for x in range(config.MAX_CACHE_READ_LINES):
                    line = next(f, None)
                    if line is None:        # end of file
                        break

                    lines_to_read.append(line)

                #  write the rest of the lines to a temp file
                for line in f:
                    out.write(line)

            # rename the temp file as the cache file
            os.remove(config.CAN_DATA_FILE)
            os.rename(config.CACHE_FILE_PATH + 'tmp_can_cache.txt', config.CAN_DATA_FILE)

            # join the array of lines together to form the message_str
            msg_string = "".join(lines_to_read)
        else:
            # Cache file is empty, just send the new_message_str
            msg_string = new_msg_string

        try:
            # Attempt to post data if string is not empty
            if msg_string:
                post_data = "deviceid:" + config.DEVICE_ID + "\n" + msg_string
                response = requests.post(config.CAN_RECEIVER_API, data=post_data, headers=config.REQUEST_HEADERS)

                if (response.status_code == 200):
                    print(' - success')
                else:
                    print(' - failed')
                    print('status code: ', response.status_code)
                    # write msg_str to file
                    self.cache_CAN_data(msg_string)

        except:
            print("Unexpected error:", sys.exc_info()[0])

            # write msg_str to file
            self.cache_CAN_data(msg_string)

            # traceback.print_exc()
            pass  # don't stop script

        # try:
        #     can_data_file.seek(0)
        #     data = "deviceid:" + DEVICE_ID + "\n" + can_data_file.read()
        #     response = requests.post(CAN_RECEIVER_API, data=data, headers=REQUEST_HEADERS)
        # #
        #     if (response.status_code == 200):
        #         print(' - success')
        #         # clear the file if successful post
        #         open(CAN_DATA_FILE, 'w').close()
        #     else:
        #         print(' - failed')
        #         print('status code: ', response.status_code)
        #         # don't clear the file
        # #
        # except:
        #     print(' - failed')
        #     print("Unexpected error:", sys.exc_info()[0])
        #     pass  # don't stop script

    # ----------------------------------------------------------------------
    # Function to POST the other data (temperature, voltage, [GPS,Accelerometer] to the API
    # Upon a 200 response, the file will be cleared.pa
    # @TODO: Set a limit on the length of the file to read in case 
    #        the file is too large
    # ----------------------------------------------------------------------
    def post_other_data(self):
        
        print('posting other data')

        temp_messages = self.temp.read_messages()
        volt_messages = self.volt.read_messages()
        
        # extract all the unique timestamps from each message dictionary
        timestamps = sorted(set(
            list(volt_messages.keys()) +            
            list(temp_messages.keys()))) 
            #list(acc_messages.keys())))

        new_msg_string = ""
        
        for ts in timestamps:
            new_msg_string += "time:" + ts + "\n"
            new_msg_string += "can:nano1000\n"

            # check if there is a temp for this timestamp
            if ts in temp_messages:
                new_msg_string +=  str(temp_messages[ts]) + "\n"

            # check if there is a volt for this timestamp
            if ts in volt_messages:
                new_msg_string += str(volt_messages[ts]) + "\n"              
                   
           

        # Check to see if there is anything in the cache file
        if os.stat(config.OTHER_DATA_FILE).st_size > 0:
            print("Data already exists in cache file")
            lines_to_read = []

            # Data exists in the cache file, add the new_message_string to the end of it
            self.cache_other_data(new_msg_string)

            # Now read N lines of data from the beginning of the file, and remove those lines
            with open(config.OTHER_DATA_FILE) as f, open(config.CACHE_FILE_PATH + 'tmp_other_cache.txt', 'w') as out:

                # read the top MAX_CACHE_READ_LINES to array
                for x in range(config.MAX_CACHE_READ_LINES):
                    line = next(f, None)
                    if line is None:        # end of file
                        break

                    lines_to_read.append(line)

                # write the rest of the lines to a temp file
                for line in f:
                    out.write(line)

            # rename the temp file as the cache file
            os.remove(config.OTHER_DATA_FILE)
            os.rename(config.CACHE_FILE_PATH + 'tmp_other_cache.txt', config.OTHER_DATA_FILE)

            # join the array of lines together to form the message_str
            msg_string = "".join(lines_to_read)
        else:
            # Cache file is empty, just send the new_message_str
            msg_string = new_msg_string

        try:
            # Attempt to post data if string is not empty
            if msg_string:
                post_data = "deviceid:" + config.DEVICE_ID + "\n" + msg_string
                response = requests.post(config.DATA_RECEIVER_API, data=post_data, headers=config.REQUEST_HEADERS)

                if (response.status_code == 200):
                    print(' - success')
                else:
                    print(' - failed')
                    print('status code: ', response.status_code)
                    # write msg_str to file
                    self.cache_other_data(msg_string)

        except:
            print("Unexpected error:", sys.exc_info()[0])

            # write msg_str to file
            self.cache_other_data(msg_string)
            #raise

            #traceback.print_exc()
            pass  # don't stop script

  
   
   
  
    def post_gps_data(self):
        
        print('posting other data')
       
        gps_messages = self.gps.read_messages()

        # extract all the unique timestamps from each message dictionary
        timestamps = sorted(set(list(gps_messages.keys())))
            
        gps_base_msg =  "?truckid={0}&lat={1}&lng={2}&time={3}&i={4}&a={5}&s={6}"        
        post_msg = ""
        
        for key, value in gps_messages.items():
            
            dt = time.strftime('%d/%b/%y %H:%M:%S', time.localtime(int(key)))
            dt = str.replace(dt,' ','%20')              
                        
            lat = value["latitude"]
            lng = value["longitude"]
            
            msg = gps_base_msg.format(config.DEVICE_ID,lat,lng,dt,"0","0","0")
            post_msg = post_msg + msg + ",\n"        
        
        
        if os.stat(config.GPS_DATA_FILE).st_size > 0:
            
            print("Data already exists in cache file")
            lines_to_read = []

            # Data exists in the cache file, add the new_message_string to the end of it
            self.cache_gps_data(post_msg)

            # Now read N lines of data from the beginning of the file, and remove those lines
            with open(config.GPS_DATA_FILE) as f, open(config.CACHE_FILE_PATH + 'tmp_other_cache.txt', 'w') as out:

                # read the top MAX_CACHE_READ_LINES to array
                for x in range(config.MAX_CACHE_READ_LINES):
                    line = next(f, None)
                    if line is None:        # end of file
                        break

                    lines_to_read.append(line)

                # write the rest of the lines to a temp file
                for line in f:
                    out.write(line)

            # rename the temp file as the cache file
            os.remove(config.GPS_DATA_FILE)
            os.rename(config.CACHE_FILE_PATH + 'tmp_other_cache.txt', config.GPS_DATA_FILE)

            # join the array of lines together to form the message_str
            post_msg = "".join(lines_to_read)
        
        
        try:
            # Attempt to post data if string is not empty
            if post_msg:
                
                response = requests.post(config.GPS_RECEIVER_API, data=post_msg, headers=config.REQUEST_HEADERS)

                if (response.status_code == 200):
                    print(' - success')
                else:
                    print(' - failed')
                    print('status code: ', response.status_code)
                    # write msg_str to file
                    self.cache_gps_data(post_msg)

        except:
            print("Unexpected error:", sys.exc_info()[0])   
            self.cache_gps_data(post_msg)
            pass
        
    # ----------------------------------------------------------------------
    # Function to fetch data messages from the sub-threads and write data to 
    # file for caching in case POST requests aren't succesful. 
    # @TODO: may need to implement some filesize management functionality in 
    #        case the API server goes down for a long period of time.
    # ----------------------------------------------------------------------
    def cache_CAN_data(self, msg_string):
        """Caches the can data to file"""
        
        print("Saving data to file")
        can_data_file = open(config.CAN_DATA_FILE, 'a+')
        can_data_file.write(msg_string)
        can_data_file.close()

    

    # ----------------------------------------------------------------------
    # Function to fetch data messages from the sub-threads and write data to
    # file for caching in case POST requests aren't succesful.
    # @TODO: may need to implement some filesize management functionality in 
    #        case the API server goes down for a long period of time.
    # ----------------------------------------------------------------------
    def cache_other_data(self, msg_string):
        """Caches the data to file"""

        print("Saving other data to file")
        other_data_file = open(config.OTHER_DATA_FILE, 'a+')
        other_data_file.write(msg_string)
        other_data_file.close()

    def cache_gps_data(self, msg_string):
        """Caches data to a file"""
        
        print ("saving gps data to file")
        gps_data_file = open(config.GPS_DATA_FILE, 'a+')
        gps_data_file.write(msg_string)
        gps_data_file.close()        
    
    

    # ----------------------------------------------------------------------
    # Function to check if the sub threads are still alive and if not,
    # recreate them.
    # ----------------------------------------------------------------------
    def check_alive(self):
        if not self.can0.is_alive():
            print('ERROR: CAN0_reader not alive, restarting')
            self.event.set()
            self.can0 = CAN_reader.CANReceiver(CAN0_NAME, CAN0_BITRATE, self.event, 1)
            self.can0.start()

        if not self.can1.is_alive():
            print('ERROR: CAN1_reader not alive, restarting')
            self.event.set()
            self.can1 = CAN_reader.CANReceiver(CAN1_NAME, CAN1_BITRATE, self.event, 1)
            self.can1.start()

        if not self.temp.is_alive():
            print('ERROR: temp_reader thread not alive, restarting')
            self.event.set()
            self.temp = temp_reader.TempReader(self.event, 1)
            self.temp.start()

        if not self.volt.is_alive():
            print('ERROR: voltage_reader not alive, restarting')
            self.event.set()
            self.volt = volt_reader.VoltReader(self.event, 1)
            self.volt.start()

        if not self.acc.is_alive():
            print('ERROR: acc_reader not alive, restarting')
            self.event.set()
            self.acc = acc_reader.AccReader(self.event, 1)
            self.acc.start()
        
        if not self.gps.is_alive():
            print('ERROR: acc_reader not alive, restarting')
            self.event.set()
            self.gps = gps_reader.GpsReader(self.event, 1)
            self.gps.start()        

    # ----------------------------------------------------------------------
    # Main application loop
    # 1. Checks if threads are alive
    # 2. Gets data from sub threads and attempts to POST to API
    #   2a. If POST is not successful, save the data to file for attempt in the next loop
    # 4. Repeat after API_POST_TIMER seconds 
    # ----------------------------------------------------------------------
    def run(self):

        try:

            while 1:
                
                print('#####################')

                # check to see if threads are alive
                self.check_alive()
    
                self.post_CAN_data()
                self.post_other_data() 
                self.post_gps_data()

                # sleep
                time.sleep(config.API_POST_TIMER)


        except KeyboardInterrupt:
            print("CTRL-C detected, attempting to close threads")

            self.event.clear()
            # Wait for other threads to finish
            self.can0.join()
            self.can1.join()
            self.temp.join()
            self.volt.join()
            self.acc.join()
            self.gps.join()

            print("threads closed")

        except:
            print("Unexpected error:", str(sys.exc_info()[0]))
            traceback.print_exc()
            raise
            # pass


# Create the application   
app = NanoSoftReader()

# dramatic pause!
time.sleep(1)

# Run the Application        
app.run()
