
using System.Diagnostics;
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

            List<string> test;
            test = new List<string>();
            test.Add("asdads");
            test.Add("asdads1");
            var result = String.Join(", ", test.ToArray());
            Console.WriteLine(result);


            // Creation of the services
            ServiceHost IPSyncHost = new ServiceHost(typeof(SyncService.IPSync));
            ServiceHost IPGetterHost = new ServiceHost(typeof(SyncService.IPGetter));
            ServiceHost UserLoginHost = new ServiceHost(typeof(LoginService.UserLogin));



            // Open User Login servivce
            try
            {
                UserLoginHost.Open();
            }
            catch (TimeoutException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            // Print the end points of the service
            Console.WriteLine("Service up and running at:");
            foreach (var ea in UserLoginHost.Description.Endpoints)
            {
                Console.WriteLine(ea.Address);
            }


            // Open IP Sync service
            try
            {
                IPSyncHost.Open();
            }
            catch (TimeoutException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            // Print the end points of the service
            Console.WriteLine("Service up and running at:");
            foreach (var ea in IPSyncHost.Description.Endpoints)
            {
                Console.WriteLine(ea.Address);
            }

            // Open IP Getter service
            try
            {
                IPGetterHost.Open();
            }
            catch (TimeoutException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            catch (CommunicationObjectFaultedException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            // Print the end points of the service
            Console.WriteLine("Service up and running at:");
            foreach (var ea in IPGetterHost.Description.Endpoints)
            {
                Console.WriteLine(ea.Address);
            }

            Console.WriteLine("Hit enter to kill servier");
            Console.ReadLine();

            // Close the services
            IPGetterHost.Close();
            IPSyncHost.Close();
            UserLoginHost.Close();
            
        }
    }
}
