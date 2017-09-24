###############################################################################
#                   Nanosoft Fleet Management Systen
#                     Nano Tracker Python Script
###############################################################################
#
#       Version:        20160808
#       Date:           1 March 2016
#       Last Update:    8 November 2016
#
#
###############################################################################
import datetime 
import time
import requests
import pickle 
import microstacknode.hardware.gps.l80gps
from datetime import datetime, timedelta
import urllib.request as ur
import urllib.parse
import urllib
import socket
REMOTE_SERVER = 'www.google.com'
import json

from ctypes import string_at
from sys import getsizeof
from binascii import hexlify

import signal
import sys
import struct
import pigpio

##############################################################################################################
#                       INTERNAL FUNCTIONS
##############################################################################################################

from RdCfg import GetUniqueGlobalParameter
#from LED import *

###############################################################################
#                           GLOBAL CONSTANTS
#
###############################################################################

#   BASE_URL = "http://ppjs.nanosoft.com.au:9000/api/dataaccess?truckid={0}&lat={1}&lng={2}&time={3}&i={4}&a={5}"

POST_URL = "http://demo.nanosoft.com.au:9000/api/dataaccess"
BASE_URL = "?truckid={0}&lat={1}&lng={2}&time={3}&i={4}&a={5}&s={6}"
#BASE_URL_MSG = "http://cannon.nanosoft.com.au:9000/api/dataaccess?truckid={0}&msg={1}"
#POST_URL = "http://cannon.nanosoft.com.au:9000/api/dataaccess"
BASE_URL_MSG = POST_URL + "?truckid={0}&msg={1}"


###############################################################################
#           GLOBAL CONSTANTS REQUIRING CONFIGURATION
#
###############################################################################

TRUCK_ID_OLD = 'TRUCK_UID'
HWVer_OLD    = 'IV'             #   Hardware Version
SoftVer_OLD  = ' IV-20160808'   #   Software Version
SerialNo_OLD = '201607_0XX'     #   Device Serial Number
LEDType_OLD  = 'CATHODE'        #   LED Type are common ANODE or CATHODE ('CATHODE' or 'ANODE')

#           NEW GLOBAL PARAMETER ARE READ FROM A FILE

TRUCK_ID_    = []               #   Empty lists for Global Variables in configuration file
HWVer_       = []
SoftVer_     = []
SerialNo_    = []
LEDType_     = []
M_D_         = []

CfgRead = GetUniqueGlobalParameter(TRUCK_ID_,HWVer_,SoftVer_,SerialNo_,LEDType_,M_D_)

TRUCK_ID            = TRUCK_ID_[0]      #    Extract variable from their lists.
HWVer               = HWVer_[0]
SoftVer             = SoftVer_[0]
SerialNo            = SerialNo_[0]
LEDType             = LEDType_[0]
MOVEMENT_DISTANCE   = float(M_D_[0])    #    0.0009 is ~ 100m in GPS co-ordinate system.

ON  = 1
OFF = 0
if(LEDType == 'CATHODE'):    
    OFF = 1                 # LED Type is a Common Cathode so invert LED power. 
    ON  = 0
   
###############################################################################
#                           GLOBAL CONSTANTS
#
###############################################################################

GPS_UPDATE_SPEED_SECONDS = 0
                            #   Set the number of seconds/10 to allow the 3G and GPS to stabilise.
StartDelay = 10             #   2 seconds + boot time of 30 seconds.
                            #   The distance the car must move before a movement sample is sent
                            #   0.00009 is approximately 10 meters
ErrorQty = 1000             #   Quantity of GPS Exceptions counted before sending to the website.

ZERO = 0                    #   Speed reference when the vehicle is not mooving.

#MOVEMENT_DISTANCE = 0.0009  #   0.0009 is ~ 100m in GPS co-ordinate system.

                            #   Set the number of half seconds before a GPS read while ignition is off

ParkedSample = 50           #   20 x 0.5 = 10 seconds.
                            #   ParkedSample = 2#20    # 20 x 0.5 = 10 seconds.
                            #   Send "Parked Sample" message every 60 Seconds.
PSMsg = 100

                            #   PSMsg = 226
                            #   Set the number of second before a forced GPS Sample is performed.
ForceSampleTime = 400
                            #   ForceSampleTime = 9
                            #   Used to turn LED ON
 
TOGGLE = 2

RED_LED = 21                #   Red LED is connected to GPIO 12
RED = 21  
BLUE_LED = 16               #   Blue LED is connected to GPIO 16
BLUE = 16 
GREEN_LED = 20              #   Green LED is connected to GPIO 20
GREEN = 20 
#CYAN = 28                  #   CYAN is a conbination of RED and BLUE
#LED_POWER = 19             #   LED Power is connected to GPIO 19 used to provide power for all LED's
LED_POWER = 12              #   LED Power is relocated for the RIO E-maxiRED_LED = 21                #   Red LED is connected to GPIO 12

CLEAR = 8
STATES = 0                  #   Variable to keep track of LED states.
                                                     
# Standard Nano-Tracker ignition pin conection IGNITION = 21               #   Ignition LED is connected to GPIO 21                
IGNITION = 19               #   Ignition input for the E-maxi Nano-Tracker
HEADLIGHT_FW = 23           #   E-maxi top head lights.
HEADLIGHT_BW = 22           #   E-maxi reedswitch
GPIO_SPARE = 13
#ALARM = 6

                            #   Create an instance of Class pigpio called pi

###############################################################################
#    Initialise GPIO inputs and output pins and Class instance
###############################################################################

pi = pigpio.pi()

pi.set_mode( RED_LED, pigpio.OUTPUT)            #   GPIO  12 as output
pi.set_mode( BLUE_LED, pigpio.OUTPUT)           #   GPIO  16 as output
pi.set_mode( GREEN_LED, pigpio.OUTPUT)          #   GPIO  20 as output
pi.set_mode( IGNITION, pigpio.INPUT)            #   GPIO  21 as input
pi.set_pull_up_down(IGNITION, pigpio.PUD_DOWN)  #   Ignition is off
#pi.set_mode( ALARM, pigpio.INPUT)               #   GPIO  6 as input
#pi.set_pull_up_down(ALARM, pigpio.PUD_DOWN)     #   Alarm is off
pi.set_mode( HEADLIGHT_FW, pigpio.INPUT)            #   GPIO  6 as input
pi.set_pull_up_down(HEADLIGHT_FW, pigpio.PUD_DOWN)  #   HEADLIGHT_FW are off
pi.set_mode( HEADLIGHT_BW, pigpio.INPUT)            #   GPIO  19 as input
pi.set_pull_up_down(HEADLIGHT_BW, pigpio.PUD_DOWN)  #   HEADLIGHT_BW are off

