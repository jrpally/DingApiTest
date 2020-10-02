using System;
using System.Text;

namespace PetStoreTest.Tools
{
    public class StringTools
    {
        const string src = "abcdefghijklmnopqrstuvwxyz0123456789";

        /// <summary>
        /// Generate Random String
        /// </summary>
        /// <param name="prefix">Prefix</param>
        /// <param name="length">length</param>
        /// <returns></returns>
        public static string GenerateRandomString(string prefix, int length)
        {
            
            StringBuilder sb = new StringBuilder();
            Random localRng = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = src[localRng.Next(0, src.Length)];
                sb.Append(c);
            }

            return prefix + sb;
        }
    }
}