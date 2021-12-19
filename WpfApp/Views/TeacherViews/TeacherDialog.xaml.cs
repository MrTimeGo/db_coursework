using System;
using System.Windows;
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp.Views.TeacherViews
{
    /// <summary>
    /// Interaction logic for TeacherInsertDialog.xaml
    /// </summary>
    public partial class TeacherDialog : Window, IDialog
    {
        public object Result { get; set; }

        public IService Service { get; set; }
        public bool DoValidate { get; set; }

        public TeacherDialog()
        {
            InitializeComponent();
            PositionBox.ItemsSource = typeof(Position).GetEnumValues();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher()
            {
                FullName = FullNameBox.Text,
                Position = PositionBox.SelectedItem == null ? Position.Assistant : (Position)PositionBox.SelectedItem
            };

            if (DoValidate)
            {
                try
                {
                    Service.ValidateModel(teacher);
                    Result = teacher;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Result = teacher;
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Result is Teacher teacher)
            {
                FullNameBox.Text = teacher.FullName;
                PositionBox.SelectedItem = teacher.Position;
            }
        }
    }
}
