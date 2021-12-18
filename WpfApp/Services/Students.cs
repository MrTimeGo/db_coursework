using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using WpfApp.Models;

namespace WpfApp.Services
{
    public class Students : IService
    {
        public UniversityContext Context { get; set; }

        public Students(UniversityContext context)
        {
            Context = context;
        }

        public void Insert(object entity)
        {
            Student student = entity as Student;
            ArgumentNullException.ThrowIfNull(student);

            Context.Add(student);
            Context.SaveChanges();
        }

        public async void Update(object entity, object newEntity)
        {
            Student student = entity as Student;
            Student newStudent = newEntity as Student;
            ArgumentNullException.ThrowIfNull(student);
            ArgumentNullException.ThrowIfNull(newStudent);

            student.FullName = newStudent.FullName;
            student.BirthDate = newStudent.BirthDate;
            student.GroupId = newStudent.GroupId;
            student.Group = Context.Groups.First(g => g.Id == student.GroupId);

            Context.Update(student);
            await Context.SaveChangesAsync();
        }

        public async void Delete(object entity)
        {
            Student student = entity as Student;
            ArgumentNullException.ThrowIfNull(student);

            Context.Remove(student);
            await Context.SaveChangesAsync();
        }

        public void InsertRandom(int amount)
        {
            Random rnd = new Random();
            int[] groupdIds = Context.Groups.Select(g => g.Id).ToArray();

            if (groupdIds.Length == 0)
            {
                throw new Exception("Can't generate students, there is no groups");
            }

            DateTime birthFrom = new DateTime(1990, 01, 01);
            DateTime birthTo = new DateTime(2005, 12, 31);

            TimeSpan diff = birthTo - birthFrom;

            for (int i = 0; i < amount; i++)
            {
                Context.Students.Add(new Student()
                {
                    FullName = RandomString(rnd.Next(8, 13), rnd),
                    BirthDate = birthFrom.AddDays(rnd.Next(diff.Days)),
                    GroupId = groupdIds[rnd.Next(groupdIds.Length)]
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
            Student student = entity as Student;
            ArgumentNullException.ThrowIfNull(student);

            if (student.GroupId == 0)
                throw new ArgumentException("Group was not provided");
            if (string.IsNullOrEmpty(student.FullName))
                throw new ArgumentException("Full name was not provided");
            if (student.BirthDate > DateTime.Now)
                throw new ArgumentException("Birth date was provided wrong");
        }

        public IEnumerable Search(object searchParams)
        {
            Student student = searchParams as Student;
            ArgumentNullException.ThrowIfNull(student);

            var query = (IQueryable<Student>)Context.Students;

            if (!string.IsNullOrEmpty(student.FullName))
            {
                query = query.Where(s => s.FullName == student.FullName);
            }
            if (student.BirthDate != DateTime.MinValue || student.BirthDate != default)
            {
                query = query.Where(s => s.BirthDate >= student.BirthDate);
            }
            if (student.GroupId > 0)
            {
                query = query.Where(s => s.GroupId == student.GroupId);
            }


            return query.OrderBy(s => s.FullName).ToArray();
        }
    }
}
