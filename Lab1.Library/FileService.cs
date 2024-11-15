using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library
{
    public class FileService : IFileService
    {
        public string[] ReadInput(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            var content = File.ReadAllText(filePath).Split(", ");
            if (content.Length != 2)
                throw new FormatException("Invalid file format. Expected two coordinates separated by ', '.");

            return content;
        }

        public void WriteOutput(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }
}
