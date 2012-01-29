ShellExecute("control.exe","mmsys.cpl","C:\Windows\System32\","open")
WinWait("Sound","",15)
WinActivate("Sound")
$x = 1
If $CmdLine[0] = 1 Then
	If $CmdLine[1] = "2" Then
		$x = 2
	ElseIf $CmdLine[1] = "3" Then
		$x = 3
	ElseIf $CmdLine[1] = "4" Then
		$x = 4
	EndIf
EndIf
For $y = 1 to $x Step 1
	Send("{DOWN}")
Next
Send("!s")
Send("{ENTER}")