###############################################################################
#                           getGPSTime
# Takes stupid time and date format from GPS and converts to an actual date
###############################################################################

def getGPSTime(dateStr, timeStr):

    utc_str = str(timeStr)

    if len(utc_str) == 3:           #  Make adjustment for 12:00 Midnight GMT
        utc_str = "0" + utc_str

    if len(utc_str) == 4:           #  Make adjustment for the fors 60 Seconds after Midnight
        utc_str = "0" + utc_str

    if len(utc_str) == 5:           #  Make adjustment for the first 9 minutes after midnight
        utc_str = "0" + utc_str

    if len(utc_str) == 6:
        utc_str = "0" + utc_str
    
    if len(utc_str) == 7:
        utc_str = "0" + utc_str

    utc_hours = int(utc_str[0:2])       #Get the hour, minutes and seconds from the utc number
    utc_mins = int(utc_str[2:4])
    utc_sec = int(utc_str[4:6])

                            
    utc_year = int(dateStr[4:6]) + 2000
    utc_month = int(dateStr[2:4])       #Get the year, month, day from the GPS format
    utc_day = int(dateStr[0:2])

    tempdate = datetime(year=utc_year, month=utc_month, day=utc_day,second=utc_sec,minute=utc_mins,hour=utc_hours)
    tempdate = tempdate + timedelta(hours=8)

    dt = tempdate.strftime('%d/%b/%y %H:%M:%S')
    dt = str.replace(dt,' ','%20')

    return dt
      
###############################################################################
#                           pickleListCreate
# 
###############################################################################

dataCacheList = []
def CheckPickleFile():
    STATES = 0                              #   Variable to keep track of LED states.  
    try:
        with open('/home/pi/Desktop/Data/dataCacheList.pickle', 'rb') as Filepointer:
#        with open('dataCacheList.pickle', 'rb') as Filepointer:
            Filepointer.close()
            FlashGreen(0.1)
            time.sleep(0.1) 
            FlashGreen(0.1)
            time.sleep(0.1) 
            FlashGreen(0.1)
            time.sleep(0.1) 
            FlashGreen(0.1)
            time.sleep(0.1) 
            FlashGreen(0.1)
            printf("Info: dataCacheList was opened and closed successfully",3,1)
    except Exception as e:
            FlashRed(0.1)
            time.sleep(0.1) 
            FlashRed(0.1)
            time.sleep(0.1) 
            FlashRed(0.1)
            time.sleep(0.1) 
            FlashRed(0.1)
            time.sleep(0.1) 
            FlashRed(0.1)
            time.sleep(1)
            printf("Warning: dataCacheList FAILED open close test",3,1)
            printf(str(e),3,1)
            STATES = Toggle_LED(CLEAR,STATES)       #   Precautionary LED Clear.
            return 0
#def pickleListCreate(dcl):
#  
##    with open('/home/pi/Desktop/Data/dataCacheList.pickle', 'wb') as handle:
#    with open('dataCacheList.pickle', 'wb') as handle:
#        pickle.dump(dcl, handle)

def pickleListFileSave(GPSData):

#    with open('dataCacheList.pickle', 'wb') as Filepointer:
    with open('/home/pi/Desktop/Data/dataCacheList.pickle', 'wb') as Filepointer:
#        Filepointer = open('dataCacheList.pickle', 'wb')
        pickle.dump(GPSData, Filepointer)
        Filepointer.close()
    
def pickleListGet():
    STATES = 0                              #   Variable to keep track of LED states.  
    try:

#        printf('-1-',3,1)
        with open('/home/pi/Desktop/Data/dataCacheList.pickle', 'rb') as Filepointer:
#        with open('dataCacheList.pickle', 'rb') as Filepointer:
#            printf('-2-',3,1)        
            s = pickle.load(Filepointer)
#            printf('-3-',3,1)
            global dataCacheList
           
            for  member in s: 
                dataCacheList.append(member)
                Filepointer.close()
                
            if((int(len(dataCacheList))) == 0):
                printf(dataCacheList,3,1)
                return 0
#            msg = ('Element 1 : ' + str(dataCacheList[0]) + ' of ' + str(len(dataCacheList)))
            msg = str(msg)
            printf(msg,3,1)
            return int(len(dataCacheList))

    except Exception as e:
        printf(str(e),3,1)
        STATES = Toggle_LED(CLEAR,STATES)       #   Precautionary LED Clear.
        return 0
        
###############################################################################
#                          Internet_Check
# 
###############################################################################        

def Internet_Check(DSP):

    """
    Host: 8.8.8.8 (google-public-dns-a.google.com)
    OpenPort: 53/tcp
    Service: domain (DNS/TCP)
    Set detection failure timeout to 2 seconds.
    """
    try:
        socket.setdefaulttimeout(1) 
        socket.socket(socket.AF_INET, socket.SOCK_STREAM).connect(("8.8.8.8", 53))
        return 'ON'

    except Exception as e:
        if(DSP == 1):
            printf(str(e),3,1)
        return 'OFF'
    
###############################################################################
#                          sendMsgToServer
# 
###############################################################################

