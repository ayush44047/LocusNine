using LocusNine_DAL;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository r = new Repository();
            var users = r.GetUsers();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("UserId\tUserName");
            Console.WriteLine("---------------------------------");
            foreach (var user in users)
            {
                Console.WriteLine("{0}\t\t{1}", user.Roleid, user.Fullname);
            }

        }
    }
}
