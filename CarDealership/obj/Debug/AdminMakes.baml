   M S B A M L   `   `   `  ����H  DCarDealership, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CarDealershipCarDealership  5          CarDealership.AdminMakes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:CarDealership     5        N� Title$  
AdminMakes��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   �� 5      $��83 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��500 �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ MakesDataGrid��5      $��0��5      $��1��5      $��3��5      $��Center=�5      $	��Top=�5      $��30q�5      
�������
�������$��1q�5!      $	��500��5"      $
��1100��5#         AutoGenerateColumns .     ColumnHeaderHeight$ 40Q�5%         	RowHeight$ 35Q�5&         GridLinesVisibility$
 None=�5'         CanUserResizeColumns .  	   CanUserResizeRows	 .  
   HeadersVisibility$
 Column=�5*         ColumnHeaderStyle 5-      �� 5.       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5/      ��  �� Property � �� �� Value �#E74C3C63   �� 50       � ��
 �����63   �� 51       � ��$
 Bold"�63   �� 52       � ��$ Century Gothic)�63   �� 53       � ��$ Center=�6C   �� 54       � ��$ 16(�61   �� 55       � ��
 �����64   �� 56       � ��$ 0,0,1,1q�68   57         RowStyle 5;      �� 5<      )  #System.Windows.Controls.DataGridRow"  6   .�5=      ��  � ��$ 13(�61   �� 5>       � ��
 �����63   �� 5?       � ��
 �����64   �� 5@       � ��$ 0,0,0,1q�68   �� 5A       � ��$
 Left=�6C   5B         	CellStyle 5F      �� 5G      *  $System.Windows.Controls.DataGridCell"  6   .�5H      ��  � ��$ 0q�60   �� 5I       � �� 5J      �� 5K       �� 
TargetType"  6.   .R�5L   "   �� #��z��5M      
�������$��1q�5O       �� CornerRadius$ 10��5P       �� Padding$ 5q�5Q      ._�5R   &   �� $��Center=�67   $��Center=�6T   5S   #   5T      5V       �� Triggers 5W      �� 5X       �� Binding 6&   �� *Price+ �� Value High6@   .a�5Y      ��  � ��
 �r���6;   �� 5Z       � ��
 �����6;   5[      5]         Columns 5a      0  *System.Windows.Controls.DataGridTextColumn  5b      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+ �� Mode$ OneWay=�6U     5c      $! Название марки��6%   $ * 6c    6=   �� *make+$ OneWay=�6c     5d      $- 'Страна-производитель��6%   $ * 6l    6C   �� *	country+$ OneWay=�6l   5f      � 5h   
   $��2��6   $��1��6   $��2��6,   .+�5j      �� -   5         ��Name$ 	AddButton��5j      $��0��6(   $��Добавить��68   $��Center=�5k      $��Center=�63   $
��Left=�6W   $��24(�5l      $��Century Gothic)�6   $
��50px��6;   $��150px��6I   $��	150,0,0,0q�6W   $��4��5m      6   �� 5o      -   5        $ ChangeButton��5o      $��0��6+   $��Изменить��6;   $��Center=�5p      $��Center=�63   $��Center=�6W   $��24(�5q      $��Century Gothic)�6   $
��50px��6;   $��150px��6I   $��0,0,50,0q�6W   $��4��5r      6   �� 5t      -   5        $ DeleteButton��5t      $��0��6+   $��Удалить��6;   $��Center=�5u      $��Center=�63   $��Right=�6W   $��24(�5v      $��Century Gothic)�6   $
��50px��6;   $��150px��6I   $��	0,0,200,0q�6W   $��4��5w      6   5x      5y      5z      