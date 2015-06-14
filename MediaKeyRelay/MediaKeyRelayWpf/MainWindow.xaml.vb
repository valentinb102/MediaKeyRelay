Class MainWindow

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
            Case ApplicationMap.VLC
                If checkbox.IsChecked Then
                    Application.VLCClient = New MediaWebClientBasicAuth(txtVLCURL.Text, "command", txtVLCLogin.Text, txtVLCPassword.Text)
                Else
                    Application.VLCClient = Nothing
                End If
        End Select

        ' save which app has been actived/deactived
        ApplicationMap.activeApps(checkbox.Tag) = checkbox.IsChecked
    End Sub
End Class
