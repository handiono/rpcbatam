//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rpc.Web
{
    using System;
    using System.Collections.Generic;
    
    public partial class ManHour
    {
        public int ManHoursID { get; set; }
        public string EmployeeID { get; set; }
        public string WorkID { get; set; }
        public int ManHours { get; set; }
        public System.DateTime Date { get; set; }
        public string LeaderID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Work Work { get; set; }
    }
}
