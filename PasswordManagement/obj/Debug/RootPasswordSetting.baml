   M S B A M L   `   `   `  ����M  IPasswordManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PasswordManagementPasswordManagement  5   	   ,    &PasswordManagement.RootPasswordSetting   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:PasswordManagement     5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ 비밀번호 변경��5   	   $	��350��6   $	��550��6&   .��5      � .+�5   
   �� $3��-관리자용 비밀번호를 변경하세요.��6   $��Center=�6,   $��0,40,0,0q�5      $	��Top=�6"   $��25(�6:   $
��Bold"�6H   �� 5   
   $h��b항상 루트 패스워드는 쉽게 기억할 수 있고, 복잡한 것으로 선택하십시오.��6   $��Center=�6C   $��0,82,0,0q�5      $	��Top=�6"   $��11(�6:   
���  ��6H   �� 5   
   $T��N영문, 숫자, 특수기호를 조합하여 만드는 것을 추천합니다.��6   $��Center=�6;   $��	0,102,0,0q�5      $	��Top=�6#   $��11(�6;   
���  ��6I   �� 5   
   $��기존 비밀번호:��6   $��Right=�6#   $��0,137,350,0q�6?   $	��Top=�6T   $��12(�5      $
��Bold"�6   G� 5   
   -   5        $��originalPasswordInput��5      $
��Left=�5      $��198,142,0,0q�61   $	��Top=�6F   $	��230��6^    G� 	MaxLength$ 16��6j   5      �� 5   
   $��새로운 비밀번호:��6   $��Right=�6$   $��0,167,350,0q�6@   $	��Top=�6U   $��12(�5      $
��Bold"�6   G� 5   
   -   5        $��newPasswordInput��5      $
��Left=�5      $��198,172,0,0q�61   $	��Top=�6F   $	��230��6^   $ 16��6j   5   .   �� 5   
   $��힌트:��6   $��Right=�6   $��0,197,350,0q�6:   $	��Top=�6O   $��12(�5       $
��Bold"�6   �� 5!   
   -   5        $��newPasswordHintInput��5#      $
��Left=�5!      $��198,202,0,0q�6-    �� TextWrapping$
 Wrap=�6B   $�� ��5"      $	��Top=�6   $	��230��62    �� 	MaxLength$ 16��6>   5#      �� 5%   
   -   5        $��warningLabel��5&   A   $_��Y힌트는 추후에 비밀번호를 잊어버렸을 때 도움이 될 키워드입니다.��5%      $��Center=�6>   $��	0,233,0,0q�6[   $	��Top=�6n   $��11(�5&      $
��Bold"�6   
���  ��6A   �� 5'   
   -   5        $��confirmNewPassword��5(   :   $��승인��5'      $��Center=�6   $��	0,274,0,0q�6;   $	��Top=�6N   $��76��5(      $��25��6   {�.  6T   5)      5*      