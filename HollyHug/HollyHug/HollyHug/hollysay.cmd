@echo off
if "%1"=="WAV" goto wav
if "%1"=="SAY" goto say
echo ERROR: No Command Given!
echo.
echo Useage:
echo hollysay [Command] [arg1] [arg2]
echo.
echo Command should be one of the following:
echo WAV = Pass two arguments to output WAV file:
echo       arg1 = Thing To Say
echo       arg2 = WAV-out file
echo SAY = Pass one argument to speak text aloud:
echo       arg1 = Thing To Say
goto end
:wav
echo Using Cepstral Swift(r) To...
echo SAY: %3
echo -- TO --
if "%4"=="" goto err
echo WAV: %4
swift -n %2 -p audio/volume=30 -o %4 %3
goto end
:say
echo Using Cepstral Swift(r) To...
echo SAY: %3
swift -n %2 -p audio/volume=30 %3
goto end
:err
echo ERROR: No File Given!
goto end
:end
