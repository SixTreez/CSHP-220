using HungryMinds.Repsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryMinds.Repository
{
    public interface ICourseRepository
    {
        CourseModel[] Courses { get; }
        CourseModel Course(int courseId);
    }
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CourseRepository : ICourseRepository
    {
        public CourseModel[] Courses
        {
            get
            {
                return DatabaseAccessor.Instance.Classes
                                               .Select(t => new CourseModel { Id = t.ClassId, Name = t.ClassName })
                                               .ToArray();
                
            }
        }

        public CourseModel Course(int courseId)
        {
            var category = DatabaseAccessor.Instance.Classes
                                                   .Where(t => t.ClassId == courseId)
                                                   .Select(t => new CourseModel { Id = t.ClassId, Name = t.ClassName })
                                                   .First();
            return category;
        }
    }

}
