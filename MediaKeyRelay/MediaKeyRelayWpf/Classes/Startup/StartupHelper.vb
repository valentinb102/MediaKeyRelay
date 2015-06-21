Imports Microsoft.Win32

Public Class StartupHelper

    Public Shared Sub AddApplicationToCurrentUserStartup()
        Using key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            key.SetValue("My ApplicationStartUpDemo", """" & Reflection.Assembly.GetExecutingAssembly().Location & """")
        End Using
    End Sub

    Public Shared Function ApplicationExistsInCurrentUserStartup() As Boolean

        Return True
    End Function
End Class
