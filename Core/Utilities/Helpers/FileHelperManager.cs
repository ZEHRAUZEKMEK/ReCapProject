using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelperManager:IFileHelper
    {
        public string Upload(List<IFormFile> file, string root)
        {
            StringBuilder builder = new StringBuilder();
            

            if (file.Count > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                foreach (var item in file)
                {
                    var extension = Path.GetExtension(item.FileName);
                    string guid = Guid.NewGuid().ToString();
                    var filePath = guid + extension;

                    builder.Append(filePath + ";");
                    using FileStream fileStream = File.Create(root + filePath);
                    item.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return builder.ToString();
        }
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }


        public string Update(List<IFormFile> file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

    }
}
