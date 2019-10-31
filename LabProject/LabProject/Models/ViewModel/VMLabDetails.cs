using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Models.ViewModel
{
    public class VMLabDetails
    {
        public int LabId { get; set; }
        public string LabName { get; set; }
        public string LabOwnerName { get; set; }
        public string Email { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public byte[] Add3 { get; set; }
        public Nullable<int> City { get; set; }
        public IEnumerable<State> State { get; set; }
        public string About { get; set; }
        public string ContactNumber { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }

      
    }
}