using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagement.objects
{
    public class SecureKeyPair
    {
        //Physically located in same file
        private String rsa_privateKey;
        private String rsa_publicKey;
        private String aes_key;

        public SecureKeyPair()
        {
            RSACryptoServiceProvider rsaCSP = new RSACryptoServiceProvider();

            //Generate Private RSA Key
            RSAParameters privateKey = RSA.Create().ExportParameters(true);
            rsaCSP.ImportParameters(privateKey);
            Rsa_privateKey = rsaCSP.ToXmlString(true);

            //Generate Public RSA Key
            RSAParameters publicKey = new RSAParameters();
            publicKey.Modulus = privateKey.Modulus;
            publicKey.Exponent = privateKey.Exponent;
            rsaCSP.ImportParameters(publicKey);
            Rsa_publicKey = rsaCSP.ToXmlString(false);

            AesCryptoServiceProvider aesCSP = new AesCryptoServiceProvider();
            aesCSP.KeySize = 128;
            aesCSP.BlockSize = 128;
            aesCSP.GenerateKey();

            byte[] keyBytes = aesCSP.Key;
            Aes_key = Convert.ToBase64String(keyBytes);
        }

        public string Rsa_privateKey { get => rsa_privateKey; set => rsa_privateKey = value; }
        public string Rsa_publicKey { get => rsa_publicKey; set => rsa_publicKey = value; }
        public string Aes_key { get => aes_key; set => aes_key = value; }
    }
}
