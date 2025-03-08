using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace foodyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public UploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var imageUrl = $"/images/{fileName}"; // URL de l'image

            return Ok(new { ImageUrl = imageUrl });
        }
    }
}
