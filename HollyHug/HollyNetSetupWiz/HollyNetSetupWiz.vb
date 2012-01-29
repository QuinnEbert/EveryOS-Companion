Module HollyNetSetupWiz
    Function Ask(ByVal Question As String) As Boolean
        If MsgBox(Question, MsgBoxStyle.YesNo, "HollyHug Network Setup - Question") = MsgBoxResult.No Then Return False
        Return True
    End Function
    Sub Main()
        Dim ReportTo As String = "NetSetup.rpt"
        '' Default values of next two are just to keep warnings out of my VB.NET environment (mad OCD!)
        Dim prvReply As Boolean = False
        Dim curQuery As String = ""
        '' Ask user if OK to run the setup wizard:
        curQuery = "Welcome to HollyHug Windows Toolkit's Setup Wizard for HollyNet!" & vbNewLine _
            & vbNewLine _
            & "HollyNet provides many features which can make your network with multiple computers running HollyHug extremely powerful, and" & vbNewLine _
            & "amazingly easier and more comfortable to use." & vbNewLine _
            & vbNewLine _
            & "Features of HollyNet include:" & vbNewLine _
            & "=> Control (nearly) all HollyHug features of other machines from across your network." & vbNewLine _
            & "=> Enables ""Holly Home"" functionality, allowing laptops to provide more-tailored power use (such as brighter LCD panel) when a laptop discovers it has returned to its ""home"" network." & vbNewLine _
            & "=> Enabling HollyNet also enables HollyHug to gather very detailed information about many Laptops' battery systems and their ongoing status as the machine runs." & vbNewLine _
            & vbNewLine _
            & "So, what do you think?  Are you ready to set up HollyNet now?" & vbNewLine
        prvReply = Ask(curQuery)
    End Sub
End Module
