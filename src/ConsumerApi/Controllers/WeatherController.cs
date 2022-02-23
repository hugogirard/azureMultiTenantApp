using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ConsumerApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase 
{
    private readonly IHttpClientFactory _httpClientFactory;

    private readonly AuthencationConfig _authenticationConfig;
    private readonly ITokenService _tokenService;

    public WeatherController(IHttpClientFactory httpClientFactory,
                             ITokenService tokenService,
                             IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _authenticationConfig = configuration.Get<AuthencationConfig>();
        _tokenService = tokenService;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        string accessToken = await _tokenService.GetBearerTokenAsync(new string[] { _authenticationConfig.WeatherApiScopes });

        var http = _httpClientFactory.CreateClient();
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",accessToken);

        var weathers = await http.GetFromJsonAsync<IEnumerable<WeatherForecast>>(_authenticationConfig.WeatherApiAddress);

        return weathers;
    }

}