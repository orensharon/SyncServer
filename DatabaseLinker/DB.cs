using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinker
{
    public class DB
    {
        public SqlConnection con;


        public void closeConnection()
        {
            // Close the connections after every request from db
            con.Close();
        }


        public SqlDataReader executeQuery(string sqlString)
        {
            // executing a given query and returns sqr reader
            SqlCommand com = new SqlCommand(sqlString, con);
            return com.ExecuteReader();
        }


        public DB()
        {
            string s = "Data Source=(localdb)\\Projects;Initial Catalog=SyncServerDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            con = new SqlConnection(s);
            con.Open();
        }

    }
}
