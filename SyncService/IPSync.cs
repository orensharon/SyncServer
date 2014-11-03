using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace SyncService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IPSync" in both code and config file together.
    public class IPSync : IIPSync
    {
        public string HelloWorld()
        {
            string ip = null;
            string username = "dummyuser";
            DatabaseLinker.IPSyncBL db_bl = new DatabaseLinker.IPSyncBL();
            
            OperationContext context = OperationContext.Current;
            MessageProperties messageProperties = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpointProperty =
            messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            ip = endpointProperty.Address;

            //db_bl.SetPCIP(username, ip);
            System.IO.File.WriteAllText(@"ip.txt", ip);
            Console.WriteLine("Hello user: " + username + ", Your IP is: " + ip);

            return ip;
        }
    }
}
