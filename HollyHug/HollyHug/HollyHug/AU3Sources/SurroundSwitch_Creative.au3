ShellExecute("C:\Program Files\Creative\Sound Blaster X-Fi\Console Launcher\ConsoLCu.exe","","C:\Program Files\Creative\Sound Blaster X-Fi\Console Launcher")
Sleep(2500)
ShellExecute("C:\Program Files\Creative\Sound Blaster X-Fi\Console Launcher\ConsoLCu.exe","","C:\Program Files\Creative\Sound Blaster X-Fi\Console Launcher")
If WinWait("Entertainment Mode","",30) = 1 Then
	If Not WinActive("Entertainment Mode","") Then
		WinActivate("Entertainment Mode","")
	EndIf
	Sleep(2500)
	If Not WinActive("Entertainment Mode","") Then
		MsgBox(4096,"Switch Surround Mode ERROR","The Creative Control Window refused active focus!",60)
		Exit 1
	EndIf
	WinMove("Entertainment Mode","",0,0)
	MouseClick("left",330,213,1,50)
	Sleep(2500)
	MouseClick("left",123,142,1,50)
	Sleep(2500)
	If $CmdLine[0] = 1 And ($CmdLine[1] = "Theatre-Surround" Or $CmdLine[1] = "Theater-Surround") Then
		MouseClick("left",84,118,1,50)
	Else
		MouseClick("left",84,141,1,50)
	EndIf
	Send("!{F4}")
Else
	MsgBox(4096,"Switch Surround Mode ERROR","Unable to grab a handle to the Creative Control Window!",60)
	Exit 1
EndIf
Exit 0