#def sendMsgToServer(msg):
def sendMsgToServer(msg,LstSize):
    STATES = 0                                  #   Variable to keep track of LED states.
    ThreeG4G = 'OFF'                            #   Assume 3G4G is OFF and test to se if this is the case. 
    try:
        
        msg1 = ('Sending HTTP msg: ' + msg)
        msg2 = ('ThreeG4G is unavailable message from Vehicle : ' + msg)
        ThreeG4G = Internet_Check(1)
        msg3 = ('In sendMsgToServer 34/4G is : ' + ThreeG4G)
        printf(msg3,3,1)
        msg3 = ('ThreeG4G : ' + ThreeG4G)        
        printf(msg3,3,1)
        msg3 = ('LstSize : ' + str(LstSize))
        printf(msg3,3,1)
        if(LstSize <= 100):
            if(ThreeG4G == 'ON'):
                printf('smts STAGE 1',3,1)
                printf(msg1,3,1)
                sendURL = BASE_URL_MSG.format(TRUCK_ID,msg)
                rsp = requests.get(sendURL,timeout=3)
                printf(rsp,3,1)
            else:
                printf(msg2,3,1)
                printf('smts STAGE 1',3,1)
        elif(LstSize <= 500):
            if(ThreeG4G == 'ON'):
                printf('smts STAGE 2',3,1)
                printf(msg1,3,1)
                sendURL = BASE_URL_MSG.format(TRUCK_ID,msg)
                rsp = requests.get(sendURL,timeout=5)
                printf(rsp,3,1)
            else:
                printf(msg2,3,1)
                printf('smts STAGE 2',3,1)
        elif(LstSize <= 1000):
            if(ThreeG4G == 'ON'):
                printf('smts STAGE 3',3,1)
                printf(msg1,3,1)
                sendURL = BASE_URL_MSG.format(TRUCK_ID,msg)
                rsp = requests.get(sendURL,timeout=10)
                printf(rsp,3,1)
            else:
                printf(msg2,3,1)
                printf('smts STAGE 3',3,1)
        elif(LstSize <= 2500):
            if(ThreeG4G == 'ON'):
                printf('smts STAGE 4',3,1)
                printf(msg1,3,1)
                sendURL = BASE_URL_MSG.format(TRUCK_ID,msg)
                rsp = requests.get(sendURL,timeout=15)
                printf(rsp,3,1)
            else:
                printf(msg2,3,1)
                printf('smts STAGE 4',3,1)
        elif(LstSize >= 2500):
            if(ThreeG4G == 'ON'):
                printf('smts STAGE 5',3,1)
                printf(msg1,3,1)
                sendURL = BASE_URL_MSG.format(TRUCK_ID,msg)
                rsp = requests.get(sendURL,timeout=60)
                printf(rsp,3,1)
            else:
                printf(msg2,3,1)
                printf('smts STAGE 5',3,1)
        
    except Exception as e:
        msg = ('ERROR (smts): ' + str(e))
        printf(msg,3,1)
        STATES = Toggle_LED(CLEAR,STATES)       #   Precautionary LED Clear.
    
###############################################################################
#                            SendDataToCloud
#
#
#
#   Description:    Proceedure SendDataToCloud receives 6 Arguments namely
#                   data,ignition,HeadLightIO,Colour,STATES & Speed        
#
#
#
###############################################################################

def SendDataToCloud(data,ignition,HeadLightIO,Colour,STATES,Speed,LstSize):
 
    if int(data['longitude']) == 12345:
        printf('GPS signal is still stablising',3,1)
        FlashRed(0.1)
    else:
        STATES = Toggle_LED(Colour,STATES)
        
        ThreeG4G = Internet_Check(1)
        msg = ('In SendDataToCloud 34/4G is :'+ str(ThreeG4G))
        printf(msg,3,1)
        try:
            global dataCacheList
        
            if int(data['longitude']) != 12345:
                if int(data['longitude']) == 0:
                    printf('no GPS signal received',3,1) 

                else:
                    datestr = getGPSTime(data['date'],data['utc'])
    
###             print('newest date' + datestr)
            #   add to the cache 
                url = BASE_URL.format(TRUCK_ID,data['latitude'],data['longitude'],datestr,ignitionIO,HeadLightIO,Speed)
            
        
                dataCacheList.append(url)
            
            #   update the file version of the list
#               pickleListCreate(dataCacheList)
                pickleListFileSave(dataCacheList)
                    
###             print('dataCacheList length:' + str(len(dataCacheList)))
###             print('before member in dataCacheList')

#               print(data)
            dCacheListSize = len(dataCacheList)
                
            msg = ('list size:' + str(dCacheListSize))
            printf(msg,3,1)

            if dCacheListSize > 0:
            
                LstSize = int(len(dataCacheList))

#               print(dataCacheList)
                d = ','.join(dataCacheList)
#               print(d)

                r = ur.Request(POST_URL)
            
                CurrentTime = time.strftime('%X %x %Z')
                printf(CurrentTime,3,1)
                if int(data['longitude']) != 12345:
                    printf(datestr,3,1)
            
#                printf('1',3,1)
                r.add_header('Content-Type', 'text/plain')
#                printf('2',3,1)
            #   POST 'd' as text/plain encodes as binary ascii, cast as string. Times out in 5 seconds

#               resp = str(ur.urlopen(r,d.encode('ascii'),timeout=15).read())

                if(ThreeG4G == 'ON'):
                    if(LstSize <= 500):
                        printf('sdtg STAGE 1',3,1)
                        resp = str(ur.urlopen(r,d.encode('ascii'),timeout=5).read())
                    elif(LstSize <= 1000):
                        printf('sdtg STAGE 2',3,1)
                        resp = str(ur.urlopen(r,d.encode('ascii'),timeout=7).read())
                    elif(LstSize <= 1500):
                        printf('sdtg STAGE 3',3,1)
                        resp = str(ur.urlopen(r,d.encode('ascii'),timeout=10).read())
                    elif(LstSize <= 2500):
                        printf('sdtg STAGE 4',3,1)
                        resp = str(ur.urlopen(r,d.encode('ascii'),timeout=15).read())
                    elif(LstSize >= 5000):
                        printf('sdtg STAGE 5',3,1)
                        resp = str(ur.urlopen(r,d.encode('ascii'),timeout=25).read())
                    elif(LstSize >= 15000):
                        printf('sdtg STAGE 6',3,1)
                        resp = str(ur.urlopen(r,d.encode('ascii'),timeout=75).read())
                    elif(LstSize >= 30000):
                        printf('sdtg STAGE 7',3,1)
                        resp = str(ur.urlopen(r,d.encode('ascii'),timeout=150).read())
                    elif(LstSize >= 60000):
                        printf('sdtg STAGE 8',3,1)
                        resp = str(ur.urlopen(r,d.encode('ascii'),timeout=300).read())
                    
                    msg = ('response: ' + str(resp))
                    printf(msg,3,1)
                    if str(resp) == 'b\'success\'':            
