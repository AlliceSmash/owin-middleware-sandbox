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
            var middlewareOptions = new MyMiddlewareConfigOptions("Hello", "Sabrina");
            middlewareOptions.IncludeDate = true;
            app.UseMyMiddleWare(middlewareOptions);
            app.UseMyOtherMiddleWare();
        }
    }
}
