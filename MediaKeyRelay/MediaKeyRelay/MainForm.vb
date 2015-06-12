Imports System.ComponentModel

Public Class MainForm
    Inherits Form

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

    Private Sub inputTextBox_TextChanged(sender As Object, e As EventArgs) Handles inputTextBox.KeyPress
        Dim sum = 2
    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class
