   M S B A M L   `   `   `  ����H  DCarDealership, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CarDealershipCarDealership  5   	       CarDealership.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CarDealership     5   	     � Title$  Авторизация��5      $	��520��6$   $	��800��61   
�������.��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $
��140* �6   �� 5      $
��140* �6   �� 5      $
��150* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��400 �6   �� 5      $��* �6   .+�5   
   �� $��80��6   $��Center=�6    $��0��6;   $��3��6K   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #E74C3C��6#    � Offset$	 0.0Q�63   � 5      $ #2C3E50��6#   $	 1.0Q�63   5      5      �� 5    
   $��Авторизация��6   
�������$��30(�69   $��Century Gothic)�6G   $��1��6c   $��Center=�6s   $��Center=�6�   �� 5!   
   $��Resources/logo.png��6   $��0,0,20,0q�6,   $��3��6>   $��0��6N   $��Right=�6[   6y   � 5$   
   $��1��6   $��1��6   .+�5%      �� $��
Логин��6   
���   �$��24(�67   $��	Sergoe UI)�6E   $��Center=�5&      $	��Top=�60   $
��10pxq�6H   �� 5'      -   5         ��Name$ LoginTextBox��5'      $
��60px��6,   $
��10pxq�6:   $��Center=�6H   $��20(�6j   $��	Sergoe UI)�6x   $��Bottom=�6�   5(      � 5+   
   $��2��6   $��1��6   .+�5,      �� $��Пароль��6   
���   �$��24(�68   $��	Sergoe UI)�6F   $��Center=�5-      $	��Top=�6.   $
��10pxq�6F   G� 5.      -   5         G�Name$ PasswordTextBox��5.      $
��60px��63   $
��10pxq�6A   $��Center=�6O   $��20(�5/      $��	Sergoe UI)�6(   $��Bottom=�6?   6\   50      �� 52   
   -   5        	 ��Name$	 LoginButton��52      $��1��6&   $��
Войти��66   $��Center=�53      $��Center=�63   $��24(�54      $��	Sergoe UI)�6   $
��50px��66   $��300px��6D   $��4��55      6   �� 56   
   -   5        
 ��Name$
 IHaveNoAccountLabel��56      $��	Underline{�61   $3��-Я ещё не зарегистрирован��6M   
���   �$��20(�6�   $��	Sergoe UI)�6�   $��Center=�57      $��Bottom=�60   $��10��6K   $��1��6Y   $��Italic$�6i    � Cursor$
 Hand��6|   $��10q�6�   6�   58      59      