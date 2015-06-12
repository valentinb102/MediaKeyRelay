Class MainWindow
    Private hook As KeyboardHook

    Private Sub butKBHook_Click(sender As Object, e As RoutedEventArgs)
        If hook Is Nothing Then
            ' startup keyboard hook
            hook = New KeyboardHook

            butKBHook.Content = "Stop Hook"
        Else
            hook.Dispose()
            hook = Nothing

            butKBHook.Content = "Start Hook"
        End If
    End Sub
End Class
