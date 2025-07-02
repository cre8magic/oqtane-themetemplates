using Microsoft.Extensions.DependencyInjection;

namespace [Owner].Theme.[Theme];

public class ThemeStartup : Oqtane.Services.IClientStartup
{
    /// <summary>
    /// Register Services which this theme needs.
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        // Register the MySettings helper
        services.AddTransient<OqtaneSettings>();
    }
}
