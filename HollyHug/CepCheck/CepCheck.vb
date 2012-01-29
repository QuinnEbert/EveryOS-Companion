Imports Microsoft.VisualBasic
Imports Microsoft.Win32
Imports System.Windows
Imports System.Windows.Forms

Public Class CepCheck
    Private Sub CepCheck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Cepstral").OpenSubKey("Swift").OpenSubKey("VoicePaths")
        Dim names As String() = rk.GetValueNames()
        Dim s As String
        For Each s In names
            TextArea.Text &= s & vbNewLine
        Next s
    End Sub
End Class
