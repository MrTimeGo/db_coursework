using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfApp.Services;

namespace WpfApp.Views.GradeViews
{
    /// <summary>
    /// Interaction logic for GradeAnalyticsDialog.xaml
    /// </summary>
    public partial class GradeAnalyticsDialog : Window
    {
        public SeriesCollection SeriesCollection { get; set; }

        public string[] BarLabels { get; set; }

        public Func<double, string> Formatter { get; set; }

        public GradeAnalyticsDialog(Grades grades)
        {
            List<double> results = grades.Analyse() as List<double>;

            ChartValues<int> values = new ChartValues<int>();
            string[] labels = new string[101];

            for (int i = 0; i <= 100; i++)
            {
                labels[i] = i.ToString();
                values.Add(results.Count(num => num == i));
            }


            InitializeComponent();
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries()
                {
                    Title = "Grades distribution",
                    Values = values
                }
            };
            BarLabels = labels;
            Formatter = v => v.ToString();


            DataContext = this;
        }
    }
}
