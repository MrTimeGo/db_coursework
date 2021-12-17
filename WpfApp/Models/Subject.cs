using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class Subject : ModelBase
    {
        private int id;
        private string name;
        private string description;
        private int teacherId;

        private Teacher teacher;
        private List<Test> tests;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public int TeacherId
        {
            get => teacherId;
            set
            {
                teacherId = value;
                OnPropertyChanged(nameof(TeacherId));
            }
        }

        public List<Test> Tests
        {
            get => tests;
            set
            {
                tests = value;
                OnPropertyChanged(nameof(Tests));
            }
        }
        public Teacher Teacher
        {
            get => teacher;
            set
            {
                teacher = value;
                OnPropertyChanged(nameof(Teacher));
            }
        }

        public override string ToString()
        {
            return $"{Id}. {Name}";
        }
    }
}
