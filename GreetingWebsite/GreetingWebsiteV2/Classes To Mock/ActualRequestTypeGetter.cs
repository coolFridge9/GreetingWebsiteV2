using Microsoft.AspNetCore.Http;

namespace GreetingWebsiteV2
{
    public class ActualRequestTypeGetter : RequestTypeGetterInterface
    {
        public string GetRequest(HttpContext context)
        {
            return context.Request.Method;
        }
    }
}