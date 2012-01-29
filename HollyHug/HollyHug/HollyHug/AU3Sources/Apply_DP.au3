;
; Edited by Quinn for clarity:
; Monday, November 2, 2009 at 3:48:31PM US/Eastern (Greensboro, NC)
;

; Make sure we have a command line argument (the profile file in <ProgramData>\NVIDIA to activate)
If Not $CmdLine[0] = 1 Then
	; FOR NOT ENOUGH PARAMATERS
	; 
	MsgBox(4096,"NVIDIA Display Profile Switcher","Incorrect Command Line Paramaters!",10)
Else
	; WE HAVE ENOUGH PARAMATERS
	; 
	; Start up the NVIDIA ControlPanel UI:
	ShellExecute("nvcplui.exe","","c:\windows\system32")
	; Wait for the UI Window To Load:
	WinWait("NVIDIA Control Panel")
	; Activate it again, just to be safe:
	WinActivate("NVIDIA Control Panel")
	; Allow a grace period (Goddammed NVCPL-UI is slow as shite):
	Sleep(4000)
	; 
	; NOTE: Going through the menus here using keys -- I put in a small delay after each step, so we can see
	; what's going on here:
	; 
	; Activate "Profile" menu
	Send("!p")
	Sleep(335)
	; Choose "Load" option
	Send("l")
	Sleep(335)
	; 
	; NOW WE'RE IN THE "Load Profile" DIALOGUE:
	;
	; Give focus to "File Name" textbox (ALT+N)
	Send("!n")
	Sleep(2000)
	; Emulate typing in the profile file name:
	Send($CmdLine[1])
	Sleep(250)
	;
	; Keeping this OFF: Probably what breaks stuff:
	;
	; These are supposed to ensure we have those ugly checkboxes ticked:
	;Send("!c!o!d!a!3")
	;Sleep(250)
	; Press "Load" or "OK" button (can't remember what NV called it):
	Send("{ENTER}")
	; Wait for the damned "Confirm" box to show up:
	WinWait("NVIDIA Control Panel")
	Sleep(250)
	; It's up -- Confirm the change of profile:
	Send("Y")
	; Wait for "Display Settings Change" momentary confirm dialogue (god -- I thought OS's were pretty stable about DPM switch now):
	WinWait("Apply Changes")
	Sleep(250)
	; Confirm the keeping of the setting (Yeah, I know the machine could "explode" if we don't like the setting -- Hesa Crista)
	Send("Y")
	Sleep(250)
	; ALT+F4
	Send("!{F4}")
EndIf
