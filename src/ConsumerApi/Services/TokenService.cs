namespace ConsumerApi.Services;
using Microsoft.Identity.Client;

public class TokenService : ITokenService
{
    private readonly IConfidentialClientApplication _confidentialClientApp;

    public TokenService(IConfiguration configuration)
    {
        var authenticationConfig = configuration.Get<AuthencationConfig>();

        _confidentialClientApp = ConfidentialClientApplicationBuilder.Create(authenticationConfig.ClientId)
                                .WithClientSecret(authenticationConfig.ClientSecret)
                                .WithAuthority(new Uri(authenticationConfig.Authority))
                                .Build();
    }

    public async Task<string> GetBearerTokenAsync(string[] scopes)
    {        
        // Normally you should cache the token and not get a new one if not needed
        // this is for demo purpose
        var result = await _confidentialClientApp.AcquireTokenForClient(scopes).ExecuteAsync();

        return result.AccessToken;
    }
}