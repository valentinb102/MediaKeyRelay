Public Class KeyEvent

    Public Enum KeyMessages
        NUMLOCK_KEYDOWN = &H45
        WM_KEYDOWN = &H1
        WM_KEYUP = &H2
    End Enum

    ' marshalled functions
    Private Declare Auto Function keybd_event Lib "user32.dll" (bVk As Byte, bScan As Byte, dwFlags As UInteger, dwExtraInfo As UIntPtr) As Boolean

    ''' <summary>
    ''' fires a key event
    ''' </summary>
    ''' <param name="keyCode">use KeyEvent.KeyCodes as a reference</param>
    Public Shared Sub FireKeyCode(keyCode As Byte)
        keybd_event(keyCode, KeyMessages.NUMLOCK_KEYDOWN, KeyMessages.WM_KEYDOWN, 0)
        Threading.Thread.Sleep(100)
        keybd_event(keyCode, KeyMessages.NUMLOCK_KEYDOWN, KeyMessages.WM_KEYDOWN Or KeyMessages.WM_KEYUP, 0)
    End Sub

    ''' <summary>
    ''' fires a keydown event
    ''' </summary>
    ''' <param name="keyCode">use KeyEvent.KeyCodes as a reference</param>
    Public Shared Sub FireKeyCodeDown(keyCode As Byte)
        keybd_event(keyCode, KeyMessages.NUMLOCK_KEYDOWN, KeyMessages.WM_KEYDOWN, 0)
    End Sub

    ''' <summary>
    ''' fires a keyup event
    ''' </summary>
    ''' <param name="keyCode">use KeyEvent.KeyCodes as a reference</param>
    Public Shared Sub FireKeyCodeUp(keyCode As Byte)
        keybd_event(keyCode, KeyMessages.NUMLOCK_KEYDOWN, KeyMessages.WM_KEYDOWN Or KeyMessages.WM_KEYUP, 0)
    End Sub
End Class
