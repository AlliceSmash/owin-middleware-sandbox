using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using testkatana.Middlewares;

namespace testkatana
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseLoggingMiddleWare();
            app.UseAuthenticationMiddleWare();
            var middlewareOptions = new MyMiddlewareConfigOptions("Hello", "Santa");
            middlewareOptions.IncludeDate = true;
            app.UseMyMiddleWare(middlewareOptions);
            app.UseMyOtherMiddleWare();
            
        }
    }
}
