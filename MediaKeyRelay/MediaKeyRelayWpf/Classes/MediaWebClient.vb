Imports System.Net

Public Class MediaWebClient
    Public webclient As New WebClient
    Private address As String
    Private commandString As String

    Public Sub New(address As String, commandString As String)
        Me.address = address
        Me.commandString = commandString
    End Sub

    Public Sub SendCommand(command As String)
        webclient.QueryString.Add(commandString, command)
        webclient.DownloadString(New Uri(address))
    End Sub

    Public Function ReceiveStatus()
        Return webclient.DownloadString(New Uri(address))
    End Function

    Public Function ReceiveStatus(tempAddress As String)
        Return webclient.DownloadString(New Uri(tempAddress))
    End Function

End Class
