
DEVICE_ID = "auto01"
CACHE_FILE_PATH = "/home/pi/Desktop/Zagro/"

CAN_DATA_FILE = CACHE_FILE_PATH + DEVICE_ID + "_can_data.txt"
OTHER_DATA_FILE = CACHE_FILE_PATH + DEVICE_ID + "_other_data.txt"

                   
CAN_RECEIVER_API = "http://demo.nanosoft.com.au:9000/api/canreceiver"# old port : 8082
DATA_RECEIVER_API = "http://demo.nanosoft.com.au:9000/api/canreceiver"


API_POST_TIMER = 5  # number of seconds between each post request to the api

CAN0_NAME = 'can0'
CAN0_BITRATE = 500000
CAN1_NAME = 'can1'
CAN1_BITRATE = 500000

MAX_CACHE_READ_LINES = 1000   # the number of lines in the cache file to read for posting

REQUEST_HEADERS = {
    'cache-control': "no-cache",
    'Content-Type': 'text/plain'
}