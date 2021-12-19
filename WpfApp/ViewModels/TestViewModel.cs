using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels.Commands;
using WpfApp.Views.TestViews;

namespace WpfApp.ViewModels
{
    public class TestViewModel
    {
        private Tests tests;

        public ObservableCollection<Test> obsCollection { get; set; }

        public TestViewModel(Tests tests)
        {
            obsCollection = tests.Context.Tests.Local.ToObservableCollection();
            this.tests = tests;


            Remove = new RemoveCommand(tests);
            Insert = new InsertCommand<TestDialog>(tests);
            Update = new UpdateCommand<TestDialog>(tests);
            Random = new RandomCommand(tests);
            Search = new SearchCommand<TestDialog, TestSeachResultDialog>(tests);
        }

        public ICommand Remove { get; set; }

        public ICommand Insert { get; set; }

        public ICommand Update { get; set; }

        public ICommand Random { get; set; }

        public ICommand Search { get; set; }
    }
}
