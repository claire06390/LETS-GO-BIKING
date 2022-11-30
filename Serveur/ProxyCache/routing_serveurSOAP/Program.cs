using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace routing_serveurSOAP
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Uri httpUrl = new Uri("http://localhost:8733/Design_Time_Addresses/routing_serveurSOAP/Service1");

    
            ServiceHost host = new ServiceHost(typeof(ProxyService), httpUrl);

            var myBinding = new BasicHttpBinding
            {
                Name = "NewBinding",
                MaxBufferPoolSize = int.MaxValue,
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
                ReaderQuotas =
                {
                    MaxStringContentLength = int.MaxValue,
                    MaxArrayLength =int.MaxValue,
                    MaxDepth=int.MaxValue,
                    MaxBytesPerRead =int.MaxValue,
                }

            };

            host.AddServiceEndpoint(typeof(IProxyService), myBinding, "");

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

        
            host.Open();

            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();

        }
    }
}
