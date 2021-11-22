using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class Student : ModelBase
    {
        private int id;
        private string fullName;
        private DateTime birthDate;
        private int groupId;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        public int GroupId
        {
            get => groupId;
            set
            {
                groupId = value;
                OnPropertyChanged(nameof(GroupId));
            }
        }

        public Student(int id, string fullName, DateTime birthDate, int groupId)
        {
            this.id = id;
            this.fullName = fullName;
            this.birthDate = birthDate;
            this.groupId = groupId;
        }
    }
}
