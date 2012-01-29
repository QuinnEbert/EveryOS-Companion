Imports Microsoft.VisualBasic
Public Class NettyWiz

    Private CurrStep As Integer

    Private Sub OpenStep(Optional ByVal Step_Num As Integer = 1)
        ''
        '' FIRST: Set the form description label and "inter" "info-label" texts properly:
        ''
        Select Case Step_Num
            Case 1
                FormStepLabel.Text = "Introduction"
                Inter_InfoLabel.Text = "Welcome to the HollyNet Setup Wizard!  HollyNet allows multiple Windows-based computers running HollyHug, and Linux-based computers running the HollyNet Linux Responder PHP-based Scriptlet, to communicate with one another, thus keeping you abreast of the status of multiple computers on your home or other Local Area Network." + vbNewLine + vbNewLine + "To get started configuring your HollyNet installation, please click ""Next""..."
            Case 2
                FormStepLabel.Text = "Choose Roles"
            Case 3
                FormStepLabel.Text = "Set Password"
            Case 4
                FormStepLabel.Text = "Let's Review"
            Case Else
                ' This should NEVER happen:
                FormStepLabel.Text = "ERR:LocTextUnfound"
        End Select
        ''
        '' FINAL: Run the proper show/hide functions:
        ''

    End Sub

    Private Sub NettyWiz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormTextLabel.Text = Me.Text
        CurrStep = 1
        OpenStep(CurrStep)
    End Sub

End Class