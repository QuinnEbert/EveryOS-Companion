Imports Microsoft.VisualBasic

Public Class HollyPic

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  
        Version.Text = "Version " & My.Application.Info.Version.Major.ToString() & "." & My.Application.Info.Version.Minor.ToString() & "." & My.Application.Info.Version.Build.ToString()
        Copyright.Text = My.Application.Info.Copyright
    End Sub

    Private Sub HollyPic_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

End Class
