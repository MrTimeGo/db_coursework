using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.Views.TestViews
{
    /// <summary>
    /// Interaction logic for TestInsertDialog.xaml
    /// </summary>
    public partial class TestDialog : Window, IDialog
    {
        public object Result { get; set; }
        public IService Service { get; set; }
        public bool DoValidate { get; set; }

        public TestDialog()
        {
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var subjects = Service.Context.Subjects.ToArray();
            SubjectBox.ItemsSource = subjects;

            if (Result is Test test)
            {
                ThemeBox.Text = test.Theme;
                MaxScoreBox.Text = test.MaxScore.ToString();
                SubjectBox.SelectedItem = subjects.First(s => s.Id == test.SubjectId);
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Subject subject = SubjectBox.SelectedItem as Subject;
            Test test = new Test()
            {
                Theme = ThemeBox.Text,
                MaxScore = string.IsNullOrEmpty(MaxScoreBox.Text) ? -1 : int.Parse(MaxScoreBox.Text),
                SubjectId = subject == null ? -1 : subject.Id,
            };

            if (DoValidate)
            {
                try
                {
                    Service.ValidateModel(test);
                    Result = test;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Result = test;
                this.Close();
            }
        }
    }

}
