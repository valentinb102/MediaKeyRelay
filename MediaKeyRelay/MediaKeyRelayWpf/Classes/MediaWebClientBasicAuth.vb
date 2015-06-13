Imports System.Net
Imports System.Text

Public Class MediaWebClientBasicAuth
    Inherits MediaWebClient

    Public Sub New(address As String, commandString As String, login As String, password As String)
        MyBase.New(address, commandString)

        ' set credentials
        Dim credentials As String = Convert.ToBase64String(Encoding.ASCII.GetBytes(login + ":" + password))
        webclient.Headers(HttpRequestHeader.Authorization) = String.Format("Basic {0}", credentials)
    End Sub

End Class
