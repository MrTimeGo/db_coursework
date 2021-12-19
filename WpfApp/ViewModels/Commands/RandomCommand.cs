using System;
using System.Windows;
using System.Windows.Input;
using WpfApp.Services;
using WpfApp.Views;

namespace WpfApp.ViewModels.Commands
{
    public class RandomCommand : ICommand
    {
        IService service;

        public RandomCommand(IService service)
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
            RandomDialog dialog = new RandomDialog();

            dialog.ShowDialog();

            if (dialog.Result == null)
                return;

            try
            {
                service.InsertRandom((int)dialog.Result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
