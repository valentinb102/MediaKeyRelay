Imports System.Collections.Specialized
Imports System.Net

Public Class MediaWebClient
    Public webclient As New WebClient
    Private address As String
    Private commandString As String

    Public Sub New(address As String, commandString As String)
        Me.address = address
        Me.commandString = commandString
    End Sub

    Public Sub SendCommand(command As String, ParamArray extraCommands As Tuple(Of String, String)())
        webclient.QueryString.Clear()
        webclient.QueryString.Add(commandString, command)

        ' add any optional parameters
        For Each extra In extraCommands
            webclient.QueryString.Add(extra.Item1, extra.Item2)
        Next

        webclient.DownloadString(New Uri(address))
    End Sub

    Public Function ReceiveStatus()
        webclient.QueryString.Clear()

        Return webclient.DownloadString(New Uri(address))
    End Function

    Public Function ReceiveStatus(tempAddress As String, ParamArray extraCommands As Tuple(Of String, String)())
        webclient.QueryString.Clear()

        ' add any optional parameters
        For Each extra In extraCommands
            webclient.QueryString.Add(extra.Item1, extra.Item2)
        Next

        Return webclient.DownloadString(New Uri(tempAddress))
    End Function

End Class
