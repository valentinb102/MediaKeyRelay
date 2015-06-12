Imports System.Runtime.InteropServices

Public Class Startup

    Public Shared Sub Main()
        Dim kbHook As New KeyboardHook

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New MainForm)
    End Sub

End Class
