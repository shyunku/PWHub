using PasswordManagement.objects;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManagement
{
    public class StringSecure
    {
        private SecureKeyPair allocatedKeyPair;

        public StringSecure(SecureKeyPair secureKeyPair)
        {
            allocatedKeyPair = secureKeyPair;
        }

        //RSA 암호화
        public String rsaEncrypt(String str)
        {
            return encryptRSA(str);
        }
        public String rsaDecrypt(String str)
        {
            return decryptRSA(str);
        }

        //AES 암호화
        public String aesEncrypt(String str)
        {
            return encryptAES(str);
        }
        public String aesDecrypt(String str)
        {
            return decryptAES(str);
        }


        public static String encodeBase64(String str)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(str);
            return Convert.ToBase64String(bytes);
        }

        public static String decodeBase64(String str)
        {
            byte[] bytes = Convert.FromBase64String(str);
            return Encoding.Unicode.GetString(bytes);
        }

        private String encryptAES(String source)
        {
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Mode = CipherMode.CBC;
            rijndaelManaged.Padding = PaddingMode.PKCS7;

            rijndaelManaged.KeySize = 128;
            rijndaelManaged.BlockSize = 128;
            byte[] encoded = Encoding.UTF8.GetBytes(allocatedKeyPair.Aes_key);
            byte[] keyBytes = new byte[16];
            int length = Math.Min(encoded.Length, keyBytes.Length);
            Array.Copy(encoded, keyBytes, length);
            rijndaelManaged.Key = keyBytes;
            rijndaelManaged.IV = keyBytes;

            ICryptoTransform transform = rijndaelManaged.CreateEncryptor();
            byte[] converted = Encoding.UTF8.GetBytes(source);

            return Convert.ToBase64String(transform.TransformFinalBlock(converted, 0, converted.Length));
        }

        private String decryptAES(String crypt)
        {
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Mode = CipherMode.CBC;
            rijndaelManaged.Padding = PaddingMode.PKCS7;

            rijndaelManaged.KeySize = 128;
            rijndaelManaged.BlockSize = 128;
            byte[] encrypted = Convert.FromBase64String(crypt);
            byte[] encoded = Encoding.UTF8.GetBytes(allocatedKeyPair.Aes_key);
            byte[] keyBytes = new byte[16];
            int length = Math.Min(encoded.Length, keyBytes.Length);
            Array.Copy(encoded, keyBytes, length);
            rijndaelManaged.Key = keyBytes;
            rijndaelManaged.IV = keyBytes;

            ICryptoTransform transform = rijndaelManaged.CreateDecryptor();
            byte[] converted = transform.TransformFinalBlock(encrypted, 0, encrypted.Length);

            return Encoding.UTF8.GetString(converted);
        }

        private String encryptRSA(String source)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(allocatedKeyPair.Rsa_publicKey);
            byte[] encoded = (new UTF8Encoding()).GetBytes(source);
            byte[] encrypted = rsa.Encrypt(encoded, false);

            return System.Convert.ToBase64String(encrypted);
        }

        private String decryptRSA(String crypt)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(allocatedKeyPair.Rsa_privateKey);
            byte[] converted = System.Convert.FromBase64String(crypt);
            byte[] decrypted = rsa.Decrypt(converted, false);

            return (new UTF8Encoding()).GetString(decrypted, 0, decrypted.Length);
        }
    }
}
