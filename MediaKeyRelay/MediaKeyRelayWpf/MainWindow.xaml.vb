Class MainWindow
    Private hook As KeyboardHook

    Private Sub btnKBHook_Click(sender As Object, e As RoutedEventArgs)
        If hook Is Nothing Then
            ' startup keyboard hook
            hook = New KeyboardHook

            btnKBHook.Content = "Stop Hook"
        Else
            hook.Dispose()
            hook = Nothing

            btnKBHook.Content = "Start Hook"
        End If
    End Sub

    Private Sub btnPausePlay_Click(sender As Object, e As RoutedEventArgs)
        KeyEvent.FireKeyCode(KeyEvent.KeyCodes.VK_MEDIA_PLAY_PAUSE)
    End Sub

    Private Sub btnStop_Click(sender As Object, e As RoutedEventArgs)
        KeyEvent.FireKeyCode(KeyEvent.KeyCodes.VK_MEDIA_STOP)
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As RoutedEventArgs)
        KeyEvent.FireKeyCode(KeyEvent.KeyCodes.VK_MEDIA_PREV_TRACK)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As RoutedEventArgs)
        KeyEvent.FireKeyCode(KeyEvent.KeyCodes.VK_MEDIA_NEXT_TRACK)
    End Sub
End Class
