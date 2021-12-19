namespace WpfApp.Models
{
    public class Grade : ModelBase
    {
        private int id;
        private int score;
        private int studentId;
        private int testId;

        private Student student;
        private Test test;

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

        public int TestId
        {
            get => testId;
            set
            {
                testId = value;
                OnPropertyChanged(nameof(TestId));
            }
        }

        public Student Student
        {
            get => student;
            set
            {
                student = value;
                OnPropertyChanged(nameof(Student));
            }
        }

        public Test Test
        {
            get => test;
            set
            {
                test = value;
                OnPropertyChanged(nameof(Test));
            }
        }

        public override string ToString()
        {
            return $"{Id}. {Score}";
        }
    }
}
