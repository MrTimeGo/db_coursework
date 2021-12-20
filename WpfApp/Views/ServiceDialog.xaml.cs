using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Windows;
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for ServiceDialog.xaml
    /// </summary>
    public partial class ServiceDialog : Window
    {
        public ServiceDialog()
        {
            InitializeComponent();
        }

        private void Backup_Click(object sender, RoutedEventArgs e)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "./../../../BackupDB.bat",
                    Arguments = $"{DateTime.Now:yyyy-MM-dd}_{DateTime.Now:HH-mm-ss}",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Verb = "runas"
                }
            };

            Stopwatch stopwatch = Stopwatch.StartNew();
            process.Start();
            process.WaitForExit();
            stopwatch.Stop();
            MessageBox.Show($"Backup was created in {stopwatch.ElapsedMilliseconds} ms.");
        }

        private void Restore_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                if (!File.Exists(dialog.FileName))
                    return;
                if (!dialog.FileName.EndsWith(".sql"))
                    return;

                UniversityContext.Instance.Database.CloseConnection();

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "./../../../RestoreDB.bat",
                        Arguments = dialog.FileName,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        Verb = "runas"
                    }
                };

                Stopwatch stopwatch = Stopwatch.StartNew();
                process.Start();
                process.WaitForExit();
                stopwatch.Stop();
                MessageBox.Show($"DB was restored in {stopwatch.ElapsedMilliseconds} ms. Restart the app.");
                Application.Current.Shutdown();
            }
        }

        private void Performance_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, long> dick = new Dictionary<string, long>();
            PerformanceStudents(dick);
            PerformanceGrades(dick);
            PerformanceGroups(dick);
            PerformanceTeachers(dick);
            PerformanceSubjects(dick);
            PerformanceTests(dick);

            new PerformanceResult(dick).ShowDialog();
        }

        private void PerformanceStudents(Dictionary<string, long> dick)
        {
            Students service = new Students(UniversityContext.Instance);
            var searchParameters = new Student()
            {
                FullName = "a",
            };
            var result = service.Search(searchParameters);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            result = service.Search(searchParameters);
            watch.Stop();

            dick.Add("students", watch.ElapsedMilliseconds);


            service.Context.Database.ExecuteSqlRaw("CREATE INDEX students_fullname_index\n" +
                                                   "ON \"Students\" USING hash (\"FullName\");");

            watch = new Stopwatch();
            watch.Start();
            result = service.Search(searchParameters);
            watch.Stop();

            dick.Add("students_index", watch.ElapsedMilliseconds);

            service.Context.Database.ExecuteSqlRaw("DROP INDEX students_fullname_index");
        }

        private void PerformanceGrades(Dictionary<string, long> dick)
        {
            Grades service = new Grades(UniversityContext.Instance);
            var searchParameters = new Grade()
            {
                Score = 1,
            };
            var result = service.Search(searchParameters);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            result = service.Search(searchParameters);
            watch.Stop();

            dick.Add("grades", watch.ElapsedMilliseconds);


            service.Context.Database.ExecuteSqlRaw("CREATE INDEX grades_score_index\n" +
                                                   "ON \"Grades\" USING hash (\"Score\");");

            watch = new Stopwatch();
            watch.Start();
            result = service.Search(searchParameters);
            watch.Stop();

            dick.Add("grades_index", watch.ElapsedMilliseconds);

            service.Context.Database.ExecuteSqlRaw("DROP INDEX grades_score_index");
        }

        private void PerformanceGroups(Dictionary<string, long> dick)
        {
            Groups service = new Groups(UniversityContext.Instance);
            var searchParameters = new Group()
            {
                Code = "AA-11"
            };
            var result = service.Search(searchParameters);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            result = service.Search(searchParameters);
            watch.Stop();

            dick.Add("groups", watch.ElapsedMilliseconds);


            service.Context.Database.ExecuteSqlRaw("CREATE INDEX groups_code_index\n" +
                                                   "ON \"Groups\" USING hash (\"Code\");");

            watch = new Stopwatch();
            watch.Start();
            result = service.Search(searchParameters);
            watch.Stop();

            dick.Add("groups_index", watch.ElapsedMilliseconds);

            service.Context.Database.ExecuteSqlRaw("DROP INDEX groups_code_index");
        }

        private void PerformanceTeachers(Dictionary<string, long> dick)
        {
            Teachers service = new Teachers(UniversityContext.Instance);
            var searchParameters = new Teacher()
            {
                FullName = "a"
            };
            var result = service.Search(searchParameters);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            result = service.Search(searchParameters);
            watch.Stop();

            dick.Add("teachers", watch.ElapsedMilliseconds);


            service.Context.Database.ExecuteSqlRaw("CREATE INDEX teachers_fullname_index\n" +
                                                   "ON \"Teachers\" USING hash (\"FullName\");");

            watch = new Stopwatch();
            watch.Start();
            result = service.Search(searchParameters);
            watch.Stop();

            dick.Add("teachers_index", watch.ElapsedMilliseconds);

            service.Context.Database.ExecuteSqlRaw("DROP INDEX teachers_fullname_index");
        }

        private void PerformanceSubjects(Dictionary<string, long> dick)
        {
            Subjects service = new Subjects(UniversityContext.Instance);
            var searchParameters = new Subject()
            {
                Name = "a"
            };
            var result = service.Search(searchParameters);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            result = service.Search(searchParameters);
            watch.Stop();

            dick.Add("subjects", watch.ElapsedMilliseconds);


            service.Context.Database.ExecuteSqlRaw("CREATE INDEX subjects_name_index\n" +
                                                   "ON \"Subjects\" USING hash (\"Name\");");

            watch = new Stopwatch();
            watch.Start();
            result = service.Search(searchParameters);
            watch.Stop();

            dick.Add("subjects_index", watch.ElapsedMilliseconds);

            service.Context.Database.ExecuteSqlRaw("DROP INDEX subjects_name_index");
        }

        private void PerformanceTests(Dictionary<string, long> dick)
        {
            Tests service = new Tests(UniversityContext.Instance);
            var searchParameters = new Test()
            {
                Theme = "a"
            };
            var result = service.Search(searchParameters);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            result = service.Search(searchParameters);
            watch.Stop();

            dick.Add("tests", watch.ElapsedMilliseconds);


            service.Context.Database.ExecuteSqlRaw("CREATE INDEX tests_theme_index\n" +
                                                   "ON \"Tests\" USING hash (\"Theme\");");

            watch = new Stopwatch();
            watch.Start();
            result = service.Search(searchParameters);
            watch.Stop();

            dick.Add("tests_index", watch.ElapsedMilliseconds);

            service.Context.Database.ExecuteSqlRaw("DROP INDEX tests_theme_index");
        }
    }
}
