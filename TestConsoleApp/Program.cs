using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var dir = System.IO.Path.GetDirectoryName(location);
            var parent = System.IO.Directory.GetParent(dir);

            Console.WriteLine($"Location: {location}");
            Console.WriteLine($"Directory name: {dir}");
            Console.WriteLine($"Parent: {parent}");

            // Delay
            Console.ReadKey();
        }
    }
}
