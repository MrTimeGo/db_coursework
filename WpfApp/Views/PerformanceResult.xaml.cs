using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for PerformanceResult.xaml
    /// </summary>
    public partial class PerformanceResult : Window
    {
        public SeriesCollection SeriesCollection { get; set; }

        public string[] BarLabels { get; set; }

        public Func<double, string> Formatter { get; set; }

        public PerformanceResult(Dictionary<string, long> dick)
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection()
            {
                new ColumnSeries()
                {
                    Title = "Students",
                    Values = new ChartValues<long>()
                    {
                        dick["students"],
                        dick["students_index"]
                    }
                },
                new ColumnSeries()
                {
                    Title = "Groups",
                    Values = new ChartValues<long>()
                    {
                        dick["groups"],
                        dick["groups_index"]
                    }
                },
                new ColumnSeries()
                {
                    Title = "Teachers",
                    Values = new ChartValues<long>()
                    {
                        dick["teachers"],
                        dick["teachers_index"]
                    }
                },
                new ColumnSeries()
                {
                    Title = "Subjects",
                    Values = new ChartValues<long>()
                    {
                        dick["subjects"],
                        dick["subjects_index"]
                    }
                },
                new ColumnSeries()
                {
                    Title = "Tests",
                    Values = new ChartValues<long>()
                    {
                        dick["tests"],
                        dick["tests_index"]
                    }
                },
                new ColumnSeries()
                {
                    Title = "Grades",
                    Values = new ChartValues<long>()
                    {
                        dick["grades"],
                        dick["grades_index"]
                    }
                }
            };
            BarLabels = new string[]
            {
                "withount index", "with index"
            };
            Formatter = v => v.ToString() + " ms";

            DataContext = this;
        }
    }
}
