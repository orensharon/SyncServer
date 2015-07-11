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
        [WebInvoke(
            Method = "POST", 
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json")]
        SyncResponse GetSafeIPJson();
    }

    [DataContract]
    public class SyncResponse
    {

        [DataMember]
        public string IP { get; set; }
    }


}
