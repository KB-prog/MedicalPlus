using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedicalApplication.Startup))]
namespace MedicalApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
