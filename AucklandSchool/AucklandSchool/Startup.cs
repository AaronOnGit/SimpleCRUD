using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AucklandSchool.Startup))]
namespace AucklandSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
