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
