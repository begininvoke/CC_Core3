using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_Core3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    var x = Task.Run(() => MainAsync(args));
                    Console.ReadLine();
                }
                else
                    Console.WriteLine("please Select File");


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static async Task MainAsync(string[] args)
        {
            Hashs start = new Hashs(args);
            string sha1 = await start.GetSHA1Hash();
            string md5 = await start.GetMD5Hash();
            string sha256 = await start.GetSHa256Hash();
            Console.WriteLine("SH1 :  " + sha1);
            Console.WriteLine("MD5 :  " + md5);
            Console.WriteLine("SHA256 :  " + sha256);
            Console.WriteLine("ByteSize :  " + start.ByteSize);
            Console.ReadLine();
        }
    }
}
