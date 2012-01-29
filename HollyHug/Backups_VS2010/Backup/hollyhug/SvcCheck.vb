Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports Microsoft
Imports Microsoft.Win32
Imports Microsoft.VisualBasic

Module ServiceCheckingModule
    Public HadSaver As Boolean = False
    Public Function RunCheck(ByVal ServiceImageName As String) As Boolean
        Dim Had_Some As Boolean = False
        HadSaver = False
        For Each IndiProc As Process In Process.GetProcesses()
            If InStr(LCase(IndiProc.ProcessName), ".scr") <> 0 Then
                ''If HollyHug.Is_Debug() Then HollyHug.LogPrint("SvcCheck Found Screensaver """ + IndiProc.ProcessName + """")
                HadSaver = True
            End If
        Next
        Dim ProcsKit As Process() = Process.GetProcessesByName(ServiceImageName)
        For Each One_Proc As Process In ProcsKit
            Had_Some = True
        Next One_Proc
        Return Had_Some
    End Function
    Public Function GotSaver() As Boolean
        For Each IndiProc As Process In Process.GetProcesses()
            If InStr(LCase(IndiProc.ProcessName), ".scr") <> 0 Then
                If HollyHug.Is_Debug() Then HollyHug.LogPrint("SvcCheck Found Screensaver """ + IndiProc.ProcessName + """")
                Return True
            End If
        Next
        Return False
    End Function
End Module
