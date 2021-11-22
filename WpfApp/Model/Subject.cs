using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class Subject : ModelBase
    {
        private int id;
        private string name;
        private string description;
        private int teacherId;

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

        public Subject(int id, string name, string description, int teacherId)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.teacherId = teacherId;
        }
    }
}
