$array = MemGetStats( )
;NOTE/Quinn: Disabled (debugging info)
;MsgBox(4096,"Memory Useage",$array[0]&" percent of RAM is now in-use.",30)
$filePtr = FileOpen("c:\memusage.hug",2)
If $filePtr = -1 Then
    MsgBox(0, "Error", "I was unable to open the memusage infofile for writing!")
    Exit
EndIf
FileWrite($filePtr,$array[0])
FileClose($filePtr)
