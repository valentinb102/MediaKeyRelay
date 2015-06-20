Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text

Public Module DataProtectionExtensions

    <Runtime.CompilerServices.Extension>
    Public Function Protect(clearText As String, Optional optionalEntropy As String = Nothing, Optional scope As DataProtectionScope = DataProtectionScope.CurrentUser) As String

        If String.IsNullOrEmpty(clearText) Then
            Return Nothing
        End If

        Dim clearBytes As Byte() = Encoding.UTF8.GetBytes(clearText)
        Dim entropyBytes As Byte() = If(String.IsNullOrEmpty(optionalEntropy), Encoding.UTF8.GetBytes(Assembly.GetExecutingAssembly().FullName), Encoding.UTF8.GetBytes(optionalEntropy))
        Dim encryptedBytes As Byte() = ProtectedData.Protect(clearBytes, entropyBytes, scope)

        Return Convert.ToBase64String(encryptedBytes)
    End Function

    <Runtime.CompilerServices.Extension>
    Public Function Unprotect(encryptedText As String, Optional optionalEntropy As String = Nothing, Optional scope As DataProtectionScope = DataProtectionScope.CurrentUser) As String

        If String.IsNullOrEmpty(encryptedText) Then
            Return Nothing
        End If

        Dim encryptedBytes As Byte() = Convert.FromBase64String(encryptedText)
        Dim entropyBytes As Byte() = If(String.IsNullOrEmpty(optionalEntropy), Encoding.UTF8.GetBytes(Assembly.GetExecutingAssembly().FullName), Encoding.UTF8.GetBytes(optionalEntropy))
        Dim clearBytes As Byte() = ProtectedData.Unprotect(encryptedBytes, entropyBytes, scope)

        Return Encoding.UTF8.GetString(clearBytes)
    End Function
End Module