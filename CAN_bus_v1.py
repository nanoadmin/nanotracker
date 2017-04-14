import threading
import time
import can

data_messages = []
    
########################################################################
class CanListener(can.Listener):
    
    def on_message_received(self, msg):
        #m = cust_msg(msg)
        #print(msg)
        data_messages.append(msg); 
        
        
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
        self.a_listener = CanListener()
        self.notifier = can.Notifier(self.bus, [self.a_listener])                 
        
        while self.event.is_set():
            #print(self.channel, ": creating message")
            ##self.messages.append("new message")
            print('datamsg', data_messages)
            time.sleep(self.timer)
            
    #----------------------------------------------------------------------
    def read_messages(self):
        """Reads the messages in the array"""
        
        #creates a DEEP copy of the message list
        messages = data_messages[:]
        #deletes the contents of the recived_messages list so it can be repopulated
        del(data_messages[:])
        
        return messages
