using System;
using System.Linq;
using System.Collections.Generic;
using bsa2018_DataStructures.Models;

namespace bsa2018_DataStructures
{
    class Program
    {
        private static List<User> users;
        public static void Main(string[] args)
        {
            LoadData load = new LoadData();
            users = load.LoadAsync().Result;
            FirstQuery(1);

            Console.ReadLine();
        }

        public static void FirstQuery(int idUser)
        {
            int count = (from user in users
                         where user.Id == idUser
                         select user.Posts).Count();
            Console.WriteLine($"Count of posts = {count}");
        }
    }
}
