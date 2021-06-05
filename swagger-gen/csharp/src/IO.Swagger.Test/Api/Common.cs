using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using System.Text;
using System.Security.Cryptography;

namespace IO.Swagger.Test
{
    public class Common
    {
        public static string getSignature(String secret, Dictionary<String,String> parameters) {
            
            string paramstr = getParameterString(parameters);
            return CreateSignature(secret, paramstr);
 
        }

        public static string getParameterString(Dictionary<String,String> parameters) {
            var paramsPair = 
                parameters.OrderBy(kv => kv.Key)
                          .Select(kv => $"{kv.Key}={kv.Value}")
                          .ToArray();
            return String.Join("&", paramsPair);
        }
        private static string CreateSignature(string secret, string message)
        {
            var signatureBytes = Hmacsha256(Encoding.UTF8.GetBytes(secret), Encoding.UTF8.GetBytes(message));
            return ByteArrayToString(signatureBytes);
        }
        
        private static byte[] Hmacsha256(byte[] keyByte, byte[] messageBytes)
        {
            using (var hash = new HMACSHA256(keyByte))
            {
                return hash.ComputeHash(messageBytes);
            }
        }

        
        private static string ByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);

            foreach (var b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }
}