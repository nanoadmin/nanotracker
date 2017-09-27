import os
import threading
import time
import datetime
import sys
import copy

from .gps import skpang_gps
from .gps.microstack_gps import L80GPS

import nanotracker_config as config 

#match function for lat/long distance calculator
from math import sin, cos, sqrt, atan2, radians

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
        
        if not self.isSingleCan:
            self.gps_microstack = L80GPS()           
        
        #for exception and compression lat_long_obj, time (utc)
        self.LastLatLong = None, None
        
        
    
    #----------------------------------------------------------------------
    def run(self):
        """Run Function - runs when thread.start() is called"""               
        
        while self.event.is_set():  
            
            ts = str(time.time()).split(".")[0]
            
            if self.isSingleCan:
                #print('is single CAN')
                latLng = self.read_gps_skpang()
            else:
                #print('is dual CAN')
                latLng = self.read_gps_microstack()
            
            isError = latLng['isError']                
            errorMsg = latLng['ErrorMsg']
            
            if isError:
            
                print ("GPS ERROR FOUND: {0}".format(errorMsg))
            
            else:
                
                last_ll, dont_use = self.LastLatLong
                
                if last_ll is None:
                    
                    self.LastLatLong = latLng, ts
                    self.messages[ts] = latLng
                    
                else:
                    
                    #check for exception and compression settings   
                    last_lat = last_ll["latitude"]  
                    last_lng = last_ll["longitude"]
                    
                    this_lat = latLng["latitude"]
                    this_lng = latLng["longitude"]
                    
                    #get distance between latitude and longitude in m
                    metresDifference =  GpsReader.getDistanceBetweenLatLong(this_lat, this_lng,last_lat,last_lng)                    
                    secondsSinceLastValue = int( ts) -  int(lastTime)                    
                   
                    wait_time_secs = config.GPS_WAIT_TIME_SECONDS
                    metres_trigger_val = config.GPS_MOVEMENT_DETECTION_METRES
                    
                    print ("metresDifference: {0} metres_trigger_val:{1} secondsSinceLastValue:{2} wait_time_secs{3}".format(str(metresDifference),str(metres_trigger_val),str(secondsSinceLastValue),str(wait_time_secs)))
                    
                    if (metresDifference >= metres_trigger_val) or (secondsSinceLastValue >= wait_time_secs):
                        
                        #add this new value and the previous value to the list (so we get "trend advise" like functionallity)
                        self.messages[lastTime] = last_ll
                        self.messages[ts] = latLng
                        
                        self.LastLatLong = latLng, ts
                
                lastTime = ts                       
                
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
            
            rand_str,lat,lng = skpang_gps.getLatLong()
            
            print(str(skpang_gps.getLatLong()))
            
            retObj['latitude'] = lat
            retObj['longitude'] = lng
           
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
            
            retObj['latitude'] = gpgll['latitude']
            retObj['longitude'] = gpgll['latitude']
            
        except:
            retObj['isError'] = True
            retObj['ErrorMsg'] = str(sys.exc_info()[0])
            
        return retObj

   
    @staticmethod
    def getDistanceBetweenLatLong(lattitude_1, longitude_1, lattitude_2, longitude_2):
                
        # approximate radius of earth in km
        R = 6373.0
        
        lat1 = radians(abs(lattitude_1))
        lon1 = radians(abs(longitude_1))
        lat2 = radians(abs(lattitude_2))
        lon2 = radians(abs(longitude_2))
        
        dlon = lon2 - lon1
        dlat = lat2 - lat1
        
        a = sin(dlat / 2)**2 + cos(lat1) * cos(lat2) * sin(dlon / 2)**2
        c = 2 * atan2(sqrt(a), sqrt(1 - a))
        
        distance = (R * c) * 1000
        
        #print("Result:", distance)
        
        return distance        
