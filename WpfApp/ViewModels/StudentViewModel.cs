using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels.Commands;

namespace WpfApp.ViewModels
{
    public class StudentViewModel
    {
        private Students students;

        public ObservableCollection<Student> obsCollection { get; set; }

        public StudentViewModel(Students students)
        {
            students.Context.Students.Load();
            students.Context.Students.Include(s => s.Group);
            obsCollection = students.Context.Students.Local.ToObservableCollection();
            this.students = students;


            Remove = new RemoveCommand(students);
            Insert = new InsertCommand(students);
        }

        public ICommand Remove { get; set; }

        public ICommand Insert { get; set; }


    }
}
