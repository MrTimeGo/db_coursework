using System;
using System.Linq;
using System.Windows;
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.Views.SubjectViews
{
    /// <summary>
    /// Interaction logic for SubjectInsertDialog.xaml
    /// </summary>
    public partial class SubjectDialog : Window, IDialog
    {
        public SubjectDialog()
        {
            InitializeComponent();
        }

        public object Result { get; set; }
        public IService Service { get; set; }
        public bool DoValidate { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var teachers = Service.Context.Teachers.ToArray();
            TeacherBox.ItemsSource = teachers;

            if (Result is Subject subject)
            {
                NameBox.Text = subject.Name;
                DescriptionBox.Text = subject.Description;
                TeacherBox.SelectedItem = teachers.First(t => t.Id == subject.TeacherId);
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Test test = TeacherBox.SelectedItem as Test;
            Subject subject = new Subject()
            {
                Name = NameBox.Text,
                Description = DescriptionBox.Text,
                TeacherId = test == null ? -1 : test.Id
            };

            if (DoValidate)
            {
                try
                {
                    Service.ValidateModel(subject);
                    Result = subject;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Result = subject;
                this.Close();
            }
        }
    }
}
