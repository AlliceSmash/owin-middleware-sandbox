using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace testkatana
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseMyMiddleWare("This is the new greeting for MyMiddleWare");
            app.UseMyOtherMiddleWare();
        }
    }
}
