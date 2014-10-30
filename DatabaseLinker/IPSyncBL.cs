using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinker
{
    public class IPSyncBL
    {

        public string GetPCIP(string username)
        {
            // TODO:
            // From given username parameter - accessing the DB and gets back the PC IP
            // If user dosent exist or dosent logged in - returns an error, else returns the IP of the PC

            return String.Empty;
        }

        public string SetPCIP(string username, string ip)
        {
            // TODO:
            // From given username parameter - accessing the DB and updates the IP of the user PC
            // If user dosent exist or dosent logged in - returns an error, else returns the IP of the PC

            return String.Empty;
        }

        public bool DiscardPCIP(string username)
        {
            // TODO:
            // From given username parameter - accessing the DB and removing the IP of the PC.
            // This method will be called when the user will decide to stop the service or exit the program
            // If user dosent exist or dosent logged in - returns an error, else returns true 

            return true;
        }

    }
}
