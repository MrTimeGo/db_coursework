using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels.Commands;
using WpfApp.Views.GroupViews;

namespace WpfApp.ViewModels
{
    public class GroupViewModel
    {
        private Groups groups;

        public ObservableCollection<Group> obsCollection { get; set; }

        public GroupViewModel(Groups groups)
        {
            obsCollection = groups.Context.Groups.Local.ToObservableCollection();
            this.groups = groups;


            Remove = new RemoveCommand(groups);
            Insert = new InsertCommand<GroupDialog>(groups);
            Update = new UpdateCommand<GroupDialog>(groups);
            Random = new RandomCommand(groups);
            Search = new SearchCommand<GroupDialog, GroupSearchResultDialog>(groups);
            Analyse = new AnalyseCommand(groups);
        }

        public ICommand Remove { get; set; }

        public ICommand Insert { get; set; }

        public ICommand Update { get; set; }

        public ICommand Random { get; set; }

        public ICommand Search { get; set; }

        public ICommand Analyse { get; set; }

        private class AnalyseCommand : ICommand
        {
            Groups groups;

            public AnalyseCommand(Groups groups)
            {
                this.groups = groups;
            }
            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                return true;
            }

            public void Execute(object? parameter)
            {
                new GroupAnalyticsDialog(groups).ShowDialog();
            }
        }
    }
}
