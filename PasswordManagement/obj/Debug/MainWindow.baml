   M S B A M L   `   `   `  ����M  IPasswordManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PasswordManagementPasswordManagement  5   	   #    PasswordManagement.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:PasswordManagement     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Title$&  션쿠의 비밀번호 관리자��5	   	   $	��300��6   $	��550��6+   .��5      � .+�5   
   �� $��PWHub��6   $��Center=�6    $��
90,32,78,0q�6=   $	��Top=�5       J� RenderTransformOrigin$ 	0.151,0.5&�6(   $��35(�5      $
��Bold"�6   �� 5   
   $��루트 패스워드 : ��6   $
��Left=�6%   $��
70,120,0,0q�6@   $	��Top=�6T   $��15(�6l   G� 5   
   -   5        $��inputRootPassword��5      $��23��6/   $��185,120,78,0q�6;   $	��Top=�6Q   6i   �� 5   
   -   5        $��접속��5      $��Center=�6   $��	0,200,0,0q�5      $	��Top=�6$   $��90��6<   $��30��6G   $��15(�5      �� 5   
   -   5        $��rootPasswordHint��5   �   $4��.[힌트] 초기 비밀번호는 root입니다.��6   $��Center=�61   $��	0,155,0,0q�6N   $	��Top=�6a   $��13(�6y   ���	#FF00AC376�   �� 5   
   -   5        $��versionInfo��5   �   $��PWHub 0.0.0v by 션쿠��6   $��Right=�6-   $��0,0,0,0q�6I   $��Bottom=�6Z   $��11(�6u   6�   5      5      