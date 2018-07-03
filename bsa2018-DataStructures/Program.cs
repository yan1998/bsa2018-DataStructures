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
            SecondQuery(1);
            Console.ReadLine();
        }

        public static void FirstQuery(int idUser)
        {
            int count = (from user in users
                         where user.Id == idUser
                         select user.Posts).Count();
            Console.WriteLine($"Count of posts = {count}");
        }

        public static void SecondQuery(int idUser)
        {
            var comments = users.Where(u => u.Id == idUser)
                .SelectMany(u => u.Posts)
                .Where(p => p.Body.Length < 50)
                .SelectMany(p=>p.Comments);
            foreach (var comment in comments)
                Console.WriteLine(comment);
        }
    }
}
