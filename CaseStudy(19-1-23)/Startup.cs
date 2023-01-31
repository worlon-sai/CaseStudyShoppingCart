using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CaseStudy_19_1_23_.Startup))]
namespace CaseStudy_19_1_23_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
