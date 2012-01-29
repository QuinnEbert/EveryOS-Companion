Imports System.Net.Sockets
Imports System.Net

Module HollyNetTestServer
    Sub Main()
        Dim server As TcpListener
        Dim passwd As String = "some_really_strong_password"
        server = Nothing
        Try
            ' Set the TcpListener on port 9185.
            Dim port As Int32 = 9185
            Dim localAddr As IPAddress = IPAddress.Parse("192.168.1.2")

            server = New TcpListener(localAddr, port)

            ' Start listening for client requests.
            server.Start()

            ' Buffer for reading data
            Dim bytes(1024) As Byte
            Dim data As String = Nothing

            ' Enter the listening loop.
            While True
                Console.Write("Waiting for a connection... ")

                ' Perform a blocking call to accept requests.
                ' You could also user server.AcceptSocket() here.
                Dim client As TcpClient = server.AcceptTcpClient()
                Console.WriteLine("Connected!")

                data = Nothing

                ' Get a stream object for reading and writing
                Dim stream As NetworkStream = client.GetStream()

                Dim i As Int32

                ' Loop to receive all the data sent by the client.
                i = stream.Read(bytes, 0, bytes.Length)
                While (i <> 0)
                    ' Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i)
                    Console.WriteLine("Received: {0}", data)

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
                    Dim msg As Byte() = System.Text.Encoding.ASCII.GetBytes(send)

                    ' Send back a response.
                    stream.Write(msg, 0, msg.Length)
                    Console.WriteLine("Sent: {0}", send)

                    i = stream.Read(bytes, 0, bytes.Length)

                End While

                ' Shutdown and end connection
                client.Close()
            End While
        Catch e As SocketException
            Console.WriteLine("SocketException: {0}", e)
        Finally
            server.Stop()
        End Try

        Console.WriteLine(ControlChars.Cr + "Hit enter to continue....")
        Console.Read()
    End Sub
End Module
