using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels.Commands;

namespace WpfApp.ViewModels
{
    public class GroupViewModel
    {
        private Groups groups;

        public ObservableCollection<Group> obsCollection { get; set; }

        public GroupViewModel(Groups groups)
        {
            groups.Context.Groups.Load();
            obsCollection = groups.Context.Groups.Local.ToObservableCollection();
            this.groups = groups;


            Remove = new RemoveCommand(groups);
            Insert = new InsertCommand(groups);
        }

        public ICommand Remove { get; set; }

        public ICommand Insert { get; set; }
    }
}
