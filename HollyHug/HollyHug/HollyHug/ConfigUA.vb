Imports Microsoft.DirectX
Imports Microsoft.DirectX.DirectSound
Imports System.Windows.Forms
Imports Microsoft.Win32.SystemEvents
Imports System.Windows
Imports System.Reflection
Imports System.Media
Imports System.Threading.Thread
Imports Microsoft.VisualBasic
Imports System
Imports System.EventArgs

Public Class ConfigUA

    Public Sub CommitUA()
        My.Settings.Save()
    End Sub

    Private Sub ConfigUA_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        CommitUA()
    End Sub

    Public Sub PopPlugs()
        ' NEW Stuff -- Pragmatically figure out which MenuItemIndex we should start to 
        ' fill in at:
        Dim idx As Integer = 0
        ' The ORIGINAL Code Stuff...
        While Not HollyHug.TrayMenu.Items.IndexOfKey("MMSYS_PD") = -1
            HollyHug.TrayMenu.Items.RemoveByKey("MMSYS_PD")
        End While
        Dim Sound_HW As DevicesCollection = New DirectSound.DevicesCollection()
        Dim HW_Infos As String = ""
        Dim currentTsi As ToolStripMenuItem
        Dim yed As Integer = 1
        Dim zed As Integer = (Sound_HW.Count - 1)
        HollyHug.ClearTheaterDevice()
        While Not zed = 0
            currentTsi = New ToolStripMenuItem()
            ' Windows XP and Older don't consider seperate outputs to be different devices:
            If HollyHug.Older_OS Then
                currentTsi.Tag = Strings.Trim(Sound_HW.Item(yed).Description())
            Else
                currentTsi.Text = Strings.Trim(Strings.Left(Sound_HW.Item(yed).Description(), (InStr(Sound_HW.Item(yed).Description(), "(") - 1)))
            End If
            HollyHug.CheckTheaterDevice(Sound_HW.Item(yed).Description())
            currentTsi.Name = "MMSYS_PD"
            'AddHandler currentTsi.Click, AddressOf HollyHug.HandleSDevMenuClicks
            'HollyHug.TrayMenu.Items.Insert(idx, currentTsi)
            yed = yed + 1
            zed = zed - 1
        End While
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.Save()
    End Sub
End Class