###                     print('was successful, deleting list from local cache')
                        del dataCacheList[:]#delete the whole list contents
                        pickleListFileSave('')
                        printf('4',3,1)
                    
                printf('3',3,1)                  

                STATES = Toggle_LED(Colour,STATES)
 
                return LstSize
      
        except Exception as e:
            msg = ('ERROR: (sdtg)' + str(e))
            printf(msg,3,1)
            STATES = Toggle_LED(Colour,STATES)  # Toggle the LED as an exception has occured
            return int(len(dataCacheList))
        
    return LstSize

###############################################################################
#                          getIgnitionIO
# 
###############################################################################
   
def getIgnitionIO():
    if((pi.read(IGNITION)) == 1):               #   print('The ignition is on')
        return 1
    if((pi.read(IGNITION)) == 0):               #   print('The ignition is off')
        return 0

###############################################################################
#                            getHeadLightIO
# 
###############################################################################
    
def getHeadLightIO():
    HeadLightIO = 0
    if((pi.read(IGNITION)) == 1):
        if((pi.read(HEADLIGHT_FW)) == 1):
            HeadLightIO = 1
            printf('The Front Headlights have been turned on',3,1)
            sendMsgToServer('The Front Headlights have been turned on',1)
        else:
            if((pi.read(HEADLIGHT_BW)) == 1):
                HeadLightIO = 2
                printf('The Back Headlights have been turned on',3,1)
                sendMsgToServer('The Back Headlights have been turned on',1)
    return HeadLightIO              #    Value of HeadLightIO is 0,1 or2
                                    #    0 - Both headlight are off
                                    #    1 - Headlights are pointing forward
                                    #    2 - Headlights are pointing backward

###############################################################################
#                            getAlarmIO
# 
###############################################################################
    
def getAlarmIO():
    if((pi.read(IGNITION)) == 0):
        if((pi.read(ALARM)) == 1):
            printf('The Alarm has been triggered',3,1)
            sendMsgToServer('The Alarm has been triggered',1)
            return 1
        else:

            return 0                #   print ('"NO" Alarm')
                                    #   print ('Alarm cannot be triggered')
    if((pi.read(ALARM)) == 1):                                   
        return 1                    #   print('Alarm while moving')
    return 0

###############################################################################
#                            Toggle_LED
# 
###############################################################################
def Toggle_LED(Colour,STATES):
        
    if(Colour == RED):
        if(bin(STATES&1) == '0b1'):         # LED was on so turn it off
            pi.write(RED_LED,ON)
            STATES = STATES - 1             # Set STATES to confirm RED LED is OFF
            if(STATES == 0):
                pi.write(LED_POWER,OFF)     # No LED's are currently on so turn LED power off.
            return STATES
        pi.write(LED_POWER,ON)              # Turn LED power on for RED LED.
        pi.write(RED_LED,OFF)
        STATES = STATES + 1                 # Set STATES to confirm RED LED is ON
        return STATES

    if(Colour == BLUE):
         
        if(bin(STATES&2) == '0b10'):        # LED was on so turn it off
            pi.write(BLUE_LED,ON)
            STATES = STATES - 2             # Set STATES to confirm BLUE LED is OFF
            if(STATES == 0):
                pi.write(LED_POWER,OFF)     # No LED's are currently on so turn LED power off.
            return STATES
        pi.write(LED_POWER,ON)              # Turn LED power on for BLUE LED.
        pi.write(BLUE_LED,OFF)
        STATES = STATES + 2                 # Set STATES to confirm BLUE LED is ON
        return STATES    
   
    if(Colour == GREEN):
        if(bin(STATES&4) == '0b100'):       # LED was on so turn it off
            pi.write(GREEN_LED,ON)
            STATES = STATES - 4             # Set STATES to confirm GREEN LED is OFF
            if(STATES == 0):
                pi.write(LED_POWER,OFF)     # No LED's are currently on so turn LED power off.
            return STATES
        pi.write(LED_POWER,ON)              # Turn LED power on for GREEN LED.
        pi.write(GREEN_LED,OFF)
        STATES = STATES + 4                 # Set STATES to confirm GREEN LED is ON
        return STATES
    
    if(Colour == CYAN):
        if(bin(STATES&8) == '0b1000'):      # LED was on so turn it off
            pi.write(GREEN_LED,ON)
            pi.write(BLUE_LED,ON)
            STATES = STATES - 8             # Set STATES to confirm CYAN LED is OFF
            if(STATES == 0):
                pi.write(LED_POWER,OFF)     # No LED's are currently on so turn LED power off.
            return STATES
        pi.write(LED_POWER,ON)              # Turn LED power on for CYAN LED.
        pi.write(GREEN_LED,OFF)
        pi.write(BLUE_LED,OFF)
        STATES = STATES + 8                 # Set STATES to confirm CYAN LED is ON
        return STATES
    
    if(Colour == CLEAR):    
        STATES = 0
        pi.write(LED_POWER,OFF) 
        pi.write(GREEN_LED,ON)              # Turn All LED's Off
        pi.write(RED_LED,ON)
        pi.write(BLUE_LED,ON)
        return STATES
    
###############################################################################
#                            FlashBlue
###############################################################################
 
def FlashBlue(delay):
    STATES = 0
    STATES = Toggle_LED(BLUE,STATES)    #   Blue LED flash to indicate
    time.sleep(delay)                   #   GPS sampling with ignition ON
    STATES = Toggle_LED(BLUE,STATES)    #   has started
    return 0

###############################################################################
#                            FlashRed
###############################################################################

def FlashRed(delay):
    STATES = 0
    STATES = Toggle_LED(RED,STATES)     #   Blue LED flash to indicate
    time.sleep(delay)                   #   GPS sampling with ignition ON
    STATES = Toggle_LED(RED,STATES)     #   has started
    return 0

###############################################################################
#                            FlashGreen
###############################################################################

