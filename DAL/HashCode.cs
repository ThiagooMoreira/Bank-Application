using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //Hashcode to hash/encrypt passwords
    public class HashCode
    {
        public string PassHash(string data)
        {
            SHA1 sha = SHA1.Create();
            byte[] hashdata = sha.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashdata.Length; i++)
            {
                sb.Append(hashdata[i].ToString());
            }
            return sb.ToString();
        }
    }
}
