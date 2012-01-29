' AboutBox.vb
' basis for a simple Ubuntu-ish "AboutBox" applet on Windows/.NET

'FIXME: TODO - Make graphical assets portable (they are currently resources)

Public Class frmAbout

    ' The application this AboutBox has to do with:
    Private AboutApp As String = "MultiCPU Compatibility Tool"

    ' Below line would mean that this comes with a standalone app (not normal, for reasons, which are hopefully obvious):
    'Private UpperApp As String = Nothing
    ' Normal behavior for bundled with other "parent" or "upper" application:
    Private UpperApp As String = "HollyHug"

    ' Small bit of text to describe the application:
    Private AppLiner As String = "Utility that automatically sets CPU affinites of applications with poor MultiCPU behavior."
    ' Not recommended, but use it if you're *really* too lazy to write description:
    'Private AppLiner As String = Nothing

    ' The application's web site address:
    Private AppAtWeb As String = "http://www.hollyhug.com/"
    ' For to have no web site url:
    'Private AppAtWeb As String = Nothing

    ' Function to open URLs using WinAPI's IPC/RPC
    ' Stolen and hacked-up heartlessly from MSDN:
    '   <http://msdn.microsoft.com/en-US/library/5acykfhc%28v=VS.80%29.aspx?appId=Dev10IDEF1&l=EN-US&k=k%28SYSTEM.WINDOWS.FORMS.LINKLABEL%29;k%28TargetFrameworkMoniker-%22.NETFRAMEWORK&k=VERSION=V2.0%22%29;k%28DevLang-VB%29&rd=true>
    '   See: "Sub VisitLink()"
    Private Sub VisitURL(ByVal TheURL As String)
        ' Call the Process.Start method to open the default browser 
        ' with a URL:
        System.Diagnostics.Process.Start(TheURL)
    End Sub

    ' Setup event that fires off when the AboutBox App starts:
    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' AboutApp should really never (sanely) be set to Nothing, but still check:
        If Not AboutApp = Nothing Then
            Me.Text &= " " & AboutApp
        End If
        If Not UpperApp = Nothing Then
            lblTitle.Text = UpperApp & " " & AboutApp
        Else
            lblTitle.Text = AboutApp
        End If
        If Not AppLiner = Nothing Then
            lblLiner.Text = AppLiner
        Else
            lblLiner.Text = ""
        End If
        If AppAtWeb = Nothing Then
            btnWebSite.Enabled = False
        End If
    End Sub

    Private Sub btnWebSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWebSite.Click
        ''The following check really shouldn't be necessary, but, you never know...
        ' Make sure the button is actually active before we allow anything to go on:
        If Not btnWebSite.Enabled Then Exit Sub
        ' OK, good, button is enabled -- Go to the web site of the application:
        VisitURL(AppAtWeb)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

End Class
