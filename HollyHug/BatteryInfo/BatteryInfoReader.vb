Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.VisualBasic.FileIO.FileSystem

Public Class BatteryInfoReader

    Public CurrVolt As String
    Public CurrWatt As String
    Public FullWatt As String
    Public areValid As Boolean

    Private InfoFile As String

    Public Sub ReadInfo()
        Dim TempData As String = ReadAllText(InfoFile)
        Dim TempBits() As String = TempData.Split(vbCrLf)
        CurrVolt = TempBits(4).Trim()
        CurrWatt = TempBits(2).Trim()
        FullWatt = TempBits(0).Trim()
        If CurrVolt = "4294967.500000" Then
            CurrVolt = "( null )"
        End If
        If CurrWatt = "4294967.500000" Then
            CurrWatt = "( null )"
        End If
        If FullWatt = "4294967.500000" Then
            FullWatt = "( null )"
        End If
        If Not CurrVolt = "( null )" And Not CurrWatt = "( null )" And Not FullWatt = "( null )" Then
            ' Awesome!
            areValid = True
        End If
    End Sub

    'FIXME: It might be a bad idea to redistribute that path down there... ;)
    Sub New(Optional ByVal Use_File As String = "Z:\Dropbox\Projects\HollyHug\BuildAll\battinfo.txt")
        InfoFile = Use_File
        areValid = False
        ReadInfo()
    End Sub

End Class
