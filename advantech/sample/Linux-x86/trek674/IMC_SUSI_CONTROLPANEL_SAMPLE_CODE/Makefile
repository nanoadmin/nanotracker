TARGET = imc_susi_hotkey_demo
SOURCES = HotKeyDemo.cpp
OBJECTS = $(SOURCES:.cpp=.o)

INC = -I../../../../headers/
CXXFLAGS = -std=gnu++0x $(INC) -ansi
LDFLAGS = -L../../../../bin/TREK674_Linux/ -Wl,-rpath=.
LIBS = -pthread -lrt -lSUSI_IMC_CONTROLPANEL

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
