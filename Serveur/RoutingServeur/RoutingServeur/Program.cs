using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RoutingServeur
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a URI to serve as the base address
            //Be careful to run Visual Studio as Admistrator or to allow VS to open new port netsh command. 
            // Example : netsh http add urlacl url=http://+:80/MyUri user=DOMAIN\user
            Uri httpUrl = new Uri("http://localhost:8733/Design_Time_Addresses/RoutingServeur/Service1/");

            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(BikeService), httpUrl);

            var myBinding = new BasicHttpBinding
            {
                Name = "NewBinding",
                MaxBufferPoolSize = int.MaxValue,
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
                ReaderQuotas =
                {
                    MaxStringContentLength =int.MaxValue,
                    MaxArrayLength =int.MaxValue,
                    MaxDepth=int.MaxValue,
                    MaxBytesPerRead =int.MaxValue,
                }

            };
            host.AddServiceEndpoint(typeof(IBikeService), myBinding, "");


            host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            host.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            //Start the Service
            host.Open();

            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();

        }
    }
}
