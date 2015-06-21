Public Class ShowWindowCommand
    Implements ICommand

    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub Execute(parameter As Object) Implements ICommand.Execute
        DirectCast(parameter, Window).WindowState = WindowState.Normal
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return parameter IsNot Nothing
    End Function

End Class
