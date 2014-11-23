using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureStorageCalc.Startup))]
namespace AzureStorageCalc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
