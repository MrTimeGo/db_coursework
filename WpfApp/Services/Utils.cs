using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Services
{
    public static class Utils
    {
        public static T Cast<T>(object target, T example)
        {
            return (T)target;
        }
    }
}
