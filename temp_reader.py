import os
import glob
import threading
import time
import copy

os.system('sudo modprobe w1-gpio')
os.system('sudo modprobe w1-therm')
base_dir = '/sys/bus/w1/devices/'
device_folder = glob.glob(base_dir + '28*')[0]
device_file = device_folder + '/w1_slave'

########################################################################
class TempReader(threading.Thread):
    """"""

    #----------------------------------------------------------------------
    def __init__(self, event, timer):
        """Constructor"""
        threading.Thread.__init__(self)
        
        self.event = event
        self.timer = timer
        
        self.messages = {}
        
    
    #----------------------------------------------------------------------
    def run(self):
        """Run Function - runs when thread.start() is called"""               
        
        while self.event.is_set():  
            
            temp = self.read_temp()
            ts = str(time.time()).split(".")[0]
            #print(temp,' Degrees C at ', ts)
            
            #if ts not in self.messages:
                #self.messages[ts] = []
                
            self.messages[ts] = temp
            
            time.sleep(self.timer)
            
    #----------------------------------------------------------------------
    def read_messages(self):
        """Reads the messages in the array"""
        
        messages = copy.deepcopy(dict(self.messages))
        self.messages.clear()
        return messages            
    
    #----------------------------------------------------------------------
    def read_temp(self):
        temp_string = []
        Line = str(self.read_temp_raw())
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
    
    
    #----------------------------------------------------------------------
    def read_temp_raw(self):
        f = open(device_file, 'r')
        lines = f.readlines()
        f.close()
        return lines    