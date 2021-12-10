using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels.Commands;

namespace WpfApp.ViewModels
{
    public class SubjectViewModel
    {
        private Subjects subjects;

        public ObservableCollection<Subject> obsCollection { get; set; }

        public SubjectViewModel(Subjects subjects)
        {
            subjects.Context.Subjects.Load();
            obsCollection = subjects.Context.Subjects.Local.ToObservableCollection();
            this.subjects = subjects;


            Remove = new RemoveCommand(subjects);
            Insert = new InsertCommand(subjects);
        }

        public ICommand Remove { get; set; }

        public ICommand Insert { get; set; }
    }
}
