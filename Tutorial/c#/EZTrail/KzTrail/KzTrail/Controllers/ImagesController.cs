using KzTrail.Models.Domain;
using KzTrail.Models.DTO;
using KzTrail.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KzTrail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        //POST: /api/images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)

        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {

                //conver DTO to Domain model

                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtention = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FildDescripion = request.FildDescripion,
                };



                // Use repository to upload image
                await imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);

            }

            return BadRequest(ModelState);

        }


        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtention = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtention.Contains(Path.GetExtension(request.File.FileName)))
            {

                ModelState.AddModelError("file", "Unsupported File Extention");
            }

            if (request.File.Length > 1048576)
            {
                ModelState.AddModelError("file", "File size is more that 10MB, Please upload a smaller file size!");
            }

        }
    }
}
