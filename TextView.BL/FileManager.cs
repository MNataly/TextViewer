using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextView.BL
{
    public interface IFileManager
    {
        bool IsExist(string filePath);
        string GetText(string filePath);
        string GetText(string filePath, Encoding encoding);
        void SaveText(string filePath, string filetext);
    }

    public class FileManager : IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.UTF8;
        public bool IsExist(string filePath)
        {
            bool isExist = File.Exists(filePath);
            return isExist;
        }

        public string GetText(string filePath)
        {
            return GetText(filePath, _defaultEncoding);
        }


        public string GetText(string filePath, Encoding encoding)
        {
            string text = File.ReadAllText(filePath, encoding);
            return text;
        }

        public void SaveText(string filePath, string filetext)
        {
            File.WriteAllText(filePath, filetext, _defaultEncoding);
        }
    }
}
