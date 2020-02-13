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
    /// RequireImportedDatafilePasswordWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RequireImportedDataPWWindow : Window
    {
        private String importedPW;

        public RequireImportedDataPWWindow(String importedPW)
        {
            InitializeComponent();
            this.importedPW = importedPW;
        }

        private void cancelThis(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void finallyCheckPassword(object sender, RoutedEventArgs e)
        {
            String inputPW = importedFilePassword.Password;
            if (!inputPW.Equals(importedPW))
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다!", "비밀번호 불일치");
                importedFilePassword.Password = "";
                return;
            }
            this.DialogResult = true;
            this.Close();
            return;
        }
    }
}
