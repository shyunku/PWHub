﻿using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PasswordManagement
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PasswordManage : Window
    {
        private DatafileManager fileManager;
        private EncryptedDatafile datafile;
        private List<AccountInfo> listItems = new List<AccountInfo>();

        private String previousSelectedAccountId = "@";

        public PasswordManage(DatafileManager datafileManager)
        {
            InitializeComponent();
            this.Title = Utils.getDefaultWindowTitle();

            fileManager = datafileManager;
            updateData();
            accountListView.ItemsSource = datafile.AccountTable;
        }

        /* ------------------------------------------- 계정 키 리스트뷰 ------------------------------------------- */

        //계정 추가
        private void addAccountClick(object sender, RoutedEventArgs e)
        {
            AddNewAccountWindow addNewAccountWindow = new AddNewAccountWindow(fileManager);
            bool? result = addNewAccountWindow.ShowDialog();
            if (result == true)
            {
                updateData();
                accountListView.ItemsSource = datafile.AccountTable;
                itemUnselected();
            }
        }

        //계정 이름 수정
        private void modifyAccountClick(object sender, RoutedEventArgs e)
        {
            AccountInfo sourceData = (AccountInfo)accountListView.SelectedItem;
            if (sourceData == null) return;

            ModifyAccountWindow modifyAccountWindow = new ModifyAccountWindow(fileManager, sourceData.ID_key);
            bool? result = modifyAccountWindow.ShowDialog();
            if (result == true)
            {
                updateData();
                accountListView.ItemsSource = datafile.AccountTable;
                itemUnselected();
            }
        }

        //계정 정보 삭제
        private void DeleteAccountClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("이 계정 정보를 삭제하시겠습니까?\n 내부의 모든 키페어가 삭제되며, 이 작업은 복구될 수 없습니다!",
                "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                AccountInfo sourceData = (AccountInfo)accountListView.SelectedItem;
                datafile.deleteAccountInfo(sourceData.ID_key);
                accountListView.ItemsSource = datafile.AccountTable;
                accountListView.Items.Refresh();
                deselect();
            }
        }

        //계정 정보 위로 이동
        private void MoveUpClick(object sender, RoutedEventArgs e)
        {
            AccountInfo sourceData = (AccountInfo)accountListView.SelectedItem;
            datafile.moveUp(sourceData.ID_key);
            accountListView.ItemsSource = datafile.AccountTable;
            accountListView.Items.Refresh();
            updateMoveItemEnableProperty(sourceData.ID_key);
        }

        //계정 정보 아래로 이동
        private void MoveDownClick(object sender, RoutedEventArgs e)
        {
            AccountInfo sourceData = (AccountInfo)accountListView.SelectedItem;
            datafile.moveDown(sourceData.ID_key);
            accountListView.ItemsSource = datafile.AccountTable;
            accountListView.Items.Refresh();
            updateMoveItemEnableProperty(sourceData.ID_key);
        }

        //계정 클릭 이벤트
        private void LightClick(object sender, MouseButtonEventArgs e)
        {
            accountListView.ItemsSource = datafile.AccountTable;
            accountListView.Items.Refresh();

            //재선택으로 취소된 경우 고려
            if (accountListView.SelectedIndex == -1)
            {
                deselect();
                return;
            }

            itemSelected();
            AccountInfo sourceData = (AccountInfo)accountListView.SelectedItem;

            //계정 키페어 리스트 업데이트
            accountKeyValueView.ItemsSource = sourceData.KeyBundle;

            if(previousSelectedAccountId != sourceData.ID_key)
            {
                datafile.viewedInfo(sourceData.ID_key);
                previousSelectedAccountId = sourceData.ID_key;
            }

            //계정 기본 정보 로드
            accountTitle.Content = "키 정보 - " + sourceData.InfoTitle;
            selectedInitialAdditionTimestamp.Content = sourceData.InitialAdditionTimestamp;
            selectedRecentUpdateTimestamp.Content = sourceData.RecentModifiedTimestamp;
            selectedViewCount.Content = sourceData.ViewCount + " 회";

            infoItemUnselected();
        }

        //드래그 하여 바깥으로 나가는 경우 방지
        private void ListViewItem_DragLeave(object sender, DragEventArgs e)
        {
            AccountInfo sourceData = (AccountInfo)accountListView.SelectedItem;
            if (sourceData == null) return;
            updateMoveItemEnableProperty(sourceData.ID_key);
        }

        //계정 리스트 외부영역 선택 시 강제 선택 해제
        private void AccountListView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            deselect();
        }

        //계정 리스트 아이템 강제 선택 해제
        private void deselect()
        {
            accountListView.SelectedItem = null;
            itemUnselected();
        }

        //계정 리스트 아이템 선택 시 호출
        private void itemSelected()
        {
            deleteAccountBtn.IsEnabled = true;
            modifyAccountBtn.IsEnabled = true;

            AccountInfo sourceData = (AccountInfo)accountListView.SelectedItem;
            if (sourceData == null) return;
            addKeyPairBtn.IsEnabled = true;
            addGeneralKeyPairBtn.IsEnabled = true;
            updateMoveItemEnableProperty(sourceData.ID_key);
        }

        //계정 리스트 아이템 선택 취소 시 호출
        private void itemUnselected()
        {
            const String nothing = "N/A";
            addKeyPairBtn.IsEnabled = false;
            addGeneralKeyPairBtn.IsEnabled = false;
            deleteAccountBtn.IsEnabled = false;
            modifyAccountBtn.IsEnabled = false;
            slideUpBtn.IsEnabled = false;
            slideDownBtn.IsEnabled = false;

            //정보 초기화
            accountTitle.Content = "키 정보";
            selectedInitialAdditionTimestamp.Content = nothing;
            selectedRecentUpdateTimestamp.Content = nothing;
            selectedViewCount.Content = nothing;

            //계정 키값 리스트 비우기
            accountKeyValueView.ItemsSource = null;

            infoItemUnselected();
        }

        //계정 정보 아이템 property 관련 버튼 enable 업데이트
        private void updateMoveItemEnableProperty(String id)
        {
            slideUpBtn.IsEnabled = datafile.isSlideUpable(id);
            slideDownBtn.IsEnabled = datafile.isSlideDownable(id);
        }

        /* ------------------------------------------- 계정 정보 키값 리스트뷰 ------------------------------------------- */

        //정보 싱글 클릭 이벤트
        private void infoLightClick(object sender, MouseButtonEventArgs e)
        {
            EncryptedKeyMap data = (EncryptedKeyMap)accountKeyValueView.SelectedItem;
            if (data == null) return;

            deleteKeyPairBtn.IsEnabled = true;
            modifyKeyPairBtn.IsEnabled = true;
        }

        //기본키값 추가
        private void AddGeneralKeyValue(object sender, RoutedEventArgs e)
        {
            AccountInfo sourceData = (AccountInfo)accountListView.SelectedItem;
            if (sourceData == null) return;
            //아이디 추가
            if (!datafile.getAccountInfo(sourceData.ID_key).isExist("아이디"))
            {
                datafile.getAccountInfo(sourceData.ID_key).addKeyPair("아이디", "-");
            }
            //비번 추가
            if (!(datafile.getAccountInfo(sourceData.ID_key).isExist("비밀번호")||
                datafile.getAccountInfo(sourceData.ID_key).isExist("비번")||
                datafile.getAccountInfo(sourceData.ID_key).isExist("Password")))
            {
                datafile.getAccountInfo(sourceData.ID_key).addKeyPair("비밀번호", "-");
            }

            accountKeyValueView.ItemsSource = datafile.getAccountInfo(sourceData.ID_key).KeyBundle;
            accountKeyValueView.Items.Refresh();
            deselectInfo();
        }

        //키값 추가
        private void AddKeyValue(object sender, RoutedEventArgs e)
        {
            AccountInfo sourceData = (AccountInfo)accountListView.SelectedItem;
            if (sourceData == null)
            {
                //키페어 추가 이후 계정 리스트 해당 아이템을 재클릭시 취소됨: 이 때 추가할 시 나타나는 오류
                //고칠 수 없는 듯함, 버튼 disable로 대체
                itemUnselected();
                return;
            }
            String selectedID = sourceData.ID_key;
            AddNewKeyPairWindow newKeyPairWindow = new AddNewKeyPairWindow(fileManager, selectedID);
            bool? result = newKeyPairWindow.ShowDialog();
            if (result == true)
            {
                updateKeyValueItems(selectedID, sourceData);
            }
        }

        //키값 삭제
        private void deleteKeyPair(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("이 키페어를 삭제하시겠습니까?\n 이 작업은 복구될 수 없습니다!",
    "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                EncryptedKeyMap data = (EncryptedKeyMap)accountKeyValueView.SelectedItem;
                AccountInfo sourceData = (AccountInfo)accountListView.SelectedItem;
                if (sourceData == null || data == null) return;
                datafile.deleteKeyPair(sourceData.ID_key, data.Id);

                accountKeyValueView.ItemsSource = datafile.getAccountInfo(sourceData.ID_key).KeyBundle;
                accountKeyValueView.Items.Refresh();
                deselectInfo();
            }
        }

        //키값 변경
        private void modifyKeyPair(object sender, RoutedEventArgs e)
        {
            AccountInfo sourceData = (AccountInfo)accountListView.SelectedItem;
            EncryptedKeyMap data = (EncryptedKeyMap)accountKeyValueView.SelectedItem;
            if (sourceData == null || data == null) return;

            ModifyKeyPairWindow modifyKeyPairWindow = new ModifyKeyPairWindow(fileManager, sourceData.ID_key, data.Id);
            bool? result = modifyKeyPairWindow.ShowDialog();
            if (result == true)
            {
                updateData();
                accountKeyValueView.ItemsSource = sourceData.KeyBundle;
                accountKeyValueView.Items.Refresh();
                deselectInfo();
            }
        }

        //키값 클립보드에 복사
        private void CopyToClipBoard(object sender, RoutedEventArgs e)
        {
            DependencyObject obj = (DependencyObject)e.OriginalSource;
            while(!(obj is ListViewItem))
            {
                try
                {
                    obj = VisualTreeHelper.GetParent(obj);
                }
                catch
                {
                    return;
                }
            }
            ListViewItem item = (ListViewItem)obj;
            EncryptedKeyMap copied = (EncryptedKeyMap)item.Content;

            Clipboard.SetText(copied.PureValue);
            //MessageBox.Show("복사했습니다!");
        }

        //소스 데이터와 ID로 직접 수정
        private void updateKeyValueItems(String id, AccountInfo source)
        {
            updateData();
            AccountInfo updatedData = datafile.getAccountInfo(id);
            accountKeyValueView.ItemsSource = updatedData.KeyBundle;  
        }

        //계정 키값 리스트 외부영역 선택 시 강제 선택 해제
        private void AccountKeyValueView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            deselectInfo();
        }

        //계정 키값 리스트 아이템 강제 선택 해제
        private void deselectInfo()
        {
            accountKeyValueView.SelectedItem = null;
            accountKeyValueView.Items.Refresh();
            infoItemUnselected();
        }

        //계정 키값 리스트 아이템 선택 취소 시 호출
        private void infoItemUnselected()
        {
            deleteKeyPairBtn.IsEnabled = false;
            modifyKeyPairBtn.IsEnabled = false;
        }

        /* ------------------------------------------- TOOL ------------------------------------------- */

        //초기 데이터 업데이트
        private void updateData()
        {
            fileManager.loadFiles();
            datafile = fileManager.getCurrentValidDataFile();
        }

        //윈도우 종료 이벤트
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            fileManager.saveFile();
            Environment.Exit(0);
        }

        //암호화된 상태로 내보내기
        private void ExportWholeDataAsEncrypted(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "데이터 파일 암호화 상태로 내보내기";
            saveFileDialog.Filter = "Data Files (*." + DatafileManager.ENCODED_FILE_EXTENSION + ")|*." + DatafileManager.ENCODED_FILE_EXTENSION + "";
            saveFileDialog.ShowDialog();
            
            if(saveFileDialog.FileName != "")
            {
                fileManager.saveFile(saveFileDialog.FileName);
            }
        }

        //비암호화 상태로 내보내기
        private void ExportWholeDataAsDecrypted(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "데이터 파일 비암호화 상태로 내보내기 (not recommended)";
            saveFileDialog.Filter = "Data Files (*." + DatafileManager.DECODED_FILE_EXTENSION + ")|*." + DatafileManager.DECODED_FILE_EXTENSION;
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                fileManager.saveFileAsRaw(saveFileDialog.FileName);
            }
        }

        //암호화 데이터로 덮어쓰기
        private void ImportToOverwriteEncryptedData(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "새로운 암호화 데이터로 기존 파일 덮어쓰기";
            openFileDialog.Filter = "Data Files (*." + DatafileManager.ENCODED_FILE_EXTENSION + ")|*." + DatafileManager.ENCODED_FILE_EXTENSION;            openFileDialog.ShowDialog();

            if(openFileDialog.FileName != "")
            {
                MessageBoxResult result = MessageBox.Show("새로운 데이터로 덮어쓰시겠습니까?\n기존 데이터는 복구할 수 없습니다!",
                    "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    fileManager.importData(openFileDialog.FileName);
                    updateData();
                    accountListView.ItemsSource = datafile.AccountTable;
                    accountListView.Items.Refresh();
                    itemUnselected();
                }
            }
        }

        //비암호화 데이터로 덮어쓰기
        private void ImportToOverwriteDecryptedData(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "새로운 비암호화 데이터로 기존 파일 덮어쓰기";
            openFileDialog.Filter = "Data Files (*."+DatafileManager.DECODED_FILE_EXTENSION+ ")|*." + DatafileManager.DECODED_FILE_EXTENSION;
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                MessageBoxResult result = MessageBox.Show("새로운 데이터로 덮어쓰시겠습니까?\n기존 데이터는 복구할 수 없습니다!",
                    "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    fileManager.importRawData(openFileDialog.FileName);
                    updateData();
                    accountListView.ItemsSource = datafile.AccountTable;
                    accountListView.Items.Refresh();
                    itemUnselected();
                }
            }
        }

        private void ResetRootPassword(object sender, RoutedEventArgs e)
        {
            this.Hide();
            RootPasswordSetting rootPasswordSetting = new RootPasswordSetting(fileManager);
            rootPasswordSetting.ShowDialog();
        }

        //전체 초기화
        private void initializeAll(object sender, RoutedEventArgs e)
        {

        }
    }
}
