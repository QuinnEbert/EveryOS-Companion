﻿' FIXME: Credentials were hastily repudiated before Git commits, it is quite
'        possible this broke some functionality
Imports System.Net.Sockets

Module HollyNetTestClient

    Sub Main()
        Dim server As String = "192.168.1.2"
        Dim message As String = "AuthorizeMe " + Trim(My.Application.GetEnvironmentVariable("ComputerName")) + " some_really_strong_password"
        Try
            ' Create a TcpClient.
            ' Note, for this client to work you need to have a TcpServer 
            ' connected to the same address as specified by the server, port
            ' combination.
            Dim port As Int32 = 9185
            Dim client As New TcpClient(server, port)

            ' Translate the passed message into ASCII and store it as a Byte array.
            Dim data As [Byte]() = System.Text.Encoding.ASCII.GetBytes(message)

            ' Get a client stream for reading and writing.
            '  Stream stream = client.GetStream();
            Dim stream As NetworkStream = client.GetStream()

            ' Send the message to the connected TcpServer. 
            stream.Write(data, 0, data.Length)

            Console.WriteLine("Sent: {0}", message)

            ' Receive the TcpServer.response.
            ' Buffer to store the response bytes.
            data = New [Byte](256) {}

            ' Close everything.
            stream.Close()
            client.Close()
            client = New TcpClient(server, port)
            stream = client.GetStream()

            ' String to store the response ASCII representation.
            Dim responseData As [String] = [String].Empty

            ' Read the first batch of the TcpServer response bytes.
            Dim bytes As Int32 = stream.Read(data, 0, data.Length)
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes)
            Console.WriteLine("Received: {0}", responseData)

            ' New Stuff:
            Dim newshite As String = "NetSpeak Oh bugger!"
            ' Translate the passed message into ASCII and store it as a Byte array.
            Dim newstuff As [Byte]() = System.Text.Encoding.ASCII.GetBytes(newshite)
            ' Send the message to the connected TcpServer. 
            stream.Write(newstuff, 0, newstuff.Length)
            Console.WriteLine("Sent: {0}", newshite)

            ' Close everything.
            stream.Close()
            client.Close()
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException: {0}", e)
        Catch e As SocketException
            Console.WriteLine("SocketException: {0}", e)
        End Try

        Console.WriteLine(ControlChars.Cr + " wait 15 seconds to continue...")
        System.Threading.Thread.Sleep(15000)
        'Console.Read()
    End Sub

End Module
