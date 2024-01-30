using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BancaDelTempo.Controller
{
    public static class EncryptionController
    {
        public static string Encrypt(string email, string password)
        {
            var bytes = $"{email}{password}";
            return "";
        }
    }
}
