

import sys
import microstack_gps
import skpang_gps

print("example= python3 gps_test.py ttyAMA0")


i = 1

print ("testing skpang type chip\nwill try 10 attempts at GPS")

while i<=10:
    
    try:
        
        print ("attempt {0}".format( i))
        
        x = skpang_gps.getLatLong()              
        
        print(str(x))
                
    except Exception as e:
        print (e)
    
    i = i + 1


i = 1

print("Testing microstack L80 type chip\nwill try 10 attempts at GPS")

arg =  sys.argv[1]
print ("the argument given = {0}".format( arg))
devicename = "/dev/{0}".format(arg)
print ("the device name is: {0}".format(devicename))


while i<=10:
    
    try:
        
        print ("attempt {0}".format( i))
        gps = L80GPS(devicename)
        x = gps.get_gpgll()
        lat = x['latitude']
        print(x)               
        
        
    except Exception as e:
        print (e)
    
    i = i + 1





