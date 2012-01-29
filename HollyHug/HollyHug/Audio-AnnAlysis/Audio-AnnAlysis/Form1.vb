Public Class Form1
    Private sndIputs As New DirectSound.CaptureDevicesCollection()
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For idx As Integer = 1 To (sndIputs.Count - 1)
            ComboBox1.Items.Add(sndIputs.Item(idx).Description.ToString())
        Next idx
        ComboBox1.SelectedIndex = 0
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim capInput As New DirectSound.Capture(sndIputs.Item(1).DriverGuid)
        Dim dCapBuff As New DirectSound.CaptureBuffer(capDescr, capInput)
        Dim levcur_a As Integer, levcur_b As Integer
        dCapBuff.Start(True)
        Thread.Sleep(80)
        dCapBuff.GetCurrentPosition(levcur_a, levcur_b)
        Label1.Text = levcur_a.ToString()
        Label2.Text = ""
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Timer1.Enabled = False Then
            Timer1.Start()
            Exit Sub
        Else
            Timer1.Stop()
            Exit Sub
        End If
    End Sub
End Class
