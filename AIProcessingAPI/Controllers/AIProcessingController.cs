using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AIProcessingController : ControllerBase
{
    private readonly AIModelService _aiModelService;

    public AIProcessingController(AIModelService aiModelService)
    {
        _aiModelService = aiModelService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("Resim seçilmedi.");
        }

        try
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            var result = await _aiModelService.ProcessImageAsync(memoryStream, file.FileName);

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"İç hata: {ex.Message}");
        }
    }
}
