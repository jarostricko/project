using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolProject.Startup))]
namespace SchoolProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
