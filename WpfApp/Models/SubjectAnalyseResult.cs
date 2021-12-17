using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class SubjectAnalyseResult
    {
        public int SubjectsCount { get; set; }
        public double AverageTestsCount { get; set; }
        public double StandardDeviationTestsCount { get; set; }
        public double KurtosisTestsCount { get; set; }
    }
}
