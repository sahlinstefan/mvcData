//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcData.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentCourse
    {
        public int StudCourse_Id { get; set; }
        public int Student_Id { get; set; }
        public int Course_Id { get; set; }
    
        public virtual Courses Courses { get; set; }
        public virtual Students Students { get; set; }
    }
}
