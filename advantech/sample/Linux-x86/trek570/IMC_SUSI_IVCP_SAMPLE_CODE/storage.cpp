#include <stdio.h>

#include "common.h"
#include "SUSI_IMC.h"

enum page_function{
	STORAGE_READ_BYTE = 1,
	STORAGE_WRITE_BYTE,
	STORAGE_READ_MULTI_BYTE,
	STORAGE_WRITE_MULTI_BYTE
};

unsigned int storage_size = 0;

static void show_welcome_title(void)
{
	printf("IVCP SDK Sample -- library version:%s\n", library_version);
	printf(">> Storage Menu\n\n");
}

static void page_menu()
{
	printf("0) back\n");

	printf("%d) Read a byte\n", STORAGE_READ_BYTE);
	printf("%d) Write a byte\n", STORAGE_WRITE_BYTE);
	printf("%d) Read multi byte\n", STORAGE_READ_MULTI_BYTE);
	printf("%d) Write multi byte\n", STORAGE_WRITE_MULTI_BYTE);
		
	printf("\nEnter your choice: ");
}

int page_init()
{
	static int init_once = 0;
	
	if( init_once )
		return 0;
	
	USHORT result;
	
	unsigned int size;
		
	if( (result = SUSI_IMC_EEPROM_GetEEPROMSize(&size)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_EEPROM_GetEEPROMSize fail. error code=0x%04x\n", result);
		return -1;
	}
	
	storage_size = size;

	init_once = 1;
	
	return 0;
}

void read_byte()
{
	printf("Address (0-%d):", storage_size - 1);
	unsigned int address;
	scanf("%u", &address);
	
	WAIT_ENTER();
	
	if( address >= storage_size )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;
	
	unsigned char data;

	if( (result = SUSI_IMC_EEPROM_ReadByte( (BYTE)address, &data)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_EEPROM_ReadByte %u fail. error code=0x%04x\n", address, result);
		return;
	}
	
	printf("Value = 0x%02x\n", data );
}

void write_byte()
{
	printf("Address (0-%d):", storage_size - 1);
	unsigned int address;
	scanf("%u", &address);
	
	WAIT_ENTER();
	
	if( address >= storage_size )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Value (0-255):");
	unsigned int v;
	scanf("%u", &v);
	
	WAIT_ENTER();
	
	if( v >= 256 )
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;	
	
	unsigned char data = v;

	if( (result = SUSI_IMC_EEPROM_WriteByte( (BYTE)address, data)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_EEPROM_WriteByte %u fail. error code=0x%04x\n", address, result);
		return;
	}
	
	printf("Success\n");
}

void read_multi_byte()
{
	printf("Address (0-%d):", storage_size - 1);
	unsigned int address;
	scanf("%u", &address);
	
	WAIT_ENTER();
	
	if( address >= storage_size )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Size (1-16):");
	unsigned int size;
	scanf("%u", &size);
	
	WAIT_ENTER();
	
	if( size > 16 || size == 0)
	{
		printf("Error range\n");
		return;
	}
	
	USHORT result;
	
	unsigned char data[256];
	unsigned char readbyte;

	if( (result =  SUSI_IMC_EEPROM_ReadMultiByte((BYTE)address, (BYTE)size, data, &readbyte)) != IMC_ERR_NO_ERROR )
	{
		printf(" SUSI_IMC_EEPROM_ReadMultiByte %u size %u fail. error code=0x%04x\n", address, size, result);
		return;
	}
	
	printf("Success read %d byte\n", readbyte);
	for(unsigned int i=0; i< readbyte; i++)
		printf("Address = %u Value = 0x%02x\n", address+i, data[i] );
}

void write_multi_byte()
{
	printf("Address (0-%d):", storage_size - 1);
	unsigned int address;
	scanf("%u", &address);
	
	WAIT_ENTER();
	
	if( address >= storage_size )
	{
		printf("Error range\n");
		return;
	}
	
	printf("Size (0-16):");
	unsigned int size;
	scanf("%u", &size);
	
	WAIT_ENTER();
	
	if( size > 16 || size == 0)
	{
		printf("Error range\n");
		return;
	}
	
	unsigned char data[256];
	printf("Data:\n");
	for(unsigned int i=0; i< size; i++)
	{
		printf("Address = %u Value(Hex):\n", address+i);
		unsigned int value;
		scanf("%x", &value);
		
		if(value>255)
		{
			printf("Error range\n");
			return;
		}
		data[i] = value;
		
		WAIT_ENTER();
	}
	
	USHORT result;
		
	unsigned char writebyte;

	if( (result = SUSI_IMC_EEPROM_WriteMultiByte((BYTE)address, (BYTE)size, data, &writebyte)) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_EEPROM_WriteMultiByte %u size %u fail. error code=0x%04x\n", address, size, result);
		return;
	}
	
	printf("Success write %d byte\n", writebyte);
}

void storage_main()
{
	USHORT result;
	int op;
	
	if( (result = SUSI_IMC_EEPROM_Initialize()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_EEPROM_Initialize fail. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return;
	}
	
	if( page_init() < 0 )
		return ;

	while(true)
	{
		CLEAR_SCREEN();
		show_welcome_title();
		page_menu();

		if( SCANF("%d", &op) <=0 )
			op = -1;

		WAIT_ENTER();

		if(op == 0)
			break;

		switch(op)
		{
			case STORAGE_READ_BYTE:
				read_byte();
				break;
			case STORAGE_WRITE_BYTE:
				write_byte();
				break;
			case STORAGE_READ_MULTI_BYTE:
				read_multi_byte();
				break;
			case STORAGE_WRITE_MULTI_BYTE:
				write_multi_byte();
				break;
			default:
				printf("Unknown choice!\n");
				break;
		}

		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();

	}
	
	if( (result = SUSI_IMC_EEPROM_Deinitialize()) != IMC_ERR_NO_ERROR )
	{
		printf("SUSI_IMC_EEPROM_Deinitialize. error code=0x%04x\n", result);
		printf("\nPress ENTER to continue. ");
		WAIT_ENTER();
		return;
	}
}
