Public Class HollyHugMediaReformatGUI

    Private MovableType_FileMenu_New As String = "New File List"

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub HollyHugMediaReformatGUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim HadAnArg As Boolean = False
        For Each cl_arg As String In My.Application.CommandLineArgs
            HadAnArg = True

            ' Only the first arg will be accepted.  Sorry folks! ;)
            Exit For
        Next cl_arg
    End Sub

End Class
