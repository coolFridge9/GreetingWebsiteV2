using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace GreetingWebsiteV2
{
    class Program
    {
        static void Main(string[] args)
        {
           WebsiteHoster.Host(args);
        }

    }

}