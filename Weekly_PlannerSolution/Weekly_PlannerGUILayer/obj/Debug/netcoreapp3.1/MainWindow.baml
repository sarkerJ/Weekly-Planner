   M S B A M L   `   `   `  ����Q  MWeekly_PlannerGUILayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Weekly_PlannerGUILayerWeekly_PlannerGUILayer  5   	   '    !Weekly_PlannerGUILayer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Weekly_PlannerGUILayer     5   	     � Title$  Weekly Planner��5   	   $	��450��6    $	��800��6-   .��5	      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      .+�5   
   � $��0��6   $��5��6   $��1��63   ��5      �� 5       �� ImageSource$ backgroundimage.jpg��6    5      �� 5      $	��20* �6#   �� 5      $	��13* �6#   �� 5       $��7* �6#   �� 5!      $	��20* �6#   �� 5"      $	��20* �6#   �� 5#      $	��20* �6#    5&      �� 5'      $��30 �6    �� 5(      �� 5)      $	��100 �6    .+�5,      �� -   5         ��Name$ LMonday��5,      $��0��6%   $��0��65   $��Monday��6B   $��Center=�6S   $��Center=�6u   ���	#FFC9ECF9���	#FF8585F6$��1q�6�   �� 5-      -   5        $ LTuesday��5-      $��1��6&   $��0��66   $��Tuesday��6C   $��Center=�6U   $��Center=�6w   ���	#FFC9ECF9���	#FF8585F6$��1q�6�   $��2��6�   �� 5.      -   5        $ 
LWednesday��5.      $��3��6(   $��0��68   $��	Wednesday��6E   $��Center=�6Y   $��Center=�6{   ���	#FFC9ECF9���	#FF8585F6$��1q�6�   �� 5/      -   5        $ 	LThursday��5/      $��4��6'   $��0��67   $��Thursday��6D   $��Center=�6W   $��Center=�6y   ���	#FFC9ECF9���	#FF8585F6$��1q�6�   �� 50      -   5        $ LFriday��50      $��5��6%   $��0��65   $��Friday��6B   $��Center=�6S   $��Center=�6u   ���	#FFC9ECF9���	#FF8585F6$��1q�6�   �� 52      -   5         ��Name$ ListBoxMonday��52      $��0��6-   $��1��6=   ���	#FFE7F1EF$��Center=�6�   55      �� 56      -   5        $ ListBoxTuesday��56      $��1��6.   $��1��6>   ���	#FFE7F1EF$��Center=�6�   $��2��6�   6�   �� 57      -   5        $ ListBoxWednesday��57      $��3��60   $��1��6@   ���	#FFE7F1EF$��Center=�6�   6�   �� 58      -	   5        $ ListBoxThursday��58      $��4��6/   $��1��6?   ���	#FFE7F1EF$��Center=�6�   6�   �� 59      -
   5        $ ListBoxFriday��59      $��5��6-   $��1��6=   ���	#FFE7F1EF$��Center=�6�   6�   �� 5;      -   5        $ LName��5;      $��Activity Name��6#   $��0��6;   $��2��6K   $��Center=�6X   $��Center=�6|   
����ح�6�   �� 5<      -   5        $ LContent��5<      $��Activity Content��6&   $��3��6A   $��2��6Q   $��Center=�6^   $��Center=�6�   
����ح�6�   � 5>      $��2��6   $��5��6     5?      �� 5@      $��40 �6$   �� 5A      .+�5D      �� -   5        $
 LDay��5D      $
��Day:��6&   $��0��65   $��0��6B   $��Center=�6R   $��Center=�6v   
����ح�6�   �� 5E      -   5         ��Name$
 TDay��5E      $��Center=�6(   $��Center=�6L   $��1��6n    �� 
IsReadOnly$
 True��6{   ���	#FFC9ECF96�   �� 5G      -   5        $��ComboBoxDays��5G      $��1��6/   $��Center=�6o   $��Center=�6�   $y�Hidden=�6�   
�������6�   5I      �� 5K      -   5        $ TContent��5K      $	��Top=�6(   $ �� HorizontalScrollBarVisibility$
 Auto=�6I   "	 �� VerticalScrollBarVisibility$
	 Auto=�6n   $��2��6�   ���	#FFC9ECF9$��4��6�   
 �� AcceptsReturn$

 True��6�   $
 True��6�   6�   �� 5L      -   5        $ TTitle��5L      $��Center=�6&   $��Center=�6H   $
 Auto=�6l   $��2��6�   $��1��6�   $

 True��6�   $��2��6�   $
 True��6�   ���	#FFC9ECF96  5O      �� 5R   
   -   5         ��Name$ BCreateActivity��5R      $��Create an Activity��6*   $��0��6G   
�������6�   �� 5S   
   -   5        $ BDeleteActivity��5S      $��Delete an Activity��6*   $��2��6G   
�������6�   �� 5T   
   -   5        $ BEditActivity��5T      $��Edit Activity��6(   $��1��6@   
�������6�   �� 5U   
   -   5        $ BAExternalView��5U      $��Activity External View��6)   $��3��6J   
�������6�   �� 5V   
   -   5        $ BNotes��5V      $��Notes��6!   $��4��61   
�������6u   5Z      5[      