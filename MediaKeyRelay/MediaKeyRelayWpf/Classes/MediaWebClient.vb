Imports System.Net

Public Class MediaWebClient

    Private webclient As New WebClient With {
        .UseDefaultCredentials = True
    }
    Private address As String
    Private commandString As String

    Public Sub New(address As String, commandString As String, Optional login As String = Nothing, Optional password As String = Nothing)
        Me.address = address
        Me.commandString = commandString

        ' set credentials
        If Not String.IsNullOrWhiteSpace(login) AndAlso Not String.IsNullOrWhiteSpace(password) Then
            webclient.Credentials = New NetworkCredential("username", "password")
        End If
    End Sub

    Public Sub SendCommand(command As String)
        webclient.QueryString.Add(commandString, command)

        webclient.DownloadString(New Uri(address))
    End Sub

End Class
