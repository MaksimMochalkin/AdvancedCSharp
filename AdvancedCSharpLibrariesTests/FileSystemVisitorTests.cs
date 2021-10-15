using System;

namespace AdvancedCSharpLibrariesTests
{
    using AdvancedCSharpLibraries;
    using NUnit.Framework;
    using Shouldly;
    using System.Linq;

    [TestFixture]
    public class FileSystemVisitorTests
    {
        // change value the _path line
        readonly string _path = "C:\\Users\\Maxim_Mochalkin\\source\\repos\\For course\\Part3\\AdvancedCSharp\\AdvancedCSharpLibrariesTests\\TestsData\\";

        [Test]
        public void ShouldReturnAllDirectoriesAndFiels()
        {
            var fileSystemVisitor = new FileSystemVisitor(_path, FiltrationOptions.AllFiles);
            Assert.DoesNotThrow(() => fileSystemVisitor.RunSearch());
        }

        [Test]
        public void ShouldReturnAllDirectories()
        {
            var fileSystemVisitor = new FileSystemVisitor(_path, FiltrationOptions.AllFiles);
            var directories = fileSystemVisitor.GetAllDirectory(_path).ToList();

            directories.Count.ShouldBe(3);
        }

        [Test]
        public void ShouldReturnAllFiles()
        {
            var fileSystemVisitor = new FileSystemVisitor(_path, FiltrationOptions.AllFiles);
            var searchPattern = fileSystemVisitor.GetFiltrationOption((int)FiltrationOptions.AllFiles);
            var files = fileSystemVisitor.GetAllFiles(_path, searchPattern).ToList();

            files.Count.ShouldBe(12);
        }

        [Test]
        public void ShouldReturnSearchOption()
        {
            var fileSystemVisitor = new FileSystemVisitor(_path, FiltrationOptions.AllFiles);
            var searchPattern = fileSystemVisitor.GetFiltrationOption((int)FiltrationOptions.TXT);
            
            searchPattern.ShouldBe("*.txt");
        }

        [Test]
        public void ShouldThrowFiltrationOptionsException()
        {
            var fileSystemVisitor = new FileSystemVisitor(_path, FiltrationOptions.AllFiles);
            var searchPattern = fileSystemVisitor.GetFiltrationOption((int)FiltrationOptions.AllFiles);
            var exception = Assert.Throws<ArgumentException>(() => fileSystemVisitor.GetFiltrationOption(5));

            Assert.That(exception.Message, Is.SupersetOf("Passed value does not exist"));
        }
    }
}