def FlashGreen(delay):
    STATES = 0
    STATES = Toggle_LED(GREEN,STATES)   #   Blue LED flash to indicate
    time.sleep(delay)                   #   GPS sampling with ignition ON
    STATES = Toggle_LED(GREEN,STATES)   #   has started
    return 0

###############################################################################
#                            FlashCyan
###############################################################################

def FlashCyan(delay):
    STATES = 0
    STATES = Toggle_LED(BLUE,STATES)    #   Cyan LED flash to indicate
    STATES = Toggle_LED(GREEN,STATES)   #   to indicate ignition has just 
    time.sleep(delay)                   #   been turned OFF/ON and the 
    STATES = Toggle_LED(BLUE,STATES)    #   vehicle has com to a holt.
    STATES = Toggle_LED(GREEN,STATES)
    return 0

###############################################################################
#                            FlashPink
###############################################################################

def FlashPink(delay):
    STATES = 0
    STATES = Toggle_LED(BLUE,STATES)    #   Pink LED flash to indicate
    STATES = Toggle_LED(RED,STATES)     #   to indicate ignition has just
    time.sleep(delay)                   #   been turned OFF/ON and the 
    STATES = Toggle_LED(BLUE,STATES)    #   vehicle has com to a holt.
    STATES = Toggle_LED(RED,STATES)
    return 0
###############################################################################
#                            FlashOrange
###############################################################################
def FlashOrange(delay):
    STATES = 0
    STATES = Toggle_LED(RED,STATES)     #   Blue LED flash to indicate
    STATES = Toggle_LED(GREEN,STATES)
    time.sleep(delay)                   #   GPS sampling with ignition ON
    STATES = Toggle_LED(RED,STATES)     #   has started
    STATES = Toggle_LED(GREEN,STATES)


###############################################################################
#                           StartUpDelay
#
#
#
#   Description:    Is an additional delay that toggles the main BLUE LED ON and OFF 
#                   the number of times defined by the variable delay passe to the
#                   proceedure.
#
#
#
###############################################################################

def StartUpDelay(delay):
    print("Info: A reboot has occurred, wait an additional 10 seconds for 3G and GPS signals to stabilize",end='')     
    printf("Info: A reboot has occurred, wait an additional 10 seconds for 3G and GPS signals to stabilize.........",2,1)
    STATES = 0   # Keeps track of which LED is on
    loop = 0
    while loop <= delay:
        STATES = Toggle_LED(BLUE,STATES)
        print(".",end='')
        time.sleep(0.1)
        STATES = Toggle_LED(BLUE,STATES)
        time.sleep(0.1)
        loop = loop + 1
    print('') # carrige return.
    print('') # carrige return.
    return 0

###############################################################################
#                           HandleException()
#
#
#
#   Description:    Is an additional delay that toggles the main BLUE LED ON and OFF 
#                   the number of times defined by the variable delay passe to the
#                   proceedure.
#
#
#
###############################################################################

def HandleException(ErrorCount,ErrorType1,ErrorType2,SendOff,CheckGPS,ParkedCnt,GPSStable,e,LstSize,ignitionIO):

    ErrorType = str(e)                                      #   Exception received count and handle it

    msg = ('GPS Sensor not Detected!!!')
    if(ErrorType == 'Indicated by data_valid field.'):
        ErrorType1[0] += 1                   #   Count the qiuantity of the verious exceptions
        msg = ('ErrorType1: '+ str(ErrorType1))
        printf(msg,3,1)
    if(ErrorType == 'Timed out before valid \'GPRMC\'.'):
        ErrorType2[0] += 1
        msg = ('ErrorType2: '+ str(ErrorType2))
        printf(msg,3,1)
        
    ErrorCount[0] += 1          
#    msg = ('# # # # Error * * * '+ str(int(ErrorCount[0])) +' * * * Error # # # #')
    printf(msg,3,1)
    
    if(int(ErrorCount[0]) >= ErrorQty):
#    if(int(ErrorCount[0]) >= 10):
        ErrorCntTot[0] = ErrorCntTot[0] + ErrorCount[0]

#        msg = ('Info: ' + str(int(ErrorType2[0])) + ' Exceptions of type" \'Timed out before valid \'GPRMC\'. received.')
#        sendMsgToServer(msg,LstSize)
#        printf(msg,2,1)

#        msg = ('Info: ' + str(int(ErrorType1[0])) + ' Exceptions of type: \'Indicated by data_valid field.\' received.')
#        sendMsgToServer(msg,LstSize)                            
#        printf(msg,2,1)
        
#        msg = ('Info: GPS signal seems unstable: The last ' + str(int(ErrorCntTot[0])) + ' exceptions received, are broken down below:')

        if(ignitionIO == 0):
            msg = ('Info: GPS signal seems unstable: Suspect that the E-maxi is parked under the roof')
            sendMsgToServer(msg,LstSize)
            printf(msg,2,1)
            msg = ('Info: The ignition is OFF')
            sendMsgToServer(msg,LstSize)
            printf(msg,2,1)

        if(ignitionIO == 1):
            msg = ('Info: GPS signal seems unstable: Suspect that the E-maxi is operating under roof conditions')
            sendMsgToServer(msg,LstSize)
            printf(msg,2,1)
            msg = ('Info: The ignition is ON')
            sendMsgToServer(msg,LstSize)
            printf(msg,2,1)
                                   
        ErrorCount[0] = 0
             
    GPSStable[0] = 0                    #   GPS has been found to be Unstable.
    SendOff[0]   = SendOff[0]   + 1
    CheckGPS[0]  = CheckGPS[0]  + 1
    ParkedCnt[0] = ParkedCnt[0] + 1
    FlashRed(0.1)
    FlashCyan(0.1)                      #   Error in inner loop detected
    time.sleep(1)
    return 0

##############################################################################
#                            printf function
#
#
#
#   Description: Logging to a file has been disabled until log file sizes can be controlled.
#
#
#
###############################################################################

def printf(msg,mode,CR):
    try:
        msg = str(msg)
        if(mode == 1):
            print(msg)
        if(mode == 2):
            print('******Logs Disabled******')
#            with open('/home/pi/Desktop/Data/FMSlog.txt', 'a') as logfile:
#                logfile.write(msg)
#                if(CR == 1):
#                    logfile.write('\n')
#                logfile.close()
        if(mode == 3):
            print(msg)
