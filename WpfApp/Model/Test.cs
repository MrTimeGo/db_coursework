using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
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

        public Test(int id, string theme, int maxScore, int subjectId, DateTime eventDate, WorkType workType)
        {
            this.id = id;
            this.theme = theme;
            this.maxScore = maxScore;
            this.subjectId = subjectId;
            this.eventDate = eventDate;
            this.workType = workType;
        }
    }
}
