
############################################################################
#
# reads from a modbus gateway (Modbus TCP to 2-port CAN Bus Gateway by ICP)
#
# sends this data over virtualised CAN network (vcan0 and vcan1)
#
# this has to be run as python2.X as will not work in 3+
#
#                                                                  Nanosoft 
#############################################################################

import struct
from pymodbus.pdu import ModbusRequest, ModbusResponse
from pymodbus.client.sync import ModbusTcpClient as ModbusClient
import time
import can
import os
import math


#modbus register locations for the input register start locations for CAN A and CAN B
REGISTER_LOCATION_CANA = 0X0000
REGISTER_LOCATION_CANB = 0X1000

class CustomModbusRequest(ModbusRequest):    

    def __init__(self, address):
        
        ModbusRequest.__init__(self)
        
        self.address = address
        
        #the length of the message wwe want to read
        self.count = 0x09 
        #the ID of ""this client""
        self.unit_id = 0x01 
        #the function code , 4 is "input register" reading
        self.function_code = 0x04

    def encode(self):
        return struct.pack('>HH', self.address, self.count)

    def decode(self, data):
        self.address, self.count = struct.unpack('>HH', data)

    def execute(self, context):
        if not (1 <= self.count <= 0x7d0):
            return self.doException(merror.IllegalValue)
        if not context.validate(self.function_code, self.address, self.count):
            return self.doException(merror.IllegalAddress)
        values = context.getValues(self.function_code, self.address, self.count)
        return CustomModbusResponse(values)


def hex4(val):
    
    padded = str.format('0x{:04X}', val).split('x')[-1]
    
    return padded

def hex2(val):
    
    padded = str.format('0x{:02X}', val).split('x')[-1]
    
    return padded


def send_can_msg(can_channel, arbitration_id, can_data, extended_id  ):
    
    #self.bus = can.interface.Bus(channel="vcan0", bustype='socketcan_native')
    #maybe we need to move this outside of the method
    bus = can.interface.Bus(channel=can_channel, bustype='socketcan_native')
    
    msg = can.Message(arbitration_id=arbitration_id,
                      data=can_data,
                      extended_id=extended_id)
    try:
        bus.send(msg)
        print "Message sent on {}".format(bus.channel_info)
    except can.CanError:
        print "Message NOT sent"


def getCANMessageFromModResponse(modbus_response):
    
    reg1 = modbus_response.registers[1]
    reg2 = modbus_response.registers[2]
    
    extended_id = (reg1 != 0)
    
    arbitration_id = int(reg2*(math.pow(256,0)) + reg1*(math.pow(256,1)))
    
    arbitration_id = hex(arbitration_id)
    
    can_data = modbus_response.registers[3:7]
    
    return  arbitration_id, can_data, extended_id  
        

#arbitration_id, data, extended_id

def readModValsSendToVCAN(modbus_client, register_location, can_channel):
    
    request = CustomModbusRequest(register_location)
    
    result = modbus_client.execute(request)
    
    containsValue = False

    for i in range(1,6):
        
        if (containsValue == False and result.registers[i] != 0):
            containsValue = True                   
        
    if containsValue:
        #get the CAN values 
        arbitration_id, can_data, extended_id = getCANMessageFromModResponse(result)
        
        send_can_msg(can_channel, arbitration_id, can_data, extended_id  )    


#The main loop 
while True:
    
    
    try:
        
        #bring up both the vcan0 and vcan1 CAN interfaces    
        os.system("sudo modprobe vcan ")
        os.system("sudo ip link add dev vcan0 type vcan")
        os.system("sudo ip link set up vcan0")
        os.system("sudo ip link add dev vcan1 type vcan")
        os.system("sudo ip link set up vcan1")
        
        
        client =  ModbusClient('10.10.10.70') 
        
        while True:
            
            #read the can data from modbus and write to vcan0
            readModValsSendToVCAN(client, 0x0000, "vcan0")
            time.sleep(0.01)      
            #read the can data from modbus and write to vcan1
            readModValsSendToVCAN(client, 0x1000, "vcan1")
            time.sleep(0.01)                 
            
                
    except:
        print "exception in main lool, restarting"