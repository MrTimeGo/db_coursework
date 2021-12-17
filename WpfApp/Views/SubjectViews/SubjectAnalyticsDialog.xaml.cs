using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
                $"Standart deviation of tests per subject: {Math.Round(analyse.StandardDeviationTestsCount,4)}\n" +
                $"Kurtosis of tests per subject: {Math.Round(analyse.KurtosisTestsCount,4)}";
            DataContext = this;
        }
    }
}
