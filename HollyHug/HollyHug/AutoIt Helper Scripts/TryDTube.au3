If FileExists("c:\detube.hug") Then FileDelete("c:\detube.hug")
$file = FileOpen("c:\detube.hug",1)
If $file = -1 Then
    MsgBox(0, "Error", "Unable to open file.")
    Exit
EndIf
If Not ProcessExists("detube.exe") Then
	FileWrite($file, "0")
Else
	FileWrite($file, "1")
EndIf
FileClose($file)