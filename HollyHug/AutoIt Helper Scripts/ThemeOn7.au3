$MsgBoxTitle = "Windows7 Theme Switcher - Unattended"
If Not ($CmdLine[0] = 1) Then
	If ($CmdLine[0] = 0) Then
		MsgBox(4096, $MsgBoxTitle, "You MUST provide a theme file for me to open!", 10)
	Else
		MsgBox(4096, $MsgBoxTitle, "You can ONLY provide ONE theme file for me to open!", 10)
	EndIf
Else
	ShellExecute($CmdLine[1])
	WinWait("Personalization","",10)
	WinActivate("Personalization")
	WinWaitActive("Personalization","",10)
	If (WinActive("Personalization")) Then
		Sleep(2000)
		WinClose("Personalization")
	Else
		MsgBox(4096, $MsgBoxTitle, "Unable to get handle to the Windows7 "+Chr(34)+"Personalization"+Chr(34)+" Window!", 10)
	EndIf
EndIf