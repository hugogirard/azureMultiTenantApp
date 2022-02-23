using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace daemon_console;

public class AuthenticationConfig
{
    public string Instance { get; set; } = "https://login.microsoftonline.com/{0}";

    public string Tenant { get; set; }

    public string ClientId { get; set; }

    public string ClientSecret { get; set; }

    public string WeatherApiAddress { get; set; }

    public string WeatherApiScopes { get; set; }

    public string Authority
    {
        get
        {
            return String.Format(CultureInfo.InvariantCulture, Instance, Tenant);
        }
    }

    public static AuthenticationConfig ReadFromJsonFile(string path)
    {
        IConfigurationRoot Configuration;

        var builder = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(path);

        Configuration = builder.Build();
        return Configuration.Get<AuthenticationConfig>();
    }
}