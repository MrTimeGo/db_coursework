using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
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

        public Teacher(int id, string fullName, Position position)
        {
            Id = id;
            FullName = fullName;
            Position = position;
        }
    }
}
