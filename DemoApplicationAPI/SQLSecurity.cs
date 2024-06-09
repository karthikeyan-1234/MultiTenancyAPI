using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DemoApplicationAPI
{
    public class SQLSecurity : ISQLSecurity
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public SQLSecurity()
        {
            string key = "Abcdefgjh9ojou3ulhalyufohlnsao32llsjljdljlfou92ljlouojljluojlsjfulj2ljouonfou2111jckakhfonclvhohlnos";
            _key = Encoding.UTF8.GetBytes(key.Substring(0, 32));
            _iv = Encoding.UTF8.GetBytes(key.Substring(0, 16));
        }


        public string? EncryptConnection(string connection)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(connection);

            using (var aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.FlushFinalBlock();
                    }


                    var encryptedBytes = ms.ToArray();
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        public string? DecryptConnection(string encryptedConnection)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedConnection);

            using (var aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream(encryptedBytes))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
