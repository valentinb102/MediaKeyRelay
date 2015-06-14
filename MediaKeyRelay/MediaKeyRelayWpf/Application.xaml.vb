Class Application
    Public Shared kbHook As New KeyboardHook
    Public Shared MPCClient As MediaWebClient
    Public Shared VLCClient As MediaWebClient

    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup

    End Sub

    Private Sub Application_Exit(sender As Object, e As ExitEventArgs) Handles Me.[Exit]

    End Sub

    Public Shared Sub keyReceived(key As Integer)
        ' generate keydown event
        If [Enum].IsDefined(GetType(KeyMap.VirtualKeyCodes), key) Then

            For Each active As String In ApplicationMap.activeApps.Keys
                If ApplicationMap.activeApps(active) Then
                    Select Case active
                        Case ApplicationMap.KeyEvent
                            KeyEvent.FireKeyCodeDown(key)
                        Case ApplicationMap.MPC
                            MPCClient.SendCommand(KeyMap.VKtoMPC(key))
                        Case ApplicationMap.VLC
                            VLCClient.SendCommand(KeyMap.VKtoVLC(key))
                    End Select
                End If
            Next
        End If
    End Sub
End Class
