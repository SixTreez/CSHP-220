using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HungryMinds.Repository;


namespace HungryMinds.Business
{
    public interface IUserManager
    {
        UserModel LogIn(string email, string password);
        UserModel Register(string email, string password);

        List<ICollection<HungryMinds.LearningDatabase.Class>> GetEnrolledCourses(string email);
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CourseModel> Classes { get; }
    }

    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserModel LogIn(string email, string password)
        {
            var user = userRepository.LogIn(email, password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.Id, Name = user.Name };
        }

        public UserModel Register(string email, string password)
        {
            var user = userRepository.Register(email, password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.Id, Name = user.Name };
        }

        public List<ICollection<HungryMinds.LearningDatabase.Class>> GetEnrolledCourses(string email) {
            var enrolledCourses = userRepository.GetClasses(email);
            return enrolledCourses;

        
        }

    }
}
