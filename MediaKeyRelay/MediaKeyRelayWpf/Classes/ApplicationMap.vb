Public Class ApplicationMap
    Public Const KeyEvent As String = "KeyEvent"
    Public Const MPC As String = "MPC"
    Public Const VLC As String = "VLC"
    Public Const Foobar As String = "Foobar"

    Public Shared activeApps As New Dictionary(Of String, Boolean) From {
        {KeyEvent, False},
        {MPC, False},
        {VLC, False},
        {Foobar, False}
    }
End Class
