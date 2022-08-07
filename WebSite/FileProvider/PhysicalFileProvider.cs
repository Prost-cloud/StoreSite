using System;
using System.IO;

namespace WebSite
{
    internal class PhysicalFileProvider : IFileProvider
    {
        private string DirectoryPath;

        public PhysicalFileProvider(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }

        public byte[] GetFileByPath(string Path)
        {
            return File.ReadAllBytes(Path);
        }

        public void TryWriteFile(byte[] FileData, string FullFileName)
        {
            FullFileName = FullFileName ?? throw new ArgumentNullException(nameof(FullFileName));
            FileData = FileData ?? throw new ArgumentNullException(nameof(FileData));

            File.WriteAllBytes(FullFileName, FileData);
        }
    }
}