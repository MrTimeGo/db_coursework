using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Model
{
    public class Group : ModelBase
    {
        private int id;
        private string code;
        private DateTime startEducation;
        private DateTime endEducation;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Code
        {
            get => code;
            set
            {
                code = value;
                OnPropertyChanged(Code);
            }
        }

        public DateTime StartEducation
        {
            get => startEducation;
            set
            {
                startEducation = value;
                OnPropertyChanged(nameof(StartEducation));
            }
        }

        public DateTime EndEducation
        {
            get => endEducation;
            set
            {
                endEducation = value;
                OnPropertyChanged(nameof(EndEducation));
            }
        }

        public Group(int id, string code, DateTime startEducation, DateTime endEducation)
        {
            this.id = id;
            this.code = code;
            this.startEducation = startEducation;
            this.endEducation = endEducation;
        }
    }
}
