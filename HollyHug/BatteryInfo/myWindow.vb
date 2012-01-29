Public Class myWindow

    Private BattInfo As BatteryInfoReader

    Private Sub myWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BattInfo = New BatteryInfoReader()
        Label1.Text = "Battery Information Gathered:"
        Label1.Text &= vbCrLf
        Label1.Text &= vbCrLf

    End Sub

End Class
