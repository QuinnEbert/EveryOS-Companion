Imports Microsoft.Win32
Imports Microsoft.Win32.SystemEvents
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Media
Imports System.Threading.Thread
Imports Microsoft.VisualBasic
Imports System
Imports System.EventArgs
Imports System.Collections
Imports System.Diagnostics
Imports System.IO
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports SpeechLib
Imports Growl
Imports System.Windows.Forms.Application
Imports System.Threading

Public Class HollyHug

    Public InitLoad As Boolean = True

    Private PowerDmp As Boolean = True

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

    Public AppLocat As String = Application.StartupPath
    Public VocsPath As String = Application.StartupPath + "\VoxCache\"

    Public Shared PowerPlans As New ReferAPM()

    Private OurBrand As Branding

    Private myBotNet As HollyNetServer

    ' NotDrill allows to force Debugger to use non-debug-statement-infused code at debug runtime
    ' Set False to allow Debug to progress normally (with the additional debugging features)
    ' Set True to allow Debug to progress like the application is retail/shipped
    'Private NotDrill As Boolean = False
    Private NotDrill As Boolean = True

    Public Older_OS As Boolean = False

    Public TheVoice As String = ""

    Private nMachine As String = StrConv(Trim(My.Application.GetEnvironmentVariable("ComputerName")), VbStrConv.ProperCase)

    Private pwrTween As Integer = 0

    ' To track whether or not we yet have a real estimate of battery timing:
    Private BatteriesPlus As Boolean = False

    'FIXME: This is for SpeedCheck (RP614v4) but sounds very generic...
    Dim TempFile As String = Application.StartupPath() + "\" + "tmpSpeed.chk"

    ''
    '' FIXME: NOTE: This is the "most interesting bit" from PowerStatus:
    ''
    Public PowerBit As String = "BatteryLifePercent"

    '' Hold the battery powerlevel as of last PowerCheck:
    Public OurPower As Double = 100

    '' The text that indicates AC is currently applied to the battery:
    Public Power_AC As String = "Online"
    '' Hold the last result of the PowerLineStatus poll:
    Public PowerSrc As String = Power_AC
    '' The text that indicates PowerLineStatus:
    Public PLStatus As String = "PowerLineStatus"

    ' Only try to start web server once (OOPS!)
    Public WebIsRun As Boolean = False

    ' Fallback speech support for Microsoft SAPI:
    Public voice As SpVoice

    ' 
    ' ADVANCED LAPTOP POWER INFORMATION STUFF:
    ' 
    Private apIndexA As Integer = -1
    Private apIndexB As Integer = -1
    Private apIndexC As Integer = -1
    Private PowerApp As String = AppLocat + "\battinfo.exe"
    'Private PowerTxt As String = AppLocat + "\battinfo.txt"
    Private PowerAxe As String = System.Environment.GetEnvironmentVariable("TEMP") + "\battinfo.axe"
    Private BattInfo As BatteryInfoReader
    Public PowerInf As Integer = 0

    ' Path to the M-Audio (Avid) Delta 1010-LT Control Panel Applet:
    Private DeltaCPL As String = Environment.GetEnvironmentVariable("SystemRoot") + "\System32\M-AudioDeltaControlPanel.exe"

    ' Support for user/systems interaction via Growl
    Private GrowlCom As Connector.GrowlConnector
    Private GrowlApp As Growl.Connector.Application
    Private Const GrowlApp_Name As String = "HollyHug Windows Toolkit"
    Private GrowlMsg As Growl.Connector.Notification
    Private GrowlNoteType_Systemal As Growl.Connector.NotificationType
    Private Const GrowlNoteType_Systemal_Name = "SYSTEMAL"
    Private GrowlNoteType_Powerage As Growl.Connector.NotificationType
    Private Const GrowlNoteType_Powerage_Name = "POWERAGE"

    '' MultiCPU Support Statuses:
    '  -1 = Kit/Cores detection not yet done
    '   0 = Kit not installed or only one Core detected
    '   1 = Kit installed and more than one Core detected
    Public MultiCPU As Integer = -1
    '' MultiCPU Tool kit "kill file"
    '   On each polling pass, MCPU Kit will check for this file.
    '   If the file exists, it will exit cleanly.
    '   This provides a bastardized form of IPC between it and
    '     HollyHug.
    Public KillFile As String = AppLocat + "\MultiprocessorDevianceBabysitter.die"

    '' For webservicehoster:
    Private wahs As New HollyHug_WebAppHostService()
    Private t As New System.Threading.Thread(AddressOf wahs.ServMain)

    '' Handler for BattInfo HTTP Listener callback:
    'AddHandler wahs.PostALPI, AddressOf PostALPIEventHandler

    '' From MSDN, at:
    ''   <http://msdn.microsoft.com/en-us/library/system.windows.application.exit.aspx>
    Public Enum ApplicationExitCode
        Success = 0
        Failure = 1
        CantWriteToApplicationLog = 2
        CantPersistApplicationState = 3
    End Enum

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
        'Dim Log2File As String = Application.StartupPath + "\HollyHug.Log"
        'WriteAllText(Log2File, (sMessage + vbNewLine), True)
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
        AnnyConf.SmartAPM_Work.Items.Clear()
        For Each APM_Plan As APM_Pair In PowerPlans.All()
            AnnyConf.SmartAPM_Idle.Items.Add(APM_Plan.NAME)
            AnnyConf.SmartAPM_Busy.Items.Add(APM_Plan.NAME)
            AnnyConf.SmartAPM_Work.Items.Add(APM_Plan.NAME)
        Next APM_Plan
        ' And, FINALLY, (if requested) we'll reload NVIDIA Display Profiles
        ''FIXME: Disabled (Not planning a return for this!)  ;(
        'If Not APM_Only Then
        'ReloadNV(False)
        'End If
    End Sub
    Private Sub PopAbout()
        Me.Show()
    End Sub
    ' Call-forward sub to allow the HTTP microserver to refresh the advanced laptop power info
    Public Sub PostALPIEventHandler(ByVal cwh As String, ByVal fwh As String, ByVal crv As String)
        Dim a, b, c As String
        a = cwh + " watt-hours remaining"
        b = crv + " volts current charge"
        c = fwh + " watt-hours when full"
        apIndexA = TrayMenuItemIndexByTag("pwrInfoA")
        apIndexB = TrayMenuItemIndexByTag("pwrInfoB")
        apIndexC = TrayMenuItemIndexByTag("pwrInfoC")
        TrayMenu.Items(apIndexA).Text = a
        TrayMenu.Items(apIndexB).Text = b
        TrayMenu.Items(apIndexC).Text = c
    End Sub
    Private Sub TrayDive_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrayDive.Tick
        If Me.Visible Then
            Me.Visible = False
        Else
            ''FIXME: What?  Did I run out of good ideas?  ;)
        End If
        If Not HollyPic.Visible Then
            TrayDive.Stop()
            Button1.Enabled = True
            Dim InitBuff As Boolean
            UseCTMixerToolStripMenuItem.Checked = ServiceCheckingModule.RunCheck("CTAudSvc")
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
            HumieAnn.Setup()
            HumanoidalActivityChecker.Start()
            If NotDrill Then
                myBotNet = New HollyNetServer()
            End If
            SvcCheck.Start()
            PowerCheck.Start()
            '' Restore the previous state of M-Audio Delta 1010's S/PDIF Monitor:
            UseDeltaDAToolStripMenuItem.Checked = My.Settings.UseDelta
            '' But disable DeltaSPDIF if the panel isn't found:
            UseDeltaDAToolStripMenuItem.Enabled = FileExists(DeltaCPL)
            '' And, uncheck this too if it is disabled:
            If Not UseDeltaDAToolStripMenuItem.Enabled Then
                UseDeltaDAToolStripMenuItem.CheckState = CheckState.Unchecked
            End If
            SetDelta(My.Settings.UseDelta)
            '' MultiCPU Detection:
            ''CODE: If FileExists(KillFile) Then
            '''''FIXME: The below doubly-commented-out lines are a much "safer" way of doing
            '''''       my technique for managing MultiCPU's fake RPC behavior.  But, users are
            '''''       likely to be annoyed when things don't work nicely, and I'm not willing
            '''''       to touch my AU3 code for the first 2011 OpenBeta (need to keep up my
            '''''       appearances and all like that).
            '' Cowardly don't run if restarted too quickly:
            ''CODE: MsgBox("MultiCPU Toolkit won't be started.  You appear to have restarted HollyHug too quickly to allow IPC/RPC to work between the two processes." + vbNewLine + vbNewLine + "If you know what you're doing, you can fix this immediately by deleting the file at:" + vbNewLine + """" + KillFile + """", MsgBoxStyle.Exclamation, "MultiCPU Tool Kit Problem")
            ''CODE: LogPrint("MultiCPU: Won't be started!  KillFile was present at startup time!")
            '' ^ ...Yeah, yeah, I know!  ;)  
            ''CODE: Else
            'FIXME: NUF hack for crappy DIE file handling:
            If FileExists(KillFile) Then
                DeleteFile(KillFile)
            End If
            ' First, most optimal, step is to check if the kit is installed:
            If FileExists(AppLocat + "\MultiprocessorDevianceBabysitter.exe") Then
                LogPrint("MultiCPU: Kit is installed, begin detection NOW...")
                Dim CountCPU As String = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS").Trim()
                If CountCPU = Nothing Or CountCPU = "" Or Len(CountCPU) > 2 Then
                    MultiCPU = 0
                    LogPrint("MultiCPU: Disabled (Processor Count Invalid or Not Set)!")
                Else
                    If Val(CountCPU) = 1 Then
                        MultiCPU = 0
                        LogPrint("MultiCPU: Disabled (Only One CPU on this Machine)!")
                    Else
                        MultiCPU = 1
                        If Not FileExists(AppLocat + "\MultiprocessorDevianceBabysitter_About.exe") Then
                            '' Give them a "fair warning" in this odd case...
                            LogPrint("MultiCPU: WARN: The ""About"" program for MultiCPU is missing...")
                            LogPrint("MultiCPU: WARN: ...Clicking ""About"" in its tray will crash it!")
                        End If
                        LogPrint("MultiCPU: Your computer has " + CountCPU + " CPU's!")
                        Shell(AppLocat + "\MultiprocessorDevianceBabysitter.exe", AppWinStyle.NormalFocus, False)
                        LogPrint("MultiCPU: We are now enabled and running!")
                    End If
                End If
            Else
                MultiCPU = 0
                LogPrint("MultiCPU: Disabled (Kit Not Installed)!")
            End If
        End If
        '' 2011.01.12 - Web App Hosting Service
        If Not WebIsRun Then
            LogPrint("HollyNet: Webserver about to be brought up...")
            AddHandler wahs.LogPrint, AddressOf LogPrint
            AddHandler wahs.PostALPI, AddressOf PostALPIEventHandler
            t.Start()
            LogPrint("HollyNet: We should now be up and running ...")
            WebIsRun = True
        Else
            LogPrint("HollyNet: Duplicated attempt to do webserver!")
        End If
        '' 2011.08.22 - Advanced Laptop Power Info
        'Try
        'BattInfo.ReadInfo()
        'apIndexA = TrayMenuItemIndexByTag("pwrInfoA")
        'apIndexB = TrayMenuItemIndexByTag("pwrInfoB")
        'apIndexC = TrayMenuItemIndexByTag("pwrInfoC")
        'If Not BattInfo.areValid Then
        'WriteAllText(PowerAxe, "Time2Die", False)
        'TrayMenu.Items.RemoveAt(apIndexA)
        'TrayMenu.Items.RemoveAt(apIndexA)
        'TrayMenu.Items.RemoveAt(apIndexA)
        ' This is redundant (it is already set this way), but, whatever...
        'PowerInf = 0
        'Else
        'TrayMenu.Items(apIndexA).Text = "(awaiting first update)"
        'TrayMenu.Items(apIndexB).Text = "(awaiting first update)"
        'TrayMenu.Items(apIndexC).Text = "(awaiting first update)"
        'PowerInf = 1
        'BattPoll.Start()
        'End If
        'Catch ex As System.IO.IOException
        'LogPrint("BatteryInfoReader: Error while reading the battinfo.txt regular update interval file...")
        'LogPrint("BatteryInfoReader: The exception message was: """ + ex.Message.ToString() + """")
        'End Try
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
    Private Function TrayMenuItemIndexByTag(ByVal Tag As String)
        Dim LastItem As Integer = ((TrayMenu.Items.Count) - 1)
        For curIndex As Integer = 0 To LastItem
            If TrayMenu.Items.Item(curIndex).Tag = Tag Then
                Return curIndex
            End If
        Next curIndex
        Return -1
    End Function
    Public Sub SayAloud(ByVal Say_What As String)
        Dim NoBinary As String = "SayAloud(): Swift(R) Binary Not Found!"
        '' An easy way to kludge the swift binary name for regression testing:
        Dim SwiftEXE As String = "swift.exe"
        If TheVoice = "NONE" Then
            If Is_Debug() Then
                TheVoice = "Diane"
            Else
                LogPrint("SayAlout(): No voice selected!")
                Exit Sub
            End If
        End If
        If Not DirectoryExists(VocsPath) Then My.Computer.FileSystem.CreateDirectory(VocsPath)
        If Not FileExists(VocsPath + VoxClean(Say_What)) Then
            Try
                Shell(SwiftEXE + " -n " + TheVoice + " -p audio/volume=30 -o """ + (VocsPath + VoxClean(Say_What)) + """ """ + Say_What + """", AppWinStyle.MinimizedFocus, True)
            Catch ex As System.IO.FileNotFoundException
                LogPrint(NoBinary)
            End Try
            If FileExists(VocsPath + VoxClean(Say_What)) Then
                My.Computer.Audio.Play(VocsPath + VoxClean(Say_What))
            Else
                Try
                    Shell(SwiftEXE + " -n " + TheVoice + " -p audio/volume=30 """ + Say_What + """", AppWinStyle.MinimizedFocus, True)
                Catch ex As System.IO.FileNotFoundException
                    LogPrint(NoBinary)
                End Try
            End If
        Else
            My.Computer.Audio.Play(VocsPath + VoxClean(Say_What))
        End If
    End Sub
    Public Sub App_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim KillFile As String = System.Environment.GetEnvironmentVariable("TEMP") + "\MultiprocessorDevianceBabysitter.die"
        If MultiCPU = 1 Then
            WriteAllText(KillFile, "Time2Die", False)
        End If
        'If PowerInf = 1 Then
        WriteAllText(PowerAxe, "Time2Die", False)
        'End If
    End Sub
    Private Sub HollyHug_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler ApplicationExit, AddressOf App_Shutdown
        GrowlNoteType_Systemal = New Growl.Connector.NotificationType(GrowlNoteType_Systemal_Name, "System Notification")
        GrowlNoteType_Powerage = New Growl.Connector.NotificationType(GrowlNoteType_Powerage_Name, "Power State Changed")
        GrowlApp = New Growl.Connector.Application(GrowlApp_Name)
        GrowlApp.Icon = StartupPath() + "\HollyPic.jpg"
        GrowlCom = New Growl.Connector.GrowlConnector()
        GrowlMsg = New Growl.Connector.Notification(GrowlApp_Name, GrowlNoteType_Systemal_Name, Nothing, "HollyHug is On-the-Job!", "HollyHug started and is now able to communicate via Growl!  Raawr!")
        GrowlCom.Register(GrowlApp, {GrowlNoteType_Systemal, GrowlNoteType_Powerage})
        GrowlCom.Notify(GrowlMsg)
        ' Instantiate the fallback SAPI voice (we must, even if we don't wind up using it)...
        voice = New SpVoice
        If IsDebug() Then
            voice.Speak("Initializing SAP-I . . .", SpeechVoiceSpeakFlags.SVSFDefault)
        End If
        'If Me.Visible Then
        'Me.Hide()
        'End If
        ' For 'good measure' reset the default (first) selected-index on the two AnnyConf ComboBoxes...
        'AnnyConf.SmartAPM_Idle.SelectedIndex = 0
        'AnnyConf.SmartAPM_Busy.SelectedIndex = 0
        'AnnyConf.SmartAPM_Work.SelectedIndex = 0
        'FIXME: This is HACK-ISH way to make sure we're always acting from the "proper" working directory...
        ChDir(Application.StartupPath())
        ' Setup for branding:
        OurBrand = New Branding()
        Dim HollyPic_NamePtr As String = OurBrand.GetAsset("HollyPic.jpg")
        If InStr(HollyPic_NamePtr, "*") = 0 Then PictureBox1.ImageLocation = HollyPic_NamePtr
        Dim NotVista As Boolean = False
        Dim WinClass As String = ""
        LogPrint("HollyAnn is starting up...")
        If Not InStr(vWindows, "Vista") = 0 Then
            LogPrint(" + Running on Windows Vista!")
            WinClass = "Windows Vista"
            Older_OS = False
        ElseIf Not InStr(vWindows, "XP") = 0 Then
            LogPrint(" + Running on Windows XP!")
            NotVista = True
            WinClass = "Windows XP"
            Older_OS = True
        ElseIf Not InStr(vWindows, "Windows 7") = 0 Then
            WinClass = "Windows 7"
            Older_OS = False
        Else
            LogPrint(" + Windows Version is UNKNOWN!")
            NotVista = True
            WinClass = "Unsupported OS"
            Older_OS = True
        End If
        Checkers.Add("Creative X-Fi (Vista) Inputs Monitor", "CTAudSvc")
        'Checkers.Add("Virtual Audio Cable Audio Repeater", "AudioRepeater")
        LogPrint("...Monitored services have been added to checker!")
        Randomize()
        LogPrint("...Random number generator has been initialised!")
        My.Settings.Reload()
        TheVoice = My.Settings.TheVoice
        LogPrint("...Settings have been loaded from persistent storage!")
        'BedTimeToolStripMenuItem.Checked = My.Settings.UseDelta
        'ConfigUA.PopPlugs()
        LogPrint("...DirectSound output devices have been loaded!!")
        Dim value As Integer = CInt(Int((3 * Rnd()) + 1))
        If value = 1 Then
            SayAloud("Greetings!")
        ElseIf value = 2 Then
            SayAloud("Hello!")
        ElseIf value = 3 Then
            SayAloud("Welcome!")
        End If
        For Each argument As String In My.Application.CommandLineArgs
            If argument = "isBootUp" Then
                BootDone.Start()
                LogPrint("...This appears to be a Windows(R) Start-Up!")
                Exit For
            End If
        Next
        If Not BootDone.Enabled Then LogPrint("...This DOES NOT appear to be a Windows(R) Start-Up!")
        If Not QueryTheaterDevice(True) = Nothing Then
            LogPrint("...Theatre pinset is """ + QueryTheaterDevice(True) + """!")
        Else
            LogPrint("...Theatre pinset could not be determined at present time!")
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
        DisProfs.Enabled = False
        If My.Computer.FileSystem.DirectoryExists("C:\ProgramData\NVIDIA") Then
            DisProfs.Enabled = True
            ReloadNV(False)
        Else
            LogPrint("NVDisProfs disabled due to lack of support!")
        End If
        If (WinClass = "Windows 7") Then
            ''FIXME: Not yet implemented!
        Else
            LogPrint("Themeing disabled due to lack of support!")
        End If
        HollyNetToolStripMenuItem.Enabled = Is_Debug()
        ' Get ready to poll power information:
        'apIndexA = TrayMenuItemIndexByTag("pwrInfoA")
        'apIndexB = TrayMenuItemIndexByTag("pwrInfoB")
        'apIndexC = TrayMenuItemIndexByTag("pwrInfoC")
        Shell(PowerApp, AppWinStyle.Hide, False)
        ' This is nasty, but, gives slightly more assurance we'll have data on-hand for the first poll:
        'System.Threading.Thread.Sleep(2000)
        'Try
        'BattInfo = New BatteryInfoReader(PowerTxt)
        'Catch ex As System.IO.IOException
        'LogPrint("BatteryInfoReader: Error during the first time reading the battinfo.txt regular update interval file...")
        'LogPrint("BatteryInfoReader: The exception message was: """ + ex.Message.ToString() + """")
        'End Try
        ' Get ready for timed remainder of startup items:
        If Me.InitLoad Then
            Me.InitLoad = False
            Me.Visible = False
            TrayDive.Start()
        End If
        LogPrint("HollyHug is running on " + WinClass)
    End Sub
    Public Sub BalloonMessage(ByVal the_text As String, Optional ByVal OneTitle As String = Nothing)
        TrayIcon.BalloonTipText = the_text
        If Not OneTitle = Nothing Then
            TrayIcon.BalloonTipTitle = OneTitle
        Else
            TrayIcon.BalloonTipTitle = nMachine + " says:"
        End If
        TrayIcon.ShowBalloonTip((15 * 1000))
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
        t.Abort()
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
        'myBotNet.ServLoop()
    End Sub
    Private Sub BootDone_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BootDone.Tick
        BootDone.Stop()
        BalloonMessage("OK, I'm ""Nice'n'Warm"" now!")
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
    ''Private Sub MooVHugToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''''If Not MooVHugToolStripMenuItem.Checked Then
    ''''ToggleSurroundMode(True)
    ''''Exit Sub
    ''''ElseIf MooVHugToolStripMenuItem.Checked Then
    ''''ToggleSurroundMode(False)
    ''''Exit Sub
    ''''End If
    ''End Sub
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
    'Private Sub LapTrackNEXTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim TempFile As String = "C:\Temp.GET"
    '    My.Computer.Network.DownloadFile("http://192.168.1.3/?cmd=NEXT", TempFile)
    '    If My.Computer.FileSystem.FileExists(TempFile) Then
    '        My.Computer.FileSystem.DeleteFile(TempFile)
    '    End If
    'End Sub
    'Private Sub LapTrackLASTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim TempFile As String = "C:\Temp.GET"
    '    My.Computer.Network.DownloadFile("http://192.168.1.3/?cmd=LAST", TempFile)
    '    If My.Computer.FileSystem.FileExists(TempFile) Then
    '        My.Computer.FileSystem.DeleteFile(TempFile)
    '    End If
    'End Sub
    Private Sub SpeedCheck_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeedCheck.Tick
        ''FIXME: Quinn: 03-28-2010 - [Note] Shunted until I find a more "modular" way of doing this.
        TrayIcon.Text = nMachine
        Exit Sub
        '' ----- ----- ----- ----- -----
        '' Stuff For NAT_Warn BalloonMessage:
        Dim Warn_Top As String = "WAN Probing Failure:"
        Dim Warn_Bot As String = "Another machine on the network is currently accessing the gateway.  WAN stats cannot be accounted at this time."
        If My.Computer.FileSystem.FileExists(Application.StartupPath + "\WebFetch.Tmp") Then
            If NAT_Warn Then
                NAT_Warn = False
                If Is_Debug() Then
                    BalloonMessage(Warn_Bot, Warn_Top)
                End If
            End If
            My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\WebFetch.Tmp")
        End If
        Dim Check614 As RP614v4 = New RP614v4("admin", "some_really_strong_password")
        Check614.LetsDoIt()
        TrayIcon.Text = nMachine
        If Check614.dns_kbyt <= 0 And Check614.ups_kbit <= 0 Then
            TrayIcon.Text &= vbNewLine & "No Current"
            TrayIcon.Text &= vbNewLine & "WAN Status"
            If NAT_Warn Then
                NAT_Warn = False
                If Is_Debug() Then
                    BalloonMessage(Warn_Bot, Warn_Top)
                End If
            End If
        Else
            TrayIcon.Text &= vbNewLine & "Download: " & Trim(Str(Check614.dns_kbyt)) & "KB/s"
            TrayIcon.Text &= vbNewLine & "Upstream: " & Trim(Str(Check614.ups_kbit)) & "kbps"
            '' Allow to warn again if a future contention occours:
            NAT_Warn = True
        End If
    End Sub
    Private Sub PowerStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PowerStatusToolStripMenuItem.Click
        If Not PowerAnn.Visible Then
            PowerAnn.Visible = True
            PowerAnn.TickTock.Start()
        End If
    End Sub
    Private Sub PowerCheck_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PowerCheck.Tick
        Dim t As Type = GetType(System.Windows.Forms.PowerStatus)
        Dim pi As PropertyInfo() = t.GetProperties()
        Dim i As Integer
        Dim propnum As Integer = 100
        Dim propval As Object
        Dim prop As PropertyInfo = Nothing
        Dim NewState As String = Nothing
        Dim PowerSec As Integer
        Dim PowerMin As String
        For i = 0 To pi.Length - 1
            prop = pi(i)
            propval = prop.GetValue(SystemInformation.PowerStatus, Nothing)
            propnum = (Val(propval.ToString()) * 100)
            If pi(i).Name = PowerBit Then
                ' Menu item displaying power level information handling:
                If propnum = 100 Then
                    ' Don't display power timing at full charge:
                    mnuPowerLevelInformation.Text = "Battery is fully charged"
                Else
                    If Not propnum = OurPower Then
                        If propnum < OurPower Then
                            PowerSec = (pwrTween / (OurPower - propnum))
                            PowerMin = Math.Round((Trim(Str((PowerSec / 60))) * propnum), 0)
                            mnuPowerLevelInformation.Text = "Estimated " + PowerMin + " minutes to flat battery"
                        Else
                            PowerSec = (pwrTween / (propnum - OurPower))
                            PowerMin = Math.Round((Trim(Str((PowerSec / 60))) * (100 - propnum)), 0)
                            mnuPowerLevelInformation.Text = "Estimated " + PowerMin + " minutes to full battery"
                        End If
                        pwrTween = 0
                    Else
                        pwrTween = (pwrTween + ((PowerCheck.Interval) / 1000))
                    End If
                End If
                ' Audible notification of power level change handling:
                If propnum Mod My.Settings.PowerAnnouncePercentage = 0 Then
                    If propnum = 100 Then
                        If Not propnum = OurPower Then
                            SayAloud("Battery is now at full charge!")
                            BalloonMessage("My battery is now full!  I'm ready-to-rock whenever you are!", "Battery is now at full charge!")
                            GrowlMsg = New Growl.Connector.Notification(GrowlApp_Name, GrowlNoteType_Powerage_Name, Nothing, "Battery at Full Charge", "My battery is now full!  I'm ready-to-rock whenever you are!")
                            GrowlCom.Notify(GrowlMsg)
                        End If
                    Else
                        If propnum > OurPower Then
                            SayAloud("Battery recharged up to " & Str(propnum) & " percent!")
                            GrowlMsg = New Growl.Connector.Notification(GrowlApp_Name, GrowlNoteType_Powerage_Name, Nothing, "Battery Recharge Update", "Battery recharged up to " & Str(propnum) & " percent!")
                            GrowlCom.Notify(GrowlMsg)
                        ElseIf propnum < OurPower Then
                            SayAloud("Battery has run down to " & Str(propnum) & " percent!")
                            GrowlMsg = New Growl.Connector.Notification(GrowlApp_Name, GrowlNoteType_Powerage_Name, Nothing, "Battery Discharge Level", "Battery has run down to " & Str(propnum) & " percent!")
                            GrowlCom.Notify(GrowlMsg)
                        End If
                    End If
                End If
                OurPower = propnum
            ElseIf pi(i).Name = PLStatus Then
                NewState = propval.ToString().Trim()
                If Not PowerSrc = NewState Then
                    If NewState = Power_AC Then
                        SayAloud("Now Recharging!")
                        BalloonMessage("I am now running on AC outlet power!", "Now Recharging!")
                    Else
                        SayAloud("Now on Battery!")
                        BalloonMessage("I am now running on battery power!", "Now on Battery!")
                    End If
                End If
                PowerSrc = NewState
            End If
            If Not PowerDmp Then
                LogPrint(pi(i).Name.Trim() + "=" + propval.ToString())
            End If
        Next i
        PowerDmp = True
    End Sub
    Private Sub HollyNetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HollyNetToolStripMenuItem.Click
        If My.Settings.NetSetup Then
            MsgBox(NettyWiz.EnUS_NotYetImplemented, MsgBoxStyle.Critical, "Error")
        Else
            NettyWiz.Show()
        End If
    End Sub
    Private Sub SetDelta(ByVal SetState As Boolean)
        If UseDeltaDAToolStripMenuItem.Enabled Then
            If Not SetState Then
                Shell("DeltaSPDIFControllerDeactivate.exe", AppWinStyle.Hide, True, -1)
            Else
                Shell("DeltaSPDIFControllerEnactivate.exe", AppWinStyle.Hide, True, -1)
            End If
        End If
    End Sub
    Private Sub UseDeltaDAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseDeltaDAToolStripMenuItem.Click
        If Not UseDeltaDAToolStripMenuItem.Enabled Then Exit Sub
        If UseDeltaDAToolStripMenuItem.Checked = True Then
            UseDeltaDAToolStripMenuItem.Checked = False
        Else
            UseDeltaDAToolStripMenuItem.Checked = True
        End If
        My.Settings.UseDelta = UseDeltaDAToolStripMenuItem.Checked
        SetDelta(My.Settings.UseDelta)
        My.Settings.Save()
    End Sub

    'Private Sub BattPoll_Tick(sender As System.Object, e As System.EventArgs) Handles BattPoll.Tick
    '    Dim a, b, c As String
    '    BattInfo.ReadInfo()
    '    a = BattInfo.CurrWatt + " watt-hours remaining"
    '    b = BattInfo.CurrVolt + " volts current charge"
    '    c = BattInfo.FullWatt + " watt-hours when full"
    '    apIndexA = TrayMenuItemIndexByTag("pwrInfoA")
    '    apIndexB = TrayMenuItemIndexByTag("pwrInfoB")
    '    apIndexC = TrayMenuItemIndexByTag("pwrInfoC")
    '    TrayMenu.Items(apIndexA).Text = a
    '    TrayMenu.Items(apIndexB).Text = b
    '    TrayMenu.Items(apIndexC).Text = c
    'End Sub
End Class
