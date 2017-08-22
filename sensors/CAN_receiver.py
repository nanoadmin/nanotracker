import can
import socket
import time
import os

#    CONSTANTS    
TIME_BETWEEN_MESSAGES_SEC = 5


received_messages = [];

class cust_msg:
    
    def __init__(self,msg):
        self.msg = msg
        self.timestamp = msg.timestamp
        self.arbitration_id = msg.arbitration_id
        self.data = msg.data
        
    def printme(self):
        print(self.msg)
        
    def __key(self):
        return self.arbitration_id
   
    def __hash__(self):
        return hash(self.arbitration_id)

class CanListener(can.Listener):
    
    def on_message_received(self, msg):
        m = cust_msg(msg)
        received_messages.append(m);



class CanReceiver:

    #----------------------------------------------------------------------
    def __init__(self, canChannel):
        
        self.canChannel = canChannel
        
        print("connecting to can interface")
        self.bus = can.interface.Bus(channel=canChannel, bustype='socketcan_native')
        self.a_listener = CanListener()
        self.notifier = can.Notifier(self.bus, [self.a_listener])        
        
        while True:
            
            #creates a DEEP copy of the message list
            message_copy = received_messages[:]
            #deletes the contents of the recived_messages list so it can be repopulated
            del(received_messages[:])
            
            #grabs the unique ID's
            unique_ids = list({m.arbitration_id for m in message_copy})
            
            #iterates through the ID's and gets the first instance of each unique one
            for i in unique_ids:
                loop_msg = next( obj for obj in message_copy if obj.arbitration_id == i)
                loop_msg.printme()
            
            time.sleep(TIME_BETWEEN_MESSAGES_SEC)        
