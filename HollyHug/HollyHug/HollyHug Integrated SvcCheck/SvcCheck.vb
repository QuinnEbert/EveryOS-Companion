Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports Microsoft
Imports Microsoft.Win32
Imports Microsoft.VisualBasic

Module Module1

    Sub Main()
        Dim Had_Some As Boolean = False
        Dim ProcsKit As Process() = Process.GetProcesses()
        Dim ProcMods As ProcessModule
        For Each One_Proc As Process In ProcsKit
            Try
                ProcMods = One_Proc.MainModule
                If LCase(ProcMods.ModuleName) = "notepad.exe" Then
                    Had_Some = True
                End If
            Catch ex As Win32Exception
                Continue For
            End Try
        Next One_Proc
        If Not Had_Some Then
            Console.WriteLine("NO")
        Else
            Console.WriteLine("OK")
        End If
        Console.WriteLine("Press any key to continue . . .")
        Console.ReadLine()
    End Sub

End Module
