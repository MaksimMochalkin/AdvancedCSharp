using System;

namespace AdvancedCSharpLibrariesTests
{
    using AdvancedCSharpLibraries;
    using NUnit.Framework;
    using Shouldly;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using static AdvancedCSharpLibraries.FileSystemVisitor;

    [TestFixture]
    public class FileSystemVisitorTests
    {
        // change value the _path line
        readonly string _path = "C:\\Users\\Maxim_Mochalkin\\source\\repos\\For course\\Part3\\AdvancedCSharp\\AdvancedCSharpLibrariesTests\\TestsData\\";

        [Test]
        public void ShouldReturnAllDirectoriesAndFiels()
        {
            var del = new FiltrationEventHandler(() =>
            {
                string[] files = Directory.GetFiles(_path, "*", SearchOption.AllDirectories);
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
            result.ShouldNotBeNull();
        }

        
    }
}