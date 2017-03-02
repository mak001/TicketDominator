using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicketDominator.Startup))]
namespace TicketDominator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
