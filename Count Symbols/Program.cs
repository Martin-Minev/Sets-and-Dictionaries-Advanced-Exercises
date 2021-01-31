using System;
using System.Collections.Generic;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text =Console.ReadLine();
            SortedDictionary<char, int> occurancies = new SortedDictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (!occurancies.ContainsKey(text[i]))
                {
                    occurancies.Add(text[i], 1);
                }
                else
                {
                    occurancies[text[i]]++;
                }
            }
            foreach (var item in occurancies)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
