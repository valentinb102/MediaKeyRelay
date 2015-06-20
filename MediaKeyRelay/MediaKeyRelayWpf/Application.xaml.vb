Class Application
    Public Const KeyboardEvent As String = "KeyEvent"
    Public Const MPC As String = "MPC"
    Public Const VLC As String = "VLC"
    Public Shared kbHook As New KeyboardHook
    Public Shared MPCClient As MediaWebClient
    Public Shared VLCClient As MediaWebClient
    Public Shared activeApps As New Dictionary(Of String, Boolean) From {
        {KeyboardEvent, False},
        {MPC, False},
        {VLC, False}
    }

    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
        ' create settings
        If MySettings.Default.Config Is Nothing Then
            MySettings.Default.Config = New AppConfig
        End If
    End Sub

    Private Sub Application_Exit(sender As Object, e As ExitEventArgs) Handles Me.[Exit]
        ' save the settings
        MySettings.Default.Save()
    End Sub

    Public Shared Sub keyReceived(key As Integer)
        ' generate keydown event
        If [Enum].IsDefined(GetType(KeyMap.VirtualKeyCodes), key) Then

            For Each active As String In activeApps.Keys
                If activeApps(active) Then

                    Select Case active
                        Case KeyboardEvent
                            KeyEvent.FireKeyCodeDown(key)
                        Case MPC
                            MPCClient.SendCommand(KeyMap.VKtoMPC(key))
                        Case VLC
                            ' if volume we have to send another param with the volume amount
                            If key = KeyMap.VirtualKeyCodes.VK_MEDIA_VOL_DOWN Or
                                key = KeyMap.VirtualKeyCodes.VK_MEDIA_VOL_UP Then

                                If key = KeyMap.VirtualKeyCodes.VK_MEDIA_VOL_DOWN Then
                                    VLCClient.SendCommand(KeyMap.VLCCommandCodes.Volume, Tuple.Create("val", "-5"))
                                Else
                                    VLCClient.SendCommand(KeyMap.VLCCommandCodes.Volume, Tuple.Create("val", "+5"))
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
