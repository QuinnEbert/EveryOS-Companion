Option Explicit
Dim usercode : usercode = MsgBox("Do you wish to allow me to apply the required system security settings to support HollyHug's remote control web server?  If you're on the fence, please do a google search for 'netsh http urlacl' (in double quotes) to learn more.  Be aware that not applying these settings will result in reduced functionality and will cause the advanced laptop power information feature to be unusable--of course, you can always reinstall or upgrade later, and you'll be allowed to set these features up again.  Allow me to apply these settings now, then?  If you allow me to apply these, and you have Windows User Account Control enabled, you'll need to choose to accept the change in the UAC security dialog that will be displayed.",4,"Apply Required System Security Support Settings?")
if usercode = vbYes then
  WScript.Quit 0
end if
WScript.Quit 1
