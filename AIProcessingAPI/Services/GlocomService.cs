using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class GlocomService
{
    private readonly HttpClient _httpClient;
    private const string FlaskApiUrl = "https://8f0b-88-255-218-254.ngrok-free.app/predict"; // Flask ngrok linki

    public GlocomService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> ProcessImageAsync(Stream imageStream, string fileName)
    {
        try
        {
            using var content = new MultipartFormDataContent();

            var imageContent = new StreamContent(imageStream);
            imageContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

            // 🟢 Flask tarafı "image" key'ini bekliyor
            content.Add(imageContent, "image", fileName);

            using var response = await _httpClient.PostAsync(FlaskApiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                return $"Hata: {response.StatusCode}";
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }
        catch (Exception ex)
        {
            return $"İç hata: {ex.Message}";
        }
    }
}
