using Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Helpers
{
    public static class FileHelper
    {
        public static string GetDirectoryName(DirectoriesEnum dir)
        {
            return Enum.GetName(typeof(DirectoriesEnum), dir);
        }
        public static async Task<string> UploadFile(IFormFile file, string subDirectory = "")
        {
            if (file == null) return null;
            bool hasSubDirectory = !string.IsNullOrWhiteSpace(subDirectory);
            string uniqueFileName;
            string filePath;
            if (file.Length < 0) throw new NullReferenceException();

            string[] allowedFileTypes = { "image/jpeg", "image/png", "application/pdf" };
            string[] allowedFileExtensions = { ".jpeg", ".png", ".pdf", ".jpg" };

            // Generate a unique file name to avoid naming conflicts
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string fileExtension = Path.GetExtension(file.FileName);
            uniqueFileName = $"{DateTime.Now.Ticks}{fileExtension}";

            // Filter file according to its Extension
            if (allowedFileExtensions.Contains(fileExtension.ToLower()))
            {
                // Set the path where the file will be stored
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                if (hasSubDirectory)
                {
                    uploadsFolder = Path.Combine(uploadsFolder, subDirectory);
                }
                filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Create the directory if it doesn't exist
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Save the file to the specified path
                using var fileStream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(fileStream);
            }
            return hasSubDirectory ? $"{subDirectory}/{uniqueFileName}" : uniqueFileName;

        }
    }
}
