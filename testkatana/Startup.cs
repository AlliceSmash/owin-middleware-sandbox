using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace testkatana
{
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
                // Do something with the incoming request:
                var response = environment["owin.ResponseBody"] as Stream;
                using (var writer = new StreamWriter(response))
                {
                    await writer.WriteAsync("<h1>Hello from My First Middleware</h1>");
                }
                // Call the next Middleware in the chain:
                await next.Invoke(environment);
                using (var writer = new StreamWriter(response))
                {
                    await writer.WriteAsync("<h1>After second middleware, say hello from My First Middleware</h1>");
                }
            };
            return appFunc;
        }

        public AppFunc MyOtherMiddleWare(AppFunc next)
        {
            AppFunc appFunc = async (IDictionary<string, object> environment) =>
            {
                // Do something with the incoming request:
                var response = environment["owin.ResponseBody"] as Stream;
                using (var writer = new StreamWriter(response))
                {
                    await writer.WriteAsync("<h1>Hello from My Second Middleware</h1>");
                }
                // Call the next Middleware in the chain:
                await next.Invoke(environment);
            };
            return appFunc;
        }
    }
}
