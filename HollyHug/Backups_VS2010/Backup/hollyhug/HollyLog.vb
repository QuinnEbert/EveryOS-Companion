Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.DateAndTime
Public Class HollyLog
    Public Sub AddEvent(ByVal sMessage As String)
        Dim TheStamp As String = Now.ToString()
        Log_View.Items.Add("@" & TheStamp & ": " & sMessage)
    End Sub
    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Hide()
    End Sub
    Private Sub Log_View_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Log_View.SelectedIndexChanged
        Dim Ent_Text As String = Nothing
        For Each Sel_Item As ListViewItem In Log_View.SelectedItems
            Ent_Text = Sel_Item.Text
            MsgBox(Ent_Text, MsgBoxStyle.Information, "HollyAnn - Log Entry")
        Next
    End Sub
    Private Sub HollyLog_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Is this a user-close, or a code-close?
        If e.CloseReason = CloseReason.UserClosing Then
            ' Override the user close, and simply hide, to avoid disposition of resources...
            e.Cancel = True
            Me.Hide()
        End If
        ' All non-user closings will be handled NORMALLY...  ;)
    End Sub
    Private Sub HollyLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' KLUDGE: I'm *really* tired of resizing the column ... <LOL>
        Dim Displays As Screen() = Screen.AllScreens()
        Dim DISP_ONE As Screen = Displays(Displays.GetLowerBound(0))
        Dim Width As Integer = DISP_ONE.Bounds.Width
        ' Resize it automagically...  ;)
        ColumnHeader1.Width = Width
    End Sub
    Private Sub TestBump_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestBump.Tick
        ' This function enables me to keep working on stuff (with ONLY the keyboard) while I am
        ' testing the HumanCheck logic

        ' CHECK: Save CPU power by not attempting to redraw UI elements when not visible
        If Not Me.Visible Then Exit Sub

        ' CHECK: Don't run the log auto-bumping without the debugger running (RETAIL/RELEASE)
        If Not HollyHug.IsDebug() Then Exit Sub

        ' Bump the list automatically so we see the latest items:
    End Sub
End Class