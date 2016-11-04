using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ORCAExpertServices.Startup))]
namespace ORCAExpertServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
