namespace NeoDefenderEngine
{
    public class InitializeStatus
    {
        public string Message { get; }
        public int Progress { get; }
        public int ProgressMax { get; }
        public int ProgressPercentage => (int)((double)Progress / ProgressMax * 100 + .5);

        public InitializeStatus(string message, int progress, int max)
        {
            Message = message;
            Progress = progress;
            ProgressMax = max;
        }
    }
}