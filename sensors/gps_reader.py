import os
import threading
import time
import copy
import smbus




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
             
        
    
    #----------------------------------------------------------------------
    def run(self):
        """Run Function - runs when thread.start() is called"""               
        
        while self.event.is_set():  
            
            ts = str(time.time()).split(".")[0]
                
            self.messages[ts] = self.read_gps(True)
            
            time.sleep(self.timer)
            
    #----------------------------------------------------------------------
    def read_messages(self):
        """Reads the messages in the array"""
        
        messages = copy.deepcopy(dict(self.messages))
        self.messages.clear()
        return messages            
    
    #----------------------------------------------------------------------
    def read_gps(self):
        
        return ''