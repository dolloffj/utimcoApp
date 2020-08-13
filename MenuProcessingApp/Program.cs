using System;
using System.Collections.Generic;
using System.IO;
using MenuService.Models;
using MenuService.Services;

namespace MenuProcessingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;
            List<int> idSums = new List<int>();
            Console.WriteLine("Please provide a valid path for a file containing a JSON string representation of the menus array as specified in the problem prompt:");
            var path = Console.ReadLine();
            
            while (keepGoing)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        var Menus = Operations.GetMenuListFromFile(path);
                        foreach (MenuContainer m in Menus)
                        {
                            var sum = Operations.ComputeMenuIdSum(m.MenuObject);
                            idSums.Add(sum);
                        }
                        keepGoing = false;
                    }
                    else
                    {
                        Console.WriteLine("There was a problem with that file, please provide another path, " +
                            "or type END to quit");
                        path = Console.ReadLine();
                        if (path.Trim() == "END")
                        {
                            keepGoing = false;
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("Something went wrong, to try again, " +
                        "enter another path containing a valid JSON menu object file, otherwise type END to quit.");
                    path = Console.ReadLine();
                    if (path.Trim() == "END")
                    {
                        keepGoing = false;
                    }
                }
                
            }

            foreach (int sum in idSums)
            {
                Console.WriteLine(sum);
            }

            Console.ReadLine();
        }
    }
}
