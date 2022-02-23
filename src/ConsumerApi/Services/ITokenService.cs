
namespace ConsumerApi.Services
{
    public interface ITokenService
    {
        Task<string> GetBearerTokenAsync(string[] scopes);
    }
}