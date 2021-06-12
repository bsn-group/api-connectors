using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using RestSharp;

namespace IO.Swagger.Client
{
    partial class ApiClient
    {
        partial void InterceptRequest(IRestRequest request)
        {
            if (Configuration.ApiKey.ContainsKey("api_secret"))
            {
                var secret = Configuration.ApiKey["api_secret"];
                request.AddOrUpdateParameter("timestamp", DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
                var sign = CreateSignature(secret, request.Parameters);
                request.AddOrUpdateParameter("sign", sign);
            }
        }

        private static string GetParameterString(IEnumerable<Parameter> parameters)
            => String.Join("&",
                parameters
                    .Where(p => p.Value != null && 
                               (p.Type == ParameterType.QueryString || p.Type == ParameterType.GetOrPost))
                    .OrderBy(p => p.Name)
                    .Select(p => $"{p.Name}={p.Value}")
               );
        
        private static string CreateSignature(string secret, IEnumerable<Parameter> parameters)
        {
            var message = GetParameterString(parameters);
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