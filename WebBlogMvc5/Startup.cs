using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBlogMvc5.Startup))]
namespace WebBlogMvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app); 
        }
    }
}
