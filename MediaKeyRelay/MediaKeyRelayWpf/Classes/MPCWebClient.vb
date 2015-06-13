Imports System.Net

Public Class MPCWebClient

    Private webclient As New WebClient
    Private address As String

    Public Enum Commands
        PlayPause = 889
        [Stop] = 890
        [Next] = 922
        Previous = 921
    End Enum

    Public Sub New(address)
        Me.address = address
    End Sub

    Public Function PlayPause() As System.Threading.Tasks.Task(Of String)
        webclient.QueryString.Add("wm_command", Commands.PlayPause)
        Return webclient.DownloadStringTaskAsync(New Uri(address))
    End Function

End Class
