   M S B A M L   `   `   `  ���� M  IPasswordManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PasswordManagementPasswordManagement  '    !PasswordManagement.PasswordManage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:PasswordManagement     -     � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=� � Title$&  션쿠의 비밀번호 관리자��$	��510��$
��1100�� � 	Resources  �� 
TargetType �� 	Resources �� Triggers P� Property P� Value	 �� Property
 �� Value��%l   '��       �� " �� ���� '��       " �� P�  � {� .  . ��� 	 �@J�Opacity$

 0.15Q�.��� .+��� $!��계정 키 관리 리스트��$
��Left=�$��	10,10,0,0q�$	��Top=�$��25(�$
��Bold"��� $��
키 정보��$��	0,10,10,0q�$��Right=�$	��490��$	��Top=�$��25(�$
��Bold"�
��������� -   $��accountListView��$
��Left=�$	��401��$��	10,58,0,0q�$	��Top=�$	��560�� �� View �� ! �� ColumnHeaderContainerStyle �� " ��.��� 	 �@J�IsHitTestVisible
 .  .P��� $��#�� �� Width$ 30�� �� DisplayMemberBinding �� *Index+�� $��계정 이름��$	 160�� �� *	InfoTitle+�� $��최근 수정한 날짜��$	 150�� �� *RecentModifiedTimestamp+�� $��추가한 날짜��$	 150�� �� *InitialAdditionTimestamp+�� $��	조회수��$ 60�� �� *	ViewCount+�� -   $��addAccountBtn��$
��Left=�$��
435,23,0,0q�$	��Top=�$��30��$��30��.���� $��resources/add_image.png���� -   $��deleteAccountBtn��$
��Left=�$��
470,23,0,0q�$	��Top=�$��30��$��30��{�.  .���� $ ��resources/delete_image.png��$��22���� -   $��
slideUpBtn��$
��Left=�$��
505,23,0,0q�$	��Top=�$��30��$��30��{�.  .���� $"��resources/slide_up_image.png���� -   $��slideDownBtn��$
��Left=�$��
540,23,0,0q�$	��Top=�$��30��$��30��{�.  .���� $$��resources/slide_down_image.png���� 
�������$��Right=�$	��120��$��	0,58,10,0q����	#FF9B9B9B$	��Top=�$	��490���� $��계정 정보 타이틀��$��Right=�$��
0,58,369,0q�$	��Top=�$��15(�$��10,5,5,5q��� -   $��selectedTitle��$	��N/A��$��Right=�$��	0,59,10,0q�$	��Top=�$	��335��$��13(����	#FF323232$��	10,5,15,5q�$��29��$��Right=�$��Center=�$
��Bold"��� $��추가한 날짜��$��Right=�$��
0,88,405,0q�$	��Top=�$��15(�$��10,5,5,5q��� -   $&�� selectedInitialAdditionTimestamp��$	��N/A��$��Right=�$��	0,88,10,0q�$	��Top=�$	��335��$��13(����	#FF767676$��	10,3,15,3q�$��30��$��Right=�$��Center=�$
��Bold"��� $��최근 수정한 날짜��$��Right=�$��0,118,369,0q�$	��Top=�$��15(�$��10,5,5,5q��� -	   $#��selectedRecentUpdateTimestamp��$	��N/A��$��Right=�$��
0,118,10,0q�$	��Top=�$	��335��$��13(����	#FF767676$��	10,3,15,3q�$��30��$��Right=�$��Center=�$
��Bold"��� $��	조회수��$��Right=�$��0,148,369,0q�$	��Top=�$��15(�$��10,5,5,5q�$	��131���� -
   $��selectedViewCount��$	��N/A��$��Right=�$��
0,148,10,0q�$	��Top=�$	��335��$��13(����	#FF767676$��	10,3,15,3q�$��30��$��Right=�$��Center=�$
��Bold"��� -   $��accountKeyValueView��$��Right=�$	��229��$��
0,230,10,0q�$	��Top=�$	��490�� ��  �� " ��.��� 	 �@J�IsHitTestVisible
 .  .P��� $��	선호도��$ 40�� �� *
Preference+�� $��
키 이름��$	 150�� �� *
KeyTitle+�� $��키 값��$	 290�� �� *Value+�� -   $��addKeyPairBtn��$��Right=�$��0,195,115,0q�$	��Top=�$��30��$��30��{�.  .���� $��resources/add_image.png���� $��Right=�$��
0,195,80,0q�$	��Top=�$��30��$��30��{�.  .���� $ ��resources/delete_image.png��$��22���� $��Right=�$��
0,195,45,0q�$	��Top=�$��30��$��30��{�.  .���� $"��resources/slide_up_image.png���� $��Right=�$��
0,195,10,0q�$	��Top=�$��30��$��30��{�.  .���� $$��resources/slide_down_image.png��