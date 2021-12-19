using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Views.TeacherViews
{
    /// <summary>
    /// Interaction logic for TeacherSearchResultDialog.xaml
    /// </summary>
    public partial class TeacherSearchResultDialog : Window, ISearchResultDialog
    {
        public TeacherSearchResultDialog()
        {
            InitializeComponent();
            Table = table;
        }

        public ListView Table { get; set; }
    }
}
