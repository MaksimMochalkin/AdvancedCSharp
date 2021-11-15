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
            var del = new FiltrationEventHandler(list =>
            {
                var result = list.Where(item => item.fileName.Contains(".xlsx"))
                .Select(item => item).ToList();

                return result;
            });

            var FSV = new FileSystemVisitor(path, del);
            var result = FSV.GetFilesAndFoldersWithoutFiltration();
            var filterResult = FSV.GetFilesAndFoldersWithFiltration();
           
        }

        
    }
}
