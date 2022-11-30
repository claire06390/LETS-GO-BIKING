using RoutingServeur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Launch_console
{
    class Program
    {

        static void Main(string[] args)
    {

        // Create the ServiceHost.
        using (ServiceHost host = new ServiceHost(typeof(BikeService)))
        {

            host.Open();

            Console.WriteLine("The service is ready at {0}", host.BaseAddresses[0]);

            Console.ReadLine();
            host.Close();
        }
    }
}
}
