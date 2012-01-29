#FIXME: This function is badly-named!
def MobiLyon_Voltages():
  import subprocess
  import sys
  if sys.platform == "win32" or sys.platform == "cygwin":
    return " "
  else:
    processA = subprocess.Popen(['./MobiLyon.VoltsCur'], shell=False, stdout=subprocess.PIPE)
    giA = processA.communicate()[0]
    processB = subprocess.Popen(['./MobiLyon.WattsCur'], shell=False, stdout=subprocess.PIPE)
    giB = processB.communicate()[0]
    processC = subprocess.Popen(['./MobiLyon.WattsMax'], shell=False, stdout=subprocess.PIPE)
    giC = processC.communicate()[0]
    processD = subprocess.Popen(['./MobiLyon.Charging'], shell=False, stdout=subprocess.PIPE)
    giD = processD.communicate()[0]
    adp = int(giD)
    rvl = "\n"
    rvl = rvl + "--------------------\n"
    if (adp == 0):
      rvl = rvl + "I'm running on my battery"
    elif (adp == 1 or adp == 2):
      rvl = rvl + "I'm running on my AC adapter"
      if (adp == 1):
        rvl = rvl + "\nMy battery is recharging"
      elif (adp == 2):
        rvl = rvl + "\nMy battery is charged up"
    else:
      rvl = rvl + "I don't know my DC state!"
    rvl = rvl + "\n--------------------"
    rvl = rvl + "\nExact Energy: "+giB+" mAh"
    rvl = rvl + "\nExact Charge: "+str(round((float(giA)/1000),1))+" Volts"
    rvl = rvl + "\n--------------------"
    rvl = rvl + "\nAt the peak of its service life, my"
    rvl = rvl + "\nbattery's energy was "+giC+" mAh"
    return rvl

def MobiLyon_PowerLvl():
  import subprocess
  import sys
  from string import rstrip
  if sys.platform == "win32" or sys.platform == "cygwin":
    processA = subprocess.Popen(['MobiLyon_PowerLvl.exe'], shell=False, stdout=subprocess.PIPE)
    giP = processA.communicate()[0]
    giP = rstrip(giP)
    #print str(giP)+"% Power Remaining"
  else:
    processA = subprocess.Popen(['./MobiLyon.PowerCur'], shell=False, stdout=subprocess.PIPE)
    processB = subprocess.Popen(['./MobiLyon.PowerMax'], shell=False, stdout=subprocess.PIPE)
    giA = processA.communicate()[0]
    giB = processB.communicate()[0]
    giT = round((float(giA) / float(giB)), 2)
    if (giT >= 1.0):
      giP = 100
    else:
      giP = (100 * giT)
    #print str(giP)+"% Power Remaining"
    #print str(int(giA)) + "mAh/" + str(int(giB)) + "mAh"
  return giP
