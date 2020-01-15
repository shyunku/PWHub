using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PasswordManagement
{
    /// <summary>
    /// ModifyKeyPairWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ModifyKeyPairWindow : Window
    {
        private DatafileManager fileManager;
        private EncryptedDatafile datafile;
        private String encryptedAccountId;
        private String encryptedKeyPairId;

        public ModifyKeyPairWindow(DatafileManager manager, String accountId, String keyPairId)
        {
            InitializeComponent();
            fileManager = manager;
            datafile = fileManager.getCurrentValidDataFile();
            encryptedAccountId = accountId;
            encryptedKeyPairId = keyPairId;
        }

        private void cancelThis(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void finallyModifyKeyPair(object sender, RoutedEventArgs e)
        {
            String keyName = newKeyName.Text;
            String valName = newKeyValue.Text;
            if (keyName.Length == 0)
            {
                MessageBox.Show("키 이름이 비어있습니다!", "계정 데이터 생성 오류");
            }
            else if (valName.Length == 0)
            {
                MessageBox.Show("키 값이 없습니다!", "계정 데이터 생성 오류");
            }
            else
            {
                datafile.modifyKeyPair(encryptedAccountId, encryptedKeyPairId, keyName, valName);
                fileManager.saveFile();
                this.DialogResult = true;
                this.Close();
            }
        }
    }
}
