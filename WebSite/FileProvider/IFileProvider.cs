namespace WebSite
{
    internal interface IFileProvider
    {
        public byte[] GetFileByPath(string Path);
        public void TryWriteFile(byte[] FileData, string FullFileName);
    }
}