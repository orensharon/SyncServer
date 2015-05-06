using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinker
{
    class IPSyncDAL : DB
    {
        public IPSyncDAL()
        {
        }

        public string GetPCIP(int user_id)
        {
            
            // From given username parameter - creating SQL query to fetch the IP of the user's pc
            // If user dosent exist or dosent logged in - returns an error, else returns the IP of the PC

            string sqlString;
            SqlDataReader rdr;
            string result;

            // SQL query
            sqlString = @"SELECT ip_address
                                FROM Users
                                WHERE user_id = " + user_id;

            result = String.Empty;
            using (SqlConnection con = new SqlConnection(ConntectString))
            {
                con.Open();
                // Execute query
                SqlCommand com = new SqlCommand(sqlString, con);
                rdr = com.ExecuteReader();

                // Handle returns items from database
                if (rdr.Read())
                {
                    result = Convert.ToString(rdr["ip_address"]);
                }
            }

            // IP error
            return result;
        }

        public string SetPCIP(int user_id, string ip)
        {
            // From given username parameter - creating SQL query to update the IP of the user's pc
            // If user dosent exist or dosent logged in - returns an error, else returns the IP of the PC

            string sqlString;
            SqlDataReader rdr;

            // SQL query
            sqlString = @"UPDATE Users 
                        SET ip_address='" + ip + "' WHERE user_id = " + user_id;

            
            using (SqlConnection con = new SqlConnection(ConntectString))
            {
                con.Open();
                // Execute query
                SqlCommand com = new SqlCommand(sqlString, con);
                rdr = com.ExecuteReader();
            }

            return String.Empty;
        }

        public string DiscardPCIP(int user_id)
        {
            // From given username parameter - creating SQL query to remove the IP of the user's pc
            // This method will be called when the user will decide to stop the service or exit the program
            // If user dosent exist or dosent logged in - returns an error, else returns true 

            return SetPCIP(user_id, String.Empty);
        }
    }
}
