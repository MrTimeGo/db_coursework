using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WpfApp.Models;

namespace WpfApp.Services
{
    public class Tests : IService
    {
        public UniversityContext Context { get; set; }

        public Tests(UniversityContext context)
        {
            this.Context = context;
        }

        public void Insert(object entity)
        {
            Test test = entity as Test;
            ArgumentNullException.ThrowIfNull(test);

            Context.Add(entity);
            Context.SaveChanges();
        }

        public async void Update(object entity, object newEntity)
        {
            Test test = entity as Test;
            Test newTest = newEntity as Test;
            ArgumentNullException.ThrowIfNull(test);
            ArgumentNullException.ThrowIfNull(newTest);

            test.Theme = newTest.Theme;
            test.MaxScore = newTest.MaxScore;
            test.SubjectId = newTest.SubjectId;
            test.Subject = Context.Subjects.First(s => s.Id == test.SubjectId);
            test.EventDate = newTest.EventDate;

            Context.Update(test);
            await Context.SaveChangesAsync();
        }

        public async void Delete(object entity)
        {
            Test test = entity as Test;
            ArgumentNullException.ThrowIfNull(test);

            Context.Remove(test);
            await Context.SaveChangesAsync();
        }

        public void InsertRandom(int amount)
        {
            Random rnd = new Random();

            int[] subjectIds = Context.Subjects.Select(s => s.Id).ToArray();

            if (subjectIds.Length == 0)
            {
                throw new Exception("Can't generate tests, there is no subjects");
            }

            for (int i = 0; i < amount; i++)
            {
                Context.Tests.Add(new Test()
                {
                    Theme = RandomString(rnd.Next(4, 11), rnd),
                    MaxScore = rnd.Next(1, 26),
                    SubjectId = subjectIds[rnd.Next(subjectIds.Length)],
                    EventDate = new DateTime(2016, 09, 01).AddDays(rnd.Next(365 * 5)),
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
            Test test = entity as Test;
            ArgumentNullException.ThrowIfNull(test);

            if (string.IsNullOrEmpty(test.Theme))
                throw new ArgumentException("Theme was not provided");
            if (test.MaxScore <= 0)
                throw new ArgumentException("Max score was provided wrong");
            if (test.SubjectId == 0)
                throw new ArgumentException("Subject was not provided");
        }

        public IEnumerable Search(object searchParams)
        {
            Test test = searchParams as Test;
            ArgumentNullException.ThrowIfNull(test);

            var query = (IQueryable<Test>)Context.Tests;

            if (!string.IsNullOrEmpty(test.Theme))
            {
                query = query.Where(t => t.Theme == test.Theme);
            }
            if (test.MaxScore > 0)
            {
                query = query.Where(t => t.MaxScore == test.MaxScore);
            }
            if (test.SubjectId > 0)
            {
                query = query.Where(t => t.SubjectId == test.SubjectId);
            }

            return query.ToArray();
        }
    }
}
