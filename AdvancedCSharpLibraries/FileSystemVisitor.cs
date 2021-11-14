namespace AdvancedCSharpLibraries
{
    using System;
    using System.Collections.Generic;
    
    public class FileSystemVisitor
    {

        public delegate List<(string fileName, string folderName)> FiltrationEventHandler();
        private event FiltrationEventHandler _filtrationEvent;

        private delegate void StartOrFinishAction(string message);
        private event StartOrFinishAction _startOrFinishEvent;

        public FileSystemVisitor(FiltrationEventHandler eventHandler)
        {
            _filtrationEvent = eventHandler;
        }

        public List<(string fileName, string folderName)> LaunchEvent()
        {
            if (_filtrationEvent != null)
            {
                _startOrFinishEvent += GenerateMessage;
                _startOrFinishEvent.Invoke("Start working");
                var result = _filtrationEvent.Invoke();
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
                _startOrFinishEvent.Invoke("Finish working");
                return result;

            }
            else
            {
                _startOrFinishEvent += GenerateMessage;
                _startOrFinishEvent.Invoke("Filtration function not found");
                return null;
            }


        }

        private void GenerateMessage(string message)
        {
            Console.WriteLine(message);
        }
        

    }
}
