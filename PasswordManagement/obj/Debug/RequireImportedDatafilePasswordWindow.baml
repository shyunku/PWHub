   M S B A M L   `   `   `  ����M  IPasswordManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PasswordManagementPasswordManagement  5   	   4    .PasswordManagement.RequireImportedDataPWWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:PasswordManagement     5   	     � 
ResizeMode$  NoResize=�5   	    � SizeToContent$ WidthAndHeight=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$, &데이터파일 비밀번호 불일치��5   	   .��5      � $��15q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $"��resources/question_image.png��6   $��32��66   $��32��6A   $��2��6M   $
��20,0q�6^   �� 5   
   2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve68   -   5        $��lblQuestion��5      $��1��68   .��6H   ��현재 관리자 비밀번호와 불러온 데이터파일의 암호가 일치하지 않습니다.
데이터 파일에 설정된 관리자 비밀번호를 입력해주세요.6�   G� 5   
   -   5        $��importedFilePassword��5      $��1��62   $��1��6B    G� 	MaxLength$ 25��6O   � 5   
   $��2��6   $��2��6!   $��Right=�65   $��0,15,0,0q�6Q   .+�5      �� -   5        $��60��5      $��0,0,10,0q�6#   .��6R   	_확인6W   �� 5      -   5        $��60��5      .��66   	_취소6;   5      5       5!      