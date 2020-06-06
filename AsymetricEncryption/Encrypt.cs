using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AsymetricEncryption
{
    public class Encrypt
    {
        
        public static byte[] EncryptDataOaepSha1(X509Certificate2 cert, byte[] data)
        {
            // GetRSAPublicKey returns an object with an independent lifetime, so it should be
            // handled via a using statement.
            using (RSA rsa = cert.GetRSAPublicKey())
            {
                // OAEP allows for multiple hashing algorithms, what was formermly just "OAEP" is
                // now OAEP-SHA1.
                return rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA512);
            }
        }
        public static byte[] DecryptDataOaepSha1(X509Certificate2 cert, byte[] data)
        {
            // GetRSAPrivateKey returns an object with an independent lifetime, so it should be
            // handled via a using statement.
            using (RSA rsa = cert.GetRSAPrivateKey())
            {
                return rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA512);
            }
        }
    }
}