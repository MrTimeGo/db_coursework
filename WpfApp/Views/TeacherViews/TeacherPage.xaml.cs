using System.Windows.Controls;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels;

namespace WpfApp.Views.TeacherViews
{
    /// <summary>
    /// Interaction logic for TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        public TeacherPage()
        {
            InitializeComponent();
            DataContext = new TeacherViewModel(new Teachers(UniversityContext.Instance));
        }
    }
}
