using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GreetingWebsiteV2
{
    public class WebsiteHoster
    {
        public static void Host(string[] args)
        {
            TextGenerator textGenerator = new TextGenerator();
            WebHost.CreateDefaultBuilder(args)
                .Configure(app =>
                {
                    app.Run(async context =>
                    {
                        await context.Response
                            .WriteAsync(textGenerator.GetText());
                    });
                })
                .Build()
                .Run();
        }
    }
}