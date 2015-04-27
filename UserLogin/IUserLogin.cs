using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;

namespace LoginService
{

    [ServiceContract]
    public interface IUserLogin
    {

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "json")]
        LoginResponse LoginAttempt(LoginRequest request);



        /*
         * Logout API's
         
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "pc",
            BodyStyle = WebMessageBodyStyle.Bare)]
        LoginResponse LogoutAttempt(LoginRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "android")]
        LoginResponse LogoutAttemptJson(LoginRequest rData);*/
    }
    
    [DataContract]
    public class LoginResponse
    {
        [DataMember]
        //public int UserID { get; set; }
        public string Token { get; set; }

    }

    [DataContract]
    public class LoginRequest
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

    }
   
}
