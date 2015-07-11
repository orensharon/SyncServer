using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;

namespace SyncService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IPSync" in both code and config file together.
    public class IPSync : IIPSync
    {
        public string Sync(string token)
        {
            string ip = null;
            string currentIp;
            int user_id;
            DatabaseLinker.IPSyncBL iPSyncBL;

            // Get the auth token from the headers
            //var authToken = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

            // Decode the user id from the token
            var payLoad = JWTManager.DecodeToken(token) as IDictionary<string, object>;

            // Authentication error
            if (payLoad == null)
            {
                SetResponseHttpStatus(HttpStatusCode.Forbidden);
                return null;
            }

            user_id = Convert.ToInt32(payLoad["UserID"]);

            iPSyncBL = new DatabaseLinker.IPSyncBL();

            ip = ExtractIPFromSender(ip);
            currentIp = iPSyncBL.GetSafeIP(user_id);

            if (!ip.Equals(currentIp))
            {
                // Saving the IP according given user id
                iPSyncBL.SetPCIP(user_id, ip);
            }
            
            Console.WriteLine("IP Sync from logged user: " + user_id + ", IP is: " + iPSyncBL.GetSafeIP(user_id));

            // Returning the saved IP
            return ip;
        }

        public bool DiscardPCIP(int user_id)
        {
            DatabaseLinker.IPSyncBL iPSyncBL;
            iPSyncBL = new DatabaseLinker.IPSyncBL();

            iPSyncBL.DiscardPCIP(user_id);
            Console.WriteLine("User logout: " + user_id);

            return true;
        }

        

        #region private functions

        private string ExtractIPFromSender(string ip)
        {
            // Extracting the IP of the sender from the headers of the message.
            OperationContext context = OperationContext.Current;
            MessageProperties messageProperties = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpointProperty =
            messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            ip = endpointProperty.Address;
            return ip;
        }
        private void SetResponseHttpStatus(HttpStatusCode statusCode)
        {
            var context = WebOperationContext.Current;
            context.OutgoingResponse.StatusCode = statusCode;
        }

        #endregion private functions
    }
}
