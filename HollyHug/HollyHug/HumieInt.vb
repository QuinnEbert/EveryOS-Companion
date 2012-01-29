Imports Microsoft.VisualBasic
Imports Microsoft.Win32
Imports System.Math
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Windows.Forms.Control
Imports System.Drawing.Point

Public Class HumieInt
    ''
    '' HumieAnn :: HollyAnn's Library for Checking for Humanoid Interaction
    ''

    ' This pair is where the mouse was when we made a verbal REST announcement:
    Public Shared RestPoxX As Integer = 0
    Public Shared RestPoxY As Integer = 0
    ' This pair is where the mouse was when we make a verbal WORK announcement:
    Public Shared WorkPosX As Integer = 0
    Public Shared WorkPosY As Integer = 0

    ' For tracking the size (in pixels) of the monitor(s) (virtual desktop(s)?)
    Public Shared s1x, s1y, s2x, s2y As Integer
    ' For tracking the threshold of mouse-movement which is considered to be the result of "human interaction"
    Public Shared mtx, mty As Integer
    ' For tracking whether or not a secondary display is connected...
    Public Shared TwoDesks As Boolean
    ' For tracking the mouse coordinates we had on the previous iteration...
    Public Shared mousePosX, mousePosY As Integer

    ' This variable allows us to track whether or not we've got an active 'intelligent' APM state change...
    Public Shared SmartPower As Boolean = False
    ' This variable allows us to track whether or not Human Interaction was detected by the most recent RunCheck() call
    Public Shared HadHuman As Boolean = False
    ' This variable keeps track of how many RunCheck()'s in-a-row have seen no human interaction (NOTE: resets to zero whenever we see activity)
    Public Shared IdleRuns As Integer

    ' This variable sets how many ticks we need to idle before we change APM modes
    Public Shared NapTicks As Integer = (4 * My.Settings.IdleTime)   ' grab from settings!

    ' A variable that allows us to track if the user is playing a game, and, if so, when they're done, "do something special"
    Public Shared GameTime As Boolean = False

    ' Internal constant for a 15-percent mouse-movement threshold
    Public Const mmThresh As Decimal = 0.15

    Public Function Is_Debug() As Boolean
        Return HollyHug.IsDebug()
    End Function
    Public Function IsDebug() As Boolean
        Return Is_Debug()
    End Function
    Public Sub LogPrint(ByVal sMessage As String)
        ' If IsDebug() Then HollyHug.LogPrint("HumanInt(): " + sMessage)
    End Sub

    Public Sub Setup()
        ' This function (re-)initializes the library's various "constants" that help us determine whether or not
        ' human interaction is present.
        LogPrint("STARTUP: Setting up the Human Presence Intelligence System!")
        ' Enumerate displays (virtual desktops/et al):
        Dim Displays As Screen() = Screen.AllScreens()
        ' Seperate the two possible (of first two -- yes, it IS limited, I know) displays out...
        Dim DISP_ONE As Screen = Displays(Displays.GetLowerBound(0))
        Dim DISP_TWO As Screen = Displays(Displays.GetUpperBound(0))
        ' Ease access...
        s1x = DISP_ONE.Bounds.Width
        s1y = DISP_ONE.Bounds.Height
        ' Handle display setup correctly for our situation...
        If Displays.GetLowerBound(0) = Displays.GetUpperBound(0) Then
            ' A second display IS NOT connected 
            TwoDesks = False
            s2x = 0
            s2y = 0
            LogPrint("STARTUP: ONE display(s) are connected!")
        Else
            ' A second display **IS** connected 
            TwoDesks = True
            s2x = DISP_TWO.Bounds.Width
            s2y = DISP_TWO.Bounds.Height
            LogPrint("STARTUP: TWO display(s) are connected!")
        End If
        If Not TwoDesks Then
            ' ONE DISPLAY = Just use it's width and height, and multiply them by the threshold...
            mtx = System.Math.Round((s1x * mmThresh))
            mty = System.Math.Round((s1y * mmThresh))
        Else
            ' FOR TWO DISPLAYS:
            ' WIDTH  is based upon the total width (added) of the two desktops
            mtx = System.Math.Round(((s1x + s2x) * mmThresh))
            ' HEIGHT is based upon whichever (if either) of the two desktops has the taller height (a bit of a KLUDGE)
            If s2y > s1y Then
                ' Desktop TWO is bigger ... Use its HEIGHT...
                mty = System.Math.Round((s2y * mmThresh))
            Else
                ' Desktop ONE is bigger, OR is SAME HEIGHT as Desktop TWO ... Use height of Desktop ONE...
                mty = System.Math.Round((s1y * mmThresh))
            End If
        End If
        'HollyHug.LogPrint("HumanInt(): " + "STARTUP: Mouse X Threshold (" + Str((mmThresh * 100)) + "%) is " + Str(mtx) + " pixels!")
        'HollyHug.LogPrint("HumanInt(): " + "STARTUP: Mouse Y Threshold (" + Str((mmThresh * 100)) + "%) is " + Str(mty) + " pixels!")
        LogPrint("STARTUP: System Setup has Completed!")
    End Sub
    Private Function IsRatial(ByVal x As Integer, ByVal y As Integer) As Boolean
        Dim NTSCUSTV, CINEFILM, TAPEFILM As Decimal
        NTSCUSTV = 3 / 4
        CINEFILM = 9 / 16
        TAPEFILM = 10 / 16
        ' The following statements might act 'improperly' in the POSSIBLE case where "x" is equal to "y", and, since we would
        ' return FALSE anyway in that case, I'll test that first, and try to avoid any sort of oddity that might happen there
        If x = y Then Return False
        If (Min(x, y) / Max(x, y)) = NTSCUSTV Then Return True
        If (Min(x, y) / Max(x, y)) = CINEFILM Then Return True
        If (Min(x, y) / Max(x, y)) = TAPEFILM Then Return True
        Return False
    End Function
    Private Function ItsAGame() As Boolean
        ' KLUDGE: This logic is a wee bit "weak" so, for the moment, it's DISABLED
        ' Return FALSE immediately to disable this stuff...
        Return False

        ' This function contains the 'smart logic' for finding out whether or not we think a full-screen game (or app)
        ' is running...

        ''
        '' FIRST: Try and find the nearest (to 8 pixels, higher and lower than exact, if-needed) mouse coordinates for
        '' division and analysis for "game-running" behaviour
        ''
        'Dim LowerX, LowerY, UpperX, UpperY, MouseX, MouseY As Integer
        'MouseX = Control.MousePosition.X
        'If MouseX Mod 8 = 0 Then
        'LowerX = MouseX : UpperX = MouseX
        'Else
        'LowerX = MouseX - (MouseX Mod 8)
        'UpperX = MouseX + (MouseX Mod 8)
        'End If
        'MouseY = Control.MousePosition.Y
        'If MouseY Mod 8 = 0 Then
        'LowerY = MouseY : UpperY = MouseY
        'Else
        'LowerY = MouseY - (MouseY Mod 8)
        'UpperY = MouseY + (MouseY Mod 8)
        'End If

        ''
        '' FINAL: Run the tests, and return the resutls...
        ''
        'If IsRatial(LowerX, LowerY) Then Return True
        'If IsRatial(LowerX, UpperY) Then Return True
        'If IsRatial(UpperX, LowerY) Then Return True
        'If IsRatial(UpperX, UpperY) Then Return True

        ' If we get here, we'll return false (no game would seem to be running)...
        'Return False
    End Function
    Public Sub RunCheck()
        ' This function runs a "single pass" of our "present humanity" checks...

        ' FIXME: HACK: Don't bother running through all these checks if we're
        ' not using SmartPower:
        If Not HollyHug.UseSmartPowerToolStripMenuItem.Checked Then
            'If IsDebug() Then HollyHug.LogPrint("SHUNT: Not going to run HumanCheck because SmartPower is OFF.")
            'HollyHug.LogPrint("SmartPower(): TICK...TOCK...*NO*!")
            HadHuman = True
            Exit Sub
        Else
            'HollyHug.LogPrint("SmartPower(): TICK...TOCK...*OK*!")
        End If

        ' FIRST: Create some locals to hold mouse positions relevant to this RunCheck...
        Dim x1, y1, x2, y2 As Integer
        x1 = mousePosX
        y1 = mousePosY
        x2 = Control.MousePosition.X
        y2 = Control.MousePosition.Y
        ' ALSO: Use some 'fancy logic' to find out if it's at-all possible that we may be running a full-screen app (game, etc)
        ' and appropriately shunt, if this seems to be the case...

        ' Determine if any mouse positions have changed more than our allowed thresholds...
        If ((Max(x1, x2) - Min(x1, x2)) >= mtx) Or ((Max(y1, y2) - Min(y1, y2)) >= mty) Then
            If Not ItsAGame() And HollyHug.UseSmartPowerToolStripMenuItem.Checked And Not ServiceCheckingModule.RunCheck("eHShell") And Not ServiceCheckingModule.RunCheck("iTunes") Then LogPrint("CHECKUP: Human Interaction WAS Detected!")
            HadHuman = True
            ' RESET the Idle Run counter...
            IdleRuns = 0
        Else
            If Not ItsAGame() And HollyHug.UseSmartPowerToolStripMenuItem.Checked And Not ServiceCheckingModule.RunCheck("eHShell") And Not ServiceCheckingModule.RunCheck("iTunes") Then LogPrint("CHECKUP: Human Interaction NOT Detected!")
            HadHuman = False
            ' INCREMENT the Idle Run counter...
            IdleRuns = IdleRuns + 1
        End If

        If IdleRuns > 0 And IdleRuns <= NapTicks Then
            If Not ItsAGame() And HollyHug.UseSmartPowerToolStripMenuItem.Checked And Not ServiceCheckingModule.RunCheck("eHShell") And Not ServiceCheckingModule.RunCheck("iTunes") Then LogPrint("TestInfo: " + Trim(Str((((30 / 15) - IdleRuns) + 1))) + " more idle runs needed before SmartPower!")
            ' *NOT* DISABLED - Horrifically VERBOSE debugging output...
            If IsDebug() Then HollyHug.BalloonMessage("I need " + Trim(Str((NapTicks - IdleRuns))) + " more idles!")
        End If

        ' NEXT: If we've gone more than 5 minutes without human interaction (or, if we've seen new interaction after
        ' more than five), make the 'necessary' intelligent changes to the machine's APM state...

        ' Observations on my part suggest that it'd be a good idea to shunt (not use) SmartPower when eHShell is running
        ' ...Check that now, and shunt SmartPower calculations if MCE is currently running...
        ' ...ALSO, check that we don't mess around with power settings during BedTime! (WHOOPS!)...
        ' FIXME: CHECK: Does having an Extender session open bugger this up?
        If Not ItsAGame() And HollyHug.UseSmartPowerToolStripMenuItem.Checked And Not ServiceCheckingModule.RunCheck("eHShell") And Not ServiceCheckingModule.RunCheck("iTunes") Then
            ' OK...MCE's not open, run a HumanInt loop, and act "appropriately" (not that HollyAnn really understands that
            ' concept!)  *LOL*
            LogPrint("-- MARK -- ***MCE IS STOPPED***")
            LogPrint("-- MARK -- ***ITUNES STOPPED***")
            LogPrint("-- MARK -- ***I'M NOT SLEEPY***")
            LogPrint("-- MARK -- ***NO GAME ACTIVE***")
            Dim value As Integer
            If Not SmartPower Then
                ServiceCheckingModule.RunCheck("SS_Check")
                If IdleRuns > NapTicks And ServiceCheckingModule.GotSaver() = True Then
                    SmartPower = True
                    If Not My.Settings.SmartPlan_Idle = "NotchYet" Then
                        HollyHug.ChangePowerPlan(My.Settings.SmartPlan_Idle, True)
                        'HollyHug.LogPrint("SmartPower(TM): Powering for IDLE!")
                    End If
                    HollyHug.TrayIcon.Text = "HollyAnn (Smart Kitty!)"
                    value = CInt(Int((3 * Rnd()) + 1))
                    If value = 1 Then
                        HollyHug.BalloonMessage("I feel so alone!")
                    ElseIf value = 2 Then
                        HollyHug.BalloonMessage("Where, oh where, has my Master gone?")
                    ElseIf value = 3 Then
                        HollyHug.BalloonMessage("Hello?!?  Anybody home?")
                    End If
                    RestPoxX = x1
                    RestPoxY = y1
                    If ServiceCheckingModule.GotSaver() = True Then
                        'HollyHug.LogPrint("NapTimer Triggered By Sceensaver")
                        Dim curr_X As Integer = Control.MousePosition.X
                        Dim curr_Y As Integer = Control.MousePosition.Y
                        'HollyHug.LogPrint("MousePos.X=" + Str(curr_X))
                        'HollyHug.LogPrint("MousePos.Y=" + Str(curr_Y))
                        HollyHug.SayAloud("It's time for a nap!")
                    End If
                End If
            Else
                '' FIXME (Dec 07 2010) : Wouldn't this (and/or the above top-level of IF) be a great place to see if we've really had screensaver
                ''   affect the IDLE/WORK switching?
                If ServiceCheckingModule.GotSaver() = False Or IdleRuns = 0 Then
                    SmartPower = False
                    If Not My.Settings.SmartPlan_Busy = "NotchYet" Then
                        HollyHug.ChangePowerPlan(My.Settings.SmartPlan_Busy, True)
                        'HollyHug.LogPrint("SmartPower(TM): Powering for BUSY!")
                    End If
                    HollyHug.TrayIcon.Text = "HollyAnn"
                    value = CInt(Int((3 * Rnd()) + 1))
                    If value = 1 Then
                        HollyHug.BalloonMessage("I've missed you so much!")
                    ElseIf value = 2 Then
                        HollyHug.BalloonMessage("Welcome back, my Master!")
                    ElseIf value = 3 Then
                        HollyHug.BalloonMessage("Nice to have you back!")
                    End If
                    If Not ServiceCheckingModule.GotSaver() Then
                        'HollyHug.LogPrint("Wake Triggered By Sceensaver End")
                        Dim curr_X As Integer = Control.MousePosition.X
                        Dim curr_Y As Integer = Control.MousePosition.Y
                        'HollyHug.LogPrint("MousePos.X=" + Str(curr_X))
                        'HollyHug.LogPrint("MousePos.Y=" + Str(curr_Y))
                        '' FIXME : This is a hack to try and keep silent when display-sleep pre-empts us:
                        If curr_X = RestPoxX And curr_Y = RestPoxY Then
                            'HollyHug.LogPrint("HACK: No speech welcoming you back; display seems to've slept.")
                        Else
                            HollyHug.SayAloud("Welcome back!")
                        End If
                    End If
                End If
            End If
            If GameTime Then
                value = CInt(Int((3 * Rnd()) + 1))
                If value = 1 Then
                    HollyHug.BalloonMessage("Did you have a fun time?  ;-)")
                ElseIf value = 2 Then
                    HollyHug.BalloonMessage("How was the game?  ;-)")
                ElseIf value = 3 Then
                    HollyHug.BalloonMessage("So, who won?  ;-)")
                End If
                GameTime = False
            End If
        Else
            ' MCE and/or BedTime! is running...
            ' * Log this (DEBUG ONLY)
            If ServiceCheckingModule.RunCheck("eHShell") Then LogPrint("-- MARK -- ***MCE IS RUNNING***")
            If ServiceCheckingModule.RunCheck("iTunes") Then LogPrint("-- MARK -- ***ITUNES RUNNING***")
            'If HollyHug.BedTimeToolStripMenuItem.Checked Then LogPrint("-- MARK -- ***I AM IN MY BED***")
            If ItsAGame() Then
                LogPrint("SmartPower(TM): SHUNT: A game seems to be running!")
                GameTime = True
            End If
            ' * Reset The IdleRuns Count (Good Measure?)
            IdleRuns = 0
        End If

        ' FINALLY: record this check's mouse positions for comparison on the next run...
        mousePosX = Control.MousePosition.X
        mousePosY = Control.MousePosition.Y
    End Sub
End Class
