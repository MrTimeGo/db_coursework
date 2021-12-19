using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Views.GroupViews
{
    /// <summary>
    /// Interaction logic for GroupSearchResultDialog.xaml
    /// </summary>
    public partial class GroupSearchResultDialog : Window, ISearchResultDialog
    {
        public GroupSearchResultDialog()
        {
            InitializeComponent();
            Table = table;
        }

        public ListView Table { get; set; }
    }
}
