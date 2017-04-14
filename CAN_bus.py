import threading
import time
import can

data_messages = []
    
########################################################################
class CANListener(can.Listener):
    
    def on_message_received(self, msg):
        m = CANMessage(msg)
        #print(msg)
        data_messages.append(m); 
        
        
########################################################################
class CANReceiver(threading.Thread):
    """CAN Receiver"""

    #----------------------------------------------------------------------
    def __init__(self, channel, event, timer):
        """Constructor"""
        
        threading.Thread.__init__(self)
        
        self.channel = channel
        self.event = event
        self.timer = timer
        
                
        
    #----------------------------------------------------------------------
    def run(self):
        """Run Function - runs when thread.start() is called"""
        
        print("connecting to can interface")
        self.bus = can.interface.Bus(channel=self.channel, bustype='socketcan_native')
        self.a_listener = CANListener()
        self.notifier = can.Notifier(self.bus, [self.a_listener])                 
        
        #while self.event.is_set():
            #print(self.channel, ": creating message")
            ##self.messages.append("new message")
            #print('datamsg', data_messages)
            #time.sleep(self.timer)
            
    #----------------------------------------------------------------------
    def read_messages(self):
        """Reads the messages in the array"""
        
        #creates a DEEP copy of the message list
        messages = data_messages[:]
        #deletes the contents of the recived_messages list so it can be repopulated
        del(data_messages[:])
        
        #grabs the unique ID's
        unique_ids = list({m.arbitration_id for m in messages})
        
        #iterates through the ID's and gets the first instance of each unique one
        unique_messages = []
        for i in unique_ids:
            loop_msg = next( obj for obj in messages if obj.arbitration_id == i)
            unique_messages.append(loop_msg)
            #loop_msg.printme()        
        
        return unique_messages


class CANMessage:
    
    def __init__(self,msg):
        self.msg = msg
        self.timestamp = msg.timestamp
        self.arbitration_id = msg.arbitration_id
        self.data = msg.data
        
    def print_me(self):
        print(self.msg)
        
    def __key(self):
        return self.arbitration_id
   
    def __hash__(self):
        return hash(self.arbitration_id)