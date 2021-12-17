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
using WpfApp.Services;
using WpfApp.Models;

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
