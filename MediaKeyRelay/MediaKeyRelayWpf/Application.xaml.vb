Class Application
    Public Shared hook As New KeyboardHook
    Public Shared mpcclient As MPCWebClient
    Public Shared commandSwitch As Integer

    Public Enum commandEnum
        KeyEvent = 1
        MPC = 2
        VLC = 3
        Foobar = 4
    End Enum

    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup

    End Sub

    Private Sub Application_Exit(sender As Object, e As ExitEventArgs) Handles Me.[Exit]

    End Sub

    Public Shared Sub keyReceived(key As Integer)
        ' generate keydown event
        If [Enum].IsDefined(GetType(KeyEvent.KeyCodes), key) Then
            KeyEvent.FireKeyCodeDown(key)
        End If
    End Sub
End Class
