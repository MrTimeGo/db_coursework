using System.Windows.Controls;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels;

namespace WpfApp.Views.TestViews
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();
            DataContext = new TestViewModel(new Tests(UniversityContext.Instance));
        }
    }
}
