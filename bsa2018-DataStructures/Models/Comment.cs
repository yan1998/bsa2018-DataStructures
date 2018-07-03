using System;
using System.Collections.Generic;
using System.Text;

namespace bsa2018_DataStructures.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int Likes { get; set; }

        public override string ToString()
        {
            return $"{Body} - {CreateAt.ToString("d")}\nLikes - {Likes}";
        }
    }
}
