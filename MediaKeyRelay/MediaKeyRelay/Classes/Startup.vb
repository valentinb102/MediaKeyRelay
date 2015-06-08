Imports System.Runtime.InteropServices

Public Class Startup
    Private Declare Auto Function SetWindowsHookEx Lib "user32.dll" (idHook As Integer, lpfn As LowLevelKeyboardProc, hMod As IntPtr, dwThreadId As UInteger) As IntPtr
    Private Declare Auto Function UnhookWindowsHookEx Lib "user32.dll" (hhk As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
    Private Declare Auto Function CallNextHookEx Lib "user32.dll" (hhk As IntPtr, nCode As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    Private Declare Auto Function GetModuleHandle Lib "kernel32.dll" (lpModuleName As String) As IntPtr
    Private Declare Auto Function SendMessage Lib "user32.dll" (hwnd As IntPtr, msg As Integer, wparam As IntPtr, lparam As IntPtr) As IntPtr

    Public Shared Sub Main()
        _hookID = SetHook(_proc)

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New MainForm)
    End Sub

    'Type of Hook - Low Level Keyboard
    Private Const WH_KEYBOARD_LL As Integer = 13
    Private Const WM_KEYDOWN As Integer = &H100
    Private Const WM_KEYUP As Integer = &H101
    Private Const WM_COPYDATA As Integer = &H4A
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
            Dim vkCode As Integer = Marshal.ReadInt32(lParam)

            ' get process
            Dim procArray As Process() = Process.GetProcessesByName("mpc-hc64")
            Dim curProcess As Process = Process.GetCurrentProcess()

            ' generate keydown event
            If [Enum].IsDefined(GetType(KeyEvent.KeyCodes), vkCode) AndAlso procArray.Length Then
                'KeyEvent.FireKeyCode(vkCode)
                SendMessageWithData(procArray(0).Handle, &HA0000003, curProcess.Handle)
            End If

        End If

        Return CallNextHookEx(_hookID, nCode, wParam, lParam)
    End Function

    Public Structure COPYDATASTRUCT
        Public dwData As IntPtr
        Public cbData As Integer
        Public lpData As IntPtr
    End Structure

    Public Shared Sub SendMessageWithData(destHandle As IntPtr, str As String, srcHandle As IntPtr)
        Dim cds As COPYDATASTRUCT

        cds.dwData = srcHandle
        str = str & Convert.ToString(ControlChars.NullChar)

        cds.cbData = str.Length + 1
        cds.lpData = Marshal.AllocCoTaskMem(str.Length)
        cds.lpData = Marshal.StringToCoTaskMemAnsi(str)
        Dim iPtr As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(cds))
        Marshal.StructureToPtr(cds, iPtr, True)

        ' send to the MFC app
        SendMessage(destHandle, WM_COPYDATA, IntPtr.Zero, iPtr)

        ' Don't forget to free the allocated memory 
        Marshal.FreeCoTaskMem(cds.lpData)
        Marshal.FreeCoTaskMem(iPtr)
    End Sub

    Public Shared Sub SendMessageWithDataUsingHGlobal(destHandle As IntPtr, str As String, srcHandle As IntPtr)
        Dim cds As COPYDATASTRUCT

        cds.dwData = srcHandle
        str = str & Convert.ToString(ControlChars.NullChar)

        cds.cbData = str.Length + 1
        cds.lpData = Marshal.AllocHGlobal(str.Length)
        cds.lpData = Marshal.StringToHGlobalAnsi(str)
        Dim iPtr As IntPtr = Marshal.AllocHGlobal(Marshal.SizeOf(cds))
        Marshal.StructureToPtr(cds, iPtr, True)

        ' send to the MFC app
        SendMessage(destHandle, WM_COPYDATA, IntPtr.Zero, iPtr)

        ' Don't forget to free the allocated memory 
        Marshal.FreeHGlobal(cds.lpData)
        Marshal.FreeHGlobal(iPtr)
    End Sub
End Class
