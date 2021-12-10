using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WpfApp.Models;

namespace WpfApp.Services
{
    public class Groups : ICUDService
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

        public async void Update(object entity)
        {
            Group group = entity as Group;
            ArgumentNullException.ThrowIfNull(group);

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
    }
}
