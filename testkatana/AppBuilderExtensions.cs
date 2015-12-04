using Owin;
using testkatana.Middlewares;

namespace testkatana
{
    public static class AppBuilderExtensions
    {

        public static void UseMyMiddleWare(this IAppBuilder app,
            MyMiddlewareConfigOptions myMiddlewareConfigOptions)
        {
            app.Use<MyMiddlewareComponent>(myMiddlewareConfigOptions);
        }

        public static void UseMyOtherMiddleWare(this IAppBuilder app)
        {
            app.Use<MyOtherMiddlewareComponent>();
        }
        public static void UseLoggingMiddleWare(this IAppBuilder app)
        {
            app.Use<LoggingComponent>();
        }

        public static void UseAuthenticationMiddleWare(this IAppBuilder app)
        {
            app.Use<AuthenticationComponent>();
        }
    }
}
