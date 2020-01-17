using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// RootPasswordSetting.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class RootPasswordSetting : Window
    {
        private DatafileManager fileManager;
        private EncryptedDatafile datafile;
        public RootPasswordSetting(DatafileManager manager)
        {
            InitializeComponent();
            fileManager = manager;
            datafile = fileManager.getCurrentValidDataFile();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            App.Current.MainWindow.Show();
        }

        private void NewPasswordInput_Changed(object sender, RoutedEventArgs e)
        {
            String password = newPasswordInput.Password;
            Utils.getPasswordSecurity(password, warningLabel, confirmNewPassword);
        }

        private void ConfirmNewPassword_Click(object sender, RoutedEventArgs e)
        {
            String originalPassword = originalPasswordInput.Password;
            String newPassword = newPasswordInput.Password;
            int canTryLoginCode = datafile.canTryLogin();
            if (canTryLoginCode == -1)
            {
                MessageBox.Show("최근에 로그인을 너무 많이 실패했습니다. " + datafile.getNextAvailableLoginText() + " 후에 시도하십시오.");
                return;
            }

            if (datafile.isCorrectPassword(originalPassword))
            {
                if (newPassword == originalPassword)
                {
                    MessageBox.Show("새로운 비밀번호가 기존 비밀번호와 일치합니다!", "비밀번호 재설정 오류");
                    return;
                }
                else
                {
                    //전부 통과
                    datafile.registerNewPassword(newPassword);
                    datafile.registerNewPasswordHint(newPasswordHintInput.Text);
                    fileManager.saveFile();
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    MessageBox.Show("새로운 비밀번호로 다시 로그인하시기 바랍니다.");
                }
            }
            else
            {
                MessageBox.Show("기존 비밀번호가 틀렸습니다. (시도 " + canTryLoginCode + "회 남음)");
            }
            originalPasswordInput.Password = "";
        }
    }
}
