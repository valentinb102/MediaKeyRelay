Imports System.Threading

Public Class KeyEvent
    Public Enum KeyCodes
        VK_MEDIA_PLAY_PAUSE = &HB3
        VK_MEDIA_NEXT_TRACK = &HB0
        VK_MEDIA_PREV_TRACK = &HB1
        VK_MEDIA_STOP = &HB2
    End Enum

    Private Enum KeyStates
        NUMLOCK_KEYDOWN = &H45
        WM_KEYDOWN = &H1
        WM_KEYUP = &H2
    End Enum

    Private Declare Auto Function keybd_event Lib "user32.dll" (bVk As Byte, bScan As Byte, dwFlags As UInteger, dwExtraInfo As UIntPtr) As Boolean

    ''' <summary>
    ''' fires a key event
    ''' </summary>
    ''' <param name="keyCode">use KeyEvent.KeyCodes as a reference</param>
    Public Shared Sub FireKeyCode(keyCode As Byte)
        keybd_event(keyCode, KeyStates.NUMLOCK_KEYDOWN, KeyStates.WM_KEYDOWN, 0)
        Thread.Sleep(100)
        keybd_event(keyCode, KeyStates.NUMLOCK_KEYDOWN, KeyStates.WM_KEYDOWN Or KeyStates.WM_KEYUP, 0)
    End Sub
End Class
