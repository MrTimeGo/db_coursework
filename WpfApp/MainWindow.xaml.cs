using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

            UniversityContext replica = new UniversityContext("Host=localhost;Port=5432;Database=UniversityReplica;Username=postgres;Password=Artik2003");
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
