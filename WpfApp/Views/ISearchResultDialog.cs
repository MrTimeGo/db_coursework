using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp.Views
{
    public interface ISearchResultDialog
    {
        public bool? ShowDialog();
        public ListView Table { get; set; }
    }
}
