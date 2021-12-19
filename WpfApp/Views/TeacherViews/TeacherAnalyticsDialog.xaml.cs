using System;
using System.Windows;
using WpfApp.Services;

namespace WpfApp.Views.TeacherViews
{
    /// <summary>
    /// Interaction logic for TeacherAnalyticsDialog.xaml
    /// </summary>
    public partial class TeacherAnalyticsDialog : Window
    {
        public string Analyse { get; set; }

        public TeacherAnalyticsDialog(Teachers teachers)
        {
            var analyse = teachers.Analyse();

            InitializeComponent();

            Analyse = $"Number of teachers: {analyse.TeacherCount}\n" +
                $"Average number of subjects per teacher: {Math.Round(analyse.AverageSubjectsCount, 4)}\n" +
                $"Standart deviation of subjects per teacher: {Math.Round(analyse.StandardDeviationSubjectsCount, 4)}\n" +
                $"Kurtosis of subjects per teacher: {Math.Round(analyse.KurtosisSubjectsCount, 4)}";
            DataContext = this;
        }
    }
}
