Imports System.Threading.Tasks

Class MainWindow

    Private Sub btnKBHook_Click(sender As Object, e As RoutedEventArgs)
        If Application.hook Is Nothing Then
            ' startup keyboard hook
            Application.hook = New KeyboardHook

            btnKBHook.Content = "Stop Hook"
        Else
            Application.hook.Dispose()
            Application.hook = Nothing

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

    Private Sub btnMPCStartConn_Click(sender As Object, e As RoutedEventArgs)
        Application.mpcclient = New MPCWebClient(txtMPCURL.Text)
        'txtMPCStatus.Text &= "play pause started" & Environment.NewLine

        'Application.mpcclient.PlayPause().ContinueWith(Sub()
        '                                                   txtMPCStatus.Text &= "play pause finished" & Environment.NewLine
        '                                               End Sub, TaskScheduler.FromCurrentSynchronizationContext)
    End Sub

    Private Sub btnMPCStopConn_Click(sender As Object, e As RoutedEventArgs)
        Application.mpcclient = Nothing
    End Sub
End Class
