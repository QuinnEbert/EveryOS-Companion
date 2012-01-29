def MobiLyon_PlayWave(wav):
  import os
  DBGPREFIX="MobiLyon_PlayWave: "
  if (os.path.isfile(wav) != True):
    print DBGPREFIX+"WAVE file \""+wav+"\" not found!"
    return False
  MYPLAYER='mplayer'
  import subprocess
  try:
    processA = subprocess.Popen([MYPLAYER,wav], shell=False, stdout=subprocess.PIPE, stderr=subprocess.PIPE)
  except OSError:
    print DBGPREFIX+"Player \""+MYPLAYER+"\" not found or could not be run!"
    return False
  giA = processA.communicate()[0]
  return True

