import struct
from pymodbus.pdu import ModbusRequest, ModbusResponse
from pymodbus.client.sync import ModbusTcpClient as ModbusClient
import time
import can


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


REGISTER_LOCATION_CANA = 0X0000
REGISTER_LOCATION_CANB = 0X1000

#check to see if the vcan0 and vcan1 are up

#if they are not up, then bring them up 



client =  ModbusClient('10.10.10.70')

request_canA = CustomModbusRequest(REGISTER_LOCATION_CANA)
request_canB = CustomModbusRequest(REGISTER_LOCATION_CANB)

result  = client.execute(request_canA)

print result

result = client.execute(request_canB)

print result		


registers = [4097, 17731, 16718, 11570, 13360, 13, 57344, 0, 2570]

# 2 Most significant two bytes of the CAN identifier. (Big-endian) 
# 3 Least significant two bytes of the CAN identifier. (Big-endian)
# 4 The Data 1 and Data 2 elements from the CAN data field. 
# 5 The Data 3 and Data 4 elements from the CAN data field.
# 6 The Data 5 and Data 6 elements from the CAN data field. 
# 7 The Data 7 and Data 8 elements from the CAN data field.
# 8 Most significant two bytes of the RX timestamp message. (Big-endian) 
# 9 Least significant two bytes of the RX timestamp message. (Big-endian)
