Dim $mouseEdge = 117
Dim $iconSizes = 56
Dim $findIndex
Dim $changePos
If $CmdLine[0] = 0 Then
	MsgBox(4096,"HollyHug Sound Device Switcher ERROR","Please supply the index number of the sound device to set as active!")
	Exit(0)
Else
	$findIndex =  Int($CmdLine[1])
	$findIndex -= 1
	$changePos =  ($iconSizes * $findIndex)
	$mouseEdge += $changePos
EndIf
If not WinExists("Sound","") Then
	ShellExecute("control.exe","mmsys.cpl","c:\windows\system32\")
EndIf
If WinWait("Sound","",30) = 1 Then
	If Not WinActive("Sound","") Then
		WinActivate("Sound","")
	EndIf
	If WinActive("Sound","") Then
		WinMove("Sound","",0,0)
		MouseMove(52,$mouseEdge,0)
		MouseClick("left")
		MouseMove(235,389,0)
		MouseClick("left")
		ControlFocus("Sound","","Button4")
		ControlClick("Sound","","Button4")
	Else
		MsgBox(4096,"HollyHug Sound Device Switcher ERROR","Lost the focus on the MMSys panel before a critical operation!")
	EndIf
Else
	MsgBox(4096,"HollyHug Sound Device Switcher ERROR","Unable to get focus on MMSys panel within the allotted timeout!")
EndIf
Exit(0)