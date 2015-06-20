<Serializable>
Public Class SettingsConfig
    Public Property MainWindow As WindowSettings
    Public Property MainSettings As FormSettings

    Public Sub New()
        MainSettings = New FormSettings
        MainWindow = New WindowSettings

        ' default settings
        MainWindow.Top = 200
        MainWindow.Left = 200
        MainWindow.Width = 600
        MainWindow.Height = 400
        MainWindow.MinimizeToTray = False

        MainSettings.SelectedTab = 0

        MainSettings.MPCURL = "http://localhost:13579/command.html"
        MainSettings.VLCURL = "http://localhost:8080/requests/status.xml"

        MainSettings.KeyEventEnabled = False
        MainSettings.MPCEnabled = False
        MainSettings.VLCEnabled = False
    End Sub
End Class
