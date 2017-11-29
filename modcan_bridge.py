############################################################################
#
# Reads from a modbus gateway (Modbus TCP to 2-port CAN Bus Gateway by ICP)
#
# Sends this data over virtualised CAN network (vcan0 and vcan1)
#
# This has to be run as python2.X as will not work in 3+
#
#                                                             Nanosoft - dg
#############################################################################

import struct
from pymodbus.pdu import ModbusRequest, ModbusResponse
from pymodbus.client.sync import ModbusTcpClient as ModbusClient
import time
import can
import os
import math

##############################
#          CONSTANTS
##############################

#modbus register locations for the input register start locations for CAN A and CAN B
REGISTER_LOCATION_CANA = 0X0000
REGISTER_LOCATION_CANB = 0X1000

MODBUS_GATEWAY_IPADDRESS = "10.10.10.70"



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


def send_can_msg(canbus_client, arbitration_id, can_data, extended_id  ):
    
    msg = can.Message(arbitration_id=arbitration_id,
                      data=can_data,
                      extended_id=extended_id)
    try:
        canbus_client.send(msg)
        print "Message sent on {}".format(canbus_client.channel_info)
    except can.CanError:
        print "Message NOT sent"


def getCANMessageFromModResponse(modbus_response):
    
    reg1 = modbus_response.registers[1]
    reg2 = modbus_response.registers[2]
    
    extended_id = (reg1 != 0)
    
    arbitration_id = int(reg2*(math.pow(256,0)) + reg1*(math.pow(256,2)))
    
    can_data_squashed = modbus_response.registers[3:7]
    
    can_data = [ int(hex(can_data_squashed[0])[2:4],16),int(hex(can_data_squashed[0])[4:6],16)
                ,int(hex(can_data_squashed[1])[2:4],16),int(hex(can_data_squashed[1])[4:6],16)
                ,int(hex(can_data_squashed[2])[2:4],16),int(hex(can_data_squashed[2])[4:6],16)
                ,int(hex(can_data_squashed[3])[2:4],16),int(hex(can_data_squashed[3])[4:6],16)]
    
    return  arbitration_id, can_data, extended_id  
        


def readModValsSendToVCAN(modbus_client, register_location, canbus_client):
    
    request = CustomModbusRequest(register_location)
    
    result = modbus_client.execute(request)
    
    containsValue = False

    for i in range(1,6):
        
        if (containsValue == False and result.registers[i] != 0):
            containsValue = True                   
        
    if containsValue:
        #get the CAN values 
        arbitration_id, can_data, extended_id = getCANMessageFromModResponse(result)
        
        send_can_msg(canbus_client, arbitration_id, can_data, extended_id  )    


#The main loop 
while True:
    
    try:                   
            
        #bring up both the vcan0 and vcan1 CAN interfaces    
        os.system("sudo modprobe vcan ")
        os.system("sudo ip link add dev vcan0 type vcan")
        os.system("sudo ip link set up vcan0")
        os.system("sudo ip link add dev vcan1 type vcan")
        os.system("sudo ip link set up vcan1")        
              
        
        #configure the modbus and canbus clients 
        canbusv0_client = can.interface.Bus(channel="vcan0", bustype='socketcan')
        canbusv1_client = can.interface.Bus(channel="vcan1", bustype='socketcan')
        modbus_client =  ModbusClient(MODBUS_GATEWAY_IPADDRESS)         
        
        
        while True:
            
            #read the can data from modbus and write to vcan0
            readModValsSendToVCAN(modbus_client, REGISTER_LOCATION_CANA , canbusv0_client)
            time.sleep(0.01)      
            #read the can data from modbus and write to vcan1
            readModValsSendToVCAN(modbus_client, REGISTER_LOCATION_CANB, canbusv1_client)
            time.sleep(0.01)                 
                
                
    except:
        print "exception in main lool, restarting"