   M S B A M L   `   `   `  ����M  IPasswordManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PasswordManagementPasswordManagement  5   	   ,    &PasswordManagement.AddNewAccountWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:PasswordManagement     5   	     � SizeToContent$  WidthAndHeight=�5   	    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ 새로운 계정 이름��5   	   .��5      � $��15q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $"��resources/question_image.png��6   $��32��66   $��32��6A   $��2��6M   $
��20,0q�6^   �� 5   
   -   5        $��lblQuestion��5      $��1��6#   .��63   75새로 추가할 계정 이름을 입력해주세요.6J   �� 5   
   -   5        $��newAccountName��5      $��1��6(   $��1��68   $	��320��6E    �� 	MaxLength$ 25��6Q   6b   � 5   
   $��2��6   $��2��6!   $��Right=�65   $��0,15,0,0q�6Q   .+�5      �� -   5        $��60��5      $��0,0,10,0q�6#   .��6N   	_확인6S   �� 5      -   5        $��60��5      .��66   	_취소6;   5      5       5!      