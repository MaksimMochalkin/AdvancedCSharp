namespace AdvancedCSharpLibraries
{
    using System;
    using System.IO;
    using System.Linq;

    public class FileSystemVisitor
    {
        private readonly string _path;
        private readonly FiltrationOptions _option;

        private Action<string, FiltrationOptions> SearchRuner { get; set; }

        private delegate void SearchInformation(string message);

        private event SearchInformation Notify;

        public FileSystemVisitor(string path, FiltrationOptions option)
        {
            _path = path;
            _option = option;
        }

        public void RunSearch()
        {
            Notify += GetProgressInformation;
            Notify?.Invoke("Search start...");
            SearchRuner += Search;
            Notify?.Invoke("Search result: ");
            SearchRuner?.Invoke(_path, _option);
            Notify?.Invoke("Search finish");
        }

        public void Search(string path, FiltrationOptions option)
        {
            if(string.IsNullOrEmpty(path))
            {

            }

            var filterOption = GetFiltrationOption((int)option);
            var directories = GetAllDirectory(path).ToList();
            var files = GetAllFiles(path, filterOption).ToList();

            Notify?.Invoke($"Directories: {Environment.NewLine}");

            foreach (var directory in directories)
            {

                Notify?.Invoke(directory);

            }
            
            Notify?.Invoke($"Files: {Environment.NewLine}");
            foreach (var file in files)
            {
                Notify?.Invoke(file);
            }
        }

        public string[] GetAllDirectory(string path)
        {
            string[] ReultSearch = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            return ReultSearch;
        }

        public string[] GetAllFiles(string path, string pattern)
        {
            string[] ReultSearch = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
            return ReultSearch;
        }

        public string GetFiltrationOption(int filtrationOptions)
        {
            switch (filtrationOptions)
            {
                case (int)FiltrationOptions.AllFiles:
                    return "*";
                case (int)FiltrationOptions.DOC:
                    return "*.docx";
                case (int)FiltrationOptions.XLSX:
                    return "*.xlsx";
                case (int)FiltrationOptions.TXT:
                    return "*.txt";
                default:
                    throw new ArgumentException("Passed value does not exist");

            }
        }

        private void GetProgressInformation(string message)
        {
            Console.WriteLine(message);
        }
    }
}
