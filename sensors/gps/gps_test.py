

import sys
from microtack_gps import L80GPS

print("example= python3 gps_test.py ttyAMA0")


arg =  print(sys.argv[1])
print ("the argument given = {0}".format( arg))

i = 1

print("Testing microstack")

print ("will try 10 attempts at GPS")

devicename = "/dev/{0}".format(arg)

while i<=10:
    
    try:
        
        print ("attempt {0}".format( i))
        gps = L80GPS()
        x = gps.get_gpgll()
        lat = x['latitude']
        print(x)               
        
        
    except:
        print ("exception caused")
    
    i = i + 1





