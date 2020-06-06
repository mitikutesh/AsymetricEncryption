using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AsymetricEncryption
{
    public class CertificateReader
    {
       
        public static X509Certificate2 selectCert(string thumbPrint)
        {

            var store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            X509Certificate2 certificate = new X509Certificate2 ();
            store.Open(OpenFlags.ReadOnly);
            //In real life here we fetch with thumprint or by name
            var cert = store.Certificates.OfType<X509Certificate2>().FirstOrDefault();

            return cert;
        }
    }
}