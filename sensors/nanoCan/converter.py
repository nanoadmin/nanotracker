
import binascii


########################################################################
class MessageConverter:
    """Collection of static methods etc which can be used to convert messages to CAN like hex values"""
        
    def DateConvert(thisDate):
        
        return "not implemented"
    
    def VoltConvert(voltage_pi, voltage_batt):
        
        #below values taken from the CAN_MessageDefinitions (nano1000, PGN=2 "Voltage", SPN 2&3)
        resolution = 0.05 
        offset = 0
        
        voltpiCANVal = MessageConverter.ConvertNumberToHex(voltage_pi,resolution,offset,4)
        voltBAttCANVal = MessageConverter.ConvertNumberToHex(voltage_batt,resolution,offset,4)
        
        #SPN 2 = Battery Voltage and SPN 3 = PI Voltage so we must return them in that order        
        return '0002 ' + voltBAttCANVal + voltpiCANVal
        
    
    def TempConvert(tempVal):
        
        #below values taken from the CAN_MessageDefinitions
        resolution = 0.03125 
        offset = -40

        #apply offset and resolution, then get hex value
        retStr = '0001 ' +  MessageConverter.ConvertNumberToHex(tempVal,resolution,offset,4)
        
        return retStr

    def ConvertNumberToHex(numb, resolution, offset, hexValueCount):        

        numb += (offset * -1)
        numb = numb / resolution
        hexVals = hex(int(numb))
        hexStr =  hexVals.replace('0x','')       
        retStr = '{0}{1}'.format( '0' * (hexValueCount - len(hexStr)),hexStr)

        return retStr


x = MessageConverter.TempConvert(25)    
print(x)


    
        
        
    
    


