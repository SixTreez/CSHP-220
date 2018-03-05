using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework2.Models.Homework2;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordHandler handler = new PasswordHandler();

            var nameAndPswd = handler.ProcessUsers();

            //Display to the console the remaining users with their Name and Password.
            foreach (var item in nameAndPswd) {
                Console.Write(item.Name + " " + item.Password);
            }
            Console.ReadLine();
        }
    }
}
