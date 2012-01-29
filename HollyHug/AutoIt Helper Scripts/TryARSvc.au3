If FileExists("c:\araudsvc.hug") Then FileDelete("c:\araudsvc.hug")
$file = FileOpen("c:\araudsvc.hug",1)
If $file = -1 Then
    MsgBox(0, "Error", "Unable to open file.")
    Exit
EndIf
If Not ProcessExists("audiorepeater.exe") Then
	FileWrite($file, "0")
Else
	FileWrite($file, "1")
EndIf
FileClose($file)