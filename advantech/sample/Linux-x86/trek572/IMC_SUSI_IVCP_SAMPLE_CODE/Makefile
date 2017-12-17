TARGET = imc_susi_ivcp_demo
SOURCES = IVCPSample.cpp firmware.cpp watchdog.cpp alarm.cpp gsensor.cpp storage.cpp power_management.cpp peripheral.cpp sensor.cpp
OBJECTS = $(SOURCES:.cpp=.o)

INC = -I../../../../headers/

ifdef DEBUG
CXXFLAGS = -std=gnu++0x $(INC) -g -Wall -ansi
else
CXXFLAGS = -std=gnu++0x $(INC) -Wall -ansi
endif
LDFLAGS = -L../../../../bin/TREK572_Linux/ -Wl,-rpath=.
LIBS = -pthread -lrt -lsusi

all: $(TARGET)

$(TARGET): $(OBJECTS)
	@echo 	"	LD $@"
	@$(CXX) $(LDFLAGS) -o $@ $^ $(LIBS)
	@echo 	"	STRIP $@"
	@strip $@

%.o: %.cpp
	@echo "	CPP $@"
	@$(CXX) -c $(CXXFLAGS) $^ -o $@

.PHONY: clean
clean:
	@echo "	CLEAN $(OBJECTS) $(TARGET)"
	@rm -f $(OBJECTS) $(TARGET) 
	
