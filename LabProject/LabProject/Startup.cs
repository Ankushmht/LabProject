using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LabProject.Startup))]
namespace LabProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
