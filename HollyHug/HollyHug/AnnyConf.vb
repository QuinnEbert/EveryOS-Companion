Imports Microsoft.VisualBasic
Imports Microsoft.Win32
Imports Microsoft.VisualBasic.FileSystem
Imports Microsoft.VisualBasic.FileIO


Public Class AnnyConf

    ' FOR DEBUGGING: If this is set to TRUE, ComboBox Index-Changes Trigger MsgBoxes with the "new GUID" shown in them '
    Private BotherMe As Boolean = True

    Private Const WinSizeX As Integer = 320
    Private Const WinSizeY As Integer = 360
    Public Const No_TPins As String = "DEVICE NOT FOUND"

    Private NewITime As Boolean = False

    Private Sub AnnyConf_RebindIdleAPM()
        Dim NewIndex As Integer = 0
        Dim PlanGuid As String = Nothing
        Dim PlanName As String = Nothing
        ' This function (called if the form (re-)loads
        '      ...will rebind the SmartAPM_Idle ComboBox to the setting saved in persisting storeage
        If Not My.Settings.SmartPlan_Idle = "NotchYet" Then
            PlanGuid = My.Settings.SmartPlan_Idle
            PlanName = HollyHug.PowerPlans.ConvertGuid(PlanGuid)
            If SmartAPM_Idle.Items.Contains(PlanName) Then
                NewIndex = SmartAPM_Idle.Items.IndexOf(PlanName)
            End If
        End If
        ''FIXME: HACK to work on XP
        If HollyHug.Older_OS = False Then
            SmartAPM_Idle.SelectedIndex = NewIndex
        End If
    End Sub
    Private Sub AnnyConf_RebindBusyAPM()
        ' This function (called if the form (re-)loads
        '      ...will rebind the SmartAPM_Busy ComboBox to the setting saved in persisting storeage
        Dim NewIndex As Integer = 0
        Dim PlanGuid As String = Nothing
        Dim PlanName As String = Nothing
        ' This function (called if the form (re-)loads
        '      ...will rebind the SmartAPM_Idle ComboBox to the setting saved in persisting storeage
        If Not My.Settings.SmartPlan_Busy = "NotchYet" Then
            PlanGuid = My.Settings.SmartPlan_Busy
            PlanName = HollyHug.PowerPlans.ConvertGuid(PlanGuid)
            If SmartAPM_Busy.Items.Contains(PlanName) Then
                NewIndex = SmartAPM_Busy.Items.IndexOf(PlanName)
            End If
        End If
        ''FIXME: HACK to work on XP
        If HollyHug.Older_OS = False Then
            SmartAPM_Busy.SelectedIndex = NewIndex
        End If
    End Sub
    Private Sub AnnyConf_RebindWorkAPM()
        ' This function (called if the form (re-)loads
        '      ...will rebind the SmartAPM_Busy ComboBox to the setting saved in persisting storeage
        Dim NewIndex As Integer = 0
        Dim PlanGuid As String = Nothing
        Dim PlanName As String = Nothing
        ' This function (called if the form (re-)loads
        '      ...will rebind the SmartAPM_Idle ComboBox to the setting saved in persisting storeage
        If Not My.Settings.SmartPlan_Work = "NotchYet" Then
            PlanGuid = My.Settings.SmartPlan_Work
            PlanName = HollyHug.PowerPlans.ConvertGuid(PlanGuid)
            If SmartAPM_Work.Items.Contains(PlanName) Then
                NewIndex = SmartAPM_Work.Items.IndexOf(PlanName)
            End If
        End If
        ''FIXME: HACK to work on XP
        If HollyHug.Older_OS = False Then
            SmartAPM_Work.SelectedIndex = NewIndex
        End If
    End Sub
    ' Cheap 'accessor' "function" for updating the SliderValueLabel with the
    ' current setting from the IdleTimeSlider:
    Private Sub RefixNum()
        SliderValueLabel.Text = IdleTimeSlider.Value.ToString()
    End Sub
    Private Sub AnnyConf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Resize the window to our desired size upon (re-)loading...
        Me.Width = WinSizeX
        Me.Height = WinSizeY
        '
        ' *** Bind control values to reasonable defaults ***
        '
        ' Grab the Theater output device name...
        'If Not HollyHug.TheaterDeviceTitle() = Nothing Then
        '    ' If it is available...
        '    txtTheaterDeviceName.Text = HollyHug.TheaterDeviceTitle()
        'Else
        '    ' If not unavailable...
        '    txtTheaterDeviceName.Text = No_TPins
        'End If
        ' Now, Rebind The 'SmartAPM' Comboboxes based on settings
        AnnyConf_RebindIdleAPM()
        AnnyConf_RebindBusyAPM()
        AnnyConf_RebindWorkAPM()
        If Not My.Settings.DisableSmartPlanOnManualSelect Then
            DoNotDisableCheckbox.Checked = True
        Else
            DoNotDisableCheckbox.Checked = False
        End If
        ' Rebind the Slider based upon value from persisting storeage:
        IdleTimeSlider.Value = My.Settings.IdleTime
        ' Bind the "Announce Power" setting from storage:
        If My.Settings.PowerAnnouncePercentage = 1 Then
            optPowerAnnouncePercentage1.Checked = True
            optPowerAnnouncePercentage5.Checked = False
        Else
            optPowerAnnouncePercentage5.Checked = True
            optPowerAnnouncePercentage1.Checked = False
        End If
        ' And, finally, force the Label of the setting for IdleTime to update:
        RefixNum()
        NewITime = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ' Close without applying
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel ' Dialogue Status
        Me.Close()
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        ' FIXME: This is probably a good cautionary message to display, but, it's annoying as hell when I'm using HollyAnn...
        'If NewITime Then
        'MsgBox("I noticed that you have changed the Idle Timeout setting..." + vbNewLine + vbNewLine + "PLEASE BE ADVISED:" + vbNewLine + "Currently, you MUST close and restart HollyHug in order to have this setting take effect!", MsgBoxStyle.Exclamation, "HollyHug Settings Change -- Please Be Aware")
        'End If
        Dim UseIndex As Integer
        Dim PlanName As String
        Dim PlanGuid As String
        ' Apply settings, save settings, and then close...
        ' *** Apply Settings ***
        '...For IDLE-APM Mode...
        ''FIXME: HACK to work on XP
        UseIndex = SmartAPM_Idle.SelectedIndex
        If Not HollyHug.Older_OS Then
            PlanName = SmartAPM_Idle.Items.Item(UseIndex).ToString()
            PlanGuid = HollyHug.PowerPlans.ConvertName(PlanName)
            My.Settings.SmartPlan_Idle = PlanGuid
        End If
        '...For BUSY-APM Mode...
        ''FIXME: HACK to work on XP        UseIndex = SmartAPM_Busy.SelectedIndex
        UseIndex = SmartAPM_Busy.SelectedIndex
        If Not HollyHug.Older_OS Then
            PlanName = SmartAPM_Busy.Items.Item(UseIndex).ToString()
            PlanGuid = HollyHug.PowerPlans.ConvertName(PlanName)
            My.Settings.SmartPlan_Busy = PlanGuid
        End If
        '...For WORK-APM Mode...
        ''FIXME: HACK to work on XP        UseIndex = SmartAPM_Busy.SelectedIndex
        UseIndex = SmartAPM_Work.SelectedIndex
        If Not HollyHug.Older_OS Then
            PlanName = SmartAPM_Work.Items.Item(UseIndex).ToString()
            PlanGuid = HollyHug.PowerPlans.ConvertName(PlanName)
            My.Settings.SmartPlan_Work = PlanGuid
        End If
        '...Setting corresponding to the 'Do NOT Disable...' Checkbox...
        If DoNotDisableCheckbox.Checked = True Then
            My.Settings.DisableSmartPlanOnManualSelect = False
        Else
            My.Settings.DisableSmartPlanOnManualSelect = True
        End If
        ' Setting for the IdleTime-out:
        My.Settings.IdleTime = IdleTimeSlider.Value
        ' Alert the user if Voice was changed:
        If Not My.Settings.TheVoice = "NONE" Then
            If Not My.Settings.TheVoice = VoiceBox.SelectedItem().ToString() Then
                Dim anResult As MsgBoxResult = MsgBox("You have changed your Cepstral Voice.  Continuing will delete your VoxCache folder.  Are you sure you want to do this?", MsgBoxStyle.OkCancel, "Voice Setting Confirmation")
                If anResult = MsgBoxResult.Cancel Then
                    Exit Sub
                Else
                    ' Clean Up VoxCache
                    My.Computer.FileSystem.DeleteDirectory(HollyHug.VocsPath, DeleteDirectoryOption.DeleteAllContents)
                    My.Computer.FileSystem.CreateDirectory(HollyHug.VocsPath)
                End If
            End If
        End If
        ' Store Power Level Announce Setting in "My"
        If optPowerAnnouncePercentage1.Checked Then
            My.Settings.PowerAnnouncePercentage = 1
        Else
            My.Settings.PowerAnnouncePercentage = 5
        End If
        ' Apply New Voice Setting:
        My.Settings.TheVoice = VoiceBox.SelectedItem().ToString()
        ' *** STORE Settings ***
        My.Settings.Save()
        ' *** Close the Form ***
        Me.DialogResult = System.Windows.Forms.DialogResult.OK ' Dialogue Status
        Me.Close()
    End Sub
    Private Sub IdleTimeSlider_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NewITime = True
        RefixNum()
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.growlforwindows.com/gfw/")
    End Sub
End Class