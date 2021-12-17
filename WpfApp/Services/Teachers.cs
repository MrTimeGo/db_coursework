using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;
using MathNet.Numerics.Statistics;

namespace WpfApp.Services
{
    public class Teachers : IService
    {
        public UniversityContext Context { get; set; }

        public Teachers(UniversityContext context)
        {
            this.Context = context;
        }

        public void Insert(object entity)
        {
            Teacher teacher = entity as Teacher;
            ArgumentNullException.ThrowIfNull(teacher);

            Context.Add(teacher);
            Context.SaveChanges();
        }

        public async void Update(object entity, object newEntity)
        {
            Teacher teacher = entity as Teacher;
            Teacher newTeacher = newEntity as Teacher;
            ArgumentNullException.ThrowIfNull(teacher);
            ArgumentNullException.ThrowIfNull(newTeacher);

            teacher.FullName = newTeacher.FullName;
            teacher.Position = newTeacher.Position;

            Context.Update(teacher);
            await Context.SaveChangesAsync();
        }

        public async void Delete(object entity)
        {
            Teacher teacher = entity as Teacher;
            ArgumentNullException.ThrowIfNull(teacher);

            Context.Remove(teacher);
            await Context.SaveChangesAsync();
        }

        public void InsertRandom(int amount)
        {
            Random rnd = new Random();
            for(int i = 0; i < amount; i++)
            {
                Context.Add(new Teacher()
                {
                    FullName = RandomString(rnd.Next(8,13), rnd),
                    Position = (Position)rnd.Next(5)
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
            Teacher teacher = entity as Teacher;
            ArgumentNullException.ThrowIfNull(teacher);

            if (string.IsNullOrEmpty(teacher.FullName))
                throw new ArgumentException("Full name was not provided");
        }

        public IEnumerable Search(object searchParams)
        {
            Teacher teacher = searchParams as Teacher;
            ArgumentNullException.ThrowIfNull(teacher);

            var query = (IQueryable<Teacher>)Context.Teachers;

            if (!string.IsNullOrEmpty(teacher.FullName))
            {
                query = query.Where(t => t.FullName == teacher.FullName);
            }
            query.Where(t => t.Position == teacher.Position);

            return query.ToArray();
        }

        public TeacherAnalyseResult Analyse()
        {
            Context.Teachers.Include(t => t.Subjects);
            var subjectsCount = Context.Teachers.Select(t => (double)t.Subjects.Count()).ToArray();
            return new TeacherAnalyseResult()
            {
                TeacherCount = Context.Teachers.Count(),
                AverageSubjectsCount = Statistics.Mean(subjectsCount),
                StandardDeviationSubjectsCount = Statistics.StandardDeviation(subjectsCount),
                KurtosisSubjectsCount = Statistics.Kurtosis(subjectsCount),
            };
        }
    }
}
