   M S B A M L   `   `   `  ����H  DCarDealership, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CarDealershipCarDealership  5   	   (    "CarDealership.ManagerPopularModels   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CarDealership     5   	     � Title$/  )Популярные автомобили��5      $	��820��67   $
��1200��6D   
������� � Icon$ 	/icon.png��6d   .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   �� 5      $��85 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��500 �6   �� 5      $��* �6   .+�5   
   � $��5��6   .+�5      �� $��80��6   $��Center=�6$   $��0��6?   $��3��6O   ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,1&�6;   .��5      �  � Color$ #E74C3C��6'    � Offset$	 0.0Q�67   � 5      $ #2C3E50��6'   $	 1.0Q�67   5      5      �� 5       $'��!Популярные модели��6   
�������$��30(�6C   $��Century Gothic)�6Q   $��2��6m   $��Center=�6}   $��Center=�6�   �� 5!      $��Resources/Logo.png��6   $��60��60   $��60��6;   $��
20,10,0,10q�6G   $��1��6[   $��0��6k   $
��Left=�6x   6�   5"      �� 5#   
   -   5         ��Name$ FILabel��5#      $��Имя фамилия��6!   
�������$��28(�6J   $��Century Gothic)�6X   $��3��6t   $��Right=�6�   $��Center=�6�   $��0,0,60,0q�6�   �� 5%   
   -   5        $��CarsListView��5%      $��Center=�6E   $��Center=�6b   $��Bottom=�6�   $
��1200��6�   $	��600��6�   $��0��6�   $��1��6�   $��3��6�   ��6'   �� *Items+��5&      �� 5'      .R�5(      � 	 � Orientation$	 
Horizontal=�6    $��Center=�69   5)      ��5,      �� 5-      .R�5.      �� $��1q�6   
�������
 �� Padding$
 10q�6D   $��5q�6Q   $	��350��5/      $	��450��6!   
������� �� CornerRadius$ 15��6A   ._�50      ��  �� Orientation$ Vertical=�6%   .+�51      �� $	��200��6B   $	��400��6O   $��Uniform=�6[   ��6$   �� *
photo_path+6[   �� 52      $
��Bold"�6C   $��16(�6U   $��5q�6c   ��6(   �� *	ModelInfo+6c   �� 53      $��14(�6=   $��5q�6K   ��6(   �� *vin+6K   �� 54      $��14(�6J   $��5q�6X   ��6(   �� *ModelMakeCountry+6X   �� 55      $��14(�6A   $��5q�6O   ��6(   �� *	mileage+6O   �� 56      $��14(�6?   $��5q�6M   ��6(   �� *Color+6M   �� 57      $��14(�6@   $��5q�6N   ��6(   �� *Status+6N   �� 58      $��14(�6?   $��5q�6M   ��6(   �� *price+6M   �� 59      $��14(�6E   $��5q�6S   ��6(   �� *SoldedCount+6S   5:      5;      5<       � 	Resources 5@       �� 
TargetType �� Property �� Value��%X   '��       �� 5A      " ��6   .�5B      ��  � ��$ Disabled=�6F   5C      5D      5E      �� 5G   
   -   5         ��Name$ 
BackButton��5G      $��0��6%   $��
Назад��65   $��Center=�5H      $��Center=�6/   $
��Left=�6S   $��24(�5I      $��Century Gothic)�6   $
��50px��67   $��200px��6E   $��30,0,0,0q�6S   $��4��5J      6   5K      5L      