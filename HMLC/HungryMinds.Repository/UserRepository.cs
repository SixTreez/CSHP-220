using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HungryMinds.Repsitory;

namespace HungryMinds.Repository
{
    public interface IUserRepository
    {
        UserModel LogIn(string email, string password);
        UserModel Register(string email, string password);
        List<ICollection<LearningDatabase.Class>> GetClasses(string email);
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserRepository : IUserRepository
    {
        public UserModel LogIn(string name, string password)
        {
            var user = DatabaseAccessor.Instance.Users
                .FirstOrDefault(t => t.UserEmail.ToLower() == name.ToLower()
                                      && t.UserPassword == password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.UserId, Name = user.UserEmail};
        }

        public UserModel Register(string email, string password)
        {
            var user = DatabaseAccessor.Instance.Users
                    .Add(new HungryMinds.LearningDatabase.User { UserEmail = email, UserPassword = password });

            DatabaseAccessor.Instance.SaveChanges();

            return new UserModel { Id = user.UserId, Name = user.UserEmail };
        }

        public List<ICollection<LearningDatabase.Class>> GetClasses(string email) {

            var classes = DatabaseAccessor.Instance.Users.Select(t => t.Classes).ToList();
            return classes;
        }

        //public UserModel UserWithCourses(string userName) {

        //    //var existingStudent = DatabaseAccessor.Instance.Users.Include("Courses")
        //    //    .Where(s => s.UserEmail == userName);

        //    //return existingStudent;

        //}
    }
}
