If $CmdLine[0] = 1 Then
	If Not ProcessExists($CmdLine[1]) Then
		Exit 0
	Else
		Exit 1
	EndIf
EndIf
