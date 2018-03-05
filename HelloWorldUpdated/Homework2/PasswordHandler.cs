using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework2.Models.Homework2;


namespace Homework2
{
    class PasswordHandler
    {

        public List<User> ProcessUsers()
        {
            var users = new List<User>();

            users.Add(new User { Name = "Dave", Password = "hello" });
            users.Add(new User { Name = "Steve", Password = "steve" });
            users.Add(new User { Name = "Lisa", Password = "hello" });

            //1.Delete the first User that has the password "hello". 
            users.Remove(users.FirstOrDefault(p => p.Password.ToLower() == "hello"));

            //2.Delete any passwords that are the lower-cased version of their Name. Do not just look for "steve".It has to be data - driven.Hint: Remove or RemoveAll
            var compareList = users.Where(x => x.Name.ToLower() == (x.Password.ToLower())).ToList();
            var res = compareList.Where(x => char.IsUpper(x.Name.ElementAt(0)) || char.IsLower(x.Password.ElementAt(0))).ToList();
            users.RemoveAll(u => res.Exists(r => r.Name == u.Name));

            //3.Display to the console, all the passwords that are "hello".
            var result = from user in users
                         where user.Password == "hello"
                         select user;        

            return result.ToList();
        }
    }
}
