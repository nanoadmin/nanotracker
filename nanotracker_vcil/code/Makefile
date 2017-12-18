TARGET = imc_susi_vcil_demo
SOURCES = VCILSample.cpp firmware.cpp module_control.cpp can.cpp j1939.cpp obd2.cpp j1708.cpp j1587.cpp
OBJECTS = $(SOURCES:.cpp=.o)

INC = -I../../../../headers/

ifdef DEBUG
CXXFLAGS = $(INC) -g -Wall -ansi
else
CXXFLAGS = $(INC) -Wall -ansi
endif
LDFLAGS = -L../../../../bin/TREK570_Linux/ -Wl,-rpath=.
LIBS = -pthread -lrt -lvcil

all: $(TARGET)

$(TARGET): $(OBJECTS)
	@echo 	"	LD $@"
	@$(CXX) $(LDFLAGS) -o $@ $^ $(LIBS)
ifndef DEBUG
	@echo 	"	STRIP $@"
	@strip $@
endif

%.o: %.cpp
	@echo "	CPP $@"
	@$(CXX) -c $(CXXFLAGS) $^ -o $@

.PHONY: clean
clean:
	@echo "	CLEAN $(OBJECTS) $(TARGET) "
	@rm -f $(OBJECTS) $(TARGET) 

