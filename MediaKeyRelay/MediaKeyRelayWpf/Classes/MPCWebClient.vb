Imports System.Net

Public Class MPCWebClient

    Private webclient As New WebClient
    Private address As String

    Public Sub New(address)
        Me.address = address
    End Sub

    Public Function SendCommand(command As Integer) As System.Threading.Tasks.Task(Of String)
        webclient.QueryString.Add("wm_command", command)

        Return webclient.DownloadStringTaskAsync(New Uri(address))
    End Function

End Class
