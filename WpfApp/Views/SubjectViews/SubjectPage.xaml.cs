using System.Windows.Controls;
using WpfApp.Models;
using WpfApp.Services;
using WpfApp.ViewModels;

namespace WpfApp.Views.SubjectViews
{
    /// <summary>
    /// Interaction logic for SubjectPage.xaml
    /// </summary>
    public partial class SubjectPage : Page
    {
        public SubjectPage()
        {
            InitializeComponent();
            DataContext = new SubjectViewModel(new Subjects(UniversityContext.Instance));
        }
    }
}
