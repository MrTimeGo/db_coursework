using Microsoft.EntityFrameworkCore;
using System.Linq;
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

            UniversityContext main = UniversityContext.Instance;

            UniversityContext replica = new UniversityContext("Host=localhost;Port=5432;Database=university_replica;Username=postgres;Password=Artik2003");
            replica.CreateSubscription();

            if (!main.Students.Any() &&
                !main.Tests.Any() &&
                !main.Groups.Any() &&
                !main.Teachers.Any() &&
                !main.Subjects.Any() &&
                !main.Grades.Any())
            {
                main.Students.AddRange(replica.Students);
                main.Tests.AddRange(replica.Tests);
                main.Grades.AddRange(replica.Grades);
                main.Groups.AddRange(replica.Groups);
                main.Subjects.AddRange(replica.Subjects);
                main.Teachers.AddRange(replica.Teachers);

                main.SaveChanges();
            }

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
