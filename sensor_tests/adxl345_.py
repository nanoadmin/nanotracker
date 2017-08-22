###############################################################################
#                   Nanosoft Fleet Management Systen
#                     Nano Tracker ADXL345
###############################################################################
#
#       Version:        2017-24-3
#       Date:           
#       Last Update:    
#
#
###############################################################################

import time
from adxl345 import ADXL345
  
adxl345 = ADXL345()

def CheckADXL345(x,dx,y,dy,z,dz,delta):
    Xold = x[0]
    Yold = y[0]
    Zold = z[0]
    axes = adxl345.getAxes(True)
    if (abs(axes['x']) <= dx):
        x[0] = 0;
    else:
        x[0] = axes['x']
    if (abs(axes['y']) <= dy):
        y[0] = 0
    else:
        y[0] = axes['y']
    if (abs(axes['z']) <= dz):
        z[0] = 0
    else:
        z[0] = axes['z']
    if( abs(Xold-x[0]) <= delta  and abs(Yold-y[0]) <= delta and abs(Zold-z[0]) <= delta):
        return 0    # While Axies are less than or equal to Delta do nothing. 
    print('At least one axis exceeded Delta set at:', delta,'G')
    return 1
    
    

print ("I2C Address of ADXL345 set to: ",hex(adxl345.address))
x = [0]
y = [0]
z = [0]
dx = 0.2
dy = 0.2
dz = 0.2
delta = 2
print ('x = ',x[0])
print ('y = ',y[0])
print ('z = ',z[0])

file = open("/home/pi/Desktop/ADX345/ADXL345.txt", "w")
count=0
while(count <= 2):
    
    update = CheckADXL345(x,dx,y,dy,z,dz,delta)

    if(update):
        file.write(str(x[0])+','+str(y[0])+','+str(z[0])+'\n')
        x = [0]
        y = [0]
        z = [0]
        #print ('x = ',x[0])
        #print ('y = ',y[0])
        #print ('z = ',z[0])
        count = count+1
file.close()
#        time.sleep(1)
    
