using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace MyServiceHost
{
    class ServiceHostProgram
    {
        static void Main(string[] args)
        {
            //Self Hosting File
            //Create a URI to serve as the base address
            Uri httpWCFUrl = new Uri("http://localhost:8090/UserService/UserServiceTest");

            //Create ServiceHost

            //FOr User WCF Rest

            //Create ServiceHost
            ServiceHost WCFRestHost = new ServiceHost(typeof(WCFRest.UserService), httpWCFUrl);
            //Add a service endpoint
            WCFRestHost.AddServiceEndpoint(typeof(WCFRest.IUserService), new WSHttpBinding(), "");

            //Enable metadata exchange
            ServiceMetadataBehavior WCFRest = new ServiceMetadataBehavior();
            WCFRest.HttpGetEnabled = true;
            WCFRestHost.Description.Behaviors.Add(WCFRest);

            //Start the Service
            WCFRestHost.Open();

            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();

        }
    }
}