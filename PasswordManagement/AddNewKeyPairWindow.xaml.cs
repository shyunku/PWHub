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
    /// AddNewKeyPairWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddNewKeyPairWindow : Window
    {
        private DatafileManager fileManager;
        private EncryptedDatafile datafile;
        private String ID_KEY;
        public AddNewKeyPairWindow(DatafileManager manager, String id)
        {
            InitializeComponent();
            fileManager = manager;
            datafile = fileManager.getCurrentValidDataFile();
            ID_KEY = id;
        }

        private void cancelThis(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void finallyAddKeyPair(object sender, RoutedEventArgs e)
        {
            String keyName = newKeyName.Text;
            String value = newKeyValue.Text;

            if (keyName.Length == 0)
            {
                MessageBox.Show("키 이름을 입력해주세요!", "키 데이터 생성 오류");
            }else if (value.Length == 0)
            {
                MessageBox.Show("키값을 입력해주세요!", "키 데이터 생성 오류");
            }
            else
            {
                AccountInfo accountInfo = datafile.getAccountInfo(ID_KEY);
                accountInfo.addKeyPair(keyName, value);
                datafile.setAccountInfo(accountInfo);

                fileManager.saveFile();
                this.DialogResult = true;
                this.Close();
                return;
            }
        }
    }
}
