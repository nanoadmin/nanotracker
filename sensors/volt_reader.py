import os
import glob
import threading
import time
import copy
import smbus
from . import nanoCan


########################################################################
class VoltReader(threading.Thread):
    """"""
    
    BusAddress = 0x48       #I2C Address of the ADS1115 wich can be adjuseted to 0x49,50 or 51
    ConversionDelay = 0.4   #Delay to alow for the ADC to perform the conversion
    ConversionReg = 0x00
    ConfigReg = 0x01    
    

    #----------------------------------------------------------------------
    def __init__(self, event, timer, voltFctr_battery, voltFctr_PI):
        """Constructor"""
        
        self.Voltfactor_Battery = voltFctr_battery
        self.VoltFactor_PI = voltFctr_PI              
        
        threading.Thread.__init__(self)                     
        
        self.event = event
        self.timer = timer
        
        self.messages = {}
        
    
    #----------------------------------------------------------------------
    def run(self):
        """Run Function - runs when thread.start() is called"""               
        
        while self.event.is_set():  
            
            #grab the temperature
            #currTemp = self.read_temp()
            
            #check if the temperature has changed since last read, if first run then mark as changed
            #tempHasChanged = self.prevVal is None or currTemp != self.prevVal
            
            
            
            #self.prevVal = currTemp
            
            #if tempHasChanged:
                
            #    ts = str(time.time()).split(".")[0]
            #    nano1000Val = nanoCan.converter.MessageConverter.TempConvert(currTemp)
            #    self.messages[ts] = nano1000Val            
            
            
            
            # need to set up the server code for receiving the voltage values 
            # need to do exception and compression with sending a value every X seconds (maybe add that as a config value)
            
            
            ts = str(time.time()).split(".")[0]                       
            
            volt_batt = self.read_voltage([0xC2,0x83],self.Voltfactor_Battery)
            volt_pi = self.read_voltage([0xE2,0x83],self.VoltFactor_PI)            
                            
            nanoCanVal = nanoCan.converter.MessageConverter.VoltConvert(volt_pi,volt_batt)
            
            self.messages[ts] = nanoCanVal           
            
            
            time.sleep(self.timer)
            
    #----------------------------------------------------------------------
    def read_messages(self):
        """Reads the messages in the array"""
        
        messages = copy.deepcopy(dict(self.messages))
        self.messages.clear()
        return messages            
    
    #----------------------------------------------------------------------
    def read_voltage(self, dataArr, multiplier ):

        # Get I2C bus
        bus = smbus.SMBus(1)
        
        data = dataArr
        bus.write_i2c_block_data(VoltReader.BusAddress, VoltReader.ConfigReg, data)
    
        time.sleep(VoltReader.ConversionDelay)    
    
        # ADS1115 address, 0x48(72)
        # Read data back from 0x00(00), 2 bytes
        # raw_adc MSB, raw_adc LSB
        data = bus.read_i2c_block_data(VoltReader.BusAddress, VoltReader.ConversionReg, 2)
    
        # Convert the data
        raw_adc = data[0] * 256 + data[1]    
      
        voltage = raw_adc * multiplier      
               
        
        return voltage