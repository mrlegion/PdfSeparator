using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Alexander\Desktop\AIPC 04.00\M7_92_AIPC_Chapter011_000_RU_04_00.PDF";

            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine($"Name: {fileInfo.Name}");
            Console.WriteLine($"Directory: {fileInfo.Directory}");

            Console.WriteLine();
            Console.WriteLine("Create new directory:");

            DirectoryInfo directoryInfo = fileInfo.Directory;

            if (directoryInfo != null)
            {
                Console.WriteLine(directoryInfo.FullName);
                
                DirectoryInfo di = new DirectoryInfo(Path.Combine(directoryInfo.FullName, Path.GetFileNameWithoutExtension(fileInfo.Name)));
                if (di.Exists)
                {
                    Console.WriteLine("директория существует, перезаписать");
                    var r = Console.ReadLine();

                    if (r.Contains("yes") || r.Contains("y"))
                        di.Create();
                    else
                    {
                        var nname = $"{Path.GetFileNameWithoutExtension(fileInfo.Name)}_{Path.GetRandomFileName()}";
                        directoryInfo.CreateSubdirectory(nname);
                    }

                }

            }


            // Delay
            Console.ReadKey();
        }
    }
}
