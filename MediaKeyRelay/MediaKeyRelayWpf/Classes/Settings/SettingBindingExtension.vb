Public Class SettingBindingExtension
    Inherits Binding

    Public Sub New()
        Initialize()
    End Sub

    Public Sub New(path As String)
        MyBase.New(path)
        Initialize()
    End Sub

    Private Sub Initialize()
        Source = MySettings.Default.Config
        Mode = BindingMode.TwoWay
    End Sub

End Class
