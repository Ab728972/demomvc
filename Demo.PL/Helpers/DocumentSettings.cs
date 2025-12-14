namespace Demo.PL.Helpers
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            // 1. Get Folder Path
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName);

            // 2. Create Folder if not exists (Optional but good practice)
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            // 3. Get File Name (Unique)
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            // 4. Get File Path
            string filePath = Path.Combine(folderPath, fileName);

            // 5. Save File
            using var fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);

            return fileName;
        }

        public static void DeleteFile(string fileName, string folderName)
        {
            if (fileName is not null)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", folderName, fileName);
                if (File.Exists(filePath)) File.Delete(filePath);
            }
        }
    }
}