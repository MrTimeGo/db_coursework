using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class Grade : ModelBase
    {
        private int id;
        private int score;
        private int studentId;
        private int verifiedBy;
        private int testId;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public int Score
        {
            get => score;
            set
            {
                score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public int StudentId
        {
            get => studentId;
            set
            {
                studentId = value;
                OnPropertyChanged(nameof(StudentId));
            }
        }

        public int VerifiedBy
        {
            get => verifiedBy;
            set
            {
                verifiedBy = value;
                OnPropertyChanged(nameof(VerifiedBy));
            }
        }

        public int TestId
        {
            get => testId;
            set
            {
                testId = value;
                OnPropertyChanged(nameof(TestId));
            }
        }

        public Grade(int id, int score, int studentId, int verifiedBy, int testId)
        {
            this.id = id;
            this.score = score;
            this.studentId = studentId;
            this.verifiedBy = verifiedBy;
            this.testId = testId;
        }
    }
}
