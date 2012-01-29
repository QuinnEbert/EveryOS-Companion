Imports Microsoft.VisualBasic
Imports System.String
Imports Microsoft.VisualBasic.FileIO.FileSystem
Public Class AnnTools
    Private Shared Function StringHasHostNameText(ByVal myString As String) As Boolean
        Dim NoSpaces As String = myString.Replace(" ", "")
        NoSpaces.Replace(vbCr, "")
        NoSpaces.Replace(vbLf, "")
        If Len(NoSpaces) > 0 Then
            Return True
        End If
        Return False
    End Function
    Public Shared Function HostName() As String
        Dim FailName As String = "NOT SURE"
        Dim NameFile As String = """c:\hostname.txt"""
        Dim Name_Cmd As String = "hostname > " & NameFile
        Dim Got_Name As String = Nothing
        Shell(Name_Cmd, AppWinStyle.Hide, True, -1)
        If Not FileExists(NameFile) Then Return FailName
        Got_Name = ReadAllText(NameFile)
        DeleteFile(NameFile)
        If Not StringHasHostNameText(Got_Name) Then Return FailName
        Return Got_Name
    End Function
End Class
