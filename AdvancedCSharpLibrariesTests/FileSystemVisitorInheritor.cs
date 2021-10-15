namespace AdvancedCSharpLibrariesTests
{
    using AdvancedCSharpLibraries;

    internal class FileSystemVisitorInheritor : FileSystemVisitor
    {
        public FileSystemVisitorInheritor(string path, FiltrationOptions option) : base(path, option)
        {
        }
    }
}
