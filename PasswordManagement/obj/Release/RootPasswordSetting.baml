   M S B A M L   `   `   `  ���� M  IPasswordManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PasswordManagementPasswordManagement  ,    &PasswordManagement.RootPasswordSetting   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:PasswordManagement     -     � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=� � Title$ 비밀번호 변경��$	��350��$	��550��.��� .+��� $3��-관리자용 비밀번호를 변경하세요.��$��Center=�$��0,40,0,0q�$	��Top=�$��25(�$
��Bold"��� $h��b항상 루트 패스워드는 쉽게 기억할 수 있고, 복잡한 것으로 선택하십시오.��$��Center=�$��0,82,0,0q�$	��Top=�$��11(�
���  ���� $T��N영문, 숫자, 특수기호를 조합하여 만드는 것을 추천합니다.��$��Center=�$��	0,102,0,0q�$	��Top=�$��11(�
���  ���� $��기존 비밀번호:��$��Right=�$��0,137,350,0q�$	��Top=�$��12(�$
��Bold"�G� -   $��originalPasswordInput��$
��Left=�$��198,142,0,0q�$	��Top=�$	��230�� G� 	MaxLength$ 16���� $��새로운 비밀번호:��$��Right=�$��0,167,350,0q�$	��Top=�$��12(�$
��Bold"�G� -   $��newPasswordInput��$
��Left=�$��198,172,0,0q�$	��Top=�$	��230��$ 16���� $��힌트:��$��Right=�$��0,197,350,0q�$	��Top=�$��12(�$
��Bold"��� -   $��newPasswordHintInput��$
��Left=�$��198,202,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��230�� �� 	MaxLength$ 16���� -   $��warningLabel��$_��Y힌트는 추후에 비밀번호를 잊어버렸을 때 도움이 될 키워드입니다.��$��Center=�$��	0,233,0,0q�$	��Top=�$��11(�$
��Bold"�
���  ���� -   $��confirmNewPassword��$��승인��$��Center=�$��	0,274,0,0q�$	��Top=�$��76��$��25��{�.  