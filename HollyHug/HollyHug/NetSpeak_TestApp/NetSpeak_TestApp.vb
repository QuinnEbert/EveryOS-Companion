Public Class NetSpeak_TestApp
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
    Private Sub HostsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HostsToolStripMenuItem.Click
        If Simple_Host_Entry_Dialogue.ShowDialog() = Windows.Forms.DialogResult.OK Then

        Else
            MsgBox("Testing aborted by user!", MsgBoxStyle.Information, "Just FYI")
        End If
    End Sub
End Class
