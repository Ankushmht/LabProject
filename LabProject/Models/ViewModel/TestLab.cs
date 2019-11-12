using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Models.ViewModel
{
    public class TestLab
    {
       
        public int testLabId { get; set; }
        public IEnumerable<LabDetail> labId { get; set; }
        public IEnumerable<Test> testId { get; set; }
        public decimal? Price { get; set; }

        public Test tests { get; set; }
        public LabDetail Labs { get; set; }

    }
}