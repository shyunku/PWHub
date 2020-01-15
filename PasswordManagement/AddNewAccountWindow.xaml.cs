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
    /// AddNewAccountWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddNewAccountWindow : Window
    {
        private DatafileManager fileManager;
        private EncryptedDatafile datafile;
        public AddNewAccountWindow(DatafileManager manager)
        {
            InitializeComponent();
            fileManager = manager;
            datafile = fileManager.getCurrentValidDataFile();
        }

        private void cancelThis(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void finallyAddAcount(object sender, RoutedEventArgs e)
        {
            String newName = newAccountName.Text;
            if(newName.Length == 0)
            {
                MessageBox.Show("이름을 입력해주세요!", "계정 데이터 생성 오류");
            }
            else
            {
                datafile.addAccountInfo(newName);
                fileManager.saveFile();
                this.DialogResult = true;
                this.Close();
            }
            newAccountName.Text = "";
        }
    }
}
