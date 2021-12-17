using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp.Views.StudentViews
{
    /// <summary>
    /// Interaction logic for StudentSeachResultDialog.xaml
    /// </summary>
    public partial class StudentSeachResultDialog : Window, ISearchResultDialog
    {
        public StudentSeachResultDialog()
        {
            InitializeComponent();
            Table = table;
        }

        public ListView Table { get; set; }
    }
}
