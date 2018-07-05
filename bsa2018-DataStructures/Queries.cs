using System;
using System.Collections.Generic;
using System.Linq;
using bsa2018_DataStructures.Models;

namespace bsa2018_DataStructures
{
    public  class Queries
    {
        private List<User> users;

        public Queries(List<User> users)
        {
            this.users = users;
        }

        public void FirstQuery(int idUser)
        {
            var counts = users.Where(u => u.Id == idUser)
                .First()
                .Posts.Select(p => (
                    Post: p,
                    CountComments: p.Comments.Count
                )).ToList();

            Console.WriteLine("Result: ");
            foreach (var count in counts)
                Console.WriteLine($"{count.Post.Title} - {count.CountComments}");
        }

        public void SecondQuery(int idUser)
        {
            var comments = users.Where(u => u.Id == idUser)
                .SelectMany(u => u.Posts)
                .SelectMany(p => p.Comments)
                .Where(c => c.Body.Length < 50);
            foreach (var comment in comments)
                Console.WriteLine(comment);
        }

        public void ThirdQuery(int idUser)
        {
            var toDos = users.Where(u => u.Id == idUser)
                .SelectMany(u => u.ToDos)
                .Where(td => td.IsComplete)
                .Select(td => ( Id : td.Id, Name : td.Name ));
            foreach (var toDo in toDos)
                Console.WriteLine(toDo.Id + " - " + toDo.Name);
        }

        public void FourthQuery()
        {
            var result = users.OrderBy(u => u.Name)
                .Select(u => { u.ToDos = u.ToDos.OrderByDescending(td => td.Name.Length).ToList(); return u; })
                .ToList();
            foreach (var user in result)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine(user);
                foreach (var toDo in user.ToDos)
                    Console.WriteLine('\t'+toDo.Name);
            }
        }

        public void FifthQuery(int idUser)
        {
            var result = users.Where(u => u.Id == idUser)
                .Select(u => (
                    User: u,
                    LastPost: u.Posts.OrderByDescending(c => c.CreateAt).FirstOrDefault(),
                    CommentsCount: 0,
                    CountUncompletedTodos: u.ToDos.Where(td => !td.IsComplete).Count(),
                    MaxCommentPost: u.Posts.Where(p => p.Body.Length > 80).OrderByDescending(p => p.Comments).FirstOrDefault(),
                    MaxLikesPost: u.Posts.OrderByDescending(p => p.Likes).FirstOrDefault()
                )).FirstOrDefault();
            result.CommentsCount = result.LastPost.Comments.Count;

            Console.WriteLine($"{result.User} {result.LastPost} {result.CommentsCount}");
        }

        public void SixthQuery(int idPost)
        {
            var result = users.SelectMany(u => u.Posts)
                .Where(p => p.Id == idPost)
                .Select(p => (
                    Post: p,
                    LongestComment: p.Comments.OrderByDescending(c => c.Body).FirstOrDefault(),
                    LikestComment: p.Comments.OrderByDescending(c => c.Likes).FirstOrDefault(),
                    Count: p.Comments.Where(c => c.Likes == 0 || c.Body.Length < 80).Count()
                )).FirstOrDefault();

            Console.WriteLine($"{result.Post}\n{result.LongestComment}\n{result.LikestComment}");
        }
    }
}
