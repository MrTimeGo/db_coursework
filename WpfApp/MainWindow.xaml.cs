using Microsoft.EntityFrameworkCore;
using System.Windows;
using WpfApp.Models;
using WpfApp.Views;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UniversityContext replica = new UniversityContext("Host=localhost;Port=5432;Database=university_replica;Username=postgres;Password=Artik2003");
            replica.CreateSubscription();

            UniversityContext.Instance.Students.Load();
            UniversityContext.Instance.Grades.Load();
            UniversityContext.Instance.Subjects.Load();
            UniversityContext.Instance.Tests.Load();
            UniversityContext.Instance.Groups.Load();
            UniversityContext.Instance.Teachers.Load();

            Main.Content = new NavigationPage();
        }
    }
}
