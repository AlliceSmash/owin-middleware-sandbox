using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlainLogging
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class NotRealLogging
    {
        AppFunc _next;
        public NotRealLogging(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            await _next.Invoke(environment);
            IOwinContext context = new OwinContext(environment);
            Console.WriteLine("URI: {0} Status Code: {1} ReasonPhrase: {2}",
            context.Request.Uri, context.Response.StatusCode, context.Response.ReasonPhrase);
        }
    }
}
