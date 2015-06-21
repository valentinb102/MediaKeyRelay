Imports System.Reflection
Imports Microsoft.Win32

Public Class StartupHelper
    Private Const AppName As String = "MediaKeyRelay"
    Private Const PathToStartupRegKey As String = "SOFTWARE\Microsoft\Windows\CurrentVersion\Run"

    Public Shared Sub AddApplicationToCurrentUserStartup()
        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(PathToStartupRegKey, True)
            key.SetValue(AppName, """" & Assembly.GetExecutingAssembly().Location & """")
        End Using
    End Sub

    Public Shared Sub RemoveApplicationFromCurrentUserStartup()
        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(PathToStartupRegKey, True)
            key.DeleteValue(AppName, False)
        End Using
    End Sub

    Public Shared Function ApplicationExistsInCurrentUserStartup() As Boolean
        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(PathToStartupRegKey, True)
            Return key.GetValue(AppName) IsNot Nothing
        End Using
    End Function
End Class
