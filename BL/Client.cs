using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Client
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public int Gender { get; set; }

        public string FullGender 
        {
            get
            {
                var GType = (GenderValue)Gender;
                return $" {GType.ToString()}";
            }
        }
        public string ClientEmail { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FullName
        {
            get
            {
                return $"{ClientSurname}, {ClientName} ({FullGender})";
            }
        }

        public enum GenderValue { Male, Female };
    }
}
