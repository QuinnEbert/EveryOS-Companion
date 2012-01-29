@ECHO OFF
set PHP_BIN=php.exe
%PHP_BIN% -c .\php.ini-recommended -d output_buffering=0 PEAR\go-pear.phar
pause
