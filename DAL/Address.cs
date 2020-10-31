using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace DAL
{
    public class AddressData
    {
        string configName = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
        public List<Address> GetAddresses(int ClientID, int AddressID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(configName))
            {
                string qry = $"Select * from Address Where ClientID={ClientID}";
                if(AddressID!=0)
                {
                    qry = $"Select * from Address Where ClientID={ClientID} and ID={AddressID}";
                }
                var output = connection.Query<Address>(qry).ToList();
                return output;
            }
        }

        public bool AddAddress(int addressid,string address1, string address2, string suburb, string city, int addrtype, int clientID)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(configName))
                {
                    if (addressid == 0)
                    {
                        var output = connection.Execute($"INSERT INTO ADDRESS (AddressLine1,AddressLine2,Suburb,City,AddressTypeID,ClientID) values('{address1}','{address2}','{suburb}','{city}','{addrtype}','{clientID}')");
                    }
                    else
                    {
                        string qry = $"UPDATE ADDRESS SET AddressLine1='{address1}',AddressLine2='{address2}',Suburb='{suburb}',City='{city}',AddressTypeID='{addrtype}',ClientID='{clientID}' WHERE ID={addressid}";
                        var output = connection.Execute($"UPDATE ADDRESS SET AddressLine1='{address1}',AddressLine2='{address2}',Suburb='{suburb}',City='{city}',AddressTypeID='{addrtype}',ClientID='{clientID}' WHERE ID={addressid}");
                    }
                 }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }


   
}


