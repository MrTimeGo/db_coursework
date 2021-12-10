using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WpfApp.Models;

namespace WpfApp.Services
{
    public class Grades : ICUDService
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

        public async void Update(object entity)
        {
            Grade grade = entity as Grade;
            ArgumentNullException.ThrowIfNull(grade);

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
    }
}
