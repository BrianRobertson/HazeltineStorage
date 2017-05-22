using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HazeltineStorage.Startup))]
namespace HazeltineStorage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
