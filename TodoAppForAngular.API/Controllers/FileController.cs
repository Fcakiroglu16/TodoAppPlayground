using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace TodoAppForAngular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileProvider _fileProvider;

        public FileController(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile? photo, CancellationToken cancellationToken)
        {
            if (photo is not { Length: > 0 }) return BadRequest("hata");
            var root = _fileProvider.GetDirectoryContents("wwwroot");
            var picturesDirectory = root.First(x => x.IsDirectory && x is { Exists: true, Name: "files" });

            var path = Path.Combine(picturesDirectory.PhysicalPath, photo.FileName);

            await using var stream = new FileStream(path, FileMode.Create);
            await photo.CopyToAsync(stream, cancellationToken);

            var returnPath = photo.FileName;

            return Created(string.Empty, null);
        }
    }
}
