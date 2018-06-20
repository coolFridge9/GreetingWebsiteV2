using Microsoft.AspNetCore.Http;

namespace GreetingWebsiteV2
{
    public interface RequestTypeGetterInterface
    {
        string GetRequest(HttpContext context);
    }
}