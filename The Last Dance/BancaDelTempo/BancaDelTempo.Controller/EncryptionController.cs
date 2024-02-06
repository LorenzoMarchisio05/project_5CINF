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
            var bytes = Encoding.UTF8.GetBytes($"{email}{password}");
            var hash = SHA256.Create().ComputeHash(bytes);
            return string.Join("", hash.Select(c => ((int)c).ToString("X2")));
        }
    }
}
