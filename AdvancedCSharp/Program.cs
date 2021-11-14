namespace AdvancedCSharp
{
    using AdvancedCSharpLibraries;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using static AdvancedCSharpLibraries.FileSystemVisitor;

    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Users\\Maxim_Mochalkin\\source\\repos\\For course\\Part3\\AdvancedCSharp\\AdvancedCSharpLibrariesTests\\TestsData\\";

            var del = new FiltrationEventHandler(() => 
            {
                string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                var result = new List<(string fileName, string folderName)>();
                foreach (var file in files)
                {
                    var fi = new FileInfo(file);
                    var name = fi.Name;
                    var dirname = fi.Directory.Name;
                    result.Add((name, dirname));
                }

                return result;
            });
            
            var FSV = new FileSystemVisitor(del);
            var result = FSV.LaunchEvent();
            
        }

        
    }
}
