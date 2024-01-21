namespace WebApplication1.Helpers
{
    public static class FileUpload
    {
        public static async Task<bool> IsValidSize(this IFormFile file, int size=5000)
            =>file.Length<=size;
        public static async Task<bool> IsValidType(this IFormFile file, string contentType = "image")
            => file.ContentType.Contains(contentType);

        public static async Task<string> SaveImage(this IFormFile file, string path)
        {
            string extension = Path.GetExtension(file.FileName);
            string filename = Path.GetFileNameWithoutExtension(file.FileName);
            if (filename.Length > 2)
            {
                filename=filename.Substring(filename.Length - 2);
            }
            filename= Path.Combine( path, filename+Path.GetRandomFileName()+extension);
            using (FileStream fs = File.Create(Path.Combine(PathConstants.RootPath, filename)))
            {
                await file.CopyToAsync(fs);
            }
            return filename;
        }
    }
}
