using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels.Commands;
using WpfApp.Views.SubjectViews;

namespace WpfApp.ViewModels
{
    public class SubjectViewModel
    {
        private Subjects subjects;

        public ObservableCollection<Subject> obsCollection { get; set; }

        public SubjectViewModel(Subjects subjects)
        {
            subjects.Context.Subjects.Include(s => s.Teacher);
            obsCollection = subjects.Context.Subjects.Local.ToObservableCollection();
            this.subjects = subjects;


            Remove = new RemoveCommand(subjects);
            Insert = new InsertCommand<SubjectDialog>(subjects);
            Update = new UpdateCommand<SubjectDialog>(subjects);
            Random = new RandomCommand(subjects);
            Search = new SearchCommand<SubjectDialog, SubjectSearchResultDialog>(subjects);
            Analyse = new AnalyseCommand(subjects);
        }

        public ICommand Remove { get; set; }

        public ICommand Insert { get; set; }

        public ICommand Update { get; set; }

        public ICommand Random { get; set; }

        public ICommand Search { get; set; }

        public ICommand Analyse { get; set; }

        private class AnalyseCommand : ICommand
        {
            Subjects subjects;

            public AnalyseCommand(Subjects subjects)
            {
                this.subjects = subjects;
            }
            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                return true;
            }

            public void Execute(object? parameter)
            {
                new SubjectAnalyticsDialog(subjects).ShowDialog();
            }
        }
    }
}
