Imports Microsoft.VisualBasic

Public Class HollyPic

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  
        Version.Text = "Version " & My.Application.Info.Version.Major.ToString() & "." & My.Application.Info.Version.Minor.ToString()
        Copyright.Text = My.Application.Info.Copyright
    End Sub

End Class
