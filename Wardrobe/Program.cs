using System;
using System.Linq;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine()
                    .Split(new[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = inputData[0];
                string[] allClothes = inputData.Skip(1).ToArray();
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                Dictionary<string, int> colorValue = wardrobe[color];
                foreach (var item in allClothes)
                {
                    if (!colorValue.ContainsKey(item))
                    {
                        colorValue.Add(item, 1);
                    }
                    else
                    {
                        colorValue[item]++;
                    }
                }
            }
            string[] searchedData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            // foreach (KeyValuePair<string, Dictionary<string, int>> colorData in wardrobe)
            foreach ((string color, Dictionary<string, int> colorData) in wardrobe)
            {
                Console.WriteLine($"{color} clothes:");
                foreach ((string clothing, int count) in colorData)
                {
                    if (searchedData[0] == color && searchedData[1]==clothing)
                    {
                        Console.WriteLine($"* {clothing} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothing} - {count}");
                    }
                }
            }
        }
    }
}
