Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Diagnostics

Public Class SmartAnn
    Private Colour_Off As System.Drawing.Color = System.Drawing.Color.Red
    Private Color_On As System.Drawing.Color = System.Drawing.Color.LimeGreen
    Private Colour_On As System.Drawing.Color = Color_On
    Private Sub SmartAnn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' FIXME -- These are disabled (because they're not used yet)!
        altLabel1.Visible = False
        altLabel2.Visible = False
        altLabel3.Visible = False
        ' THIS STUFF IS *RELEASEABLE*
        s1Status.Text = "CONNECTED"
        s1Status.ForeColor = Colour_On
        Dim Displays As Screen() = Screen.AllScreens()
        Dim DISP_ONE As Screen = Displays(Displays.GetLowerBound(0))
        Dim DISP_TWO As Screen = Displays(Displays.GetUpperBound(0))
        Dim x, y As String
        x = DISP_ONE.Bounds.Width.ToString()
        y = DISP_ONE.Bounds.Height.ToString()
        s1DimX.Text = "WIDE = " & x
        s1DimY.Text = "HIGH = " & y
        If Displays.GetLowerBound(0) = Displays.GetUpperBound(0) Then
            s2DimX.Visible = False
            s2DimY.Visible = False
            s2Status.Text = "NOT CONNECTED"
            s2Status.ForeColor = Colour_Off
        Else
            s2DimX.Visible = True
            s2DimY.Visible = True
            s2Status.Text = "CONNECTED"
            s2Status.ForeColor = Colour_On
            x = DISP_TWO.Bounds.Width.ToString()
            y = DISP_TWO.Bounds.Height.ToString()
            s1DimX.Text = "WIDE = " & x
            s1DimY.Text = "HIGH = " & y
        End If
    End Sub
End Class