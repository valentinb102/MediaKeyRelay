Public Class GlobalHotkey
    Implements IDisposable

    Private Declare Auto Function RegisterHotKey Lib "user32.dll" (hwnd As IntPtr, id As Integer, fsModifiers As UInteger, vk As UInteger) As Boolean
    Private Declare Auto Function UnregisterHotKey Lib "user32.dll" (hwnd As IntPtr, id As Integer) As Integer
    Private Declare Auto Function GlobalAddAtom Lib "kernel32.dll" (lpString As String) As Short
    Private Declare Auto Function GlobalDeleteAtom Lib "kernel32.dll" (nAtom As Short) As Short


    Private Sub IDisposable_Dispose() Implements IDisposable.Dispose
    End Sub
End Class