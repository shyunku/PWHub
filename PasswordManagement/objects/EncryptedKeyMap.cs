using Newtonsoft.Json;
using PasswordManagement.objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagement
{
    public class EncryptedKeyMap
    {
        private String keyTitle;    //키 타이틀
        private String value_;      //키 값
        private int index;          //키 인덱스
        private String id;          //ID

        private StringSecure stringSecure;

        public string KeyTitle { get => keyTitle; set => keyTitle = value; }
        public string Value {
            get
            {
                try
                {
                    //일단 AES로 암호화 시도
                    return stringSecure.aesEncrypt(value_);
                }
                catch (NullReferenceException e)
                {
                    //stringsecure가 null
                    //강제 load 후 재시도
                    forceLoadSecureKey();
                    return stringSecure.aesEncrypt(value_);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                return null;
            }
            set
            {
                try
                {
                    value_ = stringSecure.aesDecrypt(value);
                }
                catch (NullReferenceException e)
                {
                    //강제 load 후 재시도
                    forceLoadSecureKey();
                    try
                    {
                        value_ = stringSecure.aesDecrypt(value);
                    }
                    catch (Exception e2)
                    {
                        if(e2 is FormatException || e2 is CryptographicException)
                        {
                            value_ = value;
                            return;
                        }

                        throw;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        public int Index { get => index; set => index = value; }
        public string Id { get => id; set => id = value; }

        public string PureValue
        {
            get => value_;
            set => value_ = value;
        }

        public EncryptedKeyMap(String key, String value, int index, StringSecure stringSecure)
        {
            this.KeyTitle = key;
            this.Value = value;
            this.Index = index;
            this.Id = Utils.getRandomKey();

            this.stringSecure = stringSecure;
        }

        public EncryptedKeyMap()
        {
            //raw data import
        }

        public EncryptedKeyMap(String key, String value, int index, String id)
        {
            //raw data import 후 변환 용도
            this.KeyTitle = key;
            this.Value = value;
            this.Index = index;
            this.Id = id;
        }

        private void forceLoadSecureKey()
        {
            try
            {
                FileStream fileStream = new FileStream(DatafileManager.SECURE_KEY_STORAGE_NAME, FileMode.Open);
                BinaryReader reader = new BinaryReader(fileStream, Encoding.Default);
                String buffer = reader.ReadString();
                String decrypted = StringSecure.decodeBase64(buffer);
                reader.Close();
                fileStream.Close();
                //Utils.log("Secure Key force-loaded!");
                SecureKeyPair loadedSecureKey = JsonConvert.DeserializeObject<SecureKeyPair>(decrypted);
                stringSecure = new StringSecure(loadedSecureKey);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public RawKeyMap convertToRawKeyMap()
        {
            RawKeyMap rawKeyMap = new RawKeyMap
            {
                rKeyTitle = keyTitle,
                rValue_ = PureValue,
                rIndex = index,
                rId = id
            };

            return rawKeyMap;
        }
    }
}