#            with open('/home/pi/Desktop/Data/FMSlog.txt', 'a') as logfile:
#                logfile.write(msg)
#                if(CR == 1):
#                    logfile.write('\n')            
#                logfile.close()
    except Exception as e:
        print ('ERROR: Occured in function "printf", object ' + str(e))            
    return 0

#def CreateLogFile(LogFile)
#    with open('/home/pi/Desktop/filelog.txt', 'w') as LogFile:
#    return 0

 ###############################################################################
#                            Main GPS Application
#
#
#
#   Description:
#
#
#
###############################################################################   

while True:
# Provide power for all LED's and turn them off.

    pi.write(RED_LED,ON)
    pi.write(BLUE_LED,ON)
    pi.write(GREEN_LED,ON)
    time.sleep(0.1)
    
    CurrentTime = time.strftime('%X %x %Z')
    
    printf("This FMS log was created on : ",2,0)
    printf(CurrentTime,2,1)        

# Start up Delay gives the Microstack GPS module a few additioal seconds to stabilise after boot up.
    StartUpDelay(StartDelay)
    
#    CheckPickleFile()
    
    ThreeG4G = 'ON'             # Assume that there ie 3G4G coverage to start.
    ThreeG4G = Internet_Check(1)
    LstSize = pickleListGet()   # Check to see of the pickle list is empty.
    sendMsgToServer('Info: A reboot has occurred! Having waited 40 seconds, the application has now started',LstSize)

    if pi.connected:
       printf("Connected to pigpiod daemon.",1,1)
       sendMsgToServer("Info: Successfully connected to pigpiod daemon.",LstSize)

#    printf(LstSize,1,1)
#    printf(ThreeG4G,1,1)
     
# Check if the instance of pi of type pigpio was created correctly and the     
    
    msg = ('Info: Device Serial Number: ' + SerialNo + ' and Software Version: ' + SoftVer)
    sendMsgToServer(msg,LstSize)

    printf(CurrentTime,1,1)

    printf(ThreeG4G,1,1)   
    if(CfgRead == 0):
        while(CfgRead == 0):
            sendMsgToServer("Warning: Error occured while reading the configuration file",LstSize)
            printf("Warning: Error occured while reading the configuration file",2,1)
            sendMsgToServer("Info: Attempting to re-read the confiruration file",LstSize)
            printf("Info: Attempting to re-read the confiruration file",2,1)
            CfgRead = GetUniqueGlobalParameter(TRUCK_ID_,HWVer_,SoftVer_,SerialNo_,LEDType_)
 
            TRUCK_ID            = TRUCK_ID_[0]      #    Extract veriable from their lists.
            HWVer               = HWVer_[0]
            SoftVer             = SoftVer_[0]
            SerialNo            = SerialNo_[0]
            LEDType             = LEDType_[0]
            MOVEMENT_DISTANCE   = float(M_D_[0])    #    0.0009 is ~ 100m in GPS co-ordinate system.
            
            time.sleep(5)   


    sendMsgToServer("Info: Successfully read configuraton file",LstSize)
    printf("Info: Successfully read configuraton file",2,1)

    try:

        with open('/home/pi/Desktop/Data/startuptime.pickle', 'wb') as handle:
#        with open('startuptime.pickle', 'wb') as handle:
            pickle.dump(CurrentTime, handle)
    #    pickleListGet()
        
        Display1 = 0        #   Only display ignition transitions once between changes.
        Display2 = 0        #   Only take Parked Longitude and Latitude readings once when the ignition is turned off.
        
# Thes value have been converted to strings as a work arount in order to facillitate
# passing them by reference to the HandleException() proceedure.

        ErrorCntTot = [0]   #   Total number of Errors received dueto poor GPS Rolover is at 25000.
        SendOff     = [0]   #   Send date to server after timeout.
        ErrorCount  = [0]   #   Reset GPS exceptions counter.
        CheckGPS    = [0]   #   Counter to force a GPS "Parked Sample"
        ParkedCnt   = [0]   #   Counter to force a GPS "Parked Sample"
        GPSStable   = [0]   #   Flag to monitor the stability of the GPS signal 1 == GPS is Stable
        ErrorType1  = [0]   #
        ErrorType2  = [0]   #
        Skiplatdiff = 0     #   If longdiff occurred skip latdiff
        STATES = 0          #   Variable to keep track of LED states.
        longitudeOLD = 0    #   Variable used to detect if the vehicle has moved when parked.
        latitudeOLD = 0     #   Variable used to detect if the vehicle has moved when parked. i.e. It is potentially being stolen.
        ParkedSample = 0    #
        ForcedSample = 0    #   Count the number of Forced "Parked Samples" taken to indicate to the
        Munutes = 0         #   Fractions of hours the vehicle has been stationary.
        Hours = 0           #   Hours the vehicle has been stationary.

        TopSpeed = 0.0
        SpeedCnt = 0
        Stopping = 0.10     #   Variable used to detect the vehicle is come to a halt.
        Going = 4.00        #   Variable used to detect the vehicle is speeding up again.
        Stopped = 0.50      #   Variable used to detect the vehicle has stopped and suppress un necessary sampling.
#        HeadLightIO = 0
        
        ignitionIO = getIgnitionIO()    #   Check ignition 1 = ON 0 = OFF
        

        Display1 = 0        #   Assume ignition is off Enable "The ignition is OFF" Display at start up.
        Display3 = 0        #   Enable "Veicles XXX has come to a holt." Message            
        Display4 = 0        #   Suppress Top Speed Messave at power-up.
        Display5 = 0        #   Suppress message NIV vehicle XXX has been turned on.
    
        if(ignitionIO == 1):#   Only check ignition for IV Ignition Version
            Display1 = 1    #   Enable  "The ignition is ON" Display at start up.
            Display4 = 1    #   Suppress Top Speed Messave at power-up unless the ignition is already on.

        if(HWVer == 'NIV'): #   Idicate once on power-up if the pickel list has contents.
            Display5 = 1        

        while True:
