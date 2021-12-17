using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Services;
using WpfApp.Views;

namespace WpfApp.ViewModels.Commands
{
    public class SearchCommand<TDialog, TSearchDialog> : ICommand where TDialog : IDialog, new() where TSearchDialog : ISearchResultDialog, new()
    {
        IService service;

        public SearchCommand(IService service)
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
            dialog.DoValidate = false;
            dialog.Service = service;
            dialog.ShowDialog();

            if (dialog.Result == null)
                return;


            var searchResult = service.Search(dialog.Result);

            ISearchResultDialog resultDialog = new TSearchDialog();
            resultDialog.Table.ItemsSource = searchResult;
            resultDialog.ShowDialog();
        }
    }
}
