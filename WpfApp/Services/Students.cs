using System;
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
    public class Students : ICUDService
    {
        public UniversityContext Context { get; }

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

        public async void Update(object entity)
        {
            Student student = entity as Student;
            ArgumentNullException.ThrowIfNull(student);

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
    }
}
