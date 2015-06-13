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
                            ' if pause/play we determine which status is current
                            If key = KeyMap.VirtualKeyCodes.VK_MEDIA_PLAY_PAUSE Then
                                Dim status As XDocument = XDocument.Parse(VLCClient.ReceiveStatus)
                                Dim statusPaused = status...<state>.Value

                                If statusPaused = "paused" Then
                                    VLCClient.SendCommand(KeyMap.VLCCommandCodes.Play)
                                Else
                                    VLCClient.SendCommand(KeyMap.VLCCommandCodes.Pause)
                                End If
                            Else
                                VLCClient.SendCommand(KeyMap.VKtoVLC(key))
                            End If
                    End Select
                End If
            Next
        End If
    End Sub
End Class
