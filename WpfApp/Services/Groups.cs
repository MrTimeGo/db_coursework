using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Services
{
    public class Groups : IService
    {
        public UniversityContext Context { get; set; }

        public Groups(UniversityContext context)
        {
            this.Context = context;
        }

        public void Insert(object entity)
        {
            Group group = entity as Group;
            ArgumentNullException.ThrowIfNull(group);

            Context.Groups.Add(group);
            Context.SaveChanges();
        }

        public async void Update(object entity, object newEntity)
        {
            Group group = entity as Group;
            Group newGroup = newEntity as Group;
            ArgumentNullException.ThrowIfNull(group);
            ArgumentNullException.ThrowIfNull(newGroup);

            group.Code = newGroup.Code;
            group.StartEducation = newGroup.StartEducation;
            group.EndEducation = newGroup.EndEducation;

            Context.Groups.Update(group);
            await Context.SaveChangesAsync();
        }

        public async void Delete(object entity)
        {
            Group group = entity as Group;
            ArgumentNullException.ThrowIfNull(group);

            Context.Groups.Remove(group);
            await Context.SaveChangesAsync();
        }

        public void InsertRandom(int amount)
        {
            Random rnd = new Random();

            for (int i = 0; i < amount; i++)
            {
                DateTime start = new DateTime(rnd.Next(2010, 2022), 09, 01);
                DateTime end = new DateTime(start.Year + 4, 05, 31);
                Context.Add(new Group()
                {
                    Code = RandomString(2, rnd).ToUpper() + "-" + rnd.Next(10, 100),
                    StartEducation = start,
                    EndEducation = end
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
            Group group = entity as Group;
            ArgumentNullException.ThrowIfNull(group);

            var regex = new System.Text.RegularExpressions.Regex(@"^[A-Z]{2}-[0-9]{2}$");
            if (!regex.IsMatch(group.Code))
                throw new ArgumentException("Code was provided wrong");
            if (group.StartEducation >= group.EndEducation)
                throw new ArgumentException("Start and end education dates were provided wrong");
        }

        public IEnumerable Search(object searchParams)
        {
            Group group = searchParams as Group;
            ArgumentNullException.ThrowIfNull(group);

            var query = (IQueryable<Group>)Context.Groups;

            if (!string.IsNullOrEmpty(group.Code))
            {
                query = query.Where(g => g.Code == group.Code);
            }
            if (group.StartEducation != DateTime.MinValue && group.StartEducation != default)
            {
                query = query.Where(g => g.StartEducation == group.StartEducation);
            }
            if (group.EndEducation != DateTime.MinValue && group.EndEducation != default)
            {
                query = query.Where(g => g.EndEducation == group.EndEducation);
            }

            return query.ToArray();
        }

        public List<GroupAnalyseResult> Analyse()
        {
            Context.Groups.Include(g => g.Students).ThenInclude(s => s.Grades).ThenInclude(g => g.Test);

            return Context.Groups
                .Select(g => new GroupAnalyseResult()
                {
                    GroupCode = g.Code,
                    AverageScore = g.Students.Any() ?  g.Students.Average(
                    s => s.Grades.Any() ? s.Grades.Average(g => g.Score / (decimal)g.Test.MaxScore) : 0 )  : 0
                }).OrderBy(o => o.AverageScore).ToList();
        }
    }
}
