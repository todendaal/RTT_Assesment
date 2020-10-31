using DAL;
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
    public class ClientData
    {
        string configName = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
        public List<Client> GetClient(int clientID)
        {
            string qry = "Select * from Client";
            if (clientID!= 0){
                qry += " where ID=" + clientID;
            }
            qry += " Order by ClientSurname";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(configName))
            {
                return connection.Query<Client>(qry).ToList();
            }
        }

        public int SaveClient(int ClientID,string cname, string csurname, int cgender,string cemail, string cbirthdate)
        {
            int cID = ClientID;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(configName))
            {
                DateTime bdate = Convert.ToDateTime(cbirthdate);
                if (ClientID == 0)
                {
                    var output = connection.Query<int>($"INSERT INTO CLIENT (ClientName,ClientSurname,ClientEmail,Gender,DateOfBirth) values('{cname}','{csurname}','{cemail}','{cgender}','{cbirthdate}') SELECT @@IDENTITY AS 'Identity';");
                    cID = Convert.ToInt32(output.First());
                }
                else
                {
                    var output = connection.Execute($"UPDATE CLIENT SET ClientName='{cname}',ClientSurname='{csurname}',ClientEmail='{cemail}',Gender='{cgender}',DateOfBirth='{cbirthdate}' WHERE ID = {ClientID}");
                }
            }
            return cID;
        }
    }
}
