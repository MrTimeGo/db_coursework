﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class Grade : ModelBase
    {
        private int id;
        private int score;
        private int studentId;
        private int verifiedBy;
        private int testId;

        private Student student;
        private Teacher teacher;
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

        public Student Student
        {
            get => student;
            set
            {
                student = value;
                OnPropertyChanged(nameof(Student));
            }
        }

        public Teacher Teacher
        {
            get => teacher;
            set
            {
                teacher = value;
                OnPropertyChanged(nameof(Teacher));
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
    }
}