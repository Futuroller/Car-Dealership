   M S B A M L   `   `   `  ����H  DCarDealership, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CarDealershipCarDealership  5   	   *    $CarDealership.AdminMakesChangeDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CarDealership     5   	     � Title$  
Марка��5   	   $	��400��6   $	��750��6$   
�������.��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��400 �6   �� 5      $��* �6   .+�5   
   � $��3��6   .+�5      �� $��80��6   $��Center=�6$   $��0��6?   $��3��6O   ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,1&�6;   .��5      �  � Color$ #E74C3C��6'    � Offset$	 0.0Q�67   � 5      $ #2C3E50��6'   $	 1.0Q�67   5      5!      �� 5"      $��
Марка��6   
�������$��24(�67   $��Century Gothic)�6E   $��2��6a   $��Center=�6q   $��Center=�6�   �� 5#      $��Resources/Logo.png��6   $��60��60   $��60��6;   $��
20,10,0,10q�6G   $��1��6[   $��0��6k   $
��Left=�6x   6�   �� 5$      -   5         ��Name$ FILabel��5$      $��Имя фамилия��6%   
�������$��20(�6N   $��Century Gothic)�6\   $��1��6x   $��Center=�6�   $��Center=�6�   $��Right=�6�   $��15q�6�   5%      �� 5'   
   $��
Марка��6   $��24(�6    $��Century Gothic)�6.   $��0��6J   $��1��6Z   $��Center=�6g   $��Center=�6�   $��Right=�6�   �� 5(   
   -   5         ��Name$ MakeTextBox��5(      $
��50px��6'   $
��10pxq�65   $��1��6C   $��1��6S   $��Center=�6`   $��20(�6�   $��Century Gothic)�6�   $��Center=�6�   �� 5*   
   $��Страна��6   $��24(�6!   $��Century Gothic)�6/   $��0��6K   $��2��6[   $��Center=�6h   $��Center=�6�   $��Right=�6�   �� 5+   
   -   5        $ CountryTextBox��5+      $
��50px��6*   $
��10pxq�68   $��1��6F   $��2��6V   $��Center=�6c   $��20(�6�   $��Century Gothic)�6�   $��Center=�6�   �� 5-   
   -   5        	 ��Name$	 ChangeButton��5-      $��1��6'   $��Изменить��67   $��Center=�5.      $��Center=�6/   $��Center=�6S   $��24(�5/      $��Century Gothic)�6   $
��50px��67   $��200px��6E   $��3��50      6   51      52      