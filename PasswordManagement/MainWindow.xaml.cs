﻿using System;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Microsoft.TeamFoundation.Common.Internal;
using System.Security.Cryptography;

namespace PasswordManagement
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool shown_;

        private DatafileManager fileManager;
        private EncryptedDatafile datafile;
        public MainWindow()
        {
            InitializeComponent();
            this.Title = Utils.getDefaultWindowTitle();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            fileManager = new DatafileManager();
            datafile = fileManager.getCurrentValidDataFile();
            rootPasswordHint.Content = "[힌트] "+(datafile.RootPasswordHint == "" ? "없음" : datafile.RootPasswordHint);
            versionInfo.Content = Utils.getDevelopmentInfo();
        }

        private void login(object sender, RoutedEventArgs e)
        {
            int canTryLoginCode = datafile.canTryLogin();
            if(canTryLoginCode == -1)
            {
                MessageBox.Show("최근에 로그인을 너무 많이 실패했습니다. "+datafile.getNextAvailableLoginText()+" 후에 시도하십시오.");
                return;
            }

            if (datafile.isCorrectPassword(inputRootPassword.Password))
            {
                if (inputRootPassword.Password == EncryptedDatafile.DEFAULT_ROOT_PW)
                {
                    App.Current.MainWindow.Hide();
                    RootPasswordSetting rootPasswordSetting = new RootPasswordSetting(fileManager);
                    rootPasswordSetting.Show();
                }
                else
                {
                    App.Current.MainWindow.Hide();
                    PasswordManage passwordManage = new PasswordManage(fileManager);
                    passwordManage.Show();
                }
            }
            else
            {
                MessageBox.Show("비밀번호가 틀렸습니다. (시도 "+canTryLoginCode+"회 남음)");
            }
            inputRootPassword.Password = "";
        }


        private void fastEnterLogin(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                login(sender, null);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            fileManager.saveFile();
            Environment.Exit(0);
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            if (shown_) return;
            shown_ = true;
            fileManager = new DatafileManager();
            datafile = fileManager.getCurrentValidDataFile();
        }
    }
}
