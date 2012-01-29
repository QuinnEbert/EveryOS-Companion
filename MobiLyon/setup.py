from distutils.core import setup
import py2exe

setup(
	console=['MobiLyon.py'],
	data_files=[(".",[
	  "charging.wav",
	  "gdiplus.dll",
	  "lowpower.wav",
	  "maxpower.wav",
	  "MobiLyon.sh",
	  "MobiLyon_PowerLvl.exe",
	  "MSVCP90.dll",
	  "portable.wav",
	  "py.ico",
	  "py.png"
	])]
)
