   M S B A M L   `   `   `  ����H  DCarDealership, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CarDealershipCarDealership  5   	   /    )CarDealership.ManagerClientsOrdersHistory   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CarDealership     5   	     � Title$%  Просмотр заказов��5   	   $	��820��6"   $
��1400��6/   
�������.��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   �� 5      $��83 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��500 �6   �� 5      $��* �6   .+�5   
   � $��3��6   .+�5      �� $��80��6   $��Center=�6$   $��0��6?   $��3��6O   ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,1&�6;   .��5      �  � Color$ #E74C3C��6'    � Offset$	 0.0Q�67   � 5      $ #2C3E50��6'   $	 1.0Q�67   5      5      �� 5       $��Менеджер��6   
�������$��30(�6:   $��Century Gothic)�6H   $��2��6d   $��Center=�6t   $��Center=�6�   �� 5!      $��Resources/Logo.png��6   $��60��60   $��60��6;   $��
20,10,0,10q�6G   $��1��6[   $��0��6k   $
��Left=�6x   6�   5"      �� 5$   
   -   5         ��Name$ FILabel��5$      $��Имя фамилия��6!   
�������$��28(�6J   $��Century Gothic)�6X   $��3��6t   $��Center=�6�   $��Center=�6�   &   System.Windows.Controls.DataGrid  5&   
   -   5          Name$ OrderDataGrid��5'      $��0��5(      $��1��5)      $��3��5*      $��Center=�5+      $	��Top=�5,      $��30q�5-      
�������
�������$��1q�50      $	��500��51      $
��1300��52      	   AutoGenerateColumns	 .  
   ColumnHeaderHeight$
 40Q�54         	RowHeight$ 35Q�55         GridLinesVisibility$
 None=�56         CanUserResizeColumns .     CanUserResizeRows .     HeadersVisibility$ Column=�59         ColumnHeaderStyle 5<      �� 5=       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5>      ��  �� Property � �� �� Value �#E74C3C63   �� 5?       � ��
 �����63   �� 5@       � ��$
 Bold"�63   �� 5A       � ��$ Century Gothic)�63   �� 5B       � ��$ Center=�6C   �� 5C       � ��$ 16(�61   �� 5D       � ��
 �����64   �� 5E       � ��$ 0,0,1,1q�68   5F         RowStyle 5J      �� 5K      )  #System.Windows.Controls.DataGridRow"  6   .�5L      ��  � ��$ 13(�61   �� 5M       � ��
 �����63   �� 5N       � ��
 �����64   �� 5O       � ��$ 0,0,0,1q�68   �� 5P       � ��$
 Left=�6C   5Q         	CellStyle 5U      �� 5V      *  $System.Windows.Controls.DataGridCell"  6   .�5W      ��  � ��$ 0q�60   �� 5X       � �� 5Y      �� 5Z       �� 
TargetType"  6.   .R�5[   "   �� #��z��5\   %   
�������$��1q�5^   %    �� CornerRadius$ 10��5_   %    �� Padding$ 5q�5`   %   ._�5a   &   �� $��Center=�67   $��Center=�6T   5b   #   5c      5e       �� Triggers 5f      �� 5g       �� Binding 6&   �� *Price+ �� Value High6@   .a�5h      ��  � ��
 �r���6;   �� 5i       � ��
 �����6;   5j      5l         Columns 5p      0  *System.Windows.Controls.DataGridTextColumn  5q      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+  �� Mode$  OneWay=�6U     5r      $ Дата создания��6%   $ * 6h    6<   �� *
order_date+$  OneWay=�6h     5s      $ Цена��6%   $ * 6Z    63   �� *price+$  OneWay=�6Z     5t      $ Автомобиль��6%   $ * 6^    69   �� *Car+$  OneWay=�6^     5u      $ Статус��6%   $ * 6]    65   �� *Status+$  OneWay=�6]     5v      $ ФИО клиента��6%   $	 250 6b    6:   �� *Client+$  OneWay=�6b     5w      $ ФИО менеджера��6%   $	 250 6e    6<   �� *	Manager+$  OneWay=�6e   5y      �� 5{   
   -   5        ! ��Name$! 
BackButton��5{      $��0��6%   $��
Назад��65   $��Center=�5|      $��Center=�6/   $
��Left=�6S   $��24(�5}      $��Century Gothic)�6   $
��50px��67   $��200px��6E   $��30,0,0,0q�6S   $��4��5~      6   5      5�      