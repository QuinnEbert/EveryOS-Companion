Opt("WinTitleMatchMode", 2)
If WinWait(" users)","",60) = 1 Then
	WinActivate(" users)")
	WinWaitActive(" users)")
	WinSetState(" users)","",@SW_MINIMIZE)
EndIf
