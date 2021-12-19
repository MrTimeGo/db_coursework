using System;
using System.Linq;
using System.Windows;
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.Views.StudentViews
{
    /// <summary>
    /// Interaction logic for StudentInsertDialog.xaml
    /// </summary>
    public partial class StudentDialog : Window, IDialog
    {
        public StudentDialog()
        {
            InitializeComponent();
        }

        public object Result { get; set; }
        public IService Service { get; set; }
        public bool DoValidate { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var groups = Service.Context.Groups.ToArray();
            GroupBox.ItemsSource = groups;

            if (Result is Student student)
            {
                FullNameBox.Text = student.FullName;
                BirthDayBox.SelectedDate = student.BirthDate;
                GroupBox.SelectedItem = groups.First(g => g.Id == student.GroupId);
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Group group = GroupBox.SelectedItem as Group;
            Student student = new Student()
            {
                FullName = FullNameBox.Text,
                BirthDate = BirthDayBox.SelectedDate ?? DateTime.MinValue,
                GroupId = group == null ? -1 : group.Id
            };

            if (DoValidate)
            {
                try
                {
                    Service.ValidateModel(student);
                    Result = student;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                Result = student;
                this.Close();
            }
        }
    }
}
