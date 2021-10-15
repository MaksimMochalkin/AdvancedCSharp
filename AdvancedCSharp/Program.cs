namespace AdvancedCSharp
{
    using AdvancedCSharpLibraries;
   
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Users\\Maxim_Mochalkin\\source\\repos\\For course\\Part3\\AdvancedCSharp\\AdvancedCSharpLibrariesTests\\TestsData\\";
            var visitor = new FileSystemVisitor(path, FiltrationOptions.TXT);
            visitor.RunSearch();
        }
    }
}
