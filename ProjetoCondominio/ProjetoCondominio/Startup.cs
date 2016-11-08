using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoCondominio.Startup))]
namespace ProjetoCondominio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
