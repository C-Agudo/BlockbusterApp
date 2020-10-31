using BlockbusterApp.src.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Infrastructure.Service.Hashing
{
    public class DefaultHashing : IHashing
    {
        
        public UserHashedPassword Hash(string password)
        {
            Byte[] bytes = new UTF8Encoding().GetBytes(password);
            Byte[] hashBytes;

            using (SHA512 algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }

            string hashPassword =  Convert.ToBase64String(hashBytes);

            return new UserHashedPassword(hashPassword);
        }
    }
}
