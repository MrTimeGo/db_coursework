using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels.Commands;
using WpfApp.Views.TeacherViews;

namespace WpfApp.ViewModels
{
    public class TeacherViewModel
    {
        private Teachers teachers;

        public ObservableCollection<Teacher> obsCollection { get; set; }

        public TeacherViewModel(Teachers teachers)
        {
            obsCollection = teachers.Context.Teachers.Local.ToObservableCollection();
            this.teachers = teachers;


            Remove = new RemoveCommand(teachers);
            Insert = new InsertCommand<TeacherDialog>(teachers);
            Update = new UpdateCommand<TeacherDialog>(teachers);
            Random = new RandomCommand(teachers);
            Search = new SearchCommand<TeacherDialog, TeacherSearchResultDialog>(teachers);
            Analyse = new AnalyseCommand(teachers);
        }

        public ICommand Remove { get; set; }

        public ICommand Insert { get; set; }

        public ICommand Update { get; set; }

        public ICommand Random { get; set; }

        public ICommand Search { get; set; }

        public ICommand Analyse { get; set; }

        private class AnalyseCommand : ICommand
        {
            Teachers teachers;

            public AnalyseCommand(Teachers teachers)
            {
                this.teachers = teachers;
            }
            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                return true;
            }

            public void Execute(object? parameter)
            {
                new TeacherAnalyticsDialog(teachers).ShowDialog();
            }
        }
    }
}
