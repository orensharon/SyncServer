using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SyncService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIPSync" in both code and config file together.
    [ServiceContract]
    public interface IIPSync
    {
        [OperationContract]
        string Sync(string token);

        [OperationContract]
        bool DiscardPCIP(int user_id);
    }
}
