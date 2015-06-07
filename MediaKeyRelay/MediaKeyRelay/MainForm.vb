Public Class MainForm

    Private Sub mediaPlayPause(sender As Object, e As EventArgs) Handles butPlayPause.Click
        KeyEvent.FireKeyCode(KeyEvent.KeyCodes.VK_MEDIA_PLAY_PAUSE)
    End Sub

    Private Sub butStop_Click(sender As Object, e As EventArgs) Handles butStop.Click
        KeyEvent.FireKeyCode(KeyEvent.KeyCodes.VK_MEDIA_STOP)
    End Sub

    Private Sub butPrev_Click(sender As Object, e As EventArgs) Handles butPrev.Click
        KeyEvent.FireKeyCode(KeyEvent.KeyCodes.VK_MEDIA_PREV_TRACK)
    End Sub

    Private Sub butNext_Click(sender As Object, e As EventArgs) Handles butNext.Click
        KeyEvent.FireKeyCode(KeyEvent.KeyCodes.VK_MEDIA_NEXT_TRACK)
    End Sub
End Class
