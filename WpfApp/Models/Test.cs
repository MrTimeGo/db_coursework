using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public enum WorkType
    {
        Lecture,
        Practice,
        Seminar,
        Lab,
        Homework,
        Calculation,
        Controlwork,
        Exam
    }
    public class Test : ModelBase
    {
        private int id;
        private string theme;
        private int maxScore;
        private int subjectId;
        private DateTime eventDate;
        private WorkType workType;

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

        public WorkType WorkType
        {
            get => workType;
            set
            {
                workType = value;
                OnPropertyChanged(nameof(WorkType));
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

    }
}
