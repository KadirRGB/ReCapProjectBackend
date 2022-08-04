using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers.GuidHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
  
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            return Upload(file, root);
        }


        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0) //file!=null
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }


                string extension = Path.GetExtension(file.FileName);
                string filePath = Guid.NewGuid().ToString() + extension;
               /* string guid = GuidHelper.CreateGuid();
                string filePath = guid + extension; */  //GuidHelper class could be used also


                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;

                }
            }
            return null;
        }
    }
}