using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for RandomDialog.xaml
    /// </summary>
    public partial class RandomDialog : Window, IRandomDialog
    {
        public RandomDialog()
        {
            InitializeComponent();
        }

        public int? Result { get; set; }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Amount.Text))
            {
                MessageBox.Show("Should provide amount");
                return;
            }
            int result = int.Parse(Amount.Text);
            if (Result < 0)
            {
                MessageBox.Show("Amout shouldn't be negative");
                return;
            }

            Result = result;
            this.Close();
        }
    }
}
