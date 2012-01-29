Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Strings
Imports System
Imports System.Net
Imports System.Net.Sockets

Public Class HollyNetServer

    ' Private Class Variables
    Private server As TcpListener ' Shared between functions, but not classes!
    Private servePort As Int32 = 9185 ' Running on port TCP/9185
    Private serveAddr As IPAddress = IPAddress.Any ' Binding ourselves to all IPvX sockets

    ' Constructor: Initialize and start the listening TCP server socket:
    Sub New()
        ' NOTE!: Only initialize on a first startup (NullReferenceException WARNING!)
        server = Nothing
        Try
            ' Initialize the TCPListener PROPER:
            server = New TcpListener(serveAddr, servePort)
            ' DISABLED: DOESN'T WORK -- Fine-tune connection queueing - allow only 10 queued connections:
            'server.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.MaxConnections, 10)
            ' Start listening for client requests:
            server.Start()
            ' Testing output (FIXME: Testing Only?)
            HollyHug.LogPrint("HollyNet(): Waiting for a connection... ")
        Catch e As SocketException
            MsgBox("HollyHug Networking Has Encountered An Error:" + vbNewLine + vbNewLine + "SocketException: " + e.ToString(), MsgBoxStyle.Critical, "HollyHug NETWORK ERROR")
            server.Stop()
        End Try
    End Sub
    ' A "call-as-needed" pending-connection acception loop
    Public Sub ServLoop()
        ' FIXME: Nasty hack to make this MoFo compatible with LinuxPHP Stream_Socket_Client:
        Dim did_it As Boolean = False
        ' FIXME: Let user set this as a setting?
        Dim passwd As String = "some_really_strong_password"
        Try
            ' The connection-handling loop (runs while if/while we have pending connection requests):
            If server.Pending() Then
                ' DISABLED -- Extraneous debugging output:
                'HollyHug.LogPrint("HollyNet(): Connections are waiting -- Running an acception loop...")
                While server.Pending()
                    ' Perform a blocking call to accept requests.
                    ' You could also user server.AcceptSocket() here.
                    Dim client As TcpClient = server.AcceptTcpClient()
                    HollyHug.LogPrint("HollyNet(): Connected!")
                    ' Buffer for reading data:
                    Dim bytes(1024) As Byte
                    Dim data As String = Nothing
                    data = Nothing
                    ' Get a stream object for reading and writing
                    Dim stream As NetworkStream = client.GetStream()
                    Dim i As Int32
                    did_it = False
                    ' Loop to receive all the data sent by the client.
                    i = stream.Read(bytes, 0, bytes.Length)
                    While (i <> 0)
                        ' Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i)
                        HollyHug.LogPrint("HollyNet(): Received: " + data)
                        ' Process the data sent by the client.
                        Dim send As String = Nothing
                        Dim recv() As String = Strings.Split(Trim(data), " ", 3)
                        Dim a, b, c, e As Integer
                        If recv.GetLowerBound(0) = 0 Then
                            b = (recv.GetLowerBound(0) + 1)
                            a = (recv.GetUpperBound(0) + 1)
                        Else
                            b = recv.GetLowerBound(0)
                            a = recv.GetUpperBound(0)
                        End If
                        c = recv.GetLowerBound(0)
                        e = recv.GetUpperBound(0)
                        ' FIXME ABOVE: Need proper support for "true" MultiArg
                        '  Commands!!!
                        Dim d As Integer = (e - 1)
                        ' Convert the Command_Name to lowercase for easy checking:
                        Dim nCommand As String = Strings.LCase(recv(c))
                        ' Get/store the reported machine name...
                        ' FIXME: I want to have Machine_Name rep'd with uppercase
                        '  first character:
                        Dim nMachine As String = Strings.StrConv(recv(d), VbStrConv.ProperCase)
                        If ((a - b) + 1) >= 2 Then
                            If nCommand = "authoriseme" Or nCommand = "authorizeme" Then
                                If ((a - b) + 1) >= 3 Then
                                    ' Passkey should be CASE-SENSITIVE:
                                    Dim nAuthKey As String = recv(e)
                                    ' NOTE! ABOVE: We support both British and American
                                    '  spellings here!
                                    If nAuthKey = passwd Then
                                        send = "OKAY Welcome " + nMachine
                                    Else
                                        send = "FAIL Authorisation (NumArguments=" + Trim(Str(((a - b) + 1))) + ")"
                                    End If
                                Else
                                    send = "FAIL CommandArguments (" + Trim(Str(((a - b) + 1))) + ")"
                                End If
                            Else
                                send = "FAIL CommandUnsupported!"
                            End If
                        Else
                            send = "FAIL NumArguments (" + Trim(Str(((a - b) + 1))) + ")"
                        End If
                        If Not send = Nothing Then
                            did_it = True
                        End If
                        If did_it Then
                            Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes(send)
                            ' Send back a response.
                            stream.Write(msg, 0, msg.Length)
                            HollyHug.LogPrint("HollyNet(): Sent: " + send)
                            ' Shutdown and end connection
                            client.Close()
                            ' FIXME: Hack to make Linux connections compliant:
                            i = 0
                        Else
                            i = stream.Read(bytes, 0, bytes.Length)
                        End If
                    End While
                End While
                ' DISABLED -- Extraneous debugging output:
                'Else
                'HollyHug.LogPrint("HollyNet(): **** MARK **** -- No connections are waiting!")
            End If
        Catch e As InvalidOperationException
            HollyHug.LogPrint("HollyHug NETWORK ERROR: InvalidOperationException: " + e.ToString())
        Catch e As SocketException
            HollyHug.LogPrint("HollyHug NETWORK ERROR: SocketException: " + e.ToString())
            server.Stop()
        End Try
    End Sub
End Class
