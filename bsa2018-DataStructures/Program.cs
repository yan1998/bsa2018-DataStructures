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
            //FirstQuery(1);
            //SecondQuery(1);
            //ThirdQuery(27);
            FourthQuery();
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

        public static void ThirdQuery(int idUser)
        {
            var toDos = users.Where(u => u.Id == idUser)
                .SelectMany(u => u.ToDos)
                .Where(td => td.IsComplete)
                .Select(td=>new { Id=td.Id, Name=td.Name});
            foreach (var toDo in toDos)
                Console.WriteLine(toDo.Id+" - "+toDo.Name);
        }

        public static void FourthQuery()
        {
            var result = users.OrderBy(u => u.Name)
                .Select(u => { u.ToDos = u.ToDos.OrderByDescending(td => td.Name.Length).ToList(); return u; })
                .ToList();
            foreach (var user in result)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine(user);
                foreach (var toDo in user.ToDos)
                    Console.WriteLine(toDo);
            }          
        }
    }
}
