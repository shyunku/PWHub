﻿#pragma checksum "..\..\PasswordManage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "38F451264498DF7941C69615966D242435D66E19640ADBFDA1492F65DEDA8C04"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using PasswordManagement;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PasswordManagement {
    
    
    /// <summary>
    /// PasswordManage
    /// </summary>
    public partial class PasswordManage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\PasswordManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView accountListView;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\PasswordManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addAccountBtn;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\PasswordManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteAccountBtn;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\PasswordManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button slideUpBtn;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\PasswordManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button slideDownBtn;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\PasswordManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label selectedTitle;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\PasswordManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label selectedInitialAdditionTimestamp;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\PasswordManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label selectedRecentUpdateTimestamp;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\PasswordManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label selectedViewCount;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\PasswordManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView accountKeyValueView;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\PasswordManage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addKeyPairBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PasswordManagement;component/passwordmanage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PasswordManage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\PasswordManage.xaml"
            ((PasswordManagement.PasswordManage)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.accountListView = ((System.Windows.Controls.ListView)(target));
            
            #line 31 "..\..\PasswordManage.xaml"
            this.accountListView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.AccountListViewSelect);
            
            #line default
            #line hidden
            
            #line 31 "..\..\PasswordManage.xaml"
            this.accountListView.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.AccountListView_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.addAccountBtn = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\PasswordManage.xaml"
            this.addAccountBtn.Click += new System.Windows.RoutedEventHandler(this.addAccountClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.deleteAccountBtn = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\PasswordManage.xaml"
            this.deleteAccountBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteAccountClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.slideUpBtn = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\PasswordManage.xaml"
            this.slideUpBtn.Click += new System.Windows.RoutedEventHandler(this.MoveUpClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.slideDownBtn = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\PasswordManage.xaml"
            this.slideDownBtn.Click += new System.Windows.RoutedEventHandler(this.MoveDownClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.selectedTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.selectedInitialAdditionTimestamp = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.selectedRecentUpdateTimestamp = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.selectedViewCount = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.accountKeyValueView = ((System.Windows.Controls.ListView)(target));
            
            #line 74 "..\..\PasswordManage.xaml"
            this.accountKeyValueView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.AccountListViewSelect);
            
            #line default
            #line hidden
            
            #line 74 "..\..\PasswordManage.xaml"
            this.accountKeyValueView.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.AccountKeyValueView_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 12:
            this.addKeyPairBtn = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\PasswordManage.xaml"
            this.addKeyPairBtn.Click += new System.Windows.RoutedEventHandler(this.AddKeyValue);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

