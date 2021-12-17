using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Services
{
    public interface IService
    {
        public UniversityContext Context { get; set; }

        public void Insert(object entity);
        public void Update(object entity, object newEntity);
        public void Delete(object entity);
        public void InsertRandom(int amount);
        public void ValidateModel(object entity);
        public IEnumerable Search(object searchParams);
    }
}
