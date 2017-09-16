import os
import threading
import time
import copy
import smbus
from .gps.microtack_gps import L80GPS


########################################################################
class GpsReader(threading.Thread):
    """"""

    #----------------------------------------------------------------------
    def __init__(self, event, timer, address=0x53):
        """Constructor"""
        threading.Thread.__init__(self)
        
        self.event = event
        self.timer = timer
        
        self.messages = {}
        
        self.gps_l80 = L80GPS()
             
        
    
    #----------------------------------------------------------------------
    def run(self):
        """Run Function - runs when thread.start() is called"""               
        
        while self.event.is_set():  
            
            ts = str(time.time()).split(".")[0]
                
            self.messages[ts] = self.read_gps_l80()
            
            time.sleep(self.timer)
            
    #----------------------------------------------------------------------
    def read_messages(self):
        """Reads the messages in the array"""
        
        messages = copy.deepcopy(dict(self.messages))
        self.messages.clear()
        return messages            
    
    #------------below must return lat,lng,errMsg,wasErr----------------------------------------------------------
    def read_gps_l80(self):
        
        retObj = ({'latitude':None,
                    'longitude':None,
                    'isError':False,
                    'ErrorMsg':''})
        try:
            gpgll = self.gps_l80.get_gpgll()
            retObj['latitude'] = gpgll['latitude']
            retObj['longitude'] = gpgll['latitude']
        except:
            retObj['isError'] = True
            retObj['ErrorMsg'] = str(sys.exc_info()[0])
            
        return retObj
    
    def read_gps_microstack(self):
        
        return ''