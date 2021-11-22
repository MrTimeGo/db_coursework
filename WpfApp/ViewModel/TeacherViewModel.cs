using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public class TeacherViewModel
    {
        private IList<Teacher> teachers;

        public TeacherViewModel()
        {
            teachers = new List<Teacher>()
            {
                new Teacher(1, "Legezza V.P.", Position.Professor),
                new Teacher(2, "Ruslan", Position.SeniorLecturer)
            };
        }

        public IList<Teacher> Teachers 
        {
            get { return teachers; }
            set { teachers = value; }
        }

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            public bool CanExecute(object? parameter)
            {
                return true;
            }

            public event EventHandler? CanExecuteChanged;

            public void Execute(object? parameter)
            {
                MessageBox.Show(parameter.ToString());
            }
        }
    }
}
