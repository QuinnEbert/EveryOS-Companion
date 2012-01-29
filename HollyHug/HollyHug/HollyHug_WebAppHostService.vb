Imports System.Diagnostics
Imports System.Net
Imports System
Imports Microsoft.Win32
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.FileIO
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.Windows.Forms
Imports System.Windows.Forms.Application

Public Class HollyHug_WebAppHostService

    Public Event PostALPI(ByVal cwh As String, ByVal fwh As String, ByVal crv As String)

    Public Event LogPrint(ByVal sMessage As String)

    ' OCD ALERT!!! Used to remove possible double-backslashes from pathnames!  ;)
    Function ConDoubleSlash(ByVal theStr As String) As String
        Dim retStr As String = theStr
        While Not InStr(retStr, "\\") = 0
            retStr.Replace("\\", "&$")
            retStr.Replace("&$", "\")
        End While
        Return retStr
    End Function
    Sub ServMain()
        While True
            Try
                ' Make the port referrable-to in multiple places:
                Dim listenerUsePort As String = "8080"
                ' Create a localhost address with a random port
                Dim listenerAddress As String = "http://127.0.0.1:" + listenerUsePort + "/"
                ' Setup the httplistener class
                Dim listener As New HttpListener()
                listener.Prefixes.Add(listenerAddress)
                listener.Start()
                RaiseEvent LogPrint("WebService: " + "Listening on port (" + listenerUsePort + ")...")
                ' Set our callback method
                Dim asyncResult As IAsyncResult = listener.BeginGetContext(New AsyncCallback(AddressOf HttpListener_Callback), listener)
                ' Wait for an event
                asyncResult.AsyncWaitHandle.WaitOne()
                RaiseEvent LogPrint("WebService: " + " + Handling a request")
                ' Put the application in a loop to wait for the async process to *really* finish processing
                Dim timeout As DateTime = DateTime.Now.AddMinutes(2)
                While Not asyncResult.IsCompleted
                    If DateTime.Now > timeout Then
                        Return
                    End If
                End While
                RaiseEvent LogPrint("WebService: " + "...Done!")
            Catch ex As System.Net.HttpListenerException
                ' Ignore and calm down the odd overzealous user...
                System.Threading.Thread.Sleep(1000)
            End Try
        End While
    End Sub
    Sub HttpListener_Callback(ByVal result As IAsyncResult)
        RaiseEvent LogPrint("WebService: " + " + Handling a request")
        Dim listener As HttpListener = DirectCast(result.AsyncState, HttpListener)
        ' Call EndGetContext to complete the asynchronous operation.
        Dim context As HttpListenerContext = listener.EndGetContext(result)
        Dim request As HttpListenerRequest = context.Request()
        Dim requestString As String = request.Url.ToString()
        'Dim token As String = request.QueryString("oauth_token")
        'Dim verifier As String = request.QueryString("oauth_verifier")
        ' Obtain a response object.
        Dim response As HttpListenerResponse = context.Response()
        Dim responseString As String = "<HTML><BODY>Oh boy, I can't believe it <I>actually</I> works!</BODY></HTML>"
        Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(responseString)
        response.ContentLength64 = buffer.Length
        Dim output As System.IO.Stream = response.OutputStream
        ''FIXME: Validate keys are existing?
        Dim a As String = request.QueryString.GetValues("cwh")(0)
        Dim b As String = request.QueryString.GetValues("fwh")(0)
        Dim c As String = request.QueryString.GetValues("crv")(0)
        RaiseEvent PostALPI(a, b, c)
        '''' Carry on... '''
        output.Write(buffer, 0, buffer.Length)
        output.Close()
        response.Close()
        listener.Stop()
    End Sub
End Class
