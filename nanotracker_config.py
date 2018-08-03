
##########################
#                        #
#    GENERAL SETTINGS    #
#                        #
##########################

DEVICE_ID = "uniqco18"
CACHE_FILE_PATH = "/home/advantech/Desktop/cache_files/" #this directory MUST exist or exceptions will be caused

CAN_DATA_FILE = CACHE_FILE_PATH + DEVICE_ID + "_can_data.txt"
OTHER_DATA_FILE = CACHE_FILE_PATH + DEVICE_ID + "_other_data.txt"
GPS_DATA_FILE = CACHE_FILE_PATH + DEVICE_ID + "_gps_data.txt"

IS_DUAL_CAN = False # if this is the sinlge CAN device then we will mark this as false
                   
CAN_RECEIVER_API = "http://uniqco.nanosoft.com.au:9000/api/canreceiver"# old/dev port : 8082
DATA_RECEIVER_API = "http://uniqco.nanosoft.com.au:9000/api/canreceiver"
GPS_RECEIVER_API = "http://uniqco.nanosoft.com.au:9000/api/dataaccess"

GPS_WAIT_TIME_SECONDS = 600 #amount of time to wait before sending another GPS message despite the fact it hasnt moved
GPS_MOVEMENT_DETECTION_METRES = 20 # distance the GPS device needs to move before storing new value

API_POST_TIMER = 5  # number of seconds between each post request to the api

##########################
#                        #
#    CAN BUS SETTINGS    #
#                        #
##########################

CAN0_STANDARD = 'Zagro500'
CAN1_STANDARD = 'Zagro125'

IS_DUAL_CAN = True # if this is the sinlge CAN device then we will mark this as false
#below, even if the canbus is not going to be used, please give it a summy name and bitrate
CAN0_NAME = 'vcan0'
CAN0_BITRATE = 500000
CAN1_NAME = 'vcan1'
CAN1_BITRATE = 125000

MAX_CACHE_READ_LINES = 1000   # the number of lines in the cache file to read for posting


###############################
#                             #
#    OTHER SENSOR SETTINGS    #
#                             #
###############################

VOLTFACTOR_BATTERY = 14.90/20283
VOLTFACTOR_PI = 5.1/17495

ACC_READER_ADDRESS = 0x53 #dual can seems to be 0x53, single can 0x48. Need to confirm this behavior though

REQUEST_HEADERS = {
    'cache-control': "no-cache",
    'Content-Type': 'text/plain'
}


#NOTES:

#username:@dvant3ch,password:123456

# Download	the	Python-CAN	files	from:
# https://bitbucket.org/hardbyte/python-can/get/4085cffd2519.zip
# Unzip	and	install	by
# sudo python3 setup.py install
# Bring	the	CAN	interface up if	it	is	not	already	done:
# sudo /sbin/ip link set can0 up type can bitrate 500000 

#sudo apt-get install can-utils

#smbus commands
# sudo apt-get install i2c-tools libi2c-dev python-dev python3-dev
# sudo apt-get install python3-smbus

#microstack install 
# sudo apt-get install python3-microstacknode
# sudo apt-get install gpsd gpsd-clients python-gps

#modbus install material 
# sudo -H pip install  -U pymodbus

#to install pip3 and requests etc
#
#  sudo apt-get install python3-pip
#  
#  sudo pip3 install requests 
#  
#  sudo pip3 install python-can
#
#  sudo pip3 install pyserial  # please note, do NOT accidently install serial, it is pyserial
#
#
# enable auto-starting of broadband connection in ubuntu (for the TREK572):
#  https://askubuntu.com/questions/82255/how-do-i-permanently-enable-mobile-broadband-on-boot
#  https://www.raspberrypi.org/forums/viewtopic.php?f=63&t=29676
#
#
#  remot3.it commands
#
#  instructions can be foud here : file:///C:/Users/gardda9/Downloads/Installing%20the%20remot3.it%20connectd%20daemon%20on%2032-bit%20Ubuntu%20(1).pdf
#
#  wget https://github.com/weaved/installer/raw/master/Raspbian%20deb/1.3-08/connectd_1.3-08e_i386.deb
#  sudo apt-get install curl
#  sudo dpkg -i <<package name>>
#    
#  developerid : RDg4QkMyMzEtRTYxQy00MEZBLThBMDUtQTA5QkQyOTQ0OUU3
#
#
# sudo scp nanosoft@daveshouse.nanosoft.com.au:/home/nanosoft/Desktop/rc.local /etc/rc.local
#
#
#
#
#
#
#
#
#
#
