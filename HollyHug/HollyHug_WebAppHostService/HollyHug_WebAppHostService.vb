Imports System.Diagnostics
Imports System.Net
Module HollyHug_WebAppHostService
    Sub Main()
        While True
            ' Create a localhost address with a random port
            Dim listenerAddress As String = "http://localhost:8080/"
            ' Setup the httplistener class
            Dim listener As New HttpListener()
            listener.Prefixes.Add(listenerAddress)
            listener.Start()
            Console.Write("Ready for a request...")
            ' Set our callback method
            Dim asyncResult As IAsyncResult = listener.BeginGetContext(New AsyncCallback(AddressOf HttpListener_Callback), listener)
            ' Wait for an event
            asyncResult.AsyncWaitHandle.WaitOne()
            Console.WriteLine("GOT ONE!")
            ' Put the application in a loop to wait for the async process to *really* finish processing
            Dim timeout As DateTime = DateTime.Now.AddMinutes(2)
            While Not asyncResult.IsCompleted
                If DateTime.Now > timeout Then
                    Return
                End If
            End While
            Console.WriteLine("Done with that one!...OH YEAH!")
        End While
    End Sub
    Sub HttpListener_Callback(ByVal result As IAsyncResult)
        Dim listener As HttpListener = DirectCast(result.AsyncState, HttpListener)
        ' Call EndGetContext to complete the asynchronous operation.
        Dim context As HttpListenerContext = listener.EndGetContext(result)
        Dim request As HttpListenerRequest = context.Request
        'Dim token As String = request.QueryString("oauth_token")
        'Dim verifier As String = request.QueryString("oauth_verifier")
        ' Obtain a response object.
        Dim response As HttpListenerResponse = context.Response
        Dim responseString As String = "<HTML><BODY>Oh boy, I can't believe it <I>actually</I> works!</BODY></HTML>"
        Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(responseString)
        response.ContentLength64 = buffer.Length
        Dim output As System.IO.Stream = response.OutputStream
        output.Write(buffer, 0, buffer.Length)
        output.Close()
        response.Close()
        listener.Close()
    End Sub
End Module
