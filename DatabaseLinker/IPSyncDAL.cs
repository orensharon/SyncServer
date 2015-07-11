using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinker
{
    public class IPSyncDAL : DB
    {
        public IPSyncDAL()
        {
        }

        public string GetSafeIP(int user_id)
        {
            
            // From given user id parameter - creating SQL query to fetch the IP of the user's pc
            // If user dosent exist or dosent logged in - returns an empty string

            string sqlString;
            SqlDataReader rdr;
            string result;

            

            // SQL query
            sqlString = @"SELECT ip_address
                                FROM Users
                                WHERE user_id = @User";

            result = String.Empty;
            using (SqlConnection con = new SqlConnection(ConntectString))
            {
                con.Open();
                // Execute query
                SqlCommand com = new SqlCommand(sqlString, con);

                SqlParameter myparm = new SqlParameter("@User", user_id);
                com.Parameters.Add(myparm);

                rdr = com.ExecuteReader();

                // Handle returns items from database
                if (rdr.Read())
                {
                    result = Convert.ToString(rdr["ip_address"]);
                }
            }

            // return IP
            return result;
        }

        public void SetPCIP(int user_id, string ip)
        {
            // From given user id parameter - creating SQL query to update the IP of the user's pc
            // If user dosent exist or dosent logged in - do nothing

            string sqlString;
            SqlDataReader rdr;

            
            // SQL query
            sqlString = @"UPDATE Users 
                        SET ip_address= @IP WHERE user_id = @User";

            
            using (SqlConnection con = new SqlConnection(ConntectString))
            {
                con.Open();
                
                // Execute query
                SqlCommand com = new SqlCommand(sqlString, con);
                SqlParameter[] myparm = new SqlParameter[2];
                myparm[0] = new SqlParameter("@IP", ip);
                myparm[1] = new SqlParameter("@User", user_id);

                com.Parameters.Add(myparm[0]);
                com.Parameters.Add(myparm[1]);

                rdr = com.ExecuteReader();
            }
        }

        public void DiscardPCIP(int user_id)
        {
            // From given user id parameter - creating SQL query to remove the IP of the user's pc
            // This method will be called when the user will decide to stop the service or exit the program
            // If user dosent exist or dosent logged in - do nothing

            SetPCIP(user_id, String.Empty);
        }
    }
}
