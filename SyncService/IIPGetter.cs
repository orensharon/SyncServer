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
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "xml/{username}")]
        string GetPCIPXml(string username);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "json/{username}")]
        string GetPCIPJson(string username);
    }
}
