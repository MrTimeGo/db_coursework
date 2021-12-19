using System;
using System.Windows.Input;
using WpfApp.Services;
using WpfApp.Views;

namespace WpfApp.ViewModels.Commands
{
    public class UpdateCommand<TDialog> : ICommand where TDialog : IDialog, new()
    {
        IService service;

        public UpdateCommand(IService service)
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
            if (parameter == null)
                return;

            IDialog dialog = new TDialog();
            dialog.Result = parameter;
            dialog.DoValidate = true;
            dialog.Service = service;
            dialog.ShowDialog();

            if (dialog.Result == null)
                return;

            var result = dialog.Result;
            service.Update(parameter, result);
        }
    }
}
