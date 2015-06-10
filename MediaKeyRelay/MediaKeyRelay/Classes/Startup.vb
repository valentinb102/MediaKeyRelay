Imports System.Runtime.InteropServices

Public Class Startup
    Private Declare Auto Function SetWindowsHookEx Lib "user32.dll" (idHook As Integer, lpfn As LowLevelKeyboardProc, hMod As IntPtr, dwThreadId As UInteger) As IntPtr
    Private Declare Auto Function UnhookWindowsHookEx Lib "user32.dll" (hhk As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    Private Declare Auto Function CallNextHookEx Lib "user32.dll" (hhk As IntPtr, nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    Private Declare Auto Function GetModuleHandle Lib "kernel32.dll" (lpModuleName As String) As IntPtr

    Public Shared Sub Main()
        _hookID = SetHook(_proc)
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New MainForm)
        UnhookWindowsHookEx(_hookID)
    End Sub

    'Type of Hook - Low Level Keyboard
    Private Const WH_KEYBOARD_LL As Integer = 13
    Private Const WM_KEYDOWN As Integer = &H100
    Private Const WM_KEYUP As Integer = &H101
    Private Shared _hookID As IntPtr = IntPtr.Zero
    Private Shared _proc As LowLevelKeyboardProc = AddressOf HookCallback
    Private Delegate Function LowLevelKeyboardProc(nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr

    Private Shared Function SetHook(proc As LowLevelKeyboardProc) As IntPtr
        Using curProcess As Process = Process.GetCurrentProcess()
            Using curModule As ProcessModule = curProcess.MainModule
                Return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0)
            End Using
        End Using
    End Function

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

End Class
