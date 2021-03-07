using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(KiipPazardzhik.Areas.Identity.IdentityHostingStartup))]

namespace KiipPazardzhik.Areas.Identity
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