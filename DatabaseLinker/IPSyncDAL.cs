using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinker
{
    class IPSyncDAL
    {
        public string GetPCIP(string username)
        {
            // TODO:
            // From given username parameter - creating SQL query to fetch the IP of the user's pc
            // If user dosent exist or dosent logged in - returns an error, else returns the IP of the PC

            return String.Empty;
        }

        public string SetPCIP(string username, string ip)
        {
            // TODO:
            // From given username parameter - creating SQL query to update the IP of the user's pc
            // If user dosent exist or dosent logged in - returns an error, else returns the IP of the PC

            return String.Empty;
        }

        public bool DiscardPCIP(string username)
        {
            // TODO:
            // From given username parameter - creating SQL query to remove the IP of the user's pc
            // This method will be called when the user will decide to stop the service or exit the program
            // If user dosent exist or dosent logged in - returns an error, else returns true 

            return true;
        }
    }
}
