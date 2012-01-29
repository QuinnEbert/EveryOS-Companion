''' <summary>
''' "Comfort" functions for PHP-Familiarized Developers
''' </summary>
''' <remarks>
''' Author: David Quinn Ebert
''' http://www.quinnebert.net
''' </remarks>
Public Module ComfyPHP
    Public LastFail As Boolean = False
    '' 
    '' INTERNAL-ONLY CONVENIENCE FUNCTIONS:
    '' 
    Private Function ChrAtPos(ByVal tx As String, ByVal ci As String) As String
        If ci = 1 Then
            Return Left(tx, 1)
        Else
            Return Left(Right(tx, Len(tx) - ci), 1)
        End If
    End Function
    '' 
    '' FUNCTIONS FOR UTILITY BY THE PUBLIC:
    '' 
    Public Function strip_tags(ByVal FromData As String) As String
        ''WARNING: we don't support allowed_tags here!

        Dim ReString As String = ""
        Dim cc As String

        Dim Proccing As Boolean = False

        For ci As Integer = 1 To Len(FromData)
            cc = ChrAtPos(FromData, ci)
            If Not Proccing Then
                If cc = "<" Then
                    Proccing = True
                Else
                    ReString &= cc
                End If
            Else
                If cc = ">" Then
                    Proccing = False
                End If
            End If
        Next ci
        Return ReString
    End Function
    Public Function strstr(ByVal haystack As String, ByVal needle As String) As String
        Dim MyReturn As String = ""
        Dim From_Pos As Integer

        From_Pos = InStr(haystack, needle, CompareMethod.Text)

        If From_Pos = 0 Then
            LastFail = True
            '' We already have a blank-string MyReturn, no need
            ''   to modify it in any way for a non-find
        Else
            LastFail = False

            Dim RightLen As Integer = (Len(haystack) - From_Pos)

            MyReturn = Right(haystack, (RightLen + 1))
        End If

        Return MyReturn
    End Function
End Module
