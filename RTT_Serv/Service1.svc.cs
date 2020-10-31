using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL;
using BL;
using System.Configuration;


namespace RTT_Serv
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<Client> GetClients(int clientID)
        {
            //System.Configuration.
            //System.Configuration.
            DAL.ClientData client = new DAL.ClientData();
            return client.GetClient(clientID);
        }

        public List<Address> GetAddresses(int ClientID, int AddressID)
        {
            DAL.AddressData client = new DAL.AddressData();
            return client.GetAddresses(ClientID, AddressID);
        }

        public int SaveClient(int ClientID, string cname, string csurname, int cgender, string cemail, string cbirthdate)
        {
            DAL.ClientData client = new DAL.ClientData();
            int userin = client.SaveClient(ClientID, cname, csurname, cgender, cemail, cbirthdate);
            return userin;
        }
        public bool SaveAddress(int addressid, string address1, string address2, string suburb, string city, int addrtype, int clientID)
        {
            DAL.AddressData client = new DAL.AddressData();
            bool addrin = client.AddAddress(addressid, address1, address2, suburb, city, addrtype, clientID);
            return addrin;
        }

    }
}
