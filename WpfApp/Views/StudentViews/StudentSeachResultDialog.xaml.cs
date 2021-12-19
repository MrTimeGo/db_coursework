using System.Windows;
using System.Windows.Controls;

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
