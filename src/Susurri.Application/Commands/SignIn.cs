using System.Windows.Input;

namespace Susurri.Application.Commands;

public record SignIn(string Username, string Password) : ICommand, Abstractions.ICommand
{
    public bool CanExecute(object? parameter)
    {
        throw new NotImplementedException();
    }

    public void Execute(object? parameter)
    {
        throw new NotImplementedException();
    }

    public event EventHandler? CanExecuteChanged;
}