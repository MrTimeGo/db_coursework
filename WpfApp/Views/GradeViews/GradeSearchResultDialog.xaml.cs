using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Views.GradeViews
{
    /// <summary>
    /// Interaction logic for GradeSearchResultDialog.xaml
    /// </summary>
    public partial class GradeSearchResultDialog : Window, ISearchResultDialog
    {
        public GradeSearchResultDialog()
        {
            InitializeComponent();
            Table = table;
        }

        public ListView Table { get; set; }

    }
}
