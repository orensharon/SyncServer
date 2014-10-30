using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SyncService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IPGetter" in both code and config file together.
    public class IPGetter : IIPGetter
    {
        public string GetPCIPXml(string username)
        {
            string ip = System.IO.File.ReadAllText(@"ip.txt");
            Console.WriteLine(ip);
            return ip;
        }

        public string GetPCIPJson(string username)
        {
            string ip = System.IO.File.ReadAllText(@"ip.txt");
            Console.WriteLine(ip);
            return ip;
        }
    }
}
