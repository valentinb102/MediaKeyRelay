Imports System.Runtime.InteropServices

Public Class KeyboardHook
    Implements IDisposable

    Private disposed As Boolean = False
    Private Const WH_KEYBOARD_LL As Integer = 13
    Private Const WM_KEYDOWN As Integer = &H100
    Private Const WM_KEYUP As Integer = &H101
    Private Shared _hookID As IntPtr = IntPtr.Zero
    Private Shared _proc As LowLevelKeyboardProc = AddressOf HookCallback
    Private Delegate Function LowLevelKeyboardProc(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr

    Private Declare Auto Function SetWindowsHookEx Lib "user32.dll" (idHook As Integer, lpfn As LowLevelKeyboardProc, hMod As IntPtr, dwThreadId As UInteger) As IntPtr
    Private Declare Auto Function UnhookWindowsHookEx Lib "user32.dll" (hhk As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    Private Declare Auto Function CallNextHookEx Lib "user32.dll" (hhk As IntPtr, nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    Private Declare Auto Function GetModuleHandle Lib "kernel32.dll" (lpModuleName As String) As IntPtr

    Public Sub New()
        _hookID = SetHook(_proc)
    End Sub

    ''' <summary>
    ''' hook into keyboard events
    ''' </summary>
    ''' <param name="proc"></param>
    ''' <returns></returns>
    Private Shared Function SetHook(proc As LowLevelKeyboardProc) As IntPtr
        Using curProcess As Process = Process.GetCurrentProcess()
            Using curModule As ProcessModule = curProcess.MainModule
                Return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0)
            End Using
        End Using
    End Function

    ''' <summary>
    ''' callback for processing key events
    ''' </summary>
    ''' <param name="nCode"></param>
    ''' <param name="wParam"></param>
    ''' <param name="lParam"></param>
    ''' <returns></returns>
    Private Shared Function HookCallback(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr

        ' look for up keyup event
        If nCode >= 0 AndAlso wParam = WM_KEYUP Then
            ' get virtual key code
            Dim vkCode As Integer = Marshal.ReadInt32(lParam)

            ' generate keydown event
            If [Enum].IsDefined(GetType(KeyEvent.KeyCodes), vkCode) Then
                KeyEvent.FireKeyCodeDown(vkCode)
            End If
        End If

        Return CallNextHookEx(_hookID, nCode, wParam, lParam)
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If disposed Then Return

        If disposing Then
        End If

        ' try to unhook this process
        UnhookWindowsHookEx(_hookID)

        disposed = True
    End Sub
End Class
