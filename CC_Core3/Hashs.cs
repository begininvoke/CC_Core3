using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CC_Core3
{
    class Hashs
    {
        private string filePath { get; set; }
        public string ByteSize { get; set; }
        public Hashs(string[] args)
        {
            filePath = args[0];
        }
        public async Task<string> CreateMD5()
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(filePath);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                string sb = "";
                for (int i = 0; i < hashBytes.Length; i++)
                {
                   sb += (hashBytes[i].ToString("X2"));
                }
               
                return sb ;
            }
            
        }
        public async Task<string> GetMD5Hash()
        {
            using (var sha1 = new MD5CryptoServiceProvider())
                return await GetHash(filePath, sha1);
        }
        public async Task<string> GetSHa256Hash()
        {
            using (var sha1 = new SHA256CryptoServiceProvider())
                return await GetHash(filePath, sha1);
        }
        public async Task<string> GetSHA1Hash()
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
                return await GetHash(filePath, sha1);
        }

        private async Task<string> GetHash(string filePath, HashAlgorithm hasher)
        {

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                ByteSize = fs.Length.ToString();
              return await GetHash(fs, hasher); 
            }
               
        }
        private async Task<string> GetHash(Stream s, HashAlgorithm hasher)
        {
            var hash = hasher.ComputeHash(s);
            string sb = "";
            for (int i = 0; i < hash.Length; i++)
            {
                sb += (hash[i].ToString("X2"));
            }

            return sb;
            //var hashStr = Convert.ToBase64String(hash);
            //return hashStr.TrimEnd('=');
        }
      
    }
}
