
###############################################################################
#                           E-Maxi Data Simulation Dump
#
#
#
#   Description:    
#
#
#
###############################################################################

import can
import time
import os 

#               OS COMMANDS
os.system('sudo ifconfig can0 down')
os.system('sudo ifconfig can1 down')
os.system('sudo /sbin/ip link set can0 up type can bitrate 125000')
os.system('sudo /sbin/ip link set can1 up type can bitrate 500000')

TelegramDalay = 0.005

def GetData(DataLength,st):

    Data = []
    
    if(DataLength == 0):
        Data = []
    if(DataLength == 1):
        Data = [1]
        Data[0] = int(st[19:21],16)
    if(DataLength == 4):
        Data = [1,1,1,1]
        Data[0] = int(st[19:21],16)
        Data[1] = int(st[23:25],16)
        Data[2] = int(st[26:28],16)
        Data[3] = int(st[29:31],16)
    if(DataLength == 8):
        Data = [1,1,1,1,1,1,1,1]
        Data[0] = int(st[19:21],16)
        Data[1] = int(st[23:25],16)
        Data[2] = int(st[26:28],16)
        Data[3] = int(st[29:31],16)
        Data[4] = int(st[32:34],16)
        Data[5] = int(st[35:37],16)
        Data[6] = int(st[38:40],16)
        Data[7] = int(st[41:43],16)
        
    return Data
    

def ReadNextLineSendCan(can_channel, can_file):

    can_line = can_file.readline()
    
    if(can_line == ''):
        print('Restarting CANBUS Data Send.' + can_channel)       # Loop data
        print('Restart Time:',time)
        Time = time.strftime('%X %x %Z')
        print('Start Time:',Time)
        can_file.seek(0,0)
        can_line = file.readline()

    print('sending ' +  can_channel + ' '+ can_line)
        
    ID = int(can_line[8:11],16)
    DataLength = int(can_line[15:16])
    Data = GetData(DataLength,can_line)
    

    bus = can.interface.Bus(channel=can_channel, bustype='socketcan_native')     
    msg = can.Message(arbitration_id=ID, data=Data, extended_id=False)  

    bus.send(msg)     


#######     START THE PROCESS HERE 

print('Getting Ready to Start Sending CANBUS Data')
Time = time.strftime('%X %x %Z')
print('Start Time:',Time)
time.sleep(1)

can0_file = open("/home/pi/Desktop/simulator/can0_data.txt", "r")
can1_file = open("/home/pi/Desktop/simulator/can1_data.txt", "r")

    

while(1):

    ReadNextLineSendCan('can0',can0_file)
    time.sleep(TelegramDalay)

    #send 5 can1 for every can0 message
    for i in range(5):
        ReadNextLineSendCan('can1',can1_file)




        
