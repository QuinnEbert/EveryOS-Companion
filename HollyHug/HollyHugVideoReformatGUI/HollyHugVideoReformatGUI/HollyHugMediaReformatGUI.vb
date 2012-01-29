Public Class HollyHugMediaReformatGUI
    Private App_Name As String = "HollyHug Media Transcoder"
    Private Sub HollyHugVideoReformatGUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set Window Title:
        Me.Text = App_Name
        ' Set "Help > About" Menu Item Name:
        AboutAppToolStripMenuItem.Text &= " " & App_Name & "..."
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class