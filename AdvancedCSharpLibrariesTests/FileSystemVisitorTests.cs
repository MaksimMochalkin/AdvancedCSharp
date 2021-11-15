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
            var del = new FiltrationEventHandler(list =>
            {
                var result = list.Where(item => item.fileName.Contains(".xlsx"))
                .Select(item => item).ToList();

                return result;
            });

            var FSV = new FileSystemVisitor(_path, del);
            var result = FSV.GetFilesAndFoldersWithoutFiltration();
            var filterResult = FSV.GetFilesAndFoldersWithFiltration();
            result.ShouldNotBeNull();
            filterResult.ShouldNotBeEmpty();
        }

        
    }
}