using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyResume
{
    public class LearningList
    {
        public IEnumerable<LearningResumeElement> TrainingData { get; set; }

        public DateTime TrainingStartDate { get; set; }
        public DateTime TrainingEndDate { get; set; }
    }
}
