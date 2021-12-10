using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Services
{
    public interface ICUDService
    {
        public void Insert(object entity);
        public void Update(object entity);
        public void Delete(object entity);
    }
}
