using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GreetingWebsiteV2
{
    public class WebsiteHoster
    {
        private readonly TextGenerator _textGenerator = new TextGenerator();
        private readonly RequestTypeGetterInterface _requestTypeGetter;
        private readonly World _world = new World();


        public WebsiteHoster(RequestTypeGetterInterface requestTypeGetter)
        {
            _requestTypeGetter = requestTypeGetter;
        }
        
        public void Host(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .Configure(app =>
                {
                    app.Run(async context =>
                    {
                        var requestType = GetRequestType(context);
                        await DecideAction(context,requestType);
                    });
                })
                .Build()
                .Run();
        }

        private async Task DecideAction(HttpContext context, string requestType)
        {
            switch (requestType)
            {
                case "GET":
                    context.Response.StatusCode = 200;
                    await context.Response
                        .WriteAsync(_textGenerator.GetTextGET(_world));
                    break;
                case "POST":
                    context.Response.StatusCode = 200;
                    var postedData = context.Request.Form.Keys.First();
                    await context.Response
                        .WriteAsync(_textGenerator.GetTextPOST(postedData));
                    break;
                    
            }
            
        }

        private string GetRequestType(HttpContext context)
        {
            return _requestTypeGetter.GetRequest(context);
        }
    }
}