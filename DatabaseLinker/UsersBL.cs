using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinker
{
    public class UsersBL
    {


        /*
         * User attempt to login into the system with a given username and password
         * Returns true upon successful login, false otherwise
         */
        public int Login(string username, string password)
        {
            int user_id;

            UsersDAL usersDAL = new UsersDAL();
            user_id = usersDAL.Login(username, password);
            //usersDAL.closeConnection();

            return user_id;
        }


        public bool SignIn(string username, string password)
        {
            return true;
           // return usersDAL.SignIn(username, password);
        }
    }
}
