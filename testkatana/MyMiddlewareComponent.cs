using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace testkatana
{
    using Microsoft.Owin;
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class MyMiddlewareComponent
    {
        AppFunc _next;
        public MyMiddlewareComponent(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            IOwinContext context = new OwinContext(environment);
            await context.Response.WriteAsync("<h1>Hello from my first middleware</h1>");
            await _next.Invoke(environment);
            await context.Response.WriteAsync("<h4>Say hi again after you invoke second middleware</h4>");
        }
    }

    public class MyOtherMiddlewareComponent
    {
        AppFunc _next;
        public MyOtherMiddlewareComponent(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            IOwinContext context = new OwinContext(environment);
            await context.Response.WriteAsync("<h1>Hello from my second middleware</h1>");
            await _next.Invoke(environment);
         }
    }
}
