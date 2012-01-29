Imports Microsoft.VisualBasic

Public Class NettyWiz

    ''
    '' Holds the current step that the wizard is on:
    ''

    Private CurrStep As Integer

    ''
    '' Some defaults for the stateful controls...
    ''

    Private Const StateDef_btnPrev_Text As String = " << Back"
    Private Const StateDef_btnNext_Text As String = "Next >> "

    ''
    '' Localization (U.S. English)
    ''

    Private EnUS_FormName As String = "Setup HollyNet Services"
    '' ***---***---***---***---***
    Private EnUS_STEP_StepInfo_Introduction As String = "What is HollyNet?"
    Private EnUS_STEP_StepInfo_GatewayProbe As String = "Gather WAN Status"
    '' ***---***---***---***---***
    Private EnUS_STEP_StepText_Introduction As String = "HollyNet is a collection of services that HollyHug provides that make a set of network-connected computers running HollyHug more useful to you.  This Wizard aims to help you learn more about the services that HollyHug can provide, and to help you set up the ones you wish to use."
    Private EnUS_STEP_StepText_GatewayProbe As String = "Firstly, HollyHug has the ability to gather Internet (WAN) usage information in real-time from your router (possibly, depending on if your model is currently supported).  See the following list to see if your router is currently supported.  If it is not, visit our web site to see how you can get us to set up support for your router in HollyHug (registered users only).  Alternatively, if your router only supports one computer administering it at a time, you can use the ""HollyNet WAN-Stat Bridge"" option below to gather the data most recently available from your ""Master"" HollyNet bot."
    '' ***---***---***---***---***
    Private EnUS_MsgBoxes_Error As String = "Error"
    Private EnUS_MsgBoxes_Warning As String = "Warning"
    '' ***---***---***---***---***
    Private EnUS_InvalidStepNumber As String = "The step internally specified doesn't seem to exist or is not yet implemented!"
    Private EnUS_OutOfStepWARNING As String = "Step started out-of-phase; had step #"
    Private EnUS_Wizard_ButtonFunctionNotFound As String = "A way to handle the clicking of a button with this label could not be found!"
    Public EnUS_WizardLabel_PushNext As String = "Click the ""Next >> "" button to continue..."
    Public EnUS_WizardLabel_PushFinish As String = "Click the ""Finish >"" button to continue..."
    Public EnUS_NotYetImplemented As String = "Not yet implemented.  Sorry!"

    ''
    '' CONVENIENCE/COMMON FUNCTIONS
    ''

    Private Sub CheckIfOutOfStep(ByVal Shift_To As Integer)
        If Not CurrStep = Shift_To Then
            MsgBox(EnUS_OutOfStepWARNING + CurrStep.ToString().Trim() + "!", MsgBoxStyle.Exclamation, EnUS_MsgBoxes_Warning)
            CurrStep = Shift_To
        End If
    End Sub
    Private Sub ReLabelPrevBtn(Optional ByVal NewLabel As String = StateDef_btnPrev_Text)
        If Not btn_Prev.Text = NewLabel Then
            btn_Prev.Visible = False
            btn_Prev.Text = NewLabel
            btn_Prev.Visible = True
        End If
    End Sub
    Private Sub ReLabelNextBtn(Optional ByVal NewLabel As String = StateDef_btnNext_Text)
        If Not btn_Next.Text = NewLabel Then
            btn_Next.Visible = False
            btn_Next.Text = NewLabel
            btn_Next.Visible = True
        End If
    End Sub

    ''
    '' EVENT HANDLERS
    ''

    Private Sub NettyWiz_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormNameLabel.Text = EnUS_FormName
        CurrStep = 1
        STEP_Introduction()
    End Sub

    Private Sub btn_Prev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Prev.Click
        If btn_Prev.Visible Then
            If btn_Prev.Text = "Cancel" Then
                '' We're a Cancel button:
                Me.Close()
            ElseIf btn_Prev.Text = StateDef_btnPrev_Text Then
                CurrStep = CurrStep - 1
                pop_STEP(CurrStep)
            Else
                MsgBox(EnUS_Wizard_ButtonFunctionNotFound, MsgBoxStyle.Critical, EnUS_MsgBoxes_Error)
            End If
        End If
    End Sub

    Private Sub btn_Next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Next.Click
        If btn_Next.Visible Then
            If btn_Next.Text = "Finish" Then
                '' We're a Finish button:
                '' ^^^^^
                '' FIXME: We're probably going to need to do more stuff above here...
                '' ^^^^^
                My.Settings.NetSetup = True
                Me.Close()
            ElseIf btn_Next.Text = StateDef_btnNext_Text Then
                CurrStep = CurrStep + 1
                pop_STEP(CurrStep)
            Else
                MsgBox(EnUS_Wizard_ButtonFunctionNotFound, MsgBoxStyle.Critical, EnUS_MsgBoxes_Error)
            End If
        End If
    End Sub

    ''
    '' STEPS SWITCHER
    ''

    Private Sub pop_STEP(ByVal WhatStep As Integer)
        Select Case WhatStep
            Case 1
                STEP_Introduction()
            Case 2
                STEP_GatewayProbe()
            Case Else
                MsgBox(EnUS_InvalidStepNumber, MsgBoxStyle.Critical, EnUS_MsgBoxes_Error)
        End Select
    End Sub

    ''
    '' WIZARD STEPS
    ''

    Private Sub STEP_Introduction()
        '' Make sure we're not internally out-of-step:
        CheckIfOutOfStep(1)
        '' Make sure "Prev" button shows "Cancel":
        ReLabelPrevBtn("Cancel")
        '' Make sure "Next" button shows Standard Text:
        ReLabelNextBtn(StateDef_btnNext_Text)
        '' Labels
        FormStepLabel.Text = EnUS_STEP_StepInfo_Introduction
        FormTextLabel.Text = EnUS_STEP_StepText_Introduction
        Label_PushNext.Text = EnUS_WizardLabel_PushNext
    End Sub
    Private Sub STEP_GatewayProbe()
        '' Make sure we're not internally out-of-step:
        CheckIfOutOfStep(2)
        '' Make sure "Prev" button shows Standard Text:
        ReLabelPrevBtn(StateDef_btnPrev_Text)
        '' Make sure "Next" button shows Standard Text:
        ReLabelNextBtn(StateDef_btnNext_Text)
        '' Labels
        FormStepLabel.Text = EnUS_STEP_StepInfo_GatewayProbe
        FormTextLabel.Text = EnUS_STEP_StepText_GatewayProbe
        Label_PushNext.Text = "Set&Setup Option, Then, " + EnUS_WizardLabel_PushNext
    End Sub

End Class