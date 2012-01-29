#!/usr/bin/python

f = open("testdata.txt","r")
t = f.read().strip()
f.close()

i = t.split(",")

if i[0] == "0":
  print "Battery is discharging with a remaining charge of " + i[1].rstrip("0").rstrip(".") + " watt-hours at " + i[2].rstrip("0").rstrip(".") + " volts."
elif i[0] == "1":
  print "Battery is charging with "
elif i[0] == "2":
  print "Battery is fully charged at "
#print i[1]
#print i[2]
#print i[3]
#print i[4]
