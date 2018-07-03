using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using bsa2018_DataStructures.Models;

namespace bsa2018_DataStructures
{
    class Program
    {
        public static void Main(string[] args)
        {
            LoadData load = new LoadData();
            List<User> users = load.LoadAsync().Result;
            Console.WriteLine("Downloading page...");
            Console.ReadLine();
        }
    }
}
