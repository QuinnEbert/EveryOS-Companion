Imports Microsoft.VisualBasic
Imports Microsoft.Win32

Module CepCheck
    Function CepCheck() As String
        Dim rv As String = ""
        Try
            Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Cepstral").OpenSubKey("Swift").OpenSubKey("VoicePaths")
            Dim names As String() = rk.GetValueNames()
            Dim s As String
            Dim i As Integer = names.GetUpperBound(0) - names.GetLowerBound(0)
            If names.GetLowerBound(0) = 0 Then
                i = i + 1
            End If
            For Each s In names
                i = i - 1
                rv &= s
                If Not i = 0 Then
                    rv &= vbNewLine
                End If
            Next s
        Catch ex As Global.System.NullReferenceException
            HollyHug.LogPrint("Cepstral Support is Completely Absent!")
        End Try
        Return rv
    End Function
End Module
