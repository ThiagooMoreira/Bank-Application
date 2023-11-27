using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DAL
{
    
    public class NewAccount:DAO
    {
        //Method to Add account. Also uses stored procedure
        public void AddAccount(string fn, string sn, string email, string pnumber, string address1, string address2, string city, string county, string acctype, int initbal, int overd)
        {
            SqlCommand cmd = OpenCon().CreateCommand();
            cmd.CommandText = "uspAddAccount";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fn", fn);
            cmd.Parameters.AddWithValue("@sn", sn);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pnumber", pnumber);
            cmd.Parameters.AddWithValue("@address1", address1);
            cmd.Parameters.AddWithValue("@address2", address2);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@county", county);
            cmd.Parameters.AddWithValue("@acctype", acctype);
            cmd.Parameters.AddWithValue("@initbal", initbal);
            cmd.Parameters.AddWithValue("@overd", overd);
            cmd.ExecuteNonQuery();
            CloseCon();
        }


    }
}
