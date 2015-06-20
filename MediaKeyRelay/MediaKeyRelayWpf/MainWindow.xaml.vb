﻿Imports System.ComponentModel

Class MainWindow

    ' enable/disable which programs to send commands to
    Private Sub checkBoxCommands_Checked(sender As Object, e As RoutedEventArgs)
        Dim checkbox As CheckBox = sender

        ' enable / disable app specific classes
        Select Case checkbox.Tag
            Case Application.MPC
                If checkbox.IsChecked Then
                    Application.MPCClient = New MediaWebClient(txtMPCURL.Text, "wm_command")
                Else
                    Application.MPCClient = Nothing
                End If
            Case Application.VLC
                If checkbox.IsChecked Then
                    Application.VLCClient = New MediaWebClientBasicAuth(txtVLCURL.Text, "command", txtVLCLogin.Text, txtVLCPassword.Password)
                Else
                    Application.VLCClient = Nothing
                End If
        End Select

        ' save which app has been actived/deactived
        Application.activeApps(checkbox.Tag) = checkbox.IsChecked
    End Sub

    Private Sub MainWindow_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ' save credentials to settings
        MySettings.Default.Config.MainSettings.VLCLogin = txtVLCLogin.Text.Protect
        MySettings.Default.Config.MainSettings.VLCPassword = txtVLCPassword.Password.Protect

        ' save tab SelectedIndex
        MySettings.Default.Config.MainSettings.SelectedTab = tabControlMain.SelectedIndex
    End Sub

    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        ' grab saved credentials
        txtVLCLogin.Text = MySettings.Default.Config.MainSettings.VLCLogin.Unprotect
        txtVLCPassword.Password = MySettings.Default.Config.MainSettings.VLCPassword.Unprotect

        ' reorder tabs since settings are bound one at a time
        ' certain settings are dependant on others to be available
        Dim tab As TabItem = tabControlMain.Items(0)
        tabControlMain.Items.Remove(tab)
        tabControlMain.Items.Add(tab)

        ' grab saved tab SelectedIndex
        tabControlMain.SelectedIndex = MySettings.Default.Config.MainSettings.SelectedTab
    End Sub

End Class
