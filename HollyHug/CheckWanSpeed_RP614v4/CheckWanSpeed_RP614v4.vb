Public Class CheckWanSpeed_RP614v4
    Private Function Visit_Link(ByVal link_url As String) As Boolean
        ' This function was taken (and adapted) from the MSDN2008 Library's LinkLabel.LinkClicked Web Page
        ' Example
        ' ----- ----- ----- ----- -----
        ' Call the Process.Start method to open the default browser 
        ' with a URL:
        Try
            System.Diagnostics.Process.Start(link_url)
        Catch ex As Exception
            ' The error message
            MessageBox.Show("Unable to open link that was clicked.")
            Return False
        End Try
        Return True
    End Function
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Visit_Link(LinkLabel1.Text) = True Then
            ' ONLY Change the color of the link text by setting LinkVisited 
            ' to True IF the Link was Visited OK.
            LinkLabel1.LinkVisited = True
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Clear out the log message text box...
        TextBox1.Text = ""

        ' Setup for a check
        Dim Check614 As RP614v4 = New RP614v4("admin", "some_really_strong_password")
        ' Execute the check
        Check614.LetsDoIt()

        ' Put it in the text box...
        TextBox1.Text = Check614.GiveLogs()

        ' Also, set the "quick" labels:
        DnsLabel.Text = Trim(Str(Check614.dns_kbyt)) + "KB/s Dn"
        UpsLabel.Text = Trim(Str(Check614.ups_kbit)) + "kbps Up"

        ' And, add in some more TESTING-ONLY information:
        TextBox1.Text &= "-------------------------" + vbNewLine + Check614.Bandwidth

    End Sub
End Class
