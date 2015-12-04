using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;
namespace MyMiddleware
{

     using AppFunc = Func<IDictionary<string, object>, Task>;

    public class MyMiddleware
    {
        AppFunc _next;
        MyMiddlewareConfigOptions _options;
        public MyMiddleware(AppFunc next, MyMiddlewareConfigOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            IOwinContext context = new OwinContext(environment);
            await context.Response.WriteAsync(string.Format("<h1>{0}</h1>",_options.GetGreeting()));
            await _next.Invoke(environment);

            IOwinContext newcontext = new OwinContext(environment);
            newcontext.Response.StatusCode = 200;
            newcontext.Response.ReasonPhrase = "OK";
            await newcontext.Response.WriteAsync("<h4>Say hi again after you invoke second middleware</h4>");
        }
    }

    public class MyOtherMiddleware
    {
        AppFunc _next;
        public MyOtherMiddleware(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            await _next.Invoke(environment);
            IOwinContext context = new OwinContext(environment);

            await context.Response.WriteAsync("<h1>Hello from my second middleware</h1>");
             context.Response.StatusCode = 200;
             context.Response.ReasonPhrase = "OKKK";

        }
    }
}
