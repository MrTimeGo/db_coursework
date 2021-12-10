using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WpfApp.Models;

namespace WpfApp.Services
{
    public class Tests : ICUDService
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

        public async void Update(object entity)
        {
            Test test = entity as Test;
            ArgumentNullException.ThrowIfNull(test);

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
    }
}
