using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.Views.GradeViews
{
    /// <summary>
    /// Interaction logic for GradeInsertDialog.xaml
    /// </summary>
    public partial class GradeDialog : Window, IDialog
    {
        public GradeDialog()
        {
            InitializeComponent();
        }

        public object Result { get; set; }
        public IService Service { get; set; }
        public bool DoValidate { get; set; }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var students = Service.Context.Students.ToArray();
            var tests = Service.Context.Tests.ToArray();
            StudentBox.ItemsSource = students;
            TestBox.ItemsSource = tests;

            if (Result is Grade grade)
            {
                ScoreBox.Text = grade.Score.ToString();
                StudentBox.SelectedItem = students.First(s => s.Id == grade.StudentId);
                TestBox.SelectedItem = tests.First(t => t.Id == grade.TestId);
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Student student = StudentBox.SelectedItem as Student;
            Test test = TestBox.SelectedItem as Test;

            Grade grade = new Grade()
            { 
                Score = string.IsNullOrEmpty(ScoreBox.Text) ? -1 : int.Parse(ScoreBox.Text),
                StudentId = student == null ? -1 : student.Id,
                TestId = test == null ? -1 : test.Id,
            };

            if (DoValidate)
            {
                try
                {
                    Service.ValidateModel(grade);
                    Result = grade;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Result = grade;
                this.Close();
            }
        }
    }
}
