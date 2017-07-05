using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume
{
    public class JobsList
    {
        public IEnumerable<ProResumeElement> JobsData { get; set; }

        public DateTime JobsStartDate { get; set; }
        public DateTime JobsEndDate { get; set; }
    }
}
