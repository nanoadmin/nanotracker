import threading
import time
import CAN_reader
import temp_reader
import volt_reader
import acc_reader
import requests

import os
import sys
import traceback

print (sys.version)

DEVICE_ID = "auto01"
CACHE_FILE_PATH = "/home/pi/Desktop/Zagro/"
CAN_DATA_FILE = CACHE_FILE_PATH + DEVICE_ID + "_can_data.txt"
OTHER_DATA_FILE = CACHE_FILE_PATH + DEVICE_ID + "_other_data.txt"
# CAN_RECEIVER_API = "http://demo.nanosoft.com.au:8082/api/canreceiver"
CAN_RECEIVER_API = "http://188.166.243.212:1234/api/canreceiver"
DATA_RECEIVER_API = "http://188.166.243.212:1234/api/datareceiver"
API_POST_TIMER = 5  # number of seconds between each post request to the api

CAN0_NAME = 'can0'
CAN0_BITRATE = 125000
CAN1_NAME = 'can1'
CAN1_BITRATE = 500000

MAX_CACHE_READ_LINES = 1000   # the number of lines in the cache file to read for posting

REQUEST_HEADERS = {
    'cache-control': "no-cache",
    'Content-Type': 'text/plain'
}


class NanoSoftReader:
    def __init__(self):
        # Create an event object used to send events to sub-threads
        self.event = threading.Event()
        self.event.set()

        # make sure the cache files are empty to start with (may not want to do this???)
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

        # Create the Voltage Reader Thread
        self.volt = volt_reader.VoltReader(self.event, 1)
        self.volt.start()

        # Create the GPS Reader Thread
        self.acc = acc_reader.AccReader(self.event, 1)
        self.acc.start()

    # ----------------------------------------------------------------------
    # Function to POST the CAN data to the API from the cache file.
    # Upon a 200 response, the file will be cleared.
    # @TODO: Set a limit on the length of the file to read in case 
    #        the file is too large
    # ----------------------------------------------------------------------
    def post_CAN_data(self):
        print('posting CAN Data')

        # Get the messages from the sub threads
        can0_messages = self.can0.read_messages()
        can1_messages = self.can1.read_messages()

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
                new_msg_string += "can:Zagro125\n"
                for msg in can0_messages[ts]:
                    new_msg_string += str(msg) + "\n"

                    # check if there is can1 data for this timestamp
            if ts in can1_messages:
                new_msg_string += "can:Zagro500\n"
                for msg in can1_messages[ts]:
                    new_msg_string += str(msg) + "\n"

        # Check to see if there is anything in the cache file
        if os.stat(CAN_DATA_FILE).st_size > 0:
            print("Data already exists in cache file")
            lines_to_read = []

            # Data exists in the cache file, add the new_message_string to the end of it
            self.cache_CAN_data(new_msg_string)

            # Now read N lines of data from the beginning of the file, and remove those lines
            with open(CAN_DATA_FILE) as f, open(CACHE_FILE_PATH + 'tmp_can_cache.txt', 'w') as out:

                # read the top MAX_CACHE_READ_LINES to array
                for x in range(MAX_CACHE_READ_LINES):
                    line = next(f, None)
                    if line is None:        # end of file
                        break

                    lines_to_read.append(line)

                #  write the rest of the lines to a temp file
                for line in f:
                    out.write(line)

            # rename the temp file as the cache file
            os.remove(CAN_DATA_FILE)
            os.rename(CACHE_FILE_PATH + 'tmp_can_cache.txt', CAN_DATA_FILE)

            # join the array of lines together to form the message_str
            msg_string = "".join(lines_to_read)
        else:
            # Cache file is empty, just send the new_message_str
            msg_string = new_msg_string

        try:
            # Attempt to post data if string is not empty
            if msg_string:
                post_data = "deviceid:" + DEVICE_ID + "\n" + msg_string
                response = requests.post(CAN_RECEIVER_API, data=post_data, headers=REQUEST_HEADERS)

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
    # Upon a 200 response, the file will be cleared.
    # @TODO: Set a limit on the length of the file to read in case 
    #        the file is too large
    # ----------------------------------------------------------------------
    def post_other_data(self):
        print('posting other data')

        temp_messages = self.temp.read_messages()
        volt_messages = self.volt.read_messages()
        acc_messages = self.acc.read_messages()

        # extract all the unique timestamps from each message dictionary
        timestamps = sorted(set(
            list(volt_messages.keys()) +
            list(temp_messages.keys()) +
            list(acc_messages.keys())))

        new_msg_string = ""
        for ts in timestamps:
            new_msg_string += "time:" + ts + "\n"

            # check if there is a temp for this timestamp
            if ts in temp_messages:
                new_msg_string += "temp:" + str(temp_messages[ts]) + "\n"

                # check if there is a volt for this timestamp
            if ts in volt_messages:
                new_msg_string += "volt:" + str(volt_messages[ts]) + "\n"

                # check if there is a volt for this timestamp
            if ts in acc_messages:
                new_msg_string += "axis:" + str(acc_messages[ts]) + "\n"

        # Check to see if there is anything in the cache file
        if os.stat(OTHER_DATA_FILE).st_size > 0:
            print("Data already exists in cache file")
            lines_to_read = []

            # Data exists in the cache file, add the new_message_string to the end of it
            self.cache_other_data(new_msg_string)

            # Now read N lines of data from the beginning of the file, and remove those lines
            with open(OTHER_DATA_FILE) as f, open(CACHE_FILE_PATH + 'tmp_other_cache.txt', 'w') as out:

                # read the top MAX_CACHE_READ_LINES to array
                for x in range(MAX_CACHE_READ_LINES):
                    line = next(f, None)
                    if line is None:        # end of file
                        break

                    lines_to_read.append(line)

                # write the rest of the lines to a temp file
                for line in f:
                    out.write(line)

            # rename the temp file as the cache file
            os.remove(OTHER_DATA_FILE)
            os.rename(CACHE_FILE_PATH + 'tmp_other_cache.txt', OTHER_DATA_FILE)

            # join the array of lines together to form the message_str
            msg_string = "".join(lines_to_read)
        else:
            # Cache file is empty, just send the new_message_str
            msg_string = new_msg_string

        try:
            # Attempt to post data if string is not empty
            if msg_string:
                post_data = "deviceid:" + DEVICE_ID + "\n" + msg_string
                response = requests.post(DATA_RECEIVER_API, data=post_data, headers=REQUEST_HEADERS)

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
        # try:
        #     other_data_file.seek(0)
        #     data = "deviceid:" + DEVICE_ID + "\n" + other_data_file.read()
        #     response = requests.post(DATA_RECEIVER_API, data=data, headers=REQUEST_HEADERS)
        #
        #     if (response.status_code == 200):
        #         print(' - success')
        #         # clear the file if successful post
        #         open(OTHER_DATA_FILE, 'w').close()
        #
        #     else:
        #         print(' - failed')
        #         print('status code: ', response.status_code)
        #         # don't clear the file
        #         # leave the post toggle
        # except:
        #     print(' - failed')
        #     print("Unexpected error:", sys.exc_info()[0])
        #     pass  # don't stop script

    # ----------------------------------------------------------------------
    # Function to fetch data messages from the sub-threads and write data to 
    # file for caching in case POST requests aren't succesful. 
    # @TODO: may need to implement some filesize management functionality in 
    #        case the API server goes down for a long period of time.
    # ----------------------------------------------------------------------
    def cache_CAN_data(self, msg_string):
        """Caches the data to file"""
        
        print("Saving data to file")
        can_data_file = open(CAN_DATA_FILE, 'a+')
        can_data_file.write(msg_string)
        can_data_file.close()

        # can0_messages = self.can0.read_messages()
        # can1_messages = self.can1.read_messages()
        #
        # # extract all the unique timestamps from each message dictionary
        # timestamps = sorted(set(
        #     list(can0_messages.keys()) +
        #     list(can1_messages.keys())))
        #
        # # write data to file
        # for ts in timestamps:
        #
        #     can_data_file.write("time:" + ts + "\n")
        #
        #     # check if there is can0 data for this timestamp
        #     if ts in can0_messages:
        #         can_data_file.write("can:Zagro125\n")
        #         for msg in can0_messages[ts]:
        #             can_data_file.write(str(msg) + "\n")
        #
        #             # check if there is can1 data for this timestamp
        #     if ts in can1_messages:
        #         can_data_file.write("can:Zagro500\n")
        #         for msg in can1_messages[ts]:
        #             can_data_file.write(str(msg) + "\n")

    # ----------------------------------------------------------------------
    # Function to fetch data messages from the sub-threads and write data to
    # file for caching in case POST requests aren't succesful.
    # @TODO: may need to implement some filesize management functionality in 
    #        case the API server goes down for a long period of time.
    # ----------------------------------------------------------------------
    def cache_other_data(self, msg_string):
        """Caches the data to file"""

        print("Saving data to file")
        other_data_file = open(OTHER_DATA_FILE, 'a+')
        other_data_file.write(msg_string)
        other_data_file.close()

        # temp_messages = self.temp.read_messages()
        # volt_messages = self.volt.read_messages()
        # acc_messages = self.acc.read_messages()
        #
        # # extract all the unique timestamps from each message dictionary
        # timestamps = sorted(set(
        #     list(volt_messages.keys()) +
        #     list(temp_messages.keys()) +
        #     list(acc_messages.keys())))
        #
        # for ts in timestamps:
        #     other_data_file.write("time:" + ts + "\n")
        #
        #     # check if there is a temp for this timestamp
        #     if ts in temp_messages:
        #         other_data_file.write("temp:" + str(temp_messages[ts]) + "\n")
        #
        #         # check if there is a volt for this timestamp
        #     if ts in volt_messages:
        #         other_data_file.write("volt:" + str(volt_messages[ts]) + "\n")
        #
        #         # check if there is a volt for this timestamp
        #     if ts in acc_messages:
        #         other_data_file.write("axis:" + str(acc_messages[ts]) + "\n")

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

                # with open(CAN_DATA_FILE, 'a+') as can_data_file, \
                #      open(OTHER_DATA_FILE, 'a+') as other_data_file:
                #
                #     # write data to cache files
                #     self.cache_CAN_data(can_data_file)
                #     self.cache_other_data(other_data_file)
                #
                #     # post data from the cache files
                #     self.post_CAN_data(can_data_file)
                #     self.post_other_data(other_data_file)

                # sleep
                time.sleep(API_POST_TIMER)


        except KeyboardInterrupt:
            print("CTRL-C detected, attempting to close threads")

            self.event.clear()
            # Wait for other threads to finish
            self.can0.join()
            self.can1.join()
            self.temp.join()
            self.volt.join()
            self.acc.join()

            print("threads closed")

        except:
            print("Unexpected error:", str(sys.exc_info()[0]))
            traceback.print_exc()
            # pass


# Create the application   
app = NanoSoftReader()

# dramatic pause!
time.sleep(1)

# Run the Application        
app.run()
