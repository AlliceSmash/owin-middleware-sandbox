using Owin;

namespace testkatana
{
    public static class AppBuilderExtensions
    {

        public static void UseMyMiddleWare(this IAppBuilder app)
        {
            app.Use<MyMiddlewareComponent>();
        }

        public static void UseMyOtherMiddleWare(this IAppBuilder app)
        {
            app.Use<MyOtherMiddlewareComponent>();
        }
    }
}
