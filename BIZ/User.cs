using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
   public class User
    {
        //Class base User with all the informations
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string AccountType { get; set; }
        public int AccountNumber { get; set; }
        public int SortCode { get; }
        public int InitialBalance { get; set; }


        public User(string fn, string sn, string email, string pnumber, string address1, string address2, string city, string county, string acctype, int accnumber, int sortcode, int initbal)
        {
            Firstname = fn;
            Surname = sn;
            Email = email;
            PhoneNumber = pnumber;
            AddressLine1 = address1;
            AddressLine2 = address2;
            City = city;
            County = county;
            AccountType = acctype;
            AccountNumber = accnumber;
            SortCode = sortcode;
            InitialBalance = initbal;
        }
    }
}
