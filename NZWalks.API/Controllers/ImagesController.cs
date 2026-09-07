using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO.Images;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController : ControllerBase
{
    private readonly IImageRepository _imageRepository;

    public ImagesController(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto ImageRequest)
    {
        ValidateFileUpload(ImageRequest);

        if (ModelState.IsValid)
        {
            var imageDomainModel = new Image()
            {
                File = ImageRequest.File,
                FileName = ImageRequest.FileName,
                FileSizeInBytes = ImageRequest.File.Length,
                FileExtension = Path.GetExtension(ImageRequest.File.FileName),
                FileDescription = ImageRequest.FileDescription
            };

            await _imageRepository.Upload(imageDomainModel);

            return Ok(imageDomainModel);
        }

        return BadRequest(ModelState);
    }

    private void ValidateFileUpload(ImageUploadRequestDto request)
    {
        string[] allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

        if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
        {
            ModelState.AddModelError("File", "Invalid file format");
        }

        if (request.File.Length > 10485760)
        {
            ModelState.AddModelError("File", "File exceed 10MB");
        }
    }
}