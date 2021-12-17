using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Services;

namespace WpfApp.ViewModels.Commands
{
    public class RemoveCommand : ICommand
    {
        IService service;

        public RemoveCommand(IService service)
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
            if (parameter != null)
            {
                service.Delete(parameter);
            }
        }
    }
    
}
