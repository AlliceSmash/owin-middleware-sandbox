using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace NotSoRealAuthentication
{
    public static class AppBuilderExtensions
    {
        public static void UseNotRealAuthentication(this IAppBuilder app)
        {
            app.Use<NotRealAuthentication>();
        }
    }
}
