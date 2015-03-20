using MakeYourMeal.SignalR;
using Microsoft.AspNet.SignalR;
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

			//map SignalR
			//var idProvider = new CustomUserIdProvider();
			//GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);
	        app.MapSignalR();
        }
    }
}
