Imports System.Windows.Forms
Public Class Simple_Host_Entry_Dialogue
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Len(Trim(TextBox_Hostname.Text)) > 0 Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("No hostname was specified!", MsgBoxStyle.Critical, "Missing Required Information")
        End If
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub Simple_Host_Entry_Dialogue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox_Hostname.Text = ""
    End Sub
End Class
