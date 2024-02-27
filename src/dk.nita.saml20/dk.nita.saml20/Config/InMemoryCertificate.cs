using System.Security.Cryptography.X509Certificates;

namespace dk.nita.saml20.config
{
    /// <summary>
    /// In memory certificate
    /// </summary>
    public class InMemoryCertificate : Certificate
    {
        private readonly X509Certificate2 certificate;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="certificate"></param>
        public InMemoryCertificate(X509Certificate2 certificate)
        {
            this.certificate = certificate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override X509Certificate2 GetCertificate()
        {
            return certificate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override X509Certificate2 GetFirstValidX509Certificate()
        {
            return certificate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override X509Certificate2Collection GetAllValidX509Certificates()
        {
            return new X509Certificate2Collection(certificate);
        }
    }
}