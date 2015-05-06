using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLinker
{

    public class IPSyncBL
    {
        

        public string GetPCIP(int user_id)
        {
            // From given username parameter - accessing the DB and gets back the PC IP
            // If user dosent exist or dosent logged in - returns an error, else returns the IP of the PC
            string ip;
            IPSyncDAL iPSyncDAL = new IPSyncDAL();
            
            ip = iPSyncDAL.GetPCIP(user_id);

            return ip;
        }

        public void SetPCIP(int user_id, string ip)
        {
            // From given username parameter - accessing the DB and updates the IP of the user PC
            IPSyncDAL iPSyncDAL = new IPSyncDAL();

            iPSyncDAL.SetPCIP(user_id, ip);

            //iPSyncDAL.closeConnection();
        }

        public void DiscardPCIP(int user_id)
        {
            // From given username parameter - accessing the DB and removing the IP of the PC.
            // This method will be called when the user will decide to stop the service or exit the program
            IPSyncDAL iPSyncDAL = new IPSyncDAL();
            
            iPSyncDAL.DiscardPCIP(user_id);

            
        }

    }
}
