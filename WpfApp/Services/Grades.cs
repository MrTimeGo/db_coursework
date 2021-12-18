using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WpfApp.Models;
using MathNet.Numerics.Distributions;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace WpfApp.Services
{
    public class Grades : IService
    {
        public UniversityContext Context { get; set; }

        public Grades(UniversityContext context)
        {
            this.Context = context;
        }


        public void Insert(object entity)
        {
            Grade grade = entity as Grade;
            ArgumentNullException.ThrowIfNull(grade);

            Context.Grades.Add(grade);
            Context.SaveChanges();
        }

        public async void Update(object entity, object newEntity)
        {
            Grade grade = entity as Grade;
            Grade newGrade = newEntity as Grade;
            ArgumentNullException.ThrowIfNull(grade);
            ArgumentNullException.ThrowIfNull(newGrade);

            grade.Score = newGrade.Score;
            grade.StudentId = newGrade.StudentId;
            grade.TestId = newGrade.TestId;
            grade.Test = Context.Tests.First(t => t.Id == newGrade.TestId);
            grade.Student = Context.Students.First(s => s.Id == newGrade.StudentId);

            Context.Grades.Update(grade);
            await Context.SaveChangesAsync();
        }

        public async void Delete(object entity)
        {
            Grade grade = entity as Grade;
            ArgumentNullException.ThrowIfNull(grade);

            Context.Grades.Remove(grade);
            await Context.SaveChangesAsync();
        }

        public void InsertRandom(int amount)
        {
            Random rnd = new Random();

            int[] studentIds = Context.Students.Select(x => x.Id).ToArray();
            int[] testIds = Context.Tests.Select(x => x.Id).ToArray();

            if (studentIds.Length == 0)
                throw new Exception("Can't generate grades, there is no students");
            if (testIds.Length == 0)
                throw new Exception("Can't generate grades, there is no tests");

            for (int i = 0; i < amount; i++)
            {
                int testId = testIds[rnd.Next(testIds.Length)];
                int maxScore = Context.Tests.First(test => test.Id == testId).MaxScore;
                Context.Grades.Add(new Grade()
                {
                    Score = Score(maxScore, rnd),
                    StudentId = studentIds[rnd.Next(studentIds.Length)],
                    TestId = testId
                });
            }

            Task.Run(() => Context.SaveChangesAsync());
        }

        private int Score(int maxScore, Random rnd)
        {
            Normal normal = Normal.WithMeanStdDev(0.8, 0.067, rnd);

            double ratio = normal.Sample();

            ratio = ratio > 1 ? 1 : ratio;
            ratio = ratio < 0 ? 0 : ratio;

            return (int)Math.Round(ratio * maxScore);
        }
        
        public void ValidateModel(object entity)
        {
            Grade grade = entity as Grade;
            ArgumentNullException.ThrowIfNull(grade);

            int maxScore = Context.Tests.First(t => t.Id == grade.TestId).MaxScore;

            if (grade.Score > maxScore)
                throw new ArgumentException("Score can't be bigger than max score");
            if (grade.StudentId == 0)
                throw new ArgumentException("Student was not provided");
            if (grade.TestId == 0)
                throw new ArgumentException("Test was not provided");
        }

        public IEnumerable Search(object searchParams)
        {
            Grade grade = searchParams as Grade;
            ArgumentNullException.ThrowIfNull(grade);

            var query = (IQueryable<Grade>)Context.Grades;

            if (grade.Score >= 0)
            {
                query = query.Where(g => grade.Score == g.Score);
            }
            if (grade.StudentId > 0)
            {
                query = query.Where(g => g.StudentId == grade.StudentId);
            }
            if (grade.TestId > 0)
            {
                query = query.Where(g => grade.TestId == g.TestId);
            }

            return query.ToList();
        }

        public object Analyse()
        {
            Context.Grades.Include(g => g.Test);

            return Context.Grades.Select(g => Math.Round(100 * g.Score / (double)g.Test.MaxScore)).OrderBy(perc => perc).ToList();
        }
    }
}
