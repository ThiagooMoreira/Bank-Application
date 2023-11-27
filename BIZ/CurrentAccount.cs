using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    //BIZ Layer or Business Layer.
    public class CurrentAccount:User
    {
        public decimal OverDraftLimit { get; set; }

        //Gets values from class base User and also adds overdraft limit == overd.
        public CurrentAccount(string fn, string sn, string email, string pnumber, string address1, string address2, string city, string county, string acctype, int accnumber, int sortcode, int initbal, decimal overd)
        : base(fn, sn, email, pnumber, address1, address2, city, county, acctype, accnumber, sortcode, initbal)
        {
            OverDraftLimit = overd;
        }
    }
}
