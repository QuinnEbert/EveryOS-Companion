Public Class HollyApt
    Private Sub GoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoButton.Click
        If Not MyFolder.ShowDialog() = Windows.Forms.DialogResult.Cancel Then

        End If
    End Sub
End Class
