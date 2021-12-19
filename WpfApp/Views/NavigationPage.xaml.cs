using System.Windows;
using System.Windows.Controls;
using WpfApp.Views.GradeViews;
using WpfApp.Views.GroupViews;
using WpfApp.Views.StudentViews;
using WpfApp.Views.SubjectViews;
using WpfApp.Views.TeacherViews;
using WpfApp.Views.TestViews;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Page
    {
        public NavigationPage()
        {
            InitializeComponent();
        }

        private void Students_Click(object sender, RoutedEventArgs e)
        {
            var page = new StudentPage();
            this.NavigationService.Navigate(page);
        }

        private void Grades_Click(object sender, RoutedEventArgs e)
        {
            var page = new GradePage();
            this.NavigationService.Navigate(page);
        }
        private void Teachers_Click(object sender, RoutedEventArgs e)
        {
            var page = new TeacherPage();
            this.NavigationService.Navigate(page);
        }
        private void Groups_Click(object sender, RoutedEventArgs e)
        {
            var page = new GroupPage();
            this.NavigationService.Navigate(page);
        }
        private void Subjects_Click(object sender, RoutedEventArgs e)
        {
            var page = new SubjectPage();
            this.NavigationService.Navigate(page);
        }
        private void Tests_Click(object sender, RoutedEventArgs e)
        {
            var page = new TestPage();
            this.NavigationService.Navigate(page);
        }

        private void Service_Click(object sender, RoutedEventArgs e)
        {
            new ServiceDialog().ShowDialog();
        }
    }
}
