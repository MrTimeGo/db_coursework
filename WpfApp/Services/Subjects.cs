using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WpfApp.Models;

namespace WpfApp.Services
{
    public class Subjects : ICUDService
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

        public async void Update(object entity)
        {
            Subject subject = entity as Subject;
            ArgumentNullException.ThrowIfNull(subject);

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
    }
}
