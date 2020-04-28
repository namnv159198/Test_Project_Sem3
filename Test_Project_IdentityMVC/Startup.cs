using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test_Project_IdentityMVC.Startup))]
namespace Test_Project_IdentityMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
