using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(GameHub.Areas.Identity.IdentityHostingStartup))]
namespace GameHub.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}