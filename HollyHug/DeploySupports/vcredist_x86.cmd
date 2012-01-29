@echo off
cscript.exe //NoLogo //E:VBScript vcredist_x86.vbs
if errorlevel == 1 goto no
:ok
echo User approved VC++2010 runtimes installation!
start /wait vcredist_x86.exe /passive /showfinalerror
goto end
:no
echo User declined VC++2010 runtimes installation!
goto end
:end
echo [ DONE ]
exit