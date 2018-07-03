using System;
using System.Collections.Generic;
using System.Text;

namespace bsa2018_DataStructures.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }

        public override string ToString()
        {
            return $"{Name} - {IsCompleted}\n{CreateAt.ToString("d")}";
        }
    }
}
