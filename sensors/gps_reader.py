import os
import threading
import time
import copy

from .gps import skpang_gps
from .gps.microstack_gps import L80GPS


########################################################################
class GpsReader(threading.Thread):
    """"""

    #----------------------------------------------------------------------
    def __init__(self, event, timer, isSingleCan): #, address=0x53
        """Constructor"""
        threading.Thread.__init__(self)
        
        self.event = event
        self.timer = timer
        
        self.isSingleCan = isSingleCan
        
        self.messages = {}
        
        if not isSingleCan:
            self.gps_microstack = L80GPS()           
        
    
    #----------------------------------------------------------------------
    def run(self):
        """Run Function - runs when thread.start() is called"""               
        
        while self.event.is_set():  
            
            ts = str(time.time()).split(".")[0]
            
            if self.isSingleCan:
                latLng = self.read_gps_l80()
            else:
                latLng = self.read_gps_microstack()
            
            print ('lat:{0} lng:{1}'.format(  latLng['latitude'],latLng['longitude']))
            time.sleep(self.timer)
            
    #----------------------------------------------------------------------
    def read_messages(self):
        """Reads the messages in the array"""
        
        messages = copy.deepcopy(dict(self.messages))
        self.messages.clear()
        return messages            
    
    #------------below must return lat,lng,errMsg,wasErr----------------------------------------------------------
    def read_gps_skpang(self):
        
        retObj = ({'latitude':None,
                    'longitude':None,
                    'isError':False,
                    'ErrorMsg':''})
        try:
            
            lat,lng = skpang_gps.getLatLong()
            
            retObj['latitude'] = gpgll['latitude']
            retObj['longitude'] = gpgll['latitude']
        except:
            retObj['isError'] = True
            retObj['ErrorMsg'] = str(sys.exc_info()[0])
            
        return retObj
    
    def read_gps_microstack(self):
        
        #need to edit this to actually  return microstack node stuff
        
        retObj = ({'latitude':None,
                       'longitude':None,
                        'isError':False,
                        'ErrorMsg':''})
        
        try:
            
            gpgll = self.gps_microstack.get_gpgll()
            
            retObj['latitude'] = lat
            retObj['longitude'] = lng
        except:
            retObj['isError'] = True
            retObj['ErrorMsg'] = str(sys.exc_info()[0])
            
        return retObj