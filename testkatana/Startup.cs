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
            app.Use<MyMiddlewareComponent>();
            app.Use<MyOtherMiddlewareComponent>();
        }

       
    }
}
