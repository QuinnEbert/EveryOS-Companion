@echo off
c:
cd \Users\Administrator\Downloads\RealPlayer
for %%i in (*.flv) do ffmpeg -i "%%i" -target ntsc-dvd "%%i.mpeg"
for %%i in (*.mp4) do ffmpeg -i "%%i" -target ntsc-dvd "%%i.mpeg"
for %%i in (*.mpeg) do ffmpeg -i "%%i" -target ntsc-vcd "%%i.mpg"
del *.flv
del *.mp4
del *.mpeg
del *.meta
for %%i in (*.mpg) do php -f "dechrome.php" "%%i"
for %%i in (*.mpg) do move "%%i" i:\
echo Files (if any) that are left over:
dir /b *.flv
dir /b *.mp4
dir /b *.mpeg
dir /b *.mpg
