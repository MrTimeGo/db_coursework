using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using WpfApp.Models;
using MathNet.Numerics.Statistics;

namespace WpfApp.Services
{
    public class Subjects : IService
    { 
        public UniversityContext Context { get; set; }

        public Subjects(UniversityContext context)
        {
            this.Context = context;
        }


        public void Insert(object entity)
        {
            Subject subject = entity as Subject;
            ArgumentNullException.ThrowIfNull(subject);

            Context.Add(subject);
            Context.SaveChanges();
        }

        public async void Update(object entity, object newEntity)
        {
            Subject subject = entity as Subject;
            Subject newSubject = newEntity as Subject;
            ArgumentNullException.ThrowIfNull(subject);
            ArgumentNullException.ThrowIfNull(newSubject);

            subject.Name = newSubject.Name;
            subject.Description = newSubject.Description;
            subject.TeacherId = newSubject.TeacherId;
            subject.Teacher = Context.Teachers.First(t => t.Id == subject.TeacherId);

            Context.Update(subject);
            await Context.SaveChangesAsync();
        }

        public async void Delete(object entity)
        {
            Subject subject = entity as Subject;
            ArgumentNullException.ThrowIfNull(subject);

            Context.Remove(subject);
            await Context.SaveChangesAsync();
        }

        public void InsertRandom(int amount)
        {
            Random rnd = new Random();

            int[] teacherIds = Context.Teachers.Select(t => t.Id).ToArray();

            if (teacherIds.Length == 0)
            {
                throw new Exception("Can't generate subjects, there is no teachers");
            }

            for (int i = 0; i < amount; i++)
            {
                Context.Subjects.Add(new Subject()
                {
                    Name = RandomString(rnd.Next(4, 9), rnd),
                    Description = RandomString(rnd.Next(16, 33), rnd),
                    TeacherId = teacherIds[rnd.Next(teacherIds.Length)]
                });
            }

            Task.Run(() => Context.SaveChangesAsync());
        }

        private string RandomString(int length, Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void ValidateModel(object entity)
        {
            Subject subject = entity as Subject;
            ArgumentNullException.ThrowIfNull(subject);

            if (string.IsNullOrEmpty(subject.Name))
                throw new ArgumentException("Name was not provided");
            if (string.IsNullOrEmpty(subject.Description))
                throw new ArgumentException("Description was not provided");
            if (subject.TeacherId == 0)
                throw new ArgumentException("Teacher was not provided");
        }

        public IEnumerable Search(object searchParams)
        {
            Subject subject = searchParams as Subject;
            ArgumentNullException.ThrowIfNull(subject);

            var query = (IQueryable<Subject>)Context.Subjects;

            if (!string.IsNullOrEmpty(subject.Name))
            {
                query = query.Where(s => s.Name == subject.Name);
            }

            if (!string.IsNullOrEmpty(subject.Description))
            {
                query = query.Where(s => s.Description == subject.Description);
            }

            if (subject.TeacherId > 0)
            {
                query = query.Where(s => s.TeacherId == subject.TeacherId);
            }

            return query.ToArray();
        }

        public SubjectAnalyseResult Analyse()
        {
            Context.Subjects.Include(s => s.Tests);
            var testsCount = Context.Subjects.Select(s => s.Tests.Count()).Cast<double>().ToArray();

            return new SubjectAnalyseResult()
            {
                SubjectsCount = testsCount.Count(),
                AverageTestsCount = Statistics.Mean(testsCount),
                StandardDeviationTestsCount = Statistics.StandardDeviation(testsCount),
                KurtosisTestsCount = Statistics.Kurtosis(testsCount),
            };
        }
    }
}
