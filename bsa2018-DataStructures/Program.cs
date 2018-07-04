using System;
using System.Linq;
using System.Collections.Generic;
using bsa2018_DataStructures.Models;

namespace bsa2018_DataStructures
{
    class Program
    {
        private static Queries queries;

        public static void Main(string[] args)
        {
            LoadData load = new LoadData();
            queries = new Queries(load.LoadAsync().Result);
            Menu();
        }

        public static void Menu()
        {
            char x;
            do
            {
                Console.WriteLine("\nEnter a number(1-6)\n0-exit");
                x = Console.ReadKey().KeyChar;
                Console.Clear();
                switch (x)
                {
                    case '1': Console.Write("Enter a userId: ");
                        int userId = int.Parse(Console.ReadLine());
                        queries.FirstQuery(userId);
                        break;
                    case '2':
                        Console.Write("Enter a userId: ");
                        userId = int.Parse(Console.ReadLine());
                        queries.SecondQuery(userId);
                        break;
                    case '3':
                        Console.Write("Enter a userId: ");
                        userId = int.Parse(Console.ReadLine());
                        queries.ThirdQuery(userId);
                        break;
                    case '4':
                        queries.FourthQuery();
                        break;
                    case '5':
                        Console.Write("Enter a userId: ");
                        userId = int.Parse(Console.ReadLine());
                        queries.FifthQuery(userId);
                        break;
                    case '6':
                        Console.Write("Enter a postId: ");
                        int postId = int.Parse(Console.ReadLine());
                        queries.SixthQuery(postId);
                        break;
                    default:
                        Console.WriteLine("Incorrect number!");
                        break;
                }
            } while (x!='0');
        }

    }
}
