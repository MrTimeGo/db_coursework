using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels.Commands;
using WpfApp.Views.GradeViews;

namespace WpfApp.ViewModels
{
    public class GradeViewModel
    {
        private Grades grades;

        public ObservableCollection<Grade> obsCollection { get; set; }

        public GradeViewModel(Grades grades)
        {
            grades.Context.Grades.Include(g => g.Student).Include(g => g.Test);
            obsCollection = grades.Context.Grades.Local.ToObservableCollection();
            this.grades = grades;


            Remove = new RemoveCommand(grades);
            Insert = new InsertCommand<GradeDialog>(grades);
            Update = new UpdateCommand<GradeDialog>(grades);
            Random = new RandomCommand(grades);
            Search = new SearchCommand<GradeDialog, GradeSearchResultDialog>(grades);
            Analyse = new AnalyseCommand(grades);
        }

        public ICommand Remove { get; set; }

        public ICommand Insert { get; set; }

        public ICommand Update { get; set; }

        public ICommand Random { get; set; }

        public ICommand Search { get; set; }

        public ICommand Analyse { get; set; }

        private class AnalyseCommand : ICommand
        {
            Grades grades;

            public AnalyseCommand(Grades grades)
            {
                this.grades = grades;
            }
            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                return true;
            }

            public void Execute(object? parameter)
            {
                new GradeAnalyticsDialog(grades).ShowDialog();
            }
        }
    }
}
