using System;
using System.Collections.Generic;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> hashset = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                hashset.Add(Console.ReadLine());
            }
            foreach (var hs in hashset)
            {
                Console.WriteLine(hs);
            }
        }
    }
}
