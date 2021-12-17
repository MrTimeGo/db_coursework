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
                $"Average number of subjects per teacher: {Math.Round(analyse.AverageSubjectsCount,4)}\n" +
                $"Standart deviation of subjects per teacher: {Math.Round(analyse.StandardDeviationSubjectsCount,4)}\n" +
                $"Kurtosis of subjects per teacher: {Math.Round(analyse.KurtosisSubjectsCount,4)}";
            DataContext = this;
        }
    }
}
