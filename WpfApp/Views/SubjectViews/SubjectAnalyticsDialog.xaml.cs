using System;
using System.Windows;
using WpfApp.Services;

namespace WpfApp.Views.SubjectViews
{
    /// <summary>
    /// Interaction logic for SubjectAnalyticsDialog.xaml
    /// </summary>
    public partial class SubjectAnalyticsDialog : Window
    {
        public string Analyse { get; set; }

        public SubjectAnalyticsDialog(Subjects subjects)
        {
            var analyse = subjects.Analyse();

            InitializeComponent();

            Analyse = $"Number of subjects: {analyse.SubjectsCount}\n" +
                $"Average number of tests per subject: {Math.Round(analyse.AverageTestsCount, 4)}\n" +
                $"Standart deviation of tests per subject: {Math.Round(analyse.StandardDeviationTestsCount, 4)}\n" +
                $"Kurtosis of tests per subject: {Math.Round(analyse.KurtosisTestsCount, 4)}";
            DataContext = this;
        }
    }
}
