using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureCloudServices.Startup))]
namespace AzureCloudServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
