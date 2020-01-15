using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManagement
{
    class StringSecure
    {
        private const String RSA_PRIVATE_KEY = @"<RSAKeyValue><Modulus>1OKVBA0vEYJxsdEFK6GgiP2RKbIyl2tpwo8ggKCUSXdHXJ/EJuYse26JT4rxlUT5gGjxEH9arG8a+zK1SHaJvN2LjzKkkeGOWkAk8va+gEt3MeAAVrltr8+Y+TxFjzd7ZKCYk0UlcAG/kUj4EYl5gYbfIIpIspPudrZnCWsfo7k=</Modulus><Exponent>AQAB</Exponent><P>5sPc3kpz7RzdehwyZ5pSUUUO+dl/5fzn2q/K6H+QS+237iw27D1R56sXXO2N8QmTaRaL6iD+UnzUP66eP1ER1w==</P><Q>7CotyDIutJ9E5bYGWNrpE2Lw5E9TDmBF0lLUTmXhmot2hgJUt52xcFJwl+j96AP+537BJd4Tz2d5wOGzeUhk7w==</Q><DP>doWKXzFmMRZuOlVZHhUIymzpsDGhmwI2Iv+++4LpHdZObamP2+3yr0YUjcoE6RO9/m9yFSI0/TDX4o1RAbwlqQ==</DP><DQ>6tiKzGDyxxT2u4PGTgfq7Sdfq3oietJLvHo3u3pe3YNAKsUYn7tF3w9r/fRowZdvnZ8TzWdIxd/9WExZYAsYqw==</DQ><InverseQ>C91P/tw4l4pdqv5mo+j6yBRHvvfg6qdhz9UUJT2pCIOwyMf9JuDV89t6jctxMEcqgS/pkYB0nMhTuUtQdARd9Q==</InverseQ><D>0Fm1+FIi5+Mf/SUSB2LXaFurEADsjM++oYFNETaYCtLnj9p5soyBqohDcQsOZ8Yq3qdWj4vlJXBUGtfFHteM8vdvtMMrbneq+a7dqIvq57lxvYKZ98gN4R+SwSYTrH2VSYnsd+0+lt0KH/EsIdjJukQKuyQrHRGfqbpWHFFoCmU=</D></RSAKeyValue>";
        private const String RSA_PUBLIC_KEY = @"<RSAKeyValue><Modulus>1OKVBA0vEYJxsdEFK6GgiP2RKbIyl2tpwo8ggKCUSXdHXJ/EJuYse26JT4rxlUT5gGjxEH9arG8a+zK1SHaJvN2LjzKkkeGOWkAk8va+gEt3MeAAVrltr8+Y+TxFjzd7ZKCYk0UlcAG/kUj4EYl5gYbfIIpIspPudrZnCWsfo7k=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private const String AES_KEY = @"Kdz08JJ6PGsirYlAhny96l6XCeRdi9Z8vK";
        //JSON 형식 파일 전체 암호화
        public static String superEncrypt(String str)
        {
            return encryptAES(str);
        }
        public static String superDecrypt(String str)
        {
            return decryptAES(str);
        }

        //루트 비밀번호 자체 암호화 - RSA
        public static String encryptPassword(String pw)
        {
            return encryptRSA(pw);
        }

        public static String decryptPassword(String pw)
        {
            return decryptRSA(pw);
        }

        private static String encryptAES(String source)
        {
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Mode = CipherMode.CBC;
            rijndaelManaged.Padding = PaddingMode.PKCS7;

            rijndaelManaged.KeySize = 128;
            rijndaelManaged.BlockSize = 128;
            byte[] encoded = Encoding.UTF8.GetBytes(AES_KEY);
            byte[] keyBytes = new byte[16];
            int length = Math.Min(encoded.Length, keyBytes.Length);
            Array.Copy(encoded, keyBytes, length);
            rijndaelManaged.Key = keyBytes;
            rijndaelManaged.IV = keyBytes;

            ICryptoTransform transform = rijndaelManaged.CreateEncryptor();
            byte[] converted = Encoding.UTF8.GetBytes(source);

            return Convert.ToBase64String(transform.TransformFinalBlock(converted, 0, converted.Length));
        }

        private static String decryptAES(String crypt)
        {
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Mode = CipherMode.CBC;
            rijndaelManaged.Padding = PaddingMode.PKCS7;

            rijndaelManaged.KeySize = 128;
            rijndaelManaged.BlockSize = 128;
            byte[] encrypted = Convert.FromBase64String(crypt);
            byte[] encoded = Encoding.UTF8.GetBytes(AES_KEY);
            byte[] keyBytes = new byte[16];
            int length = Math.Min(encoded.Length, keyBytes.Length);
            Array.Copy(encoded, keyBytes, length);
            rijndaelManaged.Key = keyBytes;
            rijndaelManaged.IV = keyBytes;

            ICryptoTransform transform = rijndaelManaged.CreateDecryptor();
            byte[] converted = transform.TransformFinalBlock(encrypted, 0, encrypted.Length);

            return Encoding.UTF8.GetString(converted);
        }

        private static String encryptRSA(String source)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(RSA_PUBLIC_KEY);
            byte[] encoded = (new UTF8Encoding()).GetBytes(source);
            byte[] encrypted = rsa.Encrypt(encoded, false);

            return System.Convert.ToBase64String(encrypted);
        }

        private static String decryptRSA(String crypt)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(RSA_PRIVATE_KEY);
            byte[] converted = System.Convert.FromBase64String(crypt);
            byte[] decrypted = rsa.Decrypt(converted, false);

            return (new UTF8Encoding()).GetString(decrypted, 0, decrypted.Length);
        }
    }
}
