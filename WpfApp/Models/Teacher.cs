﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NpgsqlTypes;

namespace WpfApp.Models
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

        List<Grade> grades;
        List<Subject> subjects;

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

        public List<Grade> Grades
        {
            get => grades;
            set
            {
                grades = value;
                OnPropertyChanged(nameof(Grades));
            }
        }

        public List<Subject> Subjects
        {
            get => subjects;
            set
            {
                subjects = value;
                OnPropertyChanged(nameof(Subjects));
            }
        }

    }
}