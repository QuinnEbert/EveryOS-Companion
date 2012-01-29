@echo off
echo Creative Mixer (CT Audio Service) Controller Script
echo Produced On Monday, March 30th, 2009 by D. Quinn Ebert
echo -----------------------------------
echo Trying to set mixer mode of "%1"
if %1==on goto able_y
if %1==yes goto able_y
if %1==off goto able_n
if %1==no goto able_n
:failed
echo The operation "%1" isn't supported!
goto end
:able_y
echo Enableing Creative Audio Service At This Runtime . . .
net start "Creative Audio Service"
goto end
:able_n
echo Disabling Creative Audio Service At This Runtime . . .
net stop "Creative Audio Service"
goto end
:end
echo Operation Completed!
pause
exit
