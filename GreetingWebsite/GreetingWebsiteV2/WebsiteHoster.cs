using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            string data;
            var pathVal = context.Request.Path.Value;
            switch (requestType)
            {
                case "GET":
                    await GETMethod(context, pathVal);
                    break;
                case ("POST"):
                    await POSTMethod(context, pathVal);
                    break;
                case ("PUT"):
                    await PUTMethod(context, pathVal);
                    break;
                case ("DELETE"):
                    await DELETEMethod(context, pathVal);
                    break;
            }
            
        }

        private async Task PUTMethod(HttpContext context, string pathVal)
        {
            context.Response.StatusCode = 200;
            var name = pathVal.Substring(1, pathVal.Length - 1);
            if (pathVal == "/" || !_world.Names.Contains(name))
                await context.Response
                    .WriteAsync(_textGenerator.GetTextPUTFailed());
            else
            {
                var indexToReplace = _world.Names.IndexOf(name);
                _world.Names[indexToReplace] = context.Request.Form.Keys.First();
                await context.Response
                    .WriteAsync(_textGenerator.GetTextPUT());
            }
        }

        private async Task DELETEMethod(HttpContext context, string pathVal)
        {
            context.Response.StatusCode = 200;
            var name = pathVal.Substring(1, pathVal.Length - 1);
            if (pathVal == "/" || !_world.Names.Contains(name))
                await context.Response
                    .WriteAsync(_textGenerator.GetTextDELETEFailed());
            else
            {
                _world.DeleteName(name);
                await context.Response
                    .WriteAsync(_textGenerator.GetTextDELETE(name));
            }

            return;
        }

        private async Task POSTMethod(HttpContext context, string pathVal)
        {
            var name = pathVal.Substring(1, pathVal.Length - 1);
            context.Response.StatusCode = 200;

            if (pathVal == "/")
                await context.Response
                    .WriteAsync(_textGenerator.GetTextPOSTFailed());
            else
            {
                _world.AddName(name);
                await context.Response
                    .WriteAsync(_textGenerator.GetTextPOST(name));
            }
            
            /*var name = context.Request.Form.Keys.First();
            _world.AddName(name);
            await context.Response
                .WriteAsync(_textGenerator.GetTextPOST(name));*/
        }

        private async Task GETMethod(HttpContext context, string pathVal)
        {
            context.Response.StatusCode = 200;
            if (pathVal == "/")
                await context.Response
                    .WriteAsync(_textGenerator.GetTextGET(_world.Names));
            else
            {
                var name = pathVal.Substring(1, pathVal.Length - 1);
                if (_world.Names.Contains(name))
                    await context.Response
                        .WriteAsync(_textGenerator.GetTextGET(new List<string> {name}));
                else
                {
                    await context.Response
                        .WriteAsync(name + " Does not exist");
                }
            }
        }

        private string GetRequestType(HttpContext context)
        {
            return _requestTypeGetter.GetRequest(context);
        }
    }
}