using System.Windows;
using System.Windows.Controls;

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
