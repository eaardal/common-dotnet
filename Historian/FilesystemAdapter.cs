using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Historian
{
    public interface IFilesystem
    {
        IEnumerable<string> ReadAllLines(string path);
        string ReadAllText(string path);
        void WriteAllLines(string path, IEnumerable<string> lines);
        bool FileExists(string path);
        bool DirectoryExists(string path);
        FileInfo[] GetFiles(string directoryPath);
        string GetFileByPartialName(string directoryPath, string partialFileName);
    }

    public class Filesystem : IFilesystem
    {
        private static readonly Encoding Encoding = Encoding.UTF8;

        public IEnumerable<string> ReadAllLines(string path)
        {
            return File.ReadAllLines(path, Encoding);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path, Encoding);
        }

        public void WriteAllLines(string path, IEnumerable<string> lines)
        {
            File.WriteAllLines(path, lines, Encoding);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public FileInfo[] GetFiles(string directoryPath)
        {
            return Directory.GetFiles(directoryPath).Select(file => new FileInfo(file)).ToArray();
        }

        public string GetFileByPartialName(string directoryPath, string partialFileName)
        {
            return Directory.GetFiles(directoryPath).FirstOrDefault(file => file.Contains(partialFileName));
        }
    }
}
