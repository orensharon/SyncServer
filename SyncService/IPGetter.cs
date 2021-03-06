﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SyncService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IPGetter" in both code and config file together.
    public class IPGetter : IIPGetter
    {
        public SyncResponse GetSafeIPJson()
        {
            DatabaseLinker.IPSyncBL iPSyncBL;
            iPSyncBL = new DatabaseLinker.IPSyncBL();
            int user_id;

            // Get the auth token from the headers
            var authToken = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

            // Decode the user id from the token
            var payLoad = JWTManager.DecodeToken(authToken) as IDictionary<string, object>;

            
            if (payLoad == null)
            {
                // Authentication error
                SetResponseHttpStatus(HttpStatusCode.Forbidden);
                return null;
            }

            // Read user id from the token and query database
            user_id = Convert.ToInt32(payLoad["UserID"]);

            string ip = iPSyncBL.GetSafeIP(user_id);
            Console.WriteLine("Requested by: " + user_id + ", ip: " + ip);

            SyncResponse response = new SyncResponse {/* UserID = parsedUserId,*/ IP = ip };

            return response;
        }








        // Private functions


        private void SetResponseHttpStatus(HttpStatusCode statusCode)
        {
            var context = WebOperationContext.Current;
            context.OutgoingResponse.StatusCode = statusCode;
        }
    }
}
