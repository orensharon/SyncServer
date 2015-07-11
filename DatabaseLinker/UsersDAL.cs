using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinker
{
    public class UsersDAL : DB
    {

        /*
         * From a given username and password make attemp to login
         * If username and password incorrect - return -1 otherwise return user id
         */   
        public int Login(string username, string password)
        {
            
            string sqlString;
            SqlDataReader rdr;
            int result;




            // SQL query
            sqlString = @"SELECT user_id
                                FROM Users
                                WHERE username = @User AND password = @Password";

            result = -1; // as default
            using (SqlConnection con = new SqlConnection(ConntectString))
            {
                con.Open();

                // Execute query
                SqlCommand com = new SqlCommand(sqlString, con);

                SqlParameter[] myparm = new SqlParameter[2];
                myparm[0] = new SqlParameter("@User", username);
                myparm[1] = new SqlParameter("@Password", password);
                com.Parameters.Add(myparm[0]);
                com.Parameters.Add(myparm[1]);

                rdr = com.ExecuteReader();

                // Handle returns items from database
                if (rdr.Read())
                {
                    // TODO: make sure user realy exists
                    result = Convert.ToInt32(rdr["user_id"]);
                }
            }
           
            // return user id
            return result;
        }

    }
}
