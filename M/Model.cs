using System.Linq;
using System.IO;
using System;

namespace PhotoBackUper.M
{
    class Model
    {
        static bool IsJpg(FileInfo File)
        {
            return File.Extension.ToLower().Contains("jpg") || File.Extension.ToLower().Contains("jpeg");
        }
        public static void CheckFilesInfo(string Path, Action<FilesInfo> CallBack)
        {
            if (Directory.Exists(Path))
            {
                FilesInfo Result = new FilesInfo(Directory.GetFiles(Path).Select(p => new FileInfo(p)).Where(p => IsJpg(p)).ToArray());
                CallBack.Invoke(Result);
            }
            else
            {
                CallBack.Invoke(null);
            }
        }
        public static void MoveFiles(string from, string to, DateTime start, DateTime end)
        {
            if (Directory.Exists(from))
            {
                if (!Directory.Exists(to))
                {
                    string Path = "";
                    foreach (string Item in to.Split(new string[] { "/" }, StringSplitOptions.None))
                    {
                        Path += Item + "/";
                        if (!Directory.Exists(Path))
                            Directory.CreateDirectory(Path);
                    }
                }
                FileInfo[] FileInfos = Directory.GetFiles(from).Select(p => new FileInfo(p)).Where(f => f.LastWriteTime > start && f.LastWriteTime < end).ToArray();
                foreach (var file in FileInfos)
                    File.WriteAllBytes(to + "/" + file.Name, File.ReadAllBytes(file.FullName));
            }
        }
    }
}