using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DatabaseProject.Startup))]
namespace DatabaseProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
