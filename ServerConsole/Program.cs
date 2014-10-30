using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           ServiceHost IPSyncHost = new ServiceHost(typeof(SyncService.IPGetter));
           ServiceHost IPGetterHost = new ServiceHost(typeof(SyncService.IPSync));

            IPSyncHost.Open();
            Console.WriteLine("Service up and running at:");
            foreach (var ea in IPSyncHost.Description.Endpoints)
            {
                Console.WriteLine(ea.Address);
            }


            IPGetterHost.Open();

            Console.WriteLine("Service up and running at:");
            foreach (var ea in IPGetterHost.Description.Endpoints)
            {
                Console.WriteLine(ea.Address);
            }

            Console.WriteLine("Hit enter to kill servier");
            Console.ReadLine();

            IPGetterHost.Close();
            IPSyncHost.Close();

            
        }
    }
}
