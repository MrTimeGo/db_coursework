using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Services;

namespace WpfApp.Views
{
    public interface IDialog
    {
        public object Result { get; set; }
        public IService Service { get; set; }
        public bool DoValidate { get; set; }

        public bool? ShowDialog();
    }
}
