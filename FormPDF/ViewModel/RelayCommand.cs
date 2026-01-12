using System;
using System.Windows.Input;

namespace FormPDF.ViewModel
{
    // essa classe RelayCommand é uma classe simples que implementa ICommand, ela permite a associação de ação ao botão (no caso, exportar os dados clicando no botão)
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();
        public void Execute(object? parameter) => _execute();
    }
}