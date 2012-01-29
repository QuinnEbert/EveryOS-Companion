Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System

Public Class RP614v4
    Private LogsText As String
    Private Username As String
    Private Password As String
    ' We'll access this directly (from other modules/classes) for the "real" results (for app usage):
    Public Bandwidth As String
    ' And provide them also in more-convenient, seperate numbers, too:
    Public ups_kbit As Integer
    Public dns_kbyt As Integer
    Private Sub LogPrint(Optional ByVal aMessage As String = "")
        LogsText &= aMessage & vbNewLine
    End Sub
    Public Function GiveLogs() As String
        Return LogsText
    End Function
    Private Function WipeUps(ByVal InString As String) As String
        Dim MyString As String = InString
        While Not InStr(MyString, "  ", CompareMethod.Text) = 0
            MyString = Replace(MyString, "  ", " ")
        End While
        Return MyString
    End Function
    ''' <summary>
    ''' Private function grabs document at given URL, and returns its contents as string
    ''' 
    ''' NOTE:
    ''' This function returns errors retrieveable via GiveLogs()
    ''' </summary>
    ''' <returns>String with document's contents (blank on error, error details gettable via GiveLogs() function.</returns>
    ''' <remarks>Nothing.</remarks>
    Private Function WebFetch(ByVal FetchURL As String) As String
        ''''This is a TEMPORARY file that'll hold whatever we get from the URL:
        Dim tempfile As String = Application.StartupPath + "\WebFetch.Tmp"
        ''''Holds the String value we'll return at the end of the function
        Dim SendBack As String = ""
        LogPrint("WebFetch in RP614v4")
        Try
            '' Give it the good old "college try"...
            If Not Username = "" And Not Username = "" Then
                LogPrint("ARE using authentication")
                My.Computer.Network.DownloadFile(FetchURL, tempfile, Username, Password)
            Else
                LogPrint("NOT using authentication")
                My.Computer.Network.DownloadFile(FetchURL, tempfile)
            End If
            LogPrint(" + Download succeeded")
            SendBack = My.Computer.FileSystem.ReadAllText(tempfile)
            LogPrint(" + Read in data from temp file")
            My.Computer.FileSystem.DeleteFile(tempfile)
            LogPrint(" + Cleaned up the temp file")
        Catch ex As Exception
            '' Write down the error detail...
            LogPrint(" + Hit an Exception:")
            LogPrint(" +  = Message: """ + ex.Message + """")
            '' FIXME: Hack to save time writing logprint's:
            Return ""
        End Try
        LogPrint(" + Process Completed")
        '' Return:
        Return SendBack
    End Function
    Public Sub LetsDoIt()
        ''Hit this URL to grab statistical data from a 614v4 in human-readable HTML format:
        Dim Stats_At As String = "http://192.168.1.1/mtenstatisticTable.html"

        '' Let's grab the stats from the 614...
        Dim goton614 As String = WebFetch(Stats_At)

        '' Trim off from the beginning of our fetch:
        goton614 = ComfyPHP.strstr(goton614, "<span class=""thead"">WAN</span>")
        '' Get ready and them trim off from end:
        Dim endof614 As String = ComfyPHP.strstr(goton614, "</tr>")
        ' And a bit more... ;-)
        goton614 = Replace(goton614, endof614, "")
        If Not ComfyPHP.LastFail Then
            Dim Tempwidth As String = WipeUps(Replace(ComfyPHP.strip_tags(goton614), vbTab, " "))
            Tempwidth = Replace(Tempwidth, vbCr, "")
            Tempwidth = Replace(Tempwidth, vbLf, "")
            Tempwidth = Replace(Tempwidth, "     ", " ")
            Dim LinesNum As Integer = 0
            ''FIXME: Tourettic of me, isn't this?  ;-)
            Bandwidth = ""
            For Each one_part As String In Strings.Split(Tempwidth, " ")
                If Not Trim(one_part) = "" Then
                    LinesNum = LinesNum + 1
                    If LinesNum = 7 Then
                        Bandwidth &= "U=" & Trim(one_part) & "B/sec" & vbNewLine
                        ups_kbit = ((Val(one_part) * 8) / 1024)
                    ElseIf LinesNum = 8 Then
                        Bandwidth &= "D=" & Trim(one_part) & "B/sec"
                        dns_kbyt = (Val(one_part) / 1024)
                    End If
                End If
            Next one_part
        Else
            Bandwidth = ""
        End If
    End Sub
    Public Sub New(Optional ByVal un As String = "", Optional ByVal pw As String = "")
        '' Ensure we have a valid set logstext for our instance
        LogsText = ""
        '' Ensure we have a valid set bandwidth result holder for our instance
        Bandwidth = ""
        '' Bring in username and password from the function's variables
        Username = un 'username
        Password = pw 'password
        ' Give these valid values, just to be safe:
        ups_kbit = 0
        dns_kbyt = 0
        '' Just to be sure
        LogPrint("Ready to Roll!")
    End Sub
End Class
