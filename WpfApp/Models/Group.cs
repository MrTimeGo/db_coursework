using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class Group : ModelBase
    {
        private int id;
        private string code;
        private DateTime startEducation;
        private DateTime endEducation;
        private List<Student> students;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Code
        {
            get => code;
            set
            {
                code = value;
                OnPropertyChanged(Code);
            }
        }

        public DateTime StartEducation
        {
            get => startEducation;
            set
            {
                startEducation = value;
                OnPropertyChanged(nameof(StartEducation));
            }
        }

        public DateTime EndEducation
        {
            get => endEducation;
            set
            {
                endEducation = value;
                OnPropertyChanged(nameof(EndEducation));
            }
        }

        public List<Student> Students
        {
            get => students;
            set
            {
                students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

    }
}
