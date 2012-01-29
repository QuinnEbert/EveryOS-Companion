Imports Microsoft.VisualBasic

Public Class HollyOpt
    ''
    '' HollyOpt :: HollyAnn's Library for Semi-Intelligent Program-Based APM Optimisation
    ''

    ' This collection (of String's) holds "System" module-names (ones that should NEVER trip SmartPower-shunting) 
    Public SysProgs As Collection
    ' This collection (of String's) holds "Game" and "App" module-names (ones that should TRY TO trip SmartPower-shunts)
    Public FunProgs As Collection

    ' CONSTRUCTOR: Create valid Collections of the two module-name collections
    Public Sub New()
        SysProgs = New Collection()
        FunProgs = New Collection()
    End Sub

    ' This sub will go through the passed-in EXEs_Dir (NOT recursively) and add any EXE's it
    ' finds into the Shunting-exclusion list (SysProgs)
    Public Sub MkSysDir(Optional ByVal EXEs_Dir As String = "C:\SomeSystemDirectoryPath")
        For Each prog_exe As String In FileIO.FileSystem.GetFiles(EXEs_Dir, FileIO.SearchOption.SearchTopLevelOnly, "*.EXE")
            If SysProgs.Contains(prog_exe) Then HollyHug.LogPrint("ReadEXEs: Attempt to re-add duplicate module """ + prog_exe + """!")
            If Not SysProgs.Contains(prog_exe) Then SysProgs.Add(LCase(prog_exe), LCase(prog_exe))
        Next prog_exe
    End Sub

    ' This sub will go through the passed-in EXEs_Dir (WITH RECURSION) and add any EXE's it
    ' finds into the Shunting-inclusion list (FunProgs)
    Public Sub MkFunDir(Optional ByVal EXEs_Dir As String = "C:\SomeGamesInstallationPath")
        For Each prog_exe As String In FileIO.FileSystem.GetFiles(EXEs_Dir, FileIO.SearchOption.SearchAllSubDirectories, "*.EXE")
            If SysProgs.Contains(prog_exe) Then HollyHug.LogPrint("ReadEXEs: Attempt to re-add duplicate module """ + prog_exe + """!")
            If Not FunProgs.Contains(prog_exe) Then FunProgs.Add(LCase(prog_exe), LCase(prog_exe))
        Next prog_exe
    End Sub

    ' This function returns a string-containing collection of program module-names of programs which are currently
    ' running whose existance means we should (at least try to) shunt SmartPower management
    Public Function GetAnyRunningSmartApps() As Collection
        Dim myReturn As New Collection()
        ' This collection will be used to hold a 'temporary list' of our affecting-processes, prior to them being
        ' merged into the list that we will return from this function
        Dim ProcList As Collection = New Collection()
        ''
        '' STEP ONE: Build a list of processes to check through for existance...
        ''
        ' Go through all VALID processes...
        For Each proc_fun As String In FunProgs
            ProcList.Add(proc_fun)
        Next proc_fun
        ' KLUDGE: Now, go through all SYSTEM module-names, and remove any module names that may be dupes from FunProcs
        For Each proc_sys As String In SysProgs
            If ProcList.Contains(proc_sys) Then ProcList.Remove(proc_sys)
        Next proc_sys
        ''
        '' STEP TWO: Return our list of active module-names that would shunt...
        ''
        Return ProcList
    End Function
End Class
