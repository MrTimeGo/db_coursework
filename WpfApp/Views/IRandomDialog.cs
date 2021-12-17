using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Views
{
    public  interface IRandomDialog
    {
        public int? Result { get; set; }
        public bool? ShowDialog();
    }
}
