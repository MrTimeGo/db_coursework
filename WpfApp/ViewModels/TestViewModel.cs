using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels.Commands;

namespace WpfApp.ViewModels
{
    public class TestViewModel
    {
        private Tests tests;

        public ObservableCollection<Test> obsCollection { get; set; }

        public TestViewModel(Tests tests)
        {
            tests.Context.Tests.Load();
            obsCollection = tests.Context.Tests.Local.ToObservableCollection();
            this.tests = tests;


            Remove = new RemoveCommand(tests);
            Insert = new InsertCommand(tests);
        }

        public ICommand Remove { get; set; }

        public ICommand Insert { get; set; }
    }
}
