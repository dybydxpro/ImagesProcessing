using ImagesProcessing.Models;
using ImagesProcessing.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ImagesProcessing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<ActionResult<List<string>>> ConvertImages([FromForm]Image images)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<string> names = new List<string>();
                    //foreach (var imageSet in images)
                    //{
                        foreach (var img in images.ImgFile)
                        {
                            string imageName = Convert.ToString(_imageRepository.SaveImage(img));

                        if (images.Eff1 == true)
                        {
                            bool s1 = _imageRepository.Effect01(img, imageName);
                        }

                        //if (imageSet.Eff2 == true)
                        //{
                        //    bool s1 = _imageRepository.Effect02(img, imageName);
                        //}

                        //if (imageSet.Eff3 == true)
                        //{
                        //    bool s1 = _imageRepository.Effect03(img, imageName);
                        //}
                        names.Add(imageName);
                        }
                    //}

                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            else
            {
                return BadRequest("Validation Faild!");
            }

            return Ok();
        }
    }
}
