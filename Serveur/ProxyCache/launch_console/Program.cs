using System;
using System.ServiceModel;
using routing_serveurSOAP;

namespace launch_console
{
    class Program
    {

        static void Main(string[] args)
        {

            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(ProxyService)))
            {

                host.Open();

                Console.WriteLine("The service is ready at {0}", host.BaseAddresses[0]);

                Console.ReadLine();
                host.Close();
            }
        }
    }
}
