using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmNew.Model
{
    public class MyImageCat
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }

        public byte[] Data { get; set; }

        public MyImageCat(string filePath)
        {
            FilePath = filePath;
        }
        [JsonConstructor]
        public MyImageCat(string filePath, string fileName, byte[] data)
        {
            FilePath = filePath;
            FileName = fileName;
            Data = data;
        }
    }
}
