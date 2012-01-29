#!/usr/bin/python

import os
import wx
import sys
import time
 
from MobiLyon_PowerLvl import MobiLyon_PowerLvl
from MobiLyon_PowerLvl import MobiLyon_Voltages
from MobiLyon_PlayWave import MobiLyon_PlayWave
 
ID_EXIT = 101

os.chdir(sys.path[0])

ICONFILE = "py.ico"

TRAYNAME = "MobiLyon Battery Information App\n" # "\n" puts status data on its own line
TRAYNAME = TRAYNAME + "--------------------\n"
 
class TaskBarApp(wx.Frame):
 
    def __init__(self, parent, id, title):
        ICON = wx.Icon(ICONFILE, wx.BITMAP_TYPE_ICO) 
 
        wx.Frame.__init__(self, parent, -1, title, size = (1, 1),
            style=wx.FRAME_NO_TASKBAR|wx.NO_FULL_REPAINT_ON_RESIZE)
 
        self.tbicon = wx.TaskBarIcon()
 
        self.tbicon.SetIcon(ICON, TRAYNAME+"Om, nom!")
 
        self.tbmenu = wx.Menu()
        self.tbmenu.Append(ID_EXIT, "Quit", "Shut down the MobiLyon tray applet")
        wx.EVT_MENU(self.tbmenu, ID_EXIT, self.clickQuit)
 
        wx.EVT_TASKBAR_RIGHT_UP(self.tbicon, self.clickMenu)
 
        self.timer = wx.Timer(self)
        self.Bind(wx.EVT_TIMER, self.update, self.timer)
 
        self.Show(True)
 
        self.timer.Start(1000, False)
 
    def clickQuit(self, event):
        self.tbicon.RemoveIcon()
        os._exit(1)
 
    def clickMenu(self, event):
        self.tbicon.PopupMenu(self.tbmenu)
 
    def update(self, event):
        ICON = wx.Icon(ICONFILE, wx.BITMAP_TYPE_ICO) 
        self.tbicon.SetIcon(ICON, TRAYNAME+str(MobiLyon_PowerLvl())+"% of my battery is remaining"+MobiLyon_Voltages())
 
class MobiLyon(wx.App):
    def OnInit(self):
        frame = TaskBarApp(None, -1, ' ')
        frame.Center(wx.BOTH)
        frame.Show(False)
        return True
 
def _main(argv=None):
    print "MobiLyon: Deal with APM batteries that don't provide telemetric estimates on"
    print "          modern Linux systems (esp. Ubuntu >= v10)"
    print "This Python program written by David Quinn Ebert"
    print "On the Serial Tubes, see: http://www.quinnebert.net/"
    if argv is None:
        argv = sys.argv
    app = MobiLyon(0)
    app.MainLoop()
 
if __name__ == '__main__':
    try:
        import psyco
        psyco.full()
    except ImportError:
        pass
    _main()
