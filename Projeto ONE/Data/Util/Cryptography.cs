using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Projeto_ONE.Data.Util
{
    public class Cryptography
    {
        public static string GetMD5Hash(string Param)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(Param));

            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}