using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin;

namespace NotSoRealAuthentication
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class NotRealAuthentication
    {
        AppFunc _next;
        public NotRealAuthentication(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            IOwinContext context = new OwinContext(environment);
            var isAuthorized = context.Request.QueryString.Value == "santa";
            if (isAuthorized)
            {
                context.Response.StatusCode = 200;
                context.Response.ReasonPhrase = "OK";
                await _next.Invoke(environment);
            }
            else
            {
                context.Response.StatusCode = 401;
                context.Response.ReasonPhrase = "Not Authorized";
                await context.Response.WriteAsync(string.Format("<h1>Error {0} -- {1}</h1>",
                    context.Response.StatusCode,
                    context.Response.ReasonPhrase));
            }
        }

    }
}
