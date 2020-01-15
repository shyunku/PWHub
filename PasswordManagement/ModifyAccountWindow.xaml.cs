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
    /// ModifyAccountWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ModifyAccountWindow : Window
    {
        private DatafileManager fileManager;
        private EncryptedDatafile datafile;
        private String itemID = "?";
        public ModifyAccountWindow(DatafileManager manager, String id)
        {
            InitializeComponent();
            fileManager = manager;
            datafile = fileManager.getCurrentValidDataFile();
            itemID = id;
        }

        private void cancelThis(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void finallyModifyAccount(object sender, RoutedEventArgs e)
        {
            String newName = modifyAccountName.Text;
            if (newName.Length == 0)
            {
                MessageBox.Show("새 이름을 입력해주세요!", "계정 데이터 생성 오류");
            }
            else
            {
                datafile.modifyAccountTitle(itemID, newName);
                fileManager.saveFile();
                this.DialogResult = true;
                this.Close();
            }
            modifyAccountName.Text = "";
        }
    }
}
