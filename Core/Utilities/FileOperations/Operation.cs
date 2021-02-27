using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileOperations
{
    public class Operation
    {
        public static bool WriteImageFile(IFormFile Imagefile, string filePath, string newImageName)
        {
            try
            {
                var fullPath = Path.Combine(filePath, newImageName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    Imagefile.CopyTo(stream);
                }
                return true;
            }
            catch { }
            return false;
        }

        public static bool DeleteImageFile(string filePath, string fileName)
        {
            string fullPath = Path.Combine(filePath, fileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                return true;
            }
            return false;
        }
    }
}
