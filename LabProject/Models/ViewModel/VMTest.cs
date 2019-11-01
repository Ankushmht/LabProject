using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LabProject.Models.ViewModel
{
    public class VMTest
    {
        public int TestId { get; set; }
        [Required]
        public string TestName { get; set; }
        [AllowHtml]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Report Duration must be numeric")]
        public int? TestReportDuration { get; set; }
        public string PreRequisite { get; set; }

        public IEnumerable<LabDetail> LabDetails { get; set; }
        public IEnumerable<Test> Tests { get; set; }

    }
}