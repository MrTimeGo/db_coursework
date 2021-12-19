using System;
using System.Windows.Input;
using WpfApp.Services;
using WpfApp.Views;

namespace WpfApp.ViewModels.Commands
{
    public class InsertCommand<TDialog> : ICommand where TDialog : IDialog, new()
    {
        IService service;

        public InsertCommand(IService service)
        {
            this.service = service;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            IDialog dialog = new TDialog();
            dialog.DoValidate = true;
            dialog.Service = service;
            dialog.ShowDialog();

            if (dialog.Result == null)
                return;

            service.Insert(dialog.Result);
        }
    }
}
