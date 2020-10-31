using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Address
    {
        public int ID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public int AddressTypeID { get; set; }
        public int ClientID { get; set; }

        public string FullAddress
        {
            get
            {
                var AType = (AddressTypes)AddressTypeID;
                return $"&nbsp;{AType.ToString()} : {Suburb},{City}";
            }
        }

        public string AddressType
        {
            get
            {
                var AType = (AddressTypes)AddressTypeID;
                return AType.ToString();
            }
        }

        public enum AddressTypes { Home, Work, Holiday };
    }
}
