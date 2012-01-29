import wmi

c = wmi.WMI ()
for enclosure in c.Win32_PortableBattery ():
   print enclosure
