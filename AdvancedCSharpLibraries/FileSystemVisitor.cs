namespace AdvancedCSharpLibraries
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class FileSystemVisitor
    {
        private readonly string _path;

        public delegate List<(string fileName, string folderName)> FiltrationEventHandler(List<(string fileName, string folderName)> filesAndFolders);
        private event FiltrationEventHandler _filtrationEvent;

        private delegate void StartOrFinishAction(string message);
        private event StartOrFinishAction _startOrFinishEvent;

        public FileSystemVisitor(string path, FiltrationEventHandler eventHandler)
        {
            _path = path;
            _filtrationEvent = eventHandler;
        }

        public List<(string fileName, string folderName)> GetFilesAndFoldersWithoutFiltration()
        {
            if (_filtrationEvent != null)
            {
                _startOrFinishEvent += GenerateMessage;
                _startOrFinishEvent.Invoke("Start working");
                var filesAndFolders = GetFilesAndFolders();
                foreach (var item in filesAndFolders)
                {
                    Console.WriteLine(item);
                }
                _startOrFinishEvent.Invoke("Finish working");
                return filesAndFolders;

            }
            else
            {
                _startOrFinishEvent += GenerateMessage;
                _startOrFinishEvent.Invoke("Filtration function not found");
                return null;
            }


        }

        public List<(string fileName, string folderName)> GetFilesAndFoldersWithFiltration()
        {
            if (_filtrationEvent != null)
            {
                _startOrFinishEvent += GenerateMessage;
                _startOrFinishEvent.Invoke("Start filtration");
                var filesAndFolders = GetFilesAndFolders();
                var result = _filtrationEvent.Invoke(filesAndFolders);
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
                _startOrFinishEvent.Invoke("Finish filtration");
                return filesAndFolders;

            }
            else
            {
                _startOrFinishEvent += GenerateMessage;
                _startOrFinishEvent.Invoke("Filtration function not found");
                return null;
            }
        }

        private List<(string fileName, string folderName)> GetFilesAndFolders()
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
        }

        private void GenerateMessage(string message)
        {
            Console.WriteLine(message);
        }
        

    }
}
