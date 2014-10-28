using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;

namespace SyncService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIPGetter" in both code and config file together.
    [ServiceContract]
    public interface IIPGetter
    {
        [OperationContract]
        [WebGet(UriTemplate = "Test/name/{n}")]
        string DoWork(string n);
    }
}
