If FileExists("c:\ctaudsvc.hug") Then FileDelete("c:\ctaudsvc.hug")
$file = FileOpen("c:\ctaudsvc.hug",1)
If $file = -1 Then
    MsgBox(0, "Error", "Unable to open file.")
    Exit
EndIf
If Not ProcessExists("CTAudSvc.exe") Then
	FileWrite($file, "0")
Else
	FileWrite($file, "1")
EndIf
FileClose($file)