using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
namespace ATDapi.Controllers;


[ApiController]
public class FileController : ControllerBase
{
    [HttpPost]
    [Route("FileController/PostU")]
    public async Task<IActionResult> PostU(MyFile upload)
    {
        if (upload == null || upload.File.Length == 0) return BadRequest("No se proporcionó ningún archivo.");

        var path = Path.Combine(
                    "C:\\Users\\hilet.HILET\\cine\\public\\",upload.File.FileName
                );

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await upload.File.CopyToAsync(stream);
        }

        return Ok(new { file = "\\img_peliculas\\img_1\\" + upload.File.FileName });
    }

}