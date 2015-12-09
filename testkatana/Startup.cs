using Owin;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NotSoRealAuthentication;
using PlainLogging;
using MyMiddleware;
using System.Web.Http;

namespace testkatana
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNotRealLogging();
        //    app.UseNotRealAuthentication();
            //var middlewareOptions = new MyMiddlewareConfigOptions("Hello", "Santa");
            //middlewareOptions.IncludeDate = true;
            //app.UseMyMiddleware(middlewareOptions);

            var webApiConfiguration = ConfigureWebApi();
            app.UseWebApi(webApiConfiguration);
         }

        private HttpConfiguration ConfigureWebApi()
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            config.Formatters.JsonFormatter.SerializerSettings = new Newtonsoft.Json.JsonSerializerSettings();
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            return config;
        }
    }
}
