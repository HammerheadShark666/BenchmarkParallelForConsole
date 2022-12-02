namespace BenchmarkParallelForConsole.Helper
{
    public static class FileHelper
    {
        private const string FileName = "organizations-10000-1";

        public static List<string> GetFiles(int NumberOfFiles)
        {
            List<string> files = new List<string>();
            for (int i = 0; i < NumberOfFiles; i++)
            {
                files.Add(FileName);
            }

            return files;
        }
    }
}
