CXX = arm-none-linux-gnueabi-g++
TARGET = imc_susi_iic_demo
SOURCES = imc_susi_iic_sample.cpp
OBJECTS = $(SOURCES:.cpp=.o)

INC = -I../../../headers/

ifdef DEBUG
CXXFLAGS = -std=gnu++0x $(INC) -g -Wall -ansi
else
CXXFLAGS = -std=gnu++0x $(INC) -Wall -ansi
endif
LDFLAGS = -L../../../bin/TREK520_Linux/ -Wl,-rpath=.
LIBS = -pthread -lrt -lsusi

all: $(TARGET)

$(TARGET): $(OBJECTS)
	@echo 	"	LD $@"
	@$(CXX) $(LDFLAGS) -o $@ $^ $(LIBS)
	@echo 	"	STRIP $@"
	@arm-none-linux-gnueabi-strip $@

%.o: %.cpp
	@echo "	CPP $@"
	@$(CXX) -c $(CXXFLAGS) $^ -o $@

.PHONY: clean
clean:
	@echo "	CLEAN $(OBJECTS) $(TARGET)"
	@rm -f $(OBJECTS) $(TARGET) 
	
