Dim $AppName = "Audio Device Changer"

If Not $CmdLine[0] = 1 Then
	MsgBox(4096,$AppName,"Insufficient program paramaters!",10)
EndIf

Dim $SysBase = EnvGet("SystemRoot")+"\System32\"
Dim $n = Int($CmdLine[1])
Dim $x = MouseGetPos(0)
Dim $y = MouseGetPos(1)

ShellExecute("control","mmsys.cpl",$SysBase,"open",@SW_HIDE)
WinWait("Sound")
If Not WinActive("Sound") Then WinActivate("Sound")
If WinWaitActive("Sound","",30) = 1 Then
	WinMove("Sound","",0,0)
	Sleep(250)
	MouseClick("left",56,$n,1,10)
	Sleep(250)
	Send("!s")
	Sleep(250)
	Send("{ENTER}")
	Sleep(250)
	MouseMove($x,$y,10)
	Exit(0)
Else
	MsgBox(4096,$AppName,"Automation timed out waiting for focus on MMSys Window (Line 10)!",10)
	Exit(0)
EndIf
Exit(0)
