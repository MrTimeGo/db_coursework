using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Views.TestViews
{
    /// <summary>
    /// Interaction logic for TestSeachResultDialog.xaml
    /// </summary>
    public partial class TestSeachResultDialog : Window, ISearchResultDialog
    {
        public TestSeachResultDialog()
        {
            InitializeComponent();
            Table = table;
        }

        public ListView Table { get; set; }
    }
}
