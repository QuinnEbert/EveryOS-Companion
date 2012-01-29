@echo off
cscript.exe //NoLogo //E:VBScript doUrlAcl.vbs
if errorlevel == 1 goto no
:ok
echo User approved URL ACL installation!
elevate -w netsh http add urlacl url=http://127.0.0.1:8080/ user=%USERDOMAIN%\%USERNAME%
goto end
:no
echo User declined URL ACL installation!
goto end
:end
echo [ DONE ]
exit