#ifndef _VCIL_SAMPLE_CODE_COMMON_H
#define _VCIL_SAMPLE_CODE_COMMON_H

#include <stdlib.h>

extern char library_version[];

void firmware_main();
void module_control_main();
void can_main();
void j1939_main();
void obd2_main();
void j1708_main();
void j1587_main();

#define WAIT_ENTER() while( getchar()!='\n') {};

#if defined(WIN32) && !defined(WINCE) || defined(_WIN64)
	#define CLEAR_SCREEN() system("cls");
	#define SCANF(format, pvalue) scanf_s(format, pvalue)
#else
	#define CLEAR_SCREEN() system("clear");
	#define SCANF(format, pvalue) scanf(format, pvalue)
#endif

#endif
