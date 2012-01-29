Imports System.Drawing

Public Class PowerMOD

    Private YES_Colour As Color = Color.Green
    Private NOT_Colour As Color = Color.Red
    Private TXT_Colour As Color = Color.White

    Private Text_InUse As String = " is being used"
    Private Text_NoUse As String = " is not in-use"

    Private Function aProcess(ByVal ProcName As String) As Boolean
        Return ServiceCheckingModule.RunCheck(ProcName)
    End Function

    Private Sub PowerMOD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DoRedraw()
        RedrawUI.Start()
    End Sub

    Private Sub DoRedraw()
        '
        ' Media Center MOD Indicator
        '
        StatusLabel_MediaCenter.ForeColor = TXT_Colour
        StatusLabel_MediaCenter.Text = "Media Center"
        If Not aProcess("eHShell") Then
            StatusLabel_MediaCenter.BackColor = NOT_Colour
            StatusLabel_MediaCenter.Text &= Text_NoUse
        Else
            StatusLabel_MediaCenter.BackColor = YES_Colour
            StatusLabel_MediaCenter.Text &= Text_InUse
        End If
        '
        ' iTunes Music MOD Indicator
        '
        StatusLabel_iTunes.ForeColor = TXT_Colour
        StatusLabel_iTunes.Text = "iTunes Music"
        If Not aProcess("iTunes") Then
            StatusLabel_iTunes.BackColor = NOT_Colour
            StatusLabel_iTunes.Text &= Text_NoUse
        Else
            StatusLabel_iTunes.BackColor = YES_Colour
            StatusLabel_iTunes.Text &= Text_InUse
        End If
        '
        ' "Bedtime Mode" MOD Indicator
        '
        StatusLabel_BedTime.ForeColor = TXT_Colour
        StatusLabel_BedTime.Text = "Bedtime Mode"
        'If Not HollyHug.BedTimeToolStripMenuItem.Checked Then
        'StatusLabel_BedTime.BackColor = NOT_Colour
        'StatusLabel_BedTime.Text &= Text_NoUse
        'Else
        'StatusLabel_BedTime.BackColor = YES_Colour
        'StatusLabel_BedTime.Text &= Text_InUse
        'End If
    End Sub

    Private Sub RedrawUI_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedrawUI.Tick
        If Me.Visible Then DoRedraw()
    End Sub

    Private Sub PowerMOD_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        RedrawUI.Stop()
    End Sub

End Class