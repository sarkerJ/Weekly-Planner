   M S B A M L   `   `   `  ����Q  MWeekly_PlannerGUILayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Weekly_PlannerGUILayerWeekly_PlannerGUILayer  5   	   (    "Weekly_PlannerGUILayer.NotesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Weekly_PlannerGUILayer     5   	     � Title$  NotesWindow��5   	   $	��450��6   $	��800��6*   .��5	      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      .+�5   
   � $��0��6    5      �� 5      $	��120 �6    �� 5      .+�5      �� -   5         ��Name$ ListBoxNotes��5      $��1��6,   ���	#FFC9ECF9$��Center=�6P   ��5      �� 5      .R�5      �� ��5      �� 5   "   ._�5       ��  ��Name$ TestingName��6(   $
��Bold"�6=   ��6O   �� *Title+��6g   �� *NotesColourCategorys.Colour+5!      5"      5$      � 5&      $��0��6    5'      �� 5(      $��60 �6$   �� 5)      �� 5*       5-      �� 5.      �� 5/      .+�51      �� -   5        $��ComboBoxDays��51      $��Center=�6/   $��0��6R   $��1��6b   $��Center=�6o    �� Text$ --Select Day Filter --��6�    �� 
IsReadOnly$
 True��6�    �� 
IsEditable$
 True��6�   6  �� 52      -   5        $��ComboBoxColours��52      $��Center=�62   $��1��6T   $��1��6d   $��Center=�6q   $ --Select Colour Filter --��6�   $
 True��6�   $
 True��6�   6  �� 53      -   5         ��Name$ BClear��53      $��0��6)   $��2��69   $��Clear��6F   $��2��6o   
�������6�   �� 55      -   5        $��LNote��55      $��List of Notes��6%   $��Center=�6=   $��Center=�6a   $��40(�6�   $��0��6�   $��2��6�   ���	#FFB7E6F76�   56      57      � 59   
   $��1��6    5:      �� 5;      $��25 �6    �� 5<      $��30 �6    �� 5=      $��25 �6    �� 5>      $��30 �6    �� 5?      $��25 �6    �� 5@      $��30 �6    �� 5A      $��25 �6    �� 5B      �� 5C      .+�5G      �� -   5        	 ��Name$	 LNName��5G      $��	Note Name��6$   $
��Bold"�68   $��0��6J   $��Center=�6W   
����ح�6�   �� 5H      -   5        $	 LNColour��5H      $��Note Priority Colour��6&   $
��Bold"�6E   $��2��6W   $��Center=�6d   
����ح�6�   �� 5I      -   5        $	 	LNContent��5I      $
��Bold"�6'   $��Note Content��69   $��6��6P   $��Center=�6]   
����ح�6�   �� 5J      -	   5        $	 LNDay��5J      $
��Bold"�6#   $	��Day��65   $��4��6C   $��Center=�6P   
����ح�6�   �� 5L      -
   5        
 ��Name$
 TNName��5L      $��1��6&   $��Center=�63   $ �� HorizontalScrollBarVisibility$
 Auto=�6W    �� 
IsReadOnly$
 True��6|   ���	#FFC9ECF96�   �� 5M      -   5        $
 
TNPriority��5M      $
��Bold"�6*   $��Center=�6<   $��Center=�6^   $
 Auto=�6�   ���	#FFC9ECF9$��3��6�   $
 True��6�   6�   �� 5N      -   5        $
 TNDay��5N      $	��Top=�6%   $��Center=�6D   $
 Auto=�6i   $��5��6�   $
 True��6�   ���	#FFC9ECF96�   �� 5O      -   5        $
 	TNContent��5O      $	��Top=�6)   $��Center=�6H   $
 Auto=�6m   $��7��6�    �� AcceptsReturn$
 True��6�   ���	#FFC9ECF9$
 True��6�   6�   �� 5Q      -   5        $��ComboBoxDays2��5Q      $��5��6,   $��Center=�6;   $��Center=�6_   $y�Hidden=�6�   
�������6�   �� 5R      -   5        $��ComboBoxColours2��5R      $��3��6/   $��Center=�6=   $��Center=�6a   $y�Hidden=�6�   ��5S      �� 5T      .R�5U      �� ��5V      �� 5W   "   ._�5Y      �� $ TestingName��6(   $
��Bold"�6=   $
��Wrap=�6x   ��6O   �� ��6a   �� 6x   5Z      5[      5]      � 5`      $��8��6    5a      �� 5b      �� 5c      �� 5d      .+�5g      �� -   5        $ BCreateNote��5g      $��Create New Note��6.   $��0��6H   
�������6�   �� 5h      -   5        $ 	BEditNote��5h      $��	Edit Note��6,   $��1��6@   
�������6   �� 5i      -   5        $ BDeleteNote��5i      $��Delete Note��6.   $��2��6D   
�������6�   5l      5n      5o      5p      