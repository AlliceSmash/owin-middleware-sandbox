using Owin;

namespace testkatana
{
    public static class AppBuilderExtensions
    {

        public static void UseMyMiddleWare(this IAppBuilder app, string greetingOption)
        {
            app.Use<MyMiddlewareComponent>(greetingOption);
        }

        public static void UseMyOtherMiddleWare(this IAppBuilder app)
        {
            app.Use<MyOtherMiddlewareComponent>();
        }
    }
}
