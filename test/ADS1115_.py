###############################################################################
#                   Nanosoft Fleet Management Systen
#                     Nano Tracker ADS1115_.py
###############################################################################
#
#       Version:        2017-24-3
#       Date:           
#       Last Update:    
#
#
###############################################################################

import smbus
import time

BusAddress = 0x48       #I2C Address of the ADS1115 wich can be adjuseted to 0x49,50 or 51
ConversionDelay = 0.4   #Delay to alow for the ADC to perform the conversion
ConversionReg = 0x00
ConfigReg = 0x01

# Get I2C bus
bus = smbus.SMBus(1)

# ADS1115 address, 0x48(72)
# Write to configuration register, 0x01(01)
#		0xC483(50307)	AINP = AIN0 and AINN = GND, +/- 2.048V
#		0xD283(54403)	AINP = AIN1 and AINN = GND, +/- 4.096V
#				Continuous conversion mode, 128SPS
# Data = [1100 0100 1000 0011]  +/- 2.048V
# Data = [1100 0010 1000 0011]  +/- 4.096V
Data = [0xC4,0x83]  #+/- 2.048V
#Data = [0xC2,0x83]  #+/- 4.096V

bus.write_i2c_block_data(BusAddress, ConfigReg, Data)

time.sleep(ConversionDelay)

# ADS1115 address, 0x48(72)
# Read data back from 0x00(00), 2 bytes
# raw_adc MSB, raw_adc LSB
Data = bus.read_i2c_block_data(BusAddress, ConversionReg, 2)

# Convert the data
raw_adc = Data[0] * 256 + Data[1]

if raw_adc > 32767:
	raw_adc -= 65535

# Display the raw ADC value
print ("Digital Value of Analog Input on Channel-0: ",raw_adc)

# ADS1115 address, 0x48(72)
# Select configuration register, 0x01(01)
#		0xD483(54403)	AINP = AIN1 and AINN = GND, +/- 2.048V
#				Continuous conversion mode, 128SPS
Data = [0xD2,0x83]
bus.write_i2c_block_data(BusAddress, ConfigReg, Data)

time.sleep(ConversionDelay)

# ADS1115 address, 0x48(72)
# Read data back from 0x00(00), 2 bytes
# raw_adc MSB, raw_adc LSB
Data = bus.read_i2c_block_data(BusAddress, ConversionReg, 2)

# Convert the data
raw_adc = Data[0] * 256 + Data[1]

if raw_adc > 32767:
	raw_adc -= 65535

# Display the raw ADC value
print ("Digital Value of Analog Input on Channel-1: ",raw_adc)

# ADS1115 address, 0x48(72)
# Select configuration register, 0x01(01)
#		0xE483(58499)	AINP = AIN2 and AINN = GND, +/- 2.048V
#				Continuous conversion mode, 128SPS
Data = [0xE2,0x83]
bus.write_i2c_block_data(BusAddress, ConfigReg, Data)

time.sleep(ConversionDelay)

# ADS1115 address, 0x48(72)
# Read data back from 0x00(00), 2 bytes
# raw_adc MSB, raw_adc LSB
Data = bus.read_i2c_block_data(BusAddress, ConversionReg, 2)

# Convert the data
raw_adc = Data[0] * 256 + Data[1]

if raw_adc > 32767:
	raw_adc -= 65535

# Display the raw ADC value
print ("Digital Value of Analog Input on Channel-2: ",raw_adc)

# ADS1115 address, 0x48(72)
# Select configuration register, 0x01(01)
#		0xF483(62595)	AINP = AIN3 and AINN = GND, +/- 2.048V
#				Continuous conversion mode, 128SPS
Data = [0xF2,0x83]
bus.write_i2c_block_data(BusAddress, ConfigReg, Data)

time.sleep(ConversionDelay)

# ADS1115 address, 0x48(72)
# Read data back from 0x00(00), 2 bytes
# raw_adc MSB, raw_adc LSB
Data = bus.read_i2c_block_data(BusAddress, ConversionReg, 2)

# Convert the data
raw_adc = Data[0] * 256 + Data[1]

if raw_adc > 32767:
	raw_adc -= 65535

# Display the raw ADC value
print ("Digital Value of Analog Input on Channel-3: ",raw_adc)

###############################################################################
#                   Nanosoft Fleet Management Systen
#                     Nano Tracker ADS1115_.py
#
###############################################################################

count = 0
VoltageFactor1 = 25/32767
VoltageFactor2 = 5.1/32767

while(count <= 20):
        count += 1
        # ADS1115 address, 0x48(72)
        # Select configuration register, 0x01(01)
        #		0xD483(54403)	AINP = AIN1 and AINN = GND, +/- 4.096V
        #				Continuous conversion mode, 128SPS
        Data = [0xC2,0x83]
        bus.write_i2c_block_data(BusAddress, ConfigReg, Data)

        time.sleep(ConversionDelay)

        # ADS1115 address, 0x48(72)
        # Read data back from 0x00(00), 2 bytes
        # raw_adc MSB, raw_adc LSB
        Data = bus.read_i2c_block_data(BusAddress, ConversionReg, 2)

        # Convert the data
        raw_adc = Data[0] * 256 + Data[1]

        #if raw_adc > 32767:
        #	raw_adc -= 65535
        BatteryVoltage = VoltageFactor1*raw_adc


        print ("Voltage on main battery supply : ",BatteryVoltage,' volts')

        Data = [0xE2,0x83]
        bus.write_i2c_block_data(BusAddress, ConfigReg, Data)

        time.sleep(ConversionDelay)

        # ADS1115 address, 0x48(72)
        # Read data back from 0x00(00), 2 bytes
        # raw_adc MSB, raw_adc LSB
        Data = bus.read_i2c_block_data(BusAddress, ConversionReg, 2)

        # Convert the data
        raw_adc = Data[0] * 256 + Data[1]

#        if raw_adc > 32767:
#                raw_adc -= 65535

        SupplyVoltage = VoltageFactor2*raw_adc


        print ("Voltage on main battery supply : ",SupplyVoltage,' volts')
