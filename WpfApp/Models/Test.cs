using System;
using System.Collections.Generic;

namespace WpfApp.Models
{

    public class Test : ModelBase
    {
        private int id;
        private string theme;
        private int maxScore;
        private int subjectId;
        private DateTime eventDate;

        private Subject subject;
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

        public string Theme
        {
            get => theme;
            set
            {
                theme = value;
                OnPropertyChanged(nameof(Theme));
            }
        }

        public int MaxScore
        {
            get => maxScore;
            set
            {
                maxScore = value;
                OnPropertyChanged(nameof(MaxScore));
            }
        }

        public int SubjectId
        {
            get => subjectId;
            set
            {
                subjectId = value;
                OnPropertyChanged(nameof(SubjectId));
            }
        }

        public DateTime EventDate
        {
            get => eventDate;
            set
            {
                eventDate = value;
                OnPropertyChanged(nameof(EventDate));
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

        public Subject Subject
        {
            get => subject;
            set
            {
                subject = value;
                OnPropertyChanged(nameof(Subject));
            }
        }

        public override string ToString()
        {
            return $"{Id}. {Theme}. Max: {MaxScore}";
        }
    }
}
