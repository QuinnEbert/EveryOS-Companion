Option Explicit
Dim usercode : usercode = MsgBox("Do you want to install the Microsoft Visual C++ 2010 Runtimes?  This package is required to ensure proper operation of HollyHug Windows Toolkit, especially the networked UPS feature, and the expert-user laptop power information functionality.",4,"Install Required Support Components?")
if usercode = vbYes then
  WScript.Quit 0
end if
WScript.Quit 1
