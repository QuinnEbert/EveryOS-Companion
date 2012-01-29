Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.Windows.Forms
Imports System.Windows.Forms.Application

Public Class Branding

    Private BrandLog As String = ConDoubleSlash(StartupPath() + "\Branding.Log")
    Private BrandDir As String = ConDoubleSlash(StartupPath() + "\Branding")
    Private nMachine As String = StrConv(Trim(My.Application.GetEnvironmentVariable("ComputerName")), VbStrConv.ProperCase)

    Private UseBrand As String = "ERROR!!!"

    ' Shortcut to DirectoryExists function:
    Private Function DE(ByVal dirname As String) As Boolean
        Return DirectoryExists(dirname)
    End Function
    ' Log to BrandLog:
    Private Sub DoLog(ByVal Log_Text As String)
        Dim FileText As String = ""
        If Not FileExists(BrandLog) Then
            FileText = Log_Text + vbNewLine
            My.Computer.FileSystem.WriteAllText(BrandLog, FileText, False)
        Else
            FileText = My.Computer.FileSystem.ReadAllText(BrandLog) + Log_Text + vbNewLine
            My.Computer.FileSystem.DeleteFile(BrandLog)
            My.Computer.FileSystem.WriteAllText(BrandLog, FileText, False)
        End If
    End Sub
    ' Does the Branding theme exist (just ThemeFolder name passes in!)
    Private Function Brand_OK(ByVal chkTheme As String) As Boolean
        Dim checkDir As String = ConDoubleSlash(BrandDir + "\Theme_" + chkTheme)
        DoLog("Check for BrandTheme """ + chkTheme + """:")
        If DE(checkDir) Then
            DoLog("   ...GOT IT!")
            Return True
        Else
            DoLog("   ...FAILED!")
            Return False
        End If
    End Function
    ' A hopefully-passable way of handling "fatal" path-unavailable errors:
    Private Sub FatalPNF(ByVal pWasNotF As String)
        If Not DirectoryExists(pWasNotF) Then
            MsgBox("Unable to find the directory " + pWasNotF + "!  This is REQUIRED to use HollyHug.  I can't continue like this; cleaning up and exiting NOW...", MsgBoxStyle.Critical, "HollyHug FATAL ERROR")
            Application.Exit()
        End If
    End Sub
    ' OCD ALERT!!! Used to remove possible double-backslashes from pathnames!  ;)
    Private Function ConDoubleSlash(ByVal theStr As String) As String
        Dim retStr As String = theStr
        While Not InStr(retStr, "\\") = 0
            retStr.Replace("\\", "&$")
            retStr.Replace("&$", "\")
        End While
        Return retStr
    End Function
    ' Constructor: Set reasonable defaults, etc, etc...
    Sub New()
        FatalPNF(BrandDir)
        If Brand_OK(nMachine) Then
            UseBrand = ConDoubleSlash(BrandDir + "\Theme_" + nMachine)
            Exit Sub
        End If
        If Brand_OK("Default") Then
            UseBrand = ConDoubleSlash(BrandDir + "\Theme_Default")
            ' FIXME: This could fall through in some fallible situations!
            Exit Sub
        End If
    End Sub

    ''
    '' Public System (FileSystem-Style) Accessor, Returns Text (String)
    '' Used to get the Disk-Homed branding asset with passed-in filename's full
    '' pathname, for the current in-usage theme.
    ''
    Public Function GetAsset(ByVal FileName As String) As String
        If FileExists(ConDoubleSlash(UseBrand + "\" + FileName)) Then
            Return ConDoubleSlash(UseBrand + "\" + FileName)
        End If
        Return "***NO***"
    End Function

End Class
