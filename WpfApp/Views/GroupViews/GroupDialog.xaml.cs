using System;
using System.Windows;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.Services;
using RegularExpressions = System.Text.RegularExpressions;

namespace WpfApp.Views.GroupViews
{
    /// <summary>
    /// Interaction logic for GroupInsertDialog.xaml
    /// </summary>
    public partial class GroupDialog : Window, IDialog
    {
        public GroupDialog()
        {
            InitializeComponent();
        }

        public object Result { get; set; }
        public IService Service { get; set; }
        public bool DoValidate { get; set; }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Group group = new Group()
            {
                Code = CodeBox.Text,
                StartEducation = StartEducationBox.SelectedDate ?? DateTime.MinValue,
                EndEducation = EndEducationBox.SelectedDate ?? DateTime.MinValue
            };

            if (DoValidate)
            {
                try
                {
                    Service.ValidateModel(group);
                    Result = group;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Result = group;
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Result is Group group)
            {
                CodeBox.Text = group.Code;
                StartEducationBox.SelectedDate = group.StartEducation;
                EndEducationBox.SelectedDate= group.EndEducation;
            }
        }
    }
}