#ZXC1
            ignitionIO = 1                      #   Set ignition to ON for NIV Non-ignition Version
            if(HWVer == 'IV'):                  #   Only check ignition for IV Ignition Version
                ignitionIO = getIgnitionIO()    #   Check ignition 1 = ON 0 = OFF 
            HeadLightIO = getHeadLightIO()      #   Check if HEADLIGHT_FW or HEADLIGHT_BW are presenlty on.
    
            try:
                if(ignitionIO == 1):    #   skip ignition test             
                    GPSStable = [1]     #   Assume GPS signal is stable and test in try: exception: construct below.
                    if(Display1 == 1):
                        print('')
                        sendMsgToServer('Info: The ignition is ON',LstSize)
                        printf("Info: The ignition is ON",2,1)
                        FlashBlue(1)      #   Cyan LED flash to indicate GPS sampling with ignition ON has started
                        if(LstSize > 1):
                            FlashRed(1)
                        Display1 = 0        #   Enable "The ignition is OFF" to be printed next
                        Display2 = 0        #   Enable "Parked Longitude and Latitude readings" to be taken
                        SendOff = [0]       #   Enable "The ignition is OFF" to be printed.
                    try:
                        gps = microstacknode.hardware.gps.l80gps.L80GPS() 
                        data = gps.get_gprmc()

                    except Exception as e:

                        HandleException(ErrorCount,ErrorType1,ErrorType2,SendOff,CheckGPS,ParkedCnt,GPSStable,e,LstSize,ignitionIO)
                        data = {'longitude': 12345} # Create Dummy data while GPS stabelises.
#                        print(data)

                    if(Display5 == 1):      #   Enter NIV display if vehicle his just been powered up.
                        msg = ('Info: NIV vehicle ' + TRUCK_ID + ' has been turned on')
                        sendMsgToServer(msg,LstSize)
                        printf(msg,2,1)
                        LstSize = SendDataToCloud(data,ignitionIO,HeadLightIO,BLUE,STATES,0,LstSize)
                        FlashBlue(0.5)      #   Extend Blue Flash
                        if(LstSize > 1):    #   If vehicle is in 'NIV' mode indicate if pickle list has elements
                            FlashRed(1)
                        Display5 = 0                        

                   
                    if(int(GPSStable[0]) == 1):                 #   Ignore data if GPS signal is poor
                        Speed = (data['speed'])
                        SpeedFloat = round(((float(Speed)*1852)/1000),1)
                        if(SpeedFloat >= TopSpeed):              # Calculater the Journey Top Speed.
                            TopSpeed = SpeedFloat
                        if(SpeedFloat <= Stopping):
                            if(Display3 == 1):
                                FlashPink(2.0)    #   Pink LED flash to indicate Vehicle has come to a holt.
                                msg = ('Info: Vehicle ' + TRUCK_ID + ' has stopped')
                                sendMsgToServer(msg,LstSize)
                                printf(msg,2,1)
                                Display3 = 0
#ZXC1                                
                        else:
                            if(SpeedFloat >= Stopped):      #   The Vehicle has come to a holt so stop sending GPS data until it starts moving again.
                                #print('Speed is: ',Speed,'km/hr')
                                print('list size_:',LstSize)
                                if(LstSize <= 1):
                                    LstSize = SendDataToCloud(data,ignitionIO,HeadLightIO,GREEN,STATES,SpeedFloat,LstSize)
                                else:
                                    LstSize = SendDataToCloud(data,ignitionIO,HeadLightIO,BLUE,STATES,SpeedFloat,LstSize)
                                time.sleep(GPS_UPDATE_SPEED_SECONDS)
                                if(SpeedCnt >= 1):
                                    SpeedStr = str(SpeedFloat)
                                    msg = ('Info: Current vehicle Speed is: ' + SpeedStr + ' km/hr.')
                                    sendMsgToServer(msg,LstSize)
                                    printf(msg,2,1)                               
                                    SpeedCnt = 0
                                    
                            if(SpeedFloat >= Going):          
                                Display3 = 1               #   Enable message "Veicles TRUCK_ID has stopped."

                    if(int(ErrorCntTot[0]) >= 25000):           #   GPS sgnal error counter rolls over at 25000.
                        ErrorCntTot = [0]
                        ErrorType1  = [0]                       #   Reset all Error counter on rollover           
                        ErrorType2  = [0]   
                        
                    SpeedCnt = SpeedCnt + 1     
                    ForcedSample = 0    #   Reset Forced Sample to zero as ignition has been turned ON.
                    Munutes = 0         #   Reset minutes counter the vehicle has been stationary.
                    Hours = 0           #   Reset hours counter Hours the vehicle has been stationary.
                    SendOff   = [0]     #
                    ParkedCnt = [0]     #   Reset all Parked loop counters.
                    CheckGPS  = [0]     #
                    del gps


