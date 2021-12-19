using System;
using System.Collections.Generic;

namespace WpfApp.Models
{
    public class Student : ModelBase
    {
        private int id;
        private string fullName;
        private DateTime birthDate;
        private int groupId;
        private Group group;
        private List<Grade> grades;

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

        public Group Group
        {
            get => group;
            set
            {
                group = value;
                OnPropertyChanged(nameof(Group));
            }
        }

        public List<Grade> Grades
        {
            get => grades;
            set
            {
                grades = value;
                OnPropertyChanged(nameof(Grades));
            }
        }

        public override string ToString()
        {
            return $"{Id}. {FullName}";
        }
    }
}
