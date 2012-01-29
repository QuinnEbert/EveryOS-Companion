#cs --------------------------------------------------------------------------------------

This script allows us to automatically assign Uniprocessor affinities to
programs that misbehave on multi-cpu and multicore systems

Indirect thanks go to user "bobwya" for his post at the following URL
http://www.tomshardware.com/forum/179198-28-processor-affinity-automatically#t1781686
for his script from which this particular little script was based upon

The script has been rewritten a good bit with universality in mind.  Nonetheless, proper
attribution is still in-order.

#ce --------------------------------------------------------------------------------------

#Include <WinAPI.au3>
#Include <Constants.au3>

Const  $c_test_executable="RavenShield.exe"
Global $a_test_PID_list, $h_test

Local $tempDir=EnvGet("TEMP")
;ConsoleWrite("tempDir=" & $tempDir & @CRLF)
;Exit 0

; SysTray Icon Properties (Name/Icon)
TraySetToolTip("MultiCPU Compatibility Tool")
TraySetIcon("MultiprocessorDevianceBabysitter.ico")

; SysTray Icon (Re: Menu Popup) Options
Opt("TrayOnEventMode",1)
Opt("TrayMenuMode",1)

; SysTray Icon will pop menu on both left and right click:
TraySetClick(9) ; Yes, this IS the AuIT default, and I know that!  OCD rocks! ;)

;;SysTray Menu Items and Events:
;
; Menu Option: "About"
;
$item_chk = TrayCreateItem("About...")
TrayItemSetOnEvent(-1,"TrayEvent_About")
;
; Menu Item Seperator
;
TrayCreateItem("")
;
; Menu Option: "Exit"
;
$item_bye = TrayCreateItem("Exit")
TrayItemSetOnEvent(-1,"TrayEvent_Exit")
; Commit the menu:
TraySetState()

; Globalize the "about" menu item to allow us to deal with AuIT's crappy "check item" logic:
global $item_chk;

; Main Process/Interact Loop:
While 1
If FileExists($tempDir & "\MultiprocessorDevianceBabysitter.die") Then
	FileRecycle($tempDir & "\MultiprocessorDevianceBabysitter.die")
	Exit
EndIf
Sleep(20000)

$a_test_PID_list = ProcessList ($c_test_executable)

Switch $a_test_PID_list[0][0]
	Case 1
		$h_test = _WinAPI_OpenProcess($PROCESS_QUERY_INFORMATION+$PROCESS_SET_INFORMATION, False, $a_test_PID_list[1][1])
		_WinAPI_SetProcessAffinityMask($h_test, 0x01)
	; FIXME: Allow setting affinity of multiple processes with the same image name?
EndSwitch
WEnd

; Function to handle "About" on the traymenu:
Func TrayEvent_About()
	ShellExecuteWait("MultiprocessorDevianceBabysitter_About.exe")
	TrayItemSetState($item_chk,$TRAY_UNCHECKED)
EndFunc

; Function to handle "Exit" on the traymenu:
Func TrayEvent_Exit()
    Exit
EndFunc

Exit