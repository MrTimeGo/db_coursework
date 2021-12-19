using System.Windows.Controls;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels;

namespace WpfApp.Views.GroupViews
{
    /// <summary>
    /// Interaction logic for GroupPage.xaml
    /// </summary>
    public partial class GroupPage : Page
    {
        public GroupPage()
        {
            InitializeComponent();
            DataContext = new GroupViewModel(new Groups(UniversityContext.Instance));
        }
    }
}
