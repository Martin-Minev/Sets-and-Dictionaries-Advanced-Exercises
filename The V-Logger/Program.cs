using System;
using System.Linq;
using System.Collections.Generic;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, SortedSet<string>[]> asd = new Dictionary<string, SortedSet<string>[]>();
            //var userData = new[] { new SortedSet<string>(), new SortedSet<string>() };
            //asd.Add("User one", userData);

            Dictionary<string, Dictionary<string, SortedSet<string>>> app = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string commandInput = string.Empty;
            while ((commandInput = Console.ReadLine()) != "Statistics")
            {
                string[] commandData = commandInput.Split();
                string vloggerName = commandData[0];
                string command = commandData[1];
                if (command == "joined")
                {
                    if (!app.ContainsKey(vloggerName))
                    {
                        app.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        app[vloggerName].Add("following", new SortedSet<string>());
                        app[vloggerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string vloggerNameTwo = commandData[2];
                    if (app.ContainsKey(vloggerName) && app.ContainsKey(vloggerNameTwo) &&
                        vloggerName != vloggerNameTwo)
                    {
                        app[vloggerName]["following"].Add(vloggerNameTwo);
                        app[vloggerNameTwo]["followers"].Add(vloggerName);
                    }
                }
            }
            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedDataApp =
                                   app.OrderByDescending(kvp => kvp.Value["followers"].Count)
                                  .ThenBy(kvp => kvp.Value["following"].Count)
                                  .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs.");

            int counter = 0;
            foreach (KeyValuePair<string, Dictionary<string, SortedSet<string>>> item in sortedDataApp)
            {
                Console.WriteLine($"{++counter}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");
                if (counter == 1)
                {
                    foreach (string follower in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

            }
        }
    }
}
