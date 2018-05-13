using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HungryMinds.WebSite.Models
{
    public class CourseModel
    {
      
            public int Id { get; set; }
            public string Name { get; set; }

        public CourseModel() { }
            public CourseModel(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }
    }


