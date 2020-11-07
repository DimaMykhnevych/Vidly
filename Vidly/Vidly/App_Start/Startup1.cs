using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Vidly.Models;

[assembly: OwinStartup(typeof(Vidly.App_Start.Startup1))]

namespace Vidly.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new VidlyDbContext());


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
            });
        }
    }
}
