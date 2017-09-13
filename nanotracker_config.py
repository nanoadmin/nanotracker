
DEVICE_ID = "auto01"
CACHE_FILE_PATH = "/home/pi/Desktop/Zagro/"

CAN_DATA_FILE = CACHE_FILE_PATH + DEVICE_ID + "_can_data.txt"
OTHER_DATA_FILE = CACHE_FILE_PATH + DEVICE_ID + "_other_data.txt"

IS_DUAL_CAN = False # if this is the sinlge CAN device then we will mark this as false
                   
CAN_RECEIVER_API = "http://devbox2.nanosoft.com.au:9000/api/canreceiver"# old port : 8082
DATA_RECEIVER_API = "http://devbox2.nanosoft.com.au:9000/api/canreceiver"


API_POST_TIMER = 5  # number of seconds between each post request to the api

IS_DUAL_CAN = True # if this is the sinlge CAN device then we will mark this as false
#below, even if the canbus is not going to be used, please give it a summy name and bitrate
CAN0_NAME = 'can0'
CAN0_BITRATE = 125000
CAN1_NAME = 'can1'
CAN1_BITRATE = 500000

MAX_CACHE_READ_LINES = 1000   # the number of lines in the cache file to read for posting

VOLTFACTOR_BATTERY = 14.90/20283
VOLTFACTOR_PI = 5.1/17495


REQUEST_HEADERS = {
    'cache-control': "no-cache",
    'Content-Type': 'text/plain'
}