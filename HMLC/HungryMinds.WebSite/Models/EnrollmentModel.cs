using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryMinds.WebSite.Models
{
    public class EnrollmentModel
    {


        public int Course { get; set; }
        public int Student { get; set; }


        public virtual EnrollmentModel CourseName { get; set; }
        public virtual EnrollmentModel StudentName { get; set; }


    }
}