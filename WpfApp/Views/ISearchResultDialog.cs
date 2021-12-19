using System.Windows.Controls;

namespace WpfApp.Views
{
    public interface ISearchResultDialog
    {
        public bool? ShowDialog();
        public ListView Table { get; set; }
    }
}
