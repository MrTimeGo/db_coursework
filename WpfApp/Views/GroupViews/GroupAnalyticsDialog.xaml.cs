using LiveCharts;
using LiveCharts.Wpf;
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

namespace WpfApp.Views.GroupViews
{
    /// <summary>
    /// Interaction logic for GroupAnalyticsDialog.xaml
    /// </summary>
    public partial class GroupAnalyticsDialog : Window
    {
        public SeriesCollection SeriesCollection { get; set; }

        public string[] BarLabels { get; set; }

        public Func<double, string> Formatter { get; set; }

        public GroupAnalyticsDialog(Groups groups)
        {
            InitializeComponent();
            var analyseResults = groups.Analyse();

            ChartValues<decimal> values = new ChartValues<decimal>();
            string[] labels = new string[analyseResults.Count];

            for (int i = 0; i < analyseResults.Count; i++)
            {
                values.Add(Math.Round(analyseResults[i].AverageScore, 4));
                labels[i] = analyseResults[i].GroupCode;
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries()
                {
                    Values = values,
                    Title = "Average score per group",
                }
            };
            BarLabels = labels;
            Formatter = value => value.ToString();

            DataContext = this;
        }

        
    }
}
