using System.Globalization;

namespace ConsumerApi.Models;

public class AuthencationConfig 
{
    public string Instance { get;set; } = "https://login.microsoftonline.com/{0}";

    public string Tenant { get; set; }

    public string ClientId { get; set; }

    public string ClientSecret { get; set; }

    public string WeatherApiAddress { get; set; }

    public string WeatherApiScopes { get; set; }

    public string Authority 
    { 
        get 
        {
            return String.Format(CultureInfo.InvariantCulture,Instance,Tenant);
        }
    }
}