Public Class ShowWindowCommand
    Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        Dim appWindow As Window = parameter

        If appWindow.WindowState = WindowState.Minimized Then
            appWindow.WindowState = WindowState.Normal
        Else
            appWindow.WindowState = WindowState.Minimized
        End If
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return parameter IsNot Nothing
    End Function

End Class
