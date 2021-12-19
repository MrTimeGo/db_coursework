using System.Collections.Generic;

namespace WpfApp.Models
{
    public enum Position
    {
        Assistant,
        Lecturer,
        SeniorLecturer,
        Docent,
        Professor
    }
    public class Teacher : ModelBase
    {
        private int id;
        private string fullName;
        private Position position;

        List<Subject> subjects;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public Position Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

        public List<Subject> Subjects
        {
            get => subjects;
            set
            {
                subjects = value;
                OnPropertyChanged(nameof(Subjects));
            }
        }

        public override string ToString()
        {
            return $"{Id}. {FullName}";
        }
    }
}
