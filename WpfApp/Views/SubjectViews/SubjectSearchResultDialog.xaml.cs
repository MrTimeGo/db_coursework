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

namespace WpfApp.Views.SubjectViews
{
    /// <summary>
    /// Interaction logic for SubjectSearchResultDialog.xaml
    /// </summary>
    public partial class SubjectSearchResultDialog : Window, ISearchResultDialog
    {
        public SubjectSearchResultDialog()
        {
            InitializeComponent();
            Table = table;
        }

        public ListView Table { get; set; }
    }
}
