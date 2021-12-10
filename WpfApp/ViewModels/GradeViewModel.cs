using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels.Commands;

namespace WpfApp.ViewModels
{
    public class GradeViewModel
    {
        private Grades grades;

        public ObservableCollection<Grade> obsCollection { get; set; }

        public GradeViewModel(Grades grades)
        {
            grades.Context.Grades.Load();
            obsCollection = grades.Context.Grades.Local.ToObservableCollection();
            this.grades = grades;


            Remove = new RemoveCommand(grades);
            Insert = new InsertCommand(grades);
        }

        public ICommand Remove { get; set; }

        public ICommand Insert { get; set; }
    }
}
