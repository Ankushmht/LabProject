using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LabProject.Models.ViewModel
{
    public class VMLabDetails
    {
        public int LabId { get; set; }

        [Required(ErrorMessage ="Lab Name is Required")]
        public string LabName { get; set; }

        [Required(ErrorMessage = "Lab Owner Name is Required")]
        public string LabOwnerName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact Number is Required")]
        public string ContactNumber { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string About { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string Add3 { get; set; }

        public string CityName { get; set; }

        public string StateName { get; set; }

        public IEnumerable<State> State { get; set; }
        public IEnumerable<City> City { get; set; }



    }
}