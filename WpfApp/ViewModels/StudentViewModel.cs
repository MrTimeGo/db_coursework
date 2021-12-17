using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels.Commands;
using WpfApp.Views.StudentViews;

namespace WpfApp.ViewModels
{
    public class StudentViewModel
    {
        private Students students;

        public ObservableCollection<Student> obsCollection { get; set; }

        public StudentViewModel(Students students)
        {
            students.Context.Students.Include(s => s.Group);
            obsCollection = students.Context.Students.Local.ToObservableCollection();
            this.students = students;


            Remove = new RemoveCommand(students);
            Insert = new InsertCommand<StudentDialog>(students);
            Update = new UpdateCommand<StudentDialog>(students);
            Random = new RandomCommand(students);
            Search = new SearchCommand<StudentDialog, StudentSeachResultDialog>(students);
        }

        public ICommand Remove { get; set; }

        public ICommand Insert { get; set; }

        public ICommand Update { get; set; }

        public ICommand Random { get; set; }

        public ICommand Search { get; set; }
    }
}
