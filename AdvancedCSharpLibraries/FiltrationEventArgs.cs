namespace AdvancedCSharpLibraries
{
    using System;

    public class FiltrationEventArgs : EventArgs
    {
        public string FiltrationPattern { get; set; }

        public FiltrationEventArgs(string pattern)
        {
            FiltrationPattern = pattern;
        }
        
    }
}
