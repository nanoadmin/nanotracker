import os
import time
from  hardware.gps.l80gps import L80GPS
#mport microstacknode as gps
import sys



gps = L80GPS()

while True:
    
    try:
        gpgll = gps.get_gpgll()
        print('latitude: {0}'.format(gpgll['latitude']))
        print('longitude: {0}'.format(gpgll['longitude']))
        print()
        time.sleep(1)
        
    except:
        print(time.strftime("%H:%M:%S"),"unexpected Error:",sys.exc_info()[0])



