@ECHO OFF
ECHO Setup I/O port drivers(1)...
ECHO.

%~d0
CD %~dp0

call Remove.bat

ECHO 1. I/O Port Driver Installing
devcon.exe Install adv_ioport.inf   adv_ioport
ECHO.

pause
