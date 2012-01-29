If ProcessExists("magnify.exe") Then ProcessClose("magnify.exe")
ProcessWaitClose("magnify.exe")
MouseMove((@DesktopWidth/2),0,1)
ShellExecute("magnify.exe")
ProcessWait("magnify.exe")
WinWait("Magnifier")
If Not WinActive("Magnifier") Then WinActivate("Magnifier")
WinWaitActive("Magnifier")
Send("{ALTDOWN}{SPACE}{ALTUP}")
Send("n")
For $i = 16 to 1 Step -1
  Send("{LWINDOWN}{-}{LWINUP}")
Next
Send("{LWINDOWN}{+}{LWINUP}")
