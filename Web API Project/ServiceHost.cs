using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.SelfHost;
using System.Web.Http;
namespace Web_API_Project
{
    public class ServiceHost
    {
        static void main(string[] args)
        {
            // Configure Web API for self-host. 
            var config = new HttpSelfHostConfiguration("http://localhost:1010/Values/DATA");
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            using(HttpSelfHostServer server =new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Self Host Started..");
                Console.ReadLine();
            }
        }
    }
}