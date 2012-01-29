Dim $zipPath = "C:\Users\Quinn\AppData\Roaming\"
Dim $cmdParm = "-o " & $zipPath & "mIRC.zip -d C:\Users\Quinn\AppData\Roaming\"
ShellExecuteWait( "unzip" , $cmdParm, $zipPath )
ShellExecute( "mIRC.lnk" , "" , "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\mIRC" )
Exit 0