# The E-maxi ignition is OFF so all loop code starts here---->

                else:
                    if(Display1 == 0):
                        sendMsgToServer('Info: The ignition is OFF',LstSize)
                        printf("Info: The ignition is OFF",2,1)
                        if(Display4 == 1):
                            msg = ('Info: Top Speed reached on this journey was: ' + str(TopSpeed) + ' km/hr.')
                            sendMsgToServer(msg,LstSize)
                            printf(msg,2,1)
                        TopSpeed = 0.0
                        Display1 = 1
                        Display4 = 1
                    GPSStable = [1]     # Assume GPS signal is stable and test in try: exception: construct.
                    try:
                        gps=[]
                        gps = microstacknode.hardware.gps.l80gps.L80GPS()
                        Parked_data = gps.get_gprmc()

                    except Exception as e:

                        HandleException(ErrorCount,ErrorType1,ErrorType2,SendOff,CheckGPS,ParkedCnt,GPSStable,e,LstSize,ignitionIO)
                        
                    if(int(GPSStable[0]) == 1):# Assume GPS signal is stable enough to continue.

                        if(Display2 == 0):
                            sendMsgToServer('Info: Taken Parked Longitude and Latitude readings.',LstSize)
                            printf("Info: Taken Parked Longitude and Latitude readings.",2,1)                        
                            LstSize = SendDataToCloud(Parked_data,ignitionIO,HeadLightIO,BLUE,STATES,ZERO,LstSize)
                            FlashBlue(0.2)
                            if(LstSize > 1):
                                FlashRed(0.5)

                            Parked_longitude = Parked_data['longitude']
                            Parked_latitude  = Parked_data['latitude']
                            longitudeOLD = Parked_longitude
                            latitudeOLD = Parked_latitude
                            Display2 = 1       # Ensure that "Parked Longitude and Latitude readings" is diabled until the next time the ignition is switched off.

                            del gps
 
                    if(int(CheckGPS[0]) >= ParkedSample):
                        
                        if(LstSize > 1):    
                            ThreeG4G = Internet_Check(0)    # Check for internet but suppress result msg.
                            if(ThreeG4G == 'ON'):
                                sendMsgToServer('Info: The Internet connection has resumed',LstSize)
                                printf("Info: The Internet connection has resumed",2,1)
                                sendMsgToServer('Info: Data detected in Pickel List attempting to download...',LstSize)
                                printf("Info: Data detected in Pickel List attempting to download...",2,1)
                                LstSize = SendDataToCloud(Parked_data,ignitionIO,HeadLightIO,CYAN,STATES,ZERO,LstSize)
                                if(LstSize <= 1):
                                    sendMsgToServer('Info: Pickel List was successfully downloaded...',LstSize)
                                    printf("Info: Pickel List was successfully downloaded...",2,1)

                        if(int(ParkedCnt[0]) >= PSMsg):

                            msg = ('Info: ' + str(int(SendOff[0])) + ' Parked Samples Taken')
                            sendMsgToServer(msg,LstSize)    # indicate to the server exactly how many Parked samples have been taken
                            printf(msg,2,1)
                            ParkedCnt = [0]
                        try:                        
                            gps = microstacknode.hardware.gps.l80gps.L80GPS()
                            data = gps.get_gprmc()

                        except Exception as e:                         

                            longdiff = 0        #   If GPS signal is Unstable 
                            latdiff  = 0        #   Set the long/latdiff to zero.
                            
                            HandleException(ErrorCount,ErrorType1,ErrorType2,SendOff,CheckGPS,ParkedCnt,GPSStable,e,LstSize,ignitionIO)

                        if(int(GPSStable[0]) == 1):    #  Ignore data if GPS signal is poor
                            longitudeNEW = (data['longitude'])
                            latitudeNEW  = (data['latitude']) 
                            longdiff = abs(longitudeNEW - longitudeOLD)
                            latdiff = abs(latitudeNEW - latitudeOLD)
                            longitudeOLD = longitudeNEW
                            latitudeOLD = latitudeNEW
                        
                        if(longdiff > MOVEMENT_DISTANCE):     # Check if the vehicle has moved longitudanally by 10m
                            print('longdiff')
                            sendMsgToServer('Warning: Longitudinal deviation by 100m or more',LstSize)
                            printf("Warning: Longitudinal deviation by 100m or more",2,1)
                            LstSize = SendDataToCloud(data,ignitionIO,HeadLightIO,GREEN,STATES,ZERO,LstSize)
                            Skiplatdiff = 1
                        if(Skiplatdiff == 0):                   # SendDataToCloud already occured throu longdiff   
                            if(latdiff >= MOVEMENT_DISTANCE):   # Check if the vehicle has moved by 10m
                                print('latdiff')
                                sendMsgToServer('Warning: Latitudinal deviation by 10m or more',LstSize)
                                printf("Warning: Latitudinal deviation by 100m or more",2,1)
                                LstSize = SendDataToCloud(data,ignitionIO,HeadLightIO,GREEN,STATES,ZERO,LstSize)
                        Skiplatdiff = 0
                        
                        if(int(SendOff[0]) >= ForceSampleTime):
                            ForcedSample = ForcedSample + 1
                            Minutes = 15 * ForcedSample
                            if (Minutes >= 60):
                                Minutes = 0
                                ForcedSample = 0
                                Hours = Hours + 1
                                
                            msg = ('Info: Device Serial Number: ' + SerialNo + ' and Software Version: ' + SoftVer)
                            sendMsgToServer(msg,LstSize)
                            printf(msg,2,1)
                          
                            LstSize = SendDataToCloud(data,ignitionIO,HeadLightIO,GREEN,STATES,ZERO,LstSize)
                            
                            msg = ('Info: Vehicle ' + TRUCK_ID + ' has been parked for ' + str(Hours) + ' Hours ' + str(Minutes) + ' Minute: "Forced Parked Sample"')
                            sendMsgToServer(msg,LstSize)
                            printf(msg,2,1)
                            data['longitude'] = Parked_longitude    # Sent the Parked longitude and latitude as the car has not moved
                            data['latitude'] = Parked_latitude
#                            print('')
#                            print(data)

                            SendOff     = [0]   #
                            ParkedCnt   = [0]   #   Reset all Parked loop counters.
                            CheckGPS    = [0]   #
                            Display3 = 0        #   Disable message "Info: Vehicle ' + TRUCK_ID + ' has come to a stop" untill vehicle starts moving.
                          
                        del gps
                    if(int(ErrorCntTot[0]) >= 25000):           # GPS sgnal error counter rolls over at 25000.
                        ErrorCntTot = [0]
                        ErrorType1  = [0]                       #   Reset all Error counter on rollover           
                        ErrorType2  = [0]   

#                    print ('##SendOff##',int(SendOff[0]),'##SendOff##')
#                    print ('#ParkedCnt#',int(ParkedCnt[0]),'#ParkedCnt#')
                    ParkedCnt[0] = ParkedCnt[0] + 1     #
                    SendOff[0]   = SendOff[0]   + 1     #   Increment all Parked loop counters.
                    CheckGPS[0]  = CheckGPS[0]  + 1     #
                    
            except Exception as e:
                msg = ('Info: Exception in inner loop of type: " ' + str(e) + ' " received. Waiting 2 seconds before retry.')
                sendMsgToServer(msg,LstSize)
                printf(msg,2,1)
                FlashRed(0.2)
                FlashCyan(0.2)       #   Error in inner loop detected
    
    except Exception as e:
        msg = ('Outer loop Serious exception encountered: ' + str(e))
        sendMsgToServer(msg,LstSize)
        printf(msg,2,1)
        FlashRed(0.2)
        FlashWhite(0.2)       #   Error in inner loop detected