using Newtonsoft.Json;
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
        private const String DATA_FILE_NAME = "datafile.dat";
        private EncryptedDatafile datafile;

        public DatafileManager()
        {
            if (File.Exists(DATA_FILE_NAME))
            {
                //파일 존재함, 이후에 유효한지 검사
                loadFile();
            }
            else
            {
                //파일 없음, 생성
                datafile = new EncryptedDatafile();
            }
        }

        //파일이 유효하면 Load하여 가져오고, 아니면 새로운 파일 생성
        public EncryptedDatafile getCurrentValidDataFile()
        {
            return this.datafile;
        }

        public void saveFile(EncryptedDatafile updatedDatafile)
        {
            try
            {
                FileStream fileStream = new FileStream(DATA_FILE_NAME, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(fileStream);
                writer.Write(JsonConvert.SerializeObject(updatedDatafile, Formatting.Indented));
                writer.Close();
                fileStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void saveFile()
        {
            try
            {
                FileStream fileStream = new FileStream(DATA_FILE_NAME, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(fileStream);
                String buffer = JsonConvert.SerializeObject(this.datafile, Formatting.Indented);
                String encrypted = StringSecure.superEncrypt(buffer);
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
                BinaryWriter writer = new BinaryWriter(fileStream);
                String buffer = JsonConvert.SerializeObject(this.datafile, Formatting.Indented);
                String encrypted = StringSecure.superEncrypt(buffer);
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

        public void loadFile()
        {
            try
            {
                FileStream fileStream = new FileStream(DATA_FILE_NAME, FileMode.Open);
                BinaryReader reader = new BinaryReader(fileStream);
                String buffer = reader.ReadString();
                String decrypted = StringSecure.superDecrypt(buffer);
                reader.Close();
                fileStream.Close();
                Utils.log("Data loaded!");
                this.datafile = JsonConvert.DeserializeObject<EncryptedDatafile>(decrypted);
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
                BinaryReader reader = new BinaryReader(fileStream);
                String buffer = reader.ReadString();
                String decrypted = StringSecure.superDecrypt(buffer);
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
    }
}
