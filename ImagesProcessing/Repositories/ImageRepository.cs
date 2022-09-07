using Microsoft.Extensions.Hosting;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;

namespace ImagesProcessing.Repositories
{
    public class ImageRepository: IImageRepository
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageRepository(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public async Task<string> SaveImage(IFormFile imageFile)
        {
            try
            {
                using (SHA1 sha1Hash = SHA1.Create())
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(DateTime.Now.ToString("yymmssfff"));
                    byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                    string imageName = hash + Path.GetExtension(imageFile.FileName);
                    var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Resources/Upload", imageName);
                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                    return imageName;
                }
                
            }
            catch (Exception e)
            {
                return "Null";
            }
}

        public bool Effect01(IFormFile file, string name)
        {


            return true;

            //try
            //{
            //}
            //catch (Exception e)
            //{
            //    return false;
            //}
        }

        public bool Effect02(IFormFile image, string name)
        {
            return true;

            try
            {
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Effect03(IFormFile image, string name)
        {
            return true;

            try
            {
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
