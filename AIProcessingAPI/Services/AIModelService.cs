using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class AIModelService
{
    private readonly HttpClient _httpClient;
    private const string CloudRunUrl = "https://8f0b-88-255-218-254.ngrok-free.app/predict"; // Google Cloud Run API URL

    public AIModelService(HttpClient httpClient)
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

            content.Add(imageContent, "file", fileName);

            using var response = await _httpClient.PostAsync(CloudRunUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                return $"Hata: {response.StatusCode}";
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse; // JSON formatındaki yanıtı döndür
        }
        catch (Exception ex)
        {
            return $"İç hata: {ex.Message}";
        }
    }
}
