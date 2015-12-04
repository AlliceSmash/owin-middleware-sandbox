using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotSoRealAuthentication;
using PlainLogging;
using MyMiddleware;

namespace testkatana
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNotRealLogging();
            app.UseNotRealAuthentication();
            var middlewareOptions = new MyMiddlewareConfigOptions("Hello", "Santa");
            middlewareOptions.IncludeDate = true;
            app.UseMyMiddleware(middlewareOptions);
            app.UseMyOtherMiddleware();
        }
    }
}
