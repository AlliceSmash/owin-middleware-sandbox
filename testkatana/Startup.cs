using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace testkatana
{
    using Microsoft.Owin;
    using System.IO;
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var middleware = new Func<AppFunc, AppFunc>(MyMiddleWare);
            var secondMiddleware = new Func<AppFunc, AppFunc>(MyOtherMiddleWare);

            app.Use(middleware);
            app.Use(secondMiddleware);
        }

        public AppFunc MyMiddleWare(AppFunc next)
        {
            AppFunc appFunc = async (IDictionary<string, object> environment) =>
            {
                IOwinContext context = new OwinContext(environment);
                await context.Response.WriteAsync("<h1>Hello from my first middleware</h1>");
                await next.Invoke(environment);
                await context.Response.WriteAsync("<h2>after invoking second middleware, say hi from first middleware </h1>");
             };
            return appFunc;
        }

        public AppFunc MyOtherMiddleWare(AppFunc next)
        {
            AppFunc appFunc = async (IDictionary<string, object> environment) =>
            {
                IOwinContext context = new OwinContext(environment);
                await context.Response.WriteAsync("<h1>Hello from my second middleware</h1>");
                await next.Invoke(environment);
            };
            return appFunc;
        }
    }
}
