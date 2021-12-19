using System.Windows.Controls;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels;

namespace WpfApp.Views.GradeViews
{
    /// <summary>
    /// Interaction logic for GradePage.xaml
    /// </summary>
    public partial class GradePage : Page
    {
        public GradePage()
        {
            InitializeComponent();
            DataContext = new GradeViewModel(new Grades(UniversityContext.Instance));
        }
    }
}
