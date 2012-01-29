Imports Microsoft.Win32
Imports Microsoft.Win32.SystemEvents
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Media
Imports System.Threading.Thread
Imports Microsoft.VisualBasic
Imports System
Imports System.EventArgs
Imports Microsoft.DirectX
Imports Microsoft.DirectX.DirectSound
Imports System.Collections
Imports System.Diagnostics
Imports System.IO
Imports Microsoft.VisualBasic.FileIO.FileSystem

Public Class HollyHug

    Private DumpFile As String = "PowerInf.out"
    Private ReloadCL As String = "PowerInf.cmd"
    Private SwitchCL As String = "PowerCfg.exe -S "

    Private SoundBites_Hoek As New SoundPlayer(My.Resources.eudora)
    Private SoundBites_Tada As New SoundPlayer(My.Resources.tada)
    Private SwitchCT As Boolean = False
    Private SwitchAR As Boolean = False
    Private Checkers As New CheckLib
    Private HumanActCT As Boolean = False
    Private HumanActAR As Boolean = False
    Private FirstCheck As Boolean = True
    Private sTheatre As String = Nothing

    Private NAT_Warn As Boolean = True

    Public vWindows As String = Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "NotFound").ToString()

    Private HumieAnn As HumieInt = New HumieInt()

    Public VocsPath As String = Application.StartupPath + "\VoxCache\"

    Public Shared PowerPlans As New ReferAPM()

    Private OurBrand As Branding

    Private myBotNet As HollyNetServer

    Private NotDrill As Boolean = True

    Public Older_OS As Boolean = False

    Public TheVoice As String = ""

    Private nMachine As String = StrConv(Trim(My.Application.GetEnvironmentVariable("ComputerName")), VbStrConv.ProperCase)

    'FIXME: This is for SpeedCheck (RP614v4) but sounds very generic...
    Dim TempFile As String = Application.StartupPath() + "\" + "tmpSpeed.chk"

    Public Function VoxClean(ByVal text As String) As String
        Dim file As String = text
        Dim invalidFileChars As Char() = Path.GetInvalidFileNameChars()
        Dim invalidFChar As Char
        For Each invalidFChar In invalidFileChars
            file.Replace(invalidFChar, "")
        Next invalidFChar
        Return file + ".wav"
    End Function
    Public Function Is_Debug() As Boolean
        If Debugger.IsAttached() Then
            If NotDrill Then
                Return False
            Else
                Return Debugger.IsAttached()
            End If
        Else
            Return False
        End If
    End Function
    Public Function IsDebug() As Boolean
        Return Is_Debug()
    End Function
    Public Sub LogPrint(ByVal sMessage As String)
        HollyLog.AddEvent(sMessage)
    End Sub
    Public Sub ChangePowerPlan(ByVal PlanGUID As String, Optional ByVal Internal As Boolean = False)
        Dim ourShell As String = SwitchCL + PlanGUID
        Shell(ourShell, AppWinStyle.Hide, True, -1)
        If Not Internal And My.Settings.DisableSmartPlanOnManualSelect Then
            UseSmartPowerToolStripMenuItem.Checked = False
        End If
    End Sub
    Private Sub HandlePlanMenuClicks(ByVal sender As Object, ByVal e As EventArgs)
        ChangePowerPlan(sender.Tag)
        BalloonMessage("I've successfully changed the Power Plan for you! ;-)")
        SoundBites_Tada.PlaySync()
        ReloadMe()
    End Sub
    ''FIXME: Disabled (WinSeven got this right itself...Sorry!) ;(
    ' FIXME: This is a "rip-off" of the stuff from HandleSDevMenuClicks to be used by things that "just want to change to the
    ' theatre device"...
    'Public Sub EngageTheatreAudio()
    '    If Not TheaterDeviceTitle() = Nothing Then
    'Dim pos As String = Nothing
    '        For Each bit As String In Split(TheaterDeviceTitle(), " ")
    '            pos = bit
    '            Exit For
    '        Next bit
    '        Shell("AudioChg.exe " + Trim(pos), AppWinStyle.Hide, True, -1)
    '    End If
    'End Sub
    Public Sub HandleSDevMenuClicks(ByVal sender As Object, ByVal e As EventArgs)
        Dim pos As String = Nothing
        For Each bit As String In Split(sender.Text, " ")
            pos = bit
            Exit For
        Next bit
        Shell("AudioChg.exe " + Trim(pos), AppWinStyle.Hide, True, -1)
    End Sub
    Private Sub ReloadMe(Optional ByVal APM_Only As Boolean = False)
        If Older_OS Then Exit Sub
        PowerPlans = New ReferAPM()
        While Not TrayMenu.Items.IndexOfKey("APM_PLAN") = -1
            TrayMenu.Items.RemoveByKey("APM_PLAN")
        End While
        Shell(ReloadCL, AppWinStyle.Hide, True, -1)
        Dim currentTsi As ToolStripMenuItem
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(DumpFile)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    currentTsi = New ToolStripMenuItem()
                    currentTsi.Tag = currentRow(0)
                    currentTsi.Text = currentRow(1)
                    PowerPlans.Add_Pair(currentTsi.Text, currentTsi.Tag)
                    If currentRow(2) = "*" And Not UseSmartPowerToolStripMenuItem.Checked Then
                        currentTsi.Checked = True
                    Else
                        currentTsi.Checked = False
                    End If
                    currentTsi.Name = "APM_PLAN"
                    AddHandler currentTsi.Click, AddressOf HandlePlanMenuClicks
                    TrayMenu.Items.Insert(0, currentTsi)
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While
        End Using
        ' Clear and (re)load-in the list of available APM plans for the ComboBoxes in the "Setup" dialogue box...
        AnnyConf.SmartAPM_Idle.Items.Clear()
        AnnyConf.SmartAPM_Busy.Items.Clear()
        For Each APM_Plan As APM_Pair In PowerPlans.All()
            AnnyConf.SmartAPM_Idle.Items.Add(APM_Plan.NAME)
            AnnyConf.SmartAPM_Busy.Items.Add(APM_Plan.NAME)
        Next APM_Plan
        ' And, just for 'good measure' reset the default (first) selected-index on the two AnnyConf ComboBoxes...
        AnnyConf.SmartAPM_Idle.SelectedIndex = 0
        AnnyConf.SmartAPM_Busy.SelectedIndex = 0
        ' And, FINALLY, (if requested) we'll reload NVIDIA Display Profiles
        ''FIXME: Disabled (Not planning a return for this!)  ;(
        'If Not APM_Only Then
        'ReloadNV(False)
        'End If
    End Sub
    Private Sub PopAbout()
        Me.Show()
    End Sub
    Private Sub TrayDive_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrayDive.Tick
        If HollyPic.Visible Then
            Exit Sub
        Else
            TrayDive.Stop()
        End If
        Button1.Enabled = True
        Dim InitBuff As Boolean
        UseCTMixerToolStripMenuItem.Checked = ServiceCheckingModule.RunCheck("CTAudSvc")
        If Me.Visible Then
            Me.Hide()
        End If
        ReloadMe()
        If Not SvcCheck.Enabled Then
            Checkers.FirstRun = True
            InitBuff = Checkers.Run()
            If Not InitBuff Then MsgBox("Service checking hit a buffer on the initial run.  This is usually the result of some nasty logical error in my programming." + vbNewLine + vbNewLine + "If you can, please investogate this for me ASAP.  THANKS!!!" + vbNewLine + vbNewLine + "Faithfully Yours," + vbNewLine + "HollyAnn (Quinn's Desktop/Theatre PC)", MsgBoxStyle.Exclamation, "HollyAnn WARNS:")
            ApplySvcDiffs()
            FirstCheck = False
        End If
        'If Debugger.IsAttached Then LogPrint("NettyAnn STATE: Triggering WarmUp...")
        'NettyAnn.DoWarmUp()
        HumieAnn.RunSetup()
        HumanoidalActivityChecker.Start()
        'If Not SvcCheck.Enabled Then
        '   myBotNet = New HollyNetServer()
        '   SvcCheck.Start()
        'End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Enabled Then
            Me.Hide()
            SoundBites_Hoek.PlaySync()
        End If
    End Sub
    Private Function HasMatch(ByVal body As String, ByVal find As String) As Boolean
        If InStr(body, find) = 0 Then
            Return False
        End If
        Return True
    End Function
    Public Sub ClearTheaterDevice()
        sTheatre = Nothing
    End Sub
    Public Sub CheckTheaterDevice(ByVal NameText As String)
        If HasMatch(LCase(NameText), "theater") Or HasMatch(LCase(NameText), "theatre") Then
            sTheatre = NameText
        End If
    End Sub
    Public Function TheaterDeviceTitle() As String
        Return sTheatre
    End Function
    Private Function QueryTheaterDevice(Optional ByVal AsName = False) As String
        If AsName And Not sTheatre = Nothing Then Return sTheatre
        ' FIXME : Do callers handle this properly?  If not, BAD things can happen...
        If sTheatre = Nothing Then Return sTheatre
        Dim pos As String = Nothing
        For Each bit As String In Split(sTheatre, " ")
            pos = bit
            Exit For
        Next bit
        pos = Trim(pos)
        Return pos
    End Function
    Public Sub SayAloud(ByVal Say_What As String)
        If TheVoice = "NONE" Then
            LogPrint("SayAlout(): No voice selected!")
            Exit Sub
        End If
        'If Not DirectoryExists(VocsPath) Then
        '    LogPrint("SayAloud(): ALERT: Creating the directory """ + VocsPath + """ to hold cached vocals for myself!")
        'Else
        '    LogPrint("SayAloud(): VoxCache is in """ + VocsPath + """")
        'End If
        If Not DirectoryExists(VocsPath) Then My.Computer.FileSystem.CreateDirectory(VocsPath)
        'LogPrint("SayAloud(): """ + Say_What + """")
        If Not FileExists(VocsPath + VoxClean(Say_What)) Then
            Shell("swift.exe -n " + TheVoice + " -p audio/volume=30 -o """ + (VocsPath + VoxClean(Say_What)) + """ """ + Say_What + """", AppWinStyle.MinimizedFocus, True)
            If FileExists(VocsPath + VoxClean(Say_What)) Then
                My.Computer.Audio.Play(VocsPath + VoxClean(Say_What))
            Else
                Shell("swift.exe -n " + TheVoice + " -p audio/volume=30 """ + Say_What + """", AppWinStyle.MinimizedFocus, True)
            End If
        Else
            My.Computer.Audio.Play(VocsPath + VoxClean(Say_What))
        End If
    End Sub
    Private Sub HollyHug_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'FIXME: This is HACK-ISH way to make sure we're always acting from the "proper" working directory...
        ChDir(Application.StartupPath())
        ' Setup for branding:
        OurBrand = New Branding()
        Dim HollyPic_NamePtr As String = OurBrand.GetAsset("HollyPic.jpg")
        If InStr(HollyPic_NamePtr, "*") = 0 Then PictureBox1.ImageLocation = HollyPic_NamePtr
        Dim NotVista As Boolean = False
        Dim WinClass As String = ""
        'LogPrint("HollyAnn is starting up...")
        If Not InStr(vWindows, "Vista") = 0 Then
            'LogPrint(" + Running on Windows Vista!")
            WinClass = "Windows Vista"
            Older_OS = False
        ElseIf Not InStr(vWindows, "XP") = 0 Then
            'LogPrint(" + Running on Windows XP!")
            NotVista = True
            WinClass = "Windows XP"
            Older_OS = True
        ElseIf Not InStr(vWindows, "Windows 7") = 0 Then
            WinClass = "Windows 7"
            Older_OS = False
        Else
            'LogPrint(" + Windows Version is UNKNOWN!")
            NotVista = True
            WinClass = "Unsupported OS"
            Older_OS = True
        End If
        Checkers.Add("Creative X-Fi (Vista) Inputs Monitor", "CTAudSvc")
        Checkers.Add("Virtual Audio Cable Audio Repeater", "AudioRepeater")
        LogPrint("...Monitored services have been added to checker!")
        Randomize()
        LogPrint("...Random number generator has been initialised!")
        My.Settings.Reload()
        TheVoice = My.Settings.TheVoice
        LogPrint("...Settings have been loaded from persistent storage!")
        'BedTimeToolStripMenuItem.Checked = My.Settings.UseDelta
        ConfigUA.PopPlugs()
        LogPrint("...DirectSound output devices have been loaded!!")
        If Not IsDebug() Then
            Dim value As Integer = CInt(Int((3 * Rnd()) + 1))
            If value = 1 Then
                SayAloud("Greetings!")
            ElseIf value = 2 Then
                SayAloud("Hello!")
            ElseIf value = 3 Then
                SayAloud("Welcome!")
            End If
        End If
        'For Each argument As String In My.Application.CommandLineArgs
        'If argument = "isBootUp" Then
        'BootDone.Start()
        'LogPrint("...This appears to be a Windows(R) Start-Up!")
        'Exit For
        'End If
        'Next
        'If Not BootDone.Enabled Then LogPrint("...This DOES NOT appear to be a Windows(R) Start-Up!")
        If Not QueryTheaterDevice(True) = Nothing Then
            LogPrint("...THEATER pinset is """ + QueryTheaterDevice(True) + """!")
        Else
            LogPrint("...UNABLE to figure out which set of speakers is THEATER!")
        End If
        TrayIcon.Text = nMachine
        TrayIcon.BalloonTipTitle = nMachine & " says:"
        'LogPrint("...Tray Icon title re-set to ensure OCD-approvable consistency for ""BedTime!"" mode...")
        'LogPrint("...Tagged myself to go down into the system tray!")
        UseSmartPowerToolStripMenuItem.Checked = True
        LogPrint("...Enabled SmartPower Mode!")
        'FIXME: DISABLED -> This probably hasn't worked in ages (a single GUID?)
        'If Not Is_Debug() Then ChangePowerPlan("381b4222-f694-41f0-9685-ff5bb260df2e", True)
        If Not OurBrand.GetAsset("trayicon.ico") = "***NO***" Then
            Dim New_Icon As System.Drawing.Icon
            New_Icon = New System.Drawing.Icon(OurBrand.GetAsset("trayicon.ico"))
            TrayIcon.Icon = New_Icon
        End If
        AnnyConf.VoiceBox.Items.Clear()
        If Not CepCheck.CepCheck() = "" Then
            Dim cs As String() = Split(CepCheck.CepCheck(), vbNewLine)
            Dim cc As Integer = (cs.GetUpperBound(0))
            Dim ci As Integer = 0
            Dim si As Integer = 0
            For Each ov As String In cs
                AnnyConf.VoiceBox.Items.Add(ov.Replace("Cepstral_", ""))
                If ov.Replace("Cepstral_", "") = TheVoice Then
                    si = ci
                End If
                ci = ci + 1
            Next
            AnnyConf.VoiceBox.SelectedIndex = si
        Else
            AnnyConf.VoiceBox.Items.Add("No Voices Found!")
            AnnyConf.VoiceBox.SelectedIndex = 0
        End If
        If My.Computer.FileSystem.DirectoryExists("C:\ProgramData\NVIDIA") Then
            ReloadNV(False)
        Else
            LogPrint("NVDisProfs disabled due to lack of support!")
            Dim idx As Integer
            For i As Integer = 0 To (TrayMenu.Items.Count - 1)
                If TrayMenu.Items(i).Text = "NV Configs" Then
                    idx = (i - 1)
                    TrayMenu.Items.RemoveAt(idx)
                    TrayMenu.Items.RemoveAt(idx)
                    Exit For
                End If
            Next i
        End If
        TrayDive.Start()
        LogPrint("HollyHug is running on " + WinClass)
    End Sub
    Public Sub BalloonMessage(ByVal the_text As String)
        TrayIcon.BalloonTipText = the_text
        TrayIcon.ShowBalloonTip((5 * 1000))
    End Sub
    Private Sub RehashAPMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RehashAPMToolStripMenuItem.Click
        ReloadAt.Start()
    End Sub
    Private Sub ReloadAt_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadAt.Tick
        ReloadAt.Stop()
        ReloadMe()
        BalloonMessage("Hey, guess what?  I've reloaded your list of APM Power Plans! :-)")
        SoundBites_Tada.PlaySync()
    End Sub
    Private Sub ByebyeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByebyeToolStripMenuItem.Click
        ConfigUA.CommitUA()
        System.Windows.Forms.Application.Exit()
    End Sub
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        PopAbout()
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start(LinkLabel1.Text)
    End Sub
    Private Sub ConfigAPMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigAPMToolStripMenuItem.Click
        Dim CPL_Path As String = (System.Environment.GetEnvironmentVariable("SystemRoot") + "\System32\control.exe powercfg.cpl")
        Shell(CPL_Path, AppWinStyle.NormalFocus, False, 5000)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Sound_HW As DevicesCollection = New DirectSound.DevicesCollection()
        Dim HW_Infos As String = ""
        For i As Integer = 1 To (Sound_HW.Count - 1)
            HW_Infos += Sound_HW.Item(i).Description() + vbNewLine
        Next i
        MsgBox(HW_Infos)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ConfigUA.ShowDialog()
    End Sub
    Private Sub ConfigAudioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigAudioToolStripMenuItem.Click
        Shell(My.Application.GetEnvironmentVariable("SystemRoot") + "\System32\control.exe mmsys.cpl", AppWinStyle.NormalFocus, False)
    End Sub
    Private Sub WipeProf()
        While DisProfs.DropDownItems.Count > 2
            DisProfs.DropDownItems.RemoveAt(2)
        End While
    End Sub
    Private Sub HandleDispMenuClicks(ByVal sender As Object, ByVal e As EventArgs)
        Shell("Apply_DP.exe """ + sender.tag + """", AppWinStyle.NormalFocus, True, -1)
    End Sub
    Private Sub ReloadNV(Optional ByVal SayStuff As Boolean = True)
        WipeProf()
        Dim mnuItem As ToolStripMenuItem
        For Each oneFile As String In FileIO.FileSystem.GetFiles("C:\ProgramData\NVIDIA\", FileIO.SearchOption.SearchTopLevelOnly, "*.nvp")
            mnuItem = New ToolStripMenuItem(FileIO.FileSystem.GetName(oneFile))
            mnuItem.Tag = FileIO.FileSystem.GetName(oneFile)
            AddHandler mnuItem.Click, AddressOf HandleDispMenuClicks
            DisProfs.DropDownItems.Insert(DisProfs.DropDownItems.Count, mnuItem)
        Next oneFile
        If SayStuff Then BalloonMessage("Hey, guess what?  I've refreshed your list of NVIDIA display profiles! ;-)")
    End Sub
    Private Sub ReloadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadToolStripMenuItem.Click
        ReloadNV(True)
    End Sub
    Private Sub Mixer_CT_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mixer_CT.Tick
        If Not UseCTMixerToolStripMenuItem.Checked Then
            Shell("net stop ""Creative Audio Service""", AppWinStyle.Hide, True, -1)
            Mixer_CT.Stop()
        Else
            Shell("net start ""Creative Audio Service""", AppWinStyle.Hide, True, -1)
            '\/ Seems reasonable to remove as of WinSeven \/'
            'Shell("pv.exe -pr CTAudSvc.exe", AppWinStyle.Hide, True, -1)
            Mixer_CT.Stop()
        End If
    End Sub
    Private Sub UseCTMixerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseCTMixerToolStripMenuItem.Click
        If Not UseCTMixerToolStripMenuItem.Checked Then
            UseCTMixerToolStripMenuItem.Checked = True
            Mixer_CT.Start()
            HumanActCT = True
            Exit Sub
        Else
            UseCTMixerToolStripMenuItem.Checked = False
            Mixer_CT.Start()
            HumanActCT = True
            Exit Sub
        End If
    End Sub
    Public Function StateChg(ByVal StateTXT As String) As Boolean
        Dim CleanTXT As String = Trim(StateTXT)
        If Len(CleanTXT) = 1 Then
            If CleanTXT = "0" Then
                Return False
            Else
                Return True
            End If
        End If
        Return False
    End Function
    Private Sub ApplySvcDiffs()
        ' DISABLED: TESTING: Output the mouse position:
        'Dim x1, y1 As String
        'x1 = Control.MousePosition.X.ToString()
        'y1 = Control.MousePosition.Y.ToString()
        'LogPrint("TESTING: MousePosition.X=" + x1)
        'LogPrint("TESTING: MousePosition.Y=" + y1)
        ' Handle The Case Where We Have Service State Changes
        Dim DifferPS As Collection = Checkers.Dif()
        For Each aService As String In DifferPS
            If aService = LCase("CTAudSvc") Or aService = LCase("AudioRepeater") Then
                If aService = LCase("CTAudSvc") Then
                    If Not UseCTMixerToolStripMenuItem.Checked Then
                        If Not HumanActCT Then
                            If Not FirstCheck Then
                                'LogPrint("SILENT ALERT!!! I just noticed an unsolicited start of the Creative Line Monitor!")
                                UseCTMixerToolStripMenuItem.Checked = True
                            End If
                        Else
                            HumanActCT = False
                        End If
                        Continue For
                    Else
                        If Not HumanActCT Then
                            If Not FirstCheck Then
                                LogPrint("MASTER ALERTED: I just noticed an unsolicited death of the Creative Line Monitor!")
                                BalloonMessage("I just noticed an unsolicited death of the Creative Line Monitor!")
                                UseCTMixerToolStripMenuItem.Checked = False
                            End If
                        Else
                            HumanActCT = False
                        End If
                        Continue For
                    End If
                End If
            End If
        Next aService
    End Sub
    Private Sub SvcCheck_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SvcCheck.Tick
        ' Run The Service Check thru CheckLib
        Checkers.Run()
        ' Run our hooks into the changed service(s) (if any)
        ApplySvcDiffs()
        ' Run NettyAnn (now HollyNet) ProcLoop
        myBotNet.ServLoop()
    End Sub
    Private Sub BootDone_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BootDone.Tick
        BootDone.Stop()
        BalloonMessage("OK, I'm ""Nice & Warm"" now!")
    End Sub
    Private Sub MyDiaryLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyDiaryLogToolStripMenuItem.Click
        If HollyLog.Visible Then
            HollyLog.BringToFront()
        Else
            HollyLog.Show()
        End If
    End Sub
    Private Sub ToggleSurroundMode(ByVal TheatreMode As Boolean)
        If Not TheatreMode Then
            Shell("surroundswitch_creative.exe Stereo-Enveloper", AppWinStyle.Hide, True, 30)
            'MooVHugToolStripMenuItem.Checked = False
        ElseIf TheatreMode Then
            Shell("surroundswitch_creative.exe Theatre-Surround", AppWinStyle.Hide, True, 30)
            'MooVHugToolStripMenuItem.Checked = True
        End If
    End Sub
    Private Sub MooVHugToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Not MooVHugToolStripMenuItem.Checked Then
        'ToggleSurroundMode(True)
        'Exit Sub
        'ElseIf MooVHugToolStripMenuItem.Checked Then
        'ToggleSurroundMode(False)
        'Exit Sub
        'End If
    End Sub
    Private Sub SetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetupToolStripMenuItem.Click
        AnnyConf.ShowDialog()
    End Sub
    Private Sub AnnAlysisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SmartAnn.Show()
    End Sub
    Private Sub HumanoidalActivityChecker_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HumanoidalActivityChecker.Tick
        HumieAnn.RunCheck()
    End Sub
    Private Sub PowerModsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not PowerMOD.Visible Then PowerMOD.Show()
    End Sub
    Private Sub UseSmartPowerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseSmartPowerToolStripMenuItem.Click
        If UseSmartPowerToolStripMenuItem.Checked = False Then
            If My.Settings.SmartPlan_Busy = "NotchYet" Then
                ChangePowerPlan("381b4222-f694-41f0-9685-ff5bb260df2e", True)
            Else
                ChangePowerPlan(My.Settings.SmartPlan_Busy, True)
            End If
            UseSmartPowerToolStripMenuItem.Checked = True
            ReloadMe()
            Exit Sub
        End If
        If UseSmartPowerToolStripMenuItem.Checked = True Then
            UseSmartPowerToolStripMenuItem.Checked = False
            ReloadMe()
            Exit Sub
        End If
    End Sub
    Private Sub NetSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        NettyWiz.ShowDialog()
    End Sub
    Private Sub LapTrackNEXTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TempFile As String = "C:\Temp.GET"
        My.Computer.Network.DownloadFile("http://192.168.1.3/?cmd=NEXT", TempFile)
        If My.Computer.FileSystem.FileExists(TempFile) Then
            My.Computer.FileSystem.DeleteFile(TempFile)
        End If
    End Sub
    Private Sub LapTrackLASTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TempFile As String = "C:\Temp.GET"
        My.Computer.Network.DownloadFile("http://192.168.1.3/?cmd=LAST", TempFile)
        If My.Computer.FileSystem.FileExists(TempFile) Then
            My.Computer.FileSystem.DeleteFile(TempFile)
        End If
    End Sub
    Private Sub SpeedCheck_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeedCheck.Tick
        If My.Computer.FileSystem.FileExists(Application.StartupPath + "\WebFetch.Tmp") Then
            If NAT_Warn Then
                MsgBox("Seems we've got two HollyHug instances contending for access to WAN stats.  I won't warn you again during this session, but thought you should know.")
            End If
            NAT_Warn = False
            My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\WebFetch.Tmp")
        End If
        Dim Check614 As RP614v4 = New RP614v4("admin", "some_really_strong_password")
        Check614.LetsDoIt()
        TrayIcon.Text = nMachine
        If Check614.dns_kbyt <= 0 And Check614.ups_kbit <= 0 Then
            TrayIcon.Text &= vbNewLine & "No Current"
            TrayIcon.Text &= vbNewLine & "WAN Status"
            If NAT_Warn Then
                MsgBox("Seems we've got two HollyHug instances contending for access to WAN stats.  I won't warn you again during this session, but thought you should know.")
            End If
            NAT_Warn = False
        Else
            TrayIcon.Text &= vbNewLine & "Download: " & Trim(Str(Check614.dns_kbyt)) & "KB/s"
            TrayIcon.Text &= vbNewLine & "Upstream: " & Trim(Str(Check614.ups_kbit)) & "kbps"
        End If
    End Sub
End Class
