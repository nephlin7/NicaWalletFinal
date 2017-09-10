using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NicaWallet.Startup))]
namespace NicaWallet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
