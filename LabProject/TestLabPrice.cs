//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestLabPrice
    {
        public int TestLabId { get; set; }
        public Nullable<int> LabId { get; set; }
        public Nullable<int> TestId { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Test Test { get; set; }
        public virtual LabDetail Labs { get; set; }
    }
}
