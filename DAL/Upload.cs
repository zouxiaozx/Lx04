using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.IO;
namespace DAL
{
   public class Upload
    {
        private Upload() { }
            private static Upload _instace = new Upload();
        public static Upload Instance
        {
            get
            {
                return _instace;
            }
        }
        public string UpImg(IFormFile file, string filename) {

            if (file == null || !file.ContentType.StartsWith("iamge"))
                return null;
            else {
                string ext = Path.GetExtension(file.FileName);
                filename = $"{filename}{ext}";
                using (FileStream fs = File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                return ext;
            }
        }
        
    }
}
