using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels.Commands;

namespace WpfApp.ViewModels
{
    public class TeacherViewModel
    {
        private Teachers teachers;

        public ObservableCollection<Teacher> obsCollection { get; set; }

        public TeacherViewModel(Teachers teachers)
        {
            teachers.Context.Teachers.Load();
            obsCollection = teachers.Context.Teachers.Local.ToObservableCollection();
            this.teachers = teachers;


            Remove = new RemoveCommand(teachers);
            Insert = new InsertCommand(teachers);
        }

        public ICommand Remove { get; set; }

        public ICommand Insert { get; set; }
    }
}
