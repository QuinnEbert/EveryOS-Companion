Imports Microsoft.VisualBasic
Imports Microsoft.Win32
Imports System
Imports System.Collections

Public Class APM_Pair
    Public NAME As String
    Public GUID As String

    ' Initialize the pair (Nothing value for both NAME and GUID)
    Public Sub New()
        NAME = Nothing
        GUID = Nothing
    End Sub
    ' OVERLOAD: Initialize with pre-set values (for use in iterating loops, et al)
    Public Sub New(ByVal New_NAME As String, ByVal New_GUID As String)
        NAME = New_NAME
        GUID = New_GUID
    End Sub
End Class

Public Class ReferAPM
    ''
    '' HumieAnn :: HollyAnn's Library for Converting BETWEEN "friendly" APM Plan names, and GUID's
    ''

    ' A constant to allow us to use the crappy, old-fashioned 'array-style collection' method for holding APM plans...
    Public Const MaxPairs As Integer = 99

    ' This is where we hold our 'Plan Pairs' for easing our comparisons...
    ' THIS IS PRIVATE -- Callers use the 'ConvertName' or 'ConvertGuid' to "get what they need"...
    Private OurPairs(MaxPairs) As APM_Pair

    ' The Class Constructor (initialize the 'array-style collection' that holds APM Pairs)
    Public Sub New()
        ' Save some possible confusion and klutzy typing on my part...
        Dim A As Integer = OurPairs.GetLowerBound(0)
        Dim B As Integer = OurPairs.GetUpperBound(0)
        ' Initialize The OurPairs Array Elements
        For X As Integer = A To B
            OurPairs(X) = New APM_Pair()
        Next X
    End Sub

    ' Add A APM_Pair to my local group
    Public Sub Add_Pair(ByVal New_NAME As String, ByVal New_GUID As String)
        Dim One As APM_Pair
        ' Save some possible confusion and klutzy typing on my part...
        Dim A As Integer = OurPairs.GetLowerBound(0)
        Dim B As Integer = OurPairs.GetUpperBound(0)
        ' For TEMP Use: Holding One APM_Pair's (N)ame and (G)uid
        Dim N, G As String
        ' Iterate through OurPairs until we find a 'free' one...
        For X As Integer = A To B
            One = OurPairs(X)
            N = One.NAME
            G = One.GUID
            If N = Nothing Or G = Nothing Then
                ' This is the index where we'll add the new pair...
                OurPairs(X).NAME = New_NAME
                OurPairs(X).GUID = New_GUID
                Exit For
            End If
        Next X
    End Sub

    ' return the total number of useable apm_pair objects in my local group
    Public Function NumPairs() As Integer
        ' To Keep track of our 'Running Total'
        Dim CurTotal As Integer = 0
        ' For TEMP Use: Holding One APM_Pair's (N)ame and (G)uid
        Dim N, G As String
        For Each One As APM_Pair In OurPairs
            N = One.NAME
            G = One.GUID
            If N <> Nothing And G <> Nothing Then
                ' Keep track of our 'Running Total'
                CurTotal += 1
            End If
        Next One
        Return CurTotal
    End Function
    ' return the APM_Pair object with 'useable' index of 'idx'
    Public Function GetIndex(ByVal idx As Integer) As APM_Pair
        Dim Ret As APM_Pair = New APM_Pair()
        ' FIXME: I should make this function fault-tolerant of patently invalid 'IDX' arguments?  :D
        ' To Keep track of our 'Running Total' of useful APM-pairs...
        Dim CurTotal As Integer = 0
        ' For TEMP Use: Holding One APM_Pair's (N)ame and (G)uid
        Dim N, G As String
        For Each One As APM_Pair In OurPairs
            N = One.NAME
            G = One.GUID
            If N <> Nothing And G <> Nothing Then
                ' Keep track of our 'Running Total'
                CurTotal += 1
                If CurTotal = idx Then
                    Ret = New APM_Pair(N, G)
                    Exit For
                End If
            End If
        Next One
        Return Ret
    End Function

    ' Get the Guid of the passed APM Plan name, using my internal APM_Pair object
    Public Function ConvertName(ByVal Name As String) As String
        ' For TEMP Purposes - Hold the Name and Guid for each loop pass...
        Dim N, G As String
        ' Iterate through the Pairs...
        For Each One As APM_Pair In OurPairs
            N = One.NAME
            G = One.GUID
            If N <> Nothing And G <> Nothing Then
                If N = Name Then Return G
            End If
        Next One
        Return Nothing
    End Function
    ' Get the Guid of the passed APM Plan name, using the passed APM_Pair collection
    Public Function ConvertName(ByVal Name As String, ByVal UsePairs As Collection) As String
        ' For TEMP Purposes - Hold the Name and Guid for each loop pass...
        Dim N, G As String
        ' Iterate through the Pairs...
        For Each One As APM_Pair In UsePairs
            N = One.NAME
            G = One.GUID
            If N <> Nothing And G <> Nothing Then
                If N = Name Then Return G
            End If
        Next One
        Return Nothing
    End Function
    ' Get the Name of the passed APM Plan Guid, using my internal APM_Pair object
    Public Function ConvertGuid(ByVal Guid As String) As String
        ' For TEMP Purposes - Hold the Name and Guid for each loop pass...
        Dim N, G As String
        ' Iterate through the Pairs...
        For Each One As APM_Pair In OurPairs
            N = One.NAME
            G = One.GUID
            If N <> Nothing And G <> Nothing Then
                If G = Guid Then Return N
            End If
        Next One
        '@Quinn: This was not returning a SAFE default here - FIXED
        Return "FuBaRrEd"
    End Function
    ' Get the Name of the passed APM Plan Guid, using the passed APM_Pair collection
    Public Function ConvertGuid(ByVal Guid As String, ByVal UsePairs As Collection) As String
        ' For TEMP Purposes - Hold the Name and Guid for each loop pass...
        Dim N, G As String
        ' Iterate through the Pairs...
        For Each One As APM_Pair In UsePairs
            N = One.NAME
            G = One.GUID
            If N <> Nothing And G <> Nothing Then
                If G = Guid Then Return N
            End If
        Next One
        Return Nothing
    End Function

    ' This function returns a collection, containing all of the currently-available APM Plan-Pairs...
    Public Function All() As Collection
        ' To hold our 'return value' (collection, actually)
        Dim Ret As New Collection()
        ' For TEMP Purposes - Hold the Name and Guid for each loop pass...
        Dim N, G As String
        ' Used while iterating through the OurPairs group (for temp purposes)
        Dim One As New APM_Pair()
        ' Save some possible confusion and klutzy typing on my part...
        Dim A As Integer = OurPairs.GetLowerBound(0)
        Dim B As Integer = OurPairs.GetUpperBound(0)
        ' Iterate through the OurPairs array elements, adding 'real items' to the Ret collection
        For X As Integer = A To B
            N = OurPairs(X).NAME
            G = OurPairs(X).GUID
            If N <> Nothing And G <> Nothing Then
                One = New APM_Pair(N, G)
                Ret.Add(One)
            End If
        Next X
        Return Ret
    End Function

End Class
