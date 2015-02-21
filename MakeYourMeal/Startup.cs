using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MakeYourMeal.Startup))]
namespace MakeYourMeal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
