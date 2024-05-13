using System.IO;

namespace WowGame
{
    public static class FileUtility
    {
        public static void SafeWriteAllText(string savePath, string text)
        {
            File.WriteAllText(savePath, text);
        }
    }
}