Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports System.Reflection
Imports System

Public Class PowerAnn
    Private Sub PowerAnn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OurPower.Text = "NAN%"
    End Sub
    Private Sub PowerAnn_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        TickTock.Stop()
    End Sub
    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub TickTock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TickTock.Tick
        OurPower.Text = HollyHug.OurPower.ToString().Trim() + "%"
    End Sub
End Class