   M S B A M L   `   `   `  ����H  DCarDealership, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CarDealershipCarDealership  5          CarDealership.AdminOrders   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:CarDealership     5        N� Title$  	AdminCars��5      .��5
      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   �� 5      $��83 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��500 �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ OrderDataGrid��5      $��0��5      $��1��5      $��3��5      $��Center=�5      $	��Top=�5      $��30q�5      
�������
�������$��1q�5       $	��500��5!      $
��1100��5"         AutoGenerateColumns .     ColumnHeaderHeight$ 40Q�5$         	RowHeight$ 35Q�5%         GridLinesVisibility$
 None=�5&         CanUserResizeColumns .  	   CanUserResizeRows	 .  
   HeadersVisibility$
 Column=�5)         ColumnHeaderStyle 5,      �� 5-       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5.      ��  �� Property � �� �� Value �#E74C3C63   �� 5/       � ��
 �����63   �� 50       � ��$
 Bold"�63   �� 51       � ��$ Century Gothic)�63   �� 52       � ��$ Center=�6C   �� 53       � ��$ 16(�61   �� 54       � ��
 �����64   �� 55       � ��$ 0,0,1,1q�68   56         RowStyle 5:      �� 5;      )  #System.Windows.Controls.DataGridRow"  6   .�5<      ��  � ��$ 13(�61   �� 5=       � ��
 �����63   �� 5>       � ��
 �����64   �� 5?       � ��$ 0,0,0,1q�68   �� 5@       � ��$
 Left=�6C   5A         	CellStyle 5E      �� 5F      *  $System.Windows.Controls.DataGridCell"  6   .�5G      ��  � ��$ 0q�60   �� 5H       � �� 5I      �� 5J       �� 
TargetType"  6.   .R�5K   "   �� #��z��5L      
�������$��1q�5N       �� CornerRadius$ 10��5O       �� Padding$ 5q�5P      ._�5Q   &   �� $��Center=�67   $��Center=�6T   5R   #   5S      5U       �� Triggers 5V      �� 5W       �� Binding 6&   �� *Price+ �� Value High6@   .a�5X      ��  � ��
 �r���6;   �� 5Y       � ��
 �����6;   5Z      5\         Columns 5`      0  *System.Windows.Controls.DataGridTextColumn  5a      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+ �� Mode$ OneWay=�6U     5b      $ Дата заказа��6%   $ * 6f    6:   �� *
order_date+$ OneWay=�6f     5c      $ Цена��6%   $ * 6Z    63   �� *price+$ OneWay=�6Z     5d      $ Автомобиль��6%   $ * 6^    69   �� *Car+$ OneWay=�6^     5e      $ Статус��6%   $ * 6]    65   �� *Status+$ OneWay=�6]     5f      $ Клиент��6%   $	 250 6]    65   �� *Client+$ OneWay=�6]     5g      $ Менеджер��6%   $	 250 6`    67   �� *	Manager+$ OneWay=�6`   5i      � 5k   
   $��2��6   $��1��6   $��2��6,   .+�5m      �� -   5         ��Name$ 	AddButton��5m      $��0��6(   $��Добавить��68   $��Center=�5n      $��Center=�63   $
��Left=�6W   $��24(�5o      $��Century Gothic)�6   $
��50px��6;   $��150px��6I   $��	150,0,0,0q�6W   $��4��5p      6   �� 5r      -   5        $ ChangeButton��5r      $��0��6+   $��Изменить��6;   $��Center=�5s      $��Center=�63   $��Center=�6W   $��24(�5t      $��Century Gothic)�6   $
��50px��6;   $��150px��6I   $��0,0,50,0q�6W   $��4��5u      6   �� 5w      -   5        $ DeleteButton��5w      $��0��6+   $��Удалить��6;   $��Center=�5x      $��Center=�63   $��Right=�6W   $��24(�5y      $��Century Gothic)�6   $
��50px��6;   $��150px��6I   $��	0,0,200,0q�6W   $��4��5z      6   5{      5|      5}      