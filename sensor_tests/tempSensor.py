###############################################################################
#                   Nanosoft Fleet Management Systen
#                     Nano Tracker DS18B20
###############################################################################
#
#       Version:        2017-24-3
#       Date:           
#       Last Update:    
#
#
###############################################################################

import os
import glob
import time


os.system('sudo modprobe w1-gpio')
os.system('sudo modprobe w1-therm')
base_dir = '/sys/bus/w1/devices/'
device_folder = glob.glob(base_dir + '28*')[0]
device_file = device_folder + '/w1_slave'
#device_file = 'sys/bus/w1/devices/w1_slave'

def read_temp_raw():
    f = open(device_file, 'r')
    lines = f.readlines()
    f.close()
    return lines

def read_temp():
    temp_string = []
    Line = str(read_temp_raw())
#    Fline = Line
#    while lines[0].strip()[-3:] != 'YES':
#        time.sleep(0.2)
#        lines = read_temp_raw()
#        equals_pos = lines[1].find('t=')
#    if equals_pos != -1:
#        temp_string = lines[1][equals_pos+2:]
    temp_string.append(Line[(Line.find("t=")+2):(len(Line)-4)])
    temp_c = float(temp_string[0]) / 1000.0
#    temp_f = temp_c * 9.0 / 5.0 + 32.0
    return temp_c#, temp_f


while True:
    print(read_temp(),' Degrees C')
    time.sleep(1)


