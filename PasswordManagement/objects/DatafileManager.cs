using Newtonsoft.Json;
using PasswordManagement.objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagement
{
    public class DatafileManager
    {
        private const String DATA_FILE_NAME = "datafile";
        public const String ENCODED_FILE_EXTENSION = "ecd";
        public const String DECODED_FILE_EXTENSION = "ncd";
        public const String SECURE_KEY_STORAGE_NAME = "keyStore.ksf";
        private EncryptedDatafile datafile;

        private StringSecure stringSecure;

        public DatafileManager()
        {
            if (File.Exists(getEncodedDatafileName()))
            {
                //파일 존재함, 이후에 유효한지 검사
                loadFiles();
            }
            else
            {
                //파일 없음, 생성
                SecureKeyPair secureKeyPair = new SecureKeyPair();
                stringSecure = new StringSecure(secureKeyPair);
                datafile = new EncryptedDatafile(stringSecure);
                saveSecureKeyFile(secureKeyPair);
            }
        }

        //파일이 유효하면 Load하여 가져오고, 아니면 새로운 파일 생성
        public EncryptedDatafile getCurrentValidDataFile()
        {
            return this.datafile;
        }


        public void saveFile()
        {
            try
            {
                FileStream fileStream = new FileStream(getEncodedDatafileName(), FileMode.Create);
                BinaryWriter writer = new BinaryWriter(fileStream, Encoding.Default);
                String buffer = JsonConvert.SerializeObject(this.datafile, Formatting.Indented);
                String encrypted = buffer;
                writer.Write(encrypted);
                writer.Close();
                fileStream.Close();
                Utils.log("Data saved!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void saveFile(String filepathName)
        {
            try
            {
                FileStream fileStream = new FileStream(filepathName, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(fileStream, Encoding.Default);
                String buffer = JsonConvert.SerializeObject(this.datafile, Formatting.Indented);
                String encrypted = buffer;
                writer.Write(encrypted);
                writer.Close();
                fileStream.Close();
                Utils.log("Data saved to "+filepathName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void saveFileAsRaw(String filepathName)
        {
            try
            {
                FileStream fileStream = new FileStream(filepathName, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(fileStream, Encoding.Default);
                String buffer = JsonConvert.SerializeObject(datafile.convertToRawData(), Formatting.Indented);
                writer.Write(buffer);
                writer.Close();
                fileStream.Close();
                Utils.log("Raw Data saved to " + filepathName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void saveSecureKeyFile(SecureKeyPair secureKeyPair)
        {
            try
            {
                FileStream fileStream = new FileStream(SECURE_KEY_STORAGE_NAME, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(fileStream, Encoding.Default);
                String buffer = JsonConvert.SerializeObject(secureKeyPair, Formatting.Indented);
                writer.Write(StringSecure.encodeBase64(buffer));
                writer.Close();
                fileStream.Close();
                Utils.log("Secure Key saved to " + SECURE_KEY_STORAGE_NAME);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void loadFiles()
        {
            try
            {
                FileStream fileStream = new FileStream(SECURE_KEY_STORAGE_NAME, FileMode.Open);
                BinaryReader reader = new BinaryReader(fileStream, Encoding.Default);
                String buffer = reader.ReadString();
                String decrypted = StringSecure.decodeBase64(buffer);
                reader.Close();
                fileStream.Close();
                Utils.log("Secure Key loaded!");
                SecureKeyPair loadedSecureKey = JsonConvert.DeserializeObject<SecureKeyPair>(decrypted);
                this.stringSecure = new StringSecure(loadedSecureKey);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            try
            {
                FileStream fileStream = new FileStream(getEncodedDatafileName(), FileMode.Open);
                BinaryReader reader = new BinaryReader(fileStream, Encoding.Default);
                String buffer = reader.ReadString();
                String decrypted = buffer;
                reader.Close();
                fileStream.Close();
                Utils.log("Data loaded!");
                datafile = JsonConvert.DeserializeObject<EncryptedDatafile>(decrypted);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void importData(String filepathName)
        {
            try
            {
                FileStream fileStream = new FileStream(filepathName, FileMode.Open);
                BinaryReader reader = new BinaryReader(fileStream, Encoding.Default);
                String buffer = reader.ReadString();
                String decrypted = buffer;
                reader.Close();
                fileStream.Close();
                Utils.log("Data loaded from "+filepathName);
                this.datafile = JsonConvert.DeserializeObject<EncryptedDatafile>(decrypted);
                saveFile();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void importRawData(String filepathName)
        {
            try
            {
                FileStream fileStream = new FileStream(filepathName, FileMode.Open);
                BinaryReader reader = new BinaryReader(fileStream, Encoding.Default);
                String buffer = reader.ReadString();
                reader.Close();
                fileStream.Close();
                Utils.log("Raw Data loaded from " + filepathName);
                RawDatafile rawFile = JsonConvert.DeserializeObject<RawDatafile>(buffer);
                this.datafile = rawFile.convertToEncryptedData(stringSecure);
                //키가 다른 것에 대한 exception 처리할 것
                saveFile();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private String getEncodedDatafileName()
        {
            return DATA_FILE_NAME + "." + ENCODED_FILE_EXTENSION;
        }

        private String getDecodedDatafileName()
        {
            return DATA_FILE_NAME + "." + DECODED_FILE_EXTENSION;
        }
    }
}
