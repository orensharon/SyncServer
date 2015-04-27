using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace LoginService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UserLogin : IUserLogin
    {
        public LoginResponse LoginAttempt(LoginRequest request)
        {

            string username, password;
            int user_id;
            DatabaseLinker.UsersBL usersBL;
            LoginResponse response;


            // Read from json request
            username = request.Username;
            password = request.Password;

            usersBL = new DatabaseLinker.UsersBL();

            response = new LoginResponse();
            usersBL = new DatabaseLinker.UsersBL();


            user_id = usersBL.Login(username, password);

            Console.WriteLine("Welcome user id " + user_id);

            if (user_id == -1)
            {
                // Login auth fails

                // Return Bad request response code 400
                SetResponseHttpStatus(HttpStatusCode.BadRequest);
                return null;
            }
            else
            {
                // Login ok


                // Create token from (username + id)
                response.Token = JWTManager.CreateToken(user_id, username);
            }

            return response;
        }

        private void SetResponseHttpStatus(HttpStatusCode statusCode)
        {
            var context = WebOperationContext.Current;
            context.OutgoingResponse.StatusCode = statusCode;
        }
        

    }




}
