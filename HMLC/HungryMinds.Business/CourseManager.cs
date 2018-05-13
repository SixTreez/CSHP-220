using HungryMinds.Repository;
using System.Linq;

namespace HungryMinds.Business
{
    public interface ICourseManager
    {
        CourseModel[] Courses { get; }
        CourseModel Course(int courseId);
    }
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CourseModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepository courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public CourseModel[] Courses
        {
            get
            {
                return courseRepository.Courses
                                         .Select(t => new CourseModel(t.Id, t.Name))
                                         .ToArray();
            }
        }

        public CourseModel Course(int courseId)
        {
            var courseModel = courseRepository.Course(courseId);
            return new CourseModel(courseModel.Id, courseModel.Name);
        }

    }
}
