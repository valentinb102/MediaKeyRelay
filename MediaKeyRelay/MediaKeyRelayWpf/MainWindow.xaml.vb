Class MainWindow

    Private Sub btnKBHook_Click(sender As Object, e As RoutedEventArgs)
        If Application.kbHook Is Nothing Then
            ' startup keyboard hook
            Application.kbHook = New KeyboardHook

            btnKBHook.Content = "Stop Hook"
        Else
            Application.kbHook.Dispose()
            Application.kbHook = Nothing

            btnKBHook.Content = "Start Hook"
        End If
    End Sub

    Private Sub btnPausePlay_Click(sender As Object, e As RoutedEventArgs)
        KeyEvent.FireKeyCode(KeyMap.VirtualKeyCodes.VK_MEDIA_PLAY_PAUSE)
    End Sub

    Private Sub btnStop_Click(sender As Object, e As RoutedEventArgs)
        KeyEvent.FireKeyCode(KeyMap.VirtualKeyCodes.VK_MEDIA_STOP)
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As RoutedEventArgs)
        KeyEvent.FireKeyCode(KeyMap.VirtualKeyCodes.VK_MEDIA_PREV_TRACK)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As RoutedEventArgs)
        KeyEvent.FireKeyCode(KeyMap.VirtualKeyCodes.VK_MEDIA_NEXT_TRACK)
    End Sub

    ' enable/disable which programs to send commands to
    Private Sub checkBoxCommands_Checked(sender As Object, e As RoutedEventArgs)
        Dim checkbox As CheckBox = sender

        ' enable / disable app specific classes
        Select Case checkbox.Tag

            ' enable/disable mpc connection
            Case ApplicationMap.MPC
                If checkbox.IsChecked Then
                    Application.MPCClient = New MediaWebClient(txtMPCURL.Text, "wm_command")
                Else
                    Application.MPCClient = Nothing
                End If
        End Select

        ' save which app has been actived/deactived
        ApplicationMap.activeApps(checkbox.Tag) = checkbox.IsChecked
    End Sub
End Class
