ShellExecuteWait("net.exe","start ""Creative Audio Service""","C:\Windows\System32")
Sleep(5000)
If ProcessExists("CTAudSvc.exe") Then
	ShellExecuteWait("pv.exe","-pr CTAudSvc.exe","C:\Users\Administrator\Windows")
EndIf
