using Owin;

namespace PlainLogging
{
    public static class AppBuilderExtensions
    {
        public static void UseNotRealLogging(this IAppBuilder app)
        {
            app.Use<NotRealLogging>();
        }
    }
}
