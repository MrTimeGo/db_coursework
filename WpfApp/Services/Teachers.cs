using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Services
{
    public class Teachers : ICUDService
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

        public async void Update(object entity)
        {
            Teacher teacher = entity as Teacher;
            ArgumentNullException.ThrowIfNull(teacher);

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
    }
}
