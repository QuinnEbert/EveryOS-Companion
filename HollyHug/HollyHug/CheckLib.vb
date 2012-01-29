Imports Microsoft.VisualBasic
Imports System
Imports HollyHug
Public Class CheckSvc
    Public Svc_Name As String = "Service Friendly Name [UNSET]"
    Public Svc_Proc As String = "FileName.exe"
    Public Last_Was As Boolean = False
    Public FirstRun As Boolean = False
    Public bChanged As Boolean = False
End Class
Public Class CheckLib
    Public FirstRun As Boolean
    Private Services As New Collection
    Private Function Has(ByVal Name As String, ByVal Proc As String) As Boolean
        For Each aService As CheckSvc In Services
            If aService.Svc_Name = Name And aService.Svc_Proc = Proc Then
                Return True
            End If
        Next aService
        Return False
    End Function
    Public Function Dif() As Collection
        Dim ReturnOf As New Collection
        For Each aService As CheckSvc In Services
            If aService.bChanged Then
                ReturnOf.Add(aService.Svc_Proc)
            End If
        Next aService
        Return ReturnOf
    End Function
    Public Function Add(ByVal Name As String, ByVal Proc As String) As Boolean
        If Has(Name, Proc) Then Return False
        Dim aService As New CheckSvc
        aService.Svc_Name = LCase(Name)
        aService.Svc_Proc = LCase(Proc)
        aService.Last_Was = False
        aService.FirstRun = False
        aService.bChanged = False
        Services.Add(aService)
        Return True
    End Function
    Public Function Del(ByVal Name As String, ByVal Proc As String) As Boolean
        If Not Has(Name, Proc) Then Return False
        Dim DelIndex As Integer = -1
        Dim Curr_Svc As New CheckSvc
        For TheIndex As Integer = 0 To (Services.Count - 1)
            Curr_Svc = Services(TheIndex)
            If Curr_Svc.Svc_Name = LCase(Name) And Curr_Svc.Svc_Proc = LCase(Proc) Then
                DelIndex = TheIndex
                Exit For
            End If
        Next TheIndex
        If DelIndex = -1 Then Return False ' <- This should NEVER occour...
        Services.Remove(DelIndex)
        Return True
    End Function
    Public Function Chg(ByVal Name As String, ByVal Proc As String) As Boolean
        If Not Has(Name, Proc) Then Return False
        Dim Curr_Svc As New CheckSvc
        For i As Integer = 0 To (Services.Count - 1)
            If Services(i).Svc_Name = LCase(Name) And Services(i).Svc_Proc = LCase(Proc) Then
                Services(i).bChanged = True
                Exit For
            End If
        Next i
        Return True
    End Function
    Public Function Run() As Boolean
        Dim ReturnOf As Boolean = False
        For i As Integer = 1 To (Services.Count() - 1)
            Services(i).bChanged = False
            Try
                Dim TheState As Boolean = ServiceCheckingModule.RunCheck(Services(i).Svc_Proc)
                If Not TheState = Services(i).Last_Was Then
                    Services(i).bChanged = True
                    ReturnOf = True
                End If
                Services(i).Last_Was = TheState
                Services(i).FirstRun = False
            Catch ex As NullReferenceException
                ' Try and "silently" handle a possible threading error during app shutdown...
                Services(i).bChanged = False ' This way, we do not trigger any further messages' pumping (hopefully)...
                Services(i).FirstRun = False ' KLUDGE: Realistically, the app couldn't shutdown during the first run...
            End Try
        Next i
        If FirstRun Then
            FirstRun = False
            Return True
        End If
        Return ReturnOf
    End Function
End Class
