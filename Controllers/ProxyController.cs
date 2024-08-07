using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

[Route("api/proxy")]
[ApiController]
public class ProxyController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public ProxyController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet("latest")]
    public async Task<IActionResult> GetLatest()
    {
        var apiKey = "YOUR_API_KEY"; // Replace with your actual API key
        var requestUri = $"https://v6.exchangerate-api.com/v6/{apiKey}/latest/USD";
        var response = await _httpClient.GetAsync(requestUri);
        var content = await response.Content.ReadAsStringAsync();
        return Content(content, "application/json");
    }

    [HttpGet("codes")]
    public async Task<IActionResult> GetCodes()
    {
        var apiKey = "YOUR_API_KEY"; // Replace with your actual API key
        var requestUri = $"https://v6.exchangerate-api.com/v6/{apiKey}/codes";
        var response = await _httpClient.GetAsync(requestUri);
        var content = await response.Content.ReadAsStringAsync();
        return Content(content, "application/json");
    }

    [HttpGet("flag-url")]
    public async Task<IActionResult> GetFlagUrl([FromQuery] string currencyCode)
    {
        var apiKey = "YOUR_API_KEY"; // Replace with your actual API key
        var requestUri = $"https://v6.exchangerate-api.com/v6/{apiKey}/enriched/{currencyCode}";
        var response = await _httpClient.GetAsync(requestUri);
        var content = await response.Content.ReadAsStringAsync();
        return Content(content, "application/json");
    }
}
