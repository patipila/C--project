   M S B A M L   `   `   `  ����>  :WYD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WYDWYD  5   	       WYD.OwnerForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:WYD     5   	     � SizeToContent$  WidthAndHeight=�5   	    � 
ResizeMode$ CanMinimize=�5	   	    � Title$ 	OwnerForm��5
   	   $	��450��6   $	��800��6(   .��5      � -   5         �Name$ 
OwnerForm1��5      ���	#FFBAC0CC$��Right=�66   $	��800��6R    � ColumnDefinitions 5   
   �� 5      $	��74* �6   �� 5      $	��53* �6   �� 5      $	��73* �6   .+�5   
   �� -   5         ��Name$ listOwnerForm��5      $
��Left=�6)   $	��241��6D   $��	81,85,0,0q�6Q   $	��Top=�6d   $	��558��6|   $��3��6�   6�   �� 5   
   -   5         ��Name$ lblPickOwnerForm��5      $"��Pick yourself from the list.��6*   $
��Left=�6Q   $��35��6l   $��	81,23,0,0q�6x   $	��Top=�6�   $	��479��6�   $��Franklin Gothic Heavy)�6�   $��22(�6�   ���	#FFBAC0CC���	#FF19224E$��3��6  �� 5   
   -   5        $ AppName_lbl��5      $��  WALK YOUR 
        DOG��6%   $��140,52,12,327q�6L    J� RenderTransformOrigin$ 0.5,0.5&�6c   $��Franklin Gothic Heavy)�6�   $��18(�6�   $
��Bold"�6�   ���	#FF239C99$��Italic$�6�   
���   �$��3,3,3,3q�6  $��2��6  ��5      �� 5       �� EndPoint$ 0.5,1&�6&   	 �� 
StartPoint$	 0.5,0&�67   .��5      � 
 � Color$
 	#FF141C48��6#    � Offset$ 0.136Q�65   � 5      $
 	#FF62769E��6#   $ 1Q�65   5      z�5      V� 5      .~�5      �� �� 5       �� AngleY$ -5.955Q�6$   �� 5      T� 5       T� Y$ -41.723Q�6)   5       5"      �� 5#   
   -   5         ��Name$ btnDeleteOwnerForm��5#      $��Delete��6-   $
��Left=�6>   $��60��6Y   $��
158,93,0,0q�6e   $	��Top=�6y   $	��102��6�   ���	#FF5D7199$��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FF1E254B���	#FF299794$��1,1,3,3q�6  $��2��6.  6>  �� 5$   
   -   5        $ btnAddOwnerForm��5$      $	��Add��6*   $
��Left=�68   $��60��6S   $��158,176,0,0q�6_   $	��Top=�6t   $	��102��6�   ���	#FF5D7199$��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FF1E254B���	#FF299794$��1,1,3,3q�6  $��2��6)  69  �� 5%   
   -   5        $ btnNextOwnerForm��5%      $
��Next��6+   {�.  $
��Left=�6L   $��58��6g   $��
39,350,0,0q�6s   $	��Top=�6�   $��98��6�   ���	#FF5D7199$��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FF1E254B���	#FF299794$��1,1,3,3q�6!  $��1��6;  6K  �� 5&   
   -   5        $ btnExitOwnerForm��5&      $
��Exit��6+   $
��Left=�6:   $��58��6U   $��
81,350,0,0q�6a   $	��Top=�6u   $��98��6�   ���	#FF5D7199$��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FF1E254B���	#FF299794$��1,1,3,3q�6  6)  �� 5'   
   -	   5         ��Name$ cbxSortDirectionOwnerForm��5'      $y�Hidden=�66   $��2��6J   $
��Left=�6Z   $��158,324,0,0q�6u   $	��Top=�6�   $	��102��6�   $��21��6�   �� 5(   
   -
   5        $ cbxSortByWhatOwnerForm��5(      $y�Hidden=�63   $��2��6G   $
��Left=�6W   $��158,350,0,0q�6r   $	��Top=�6�   $	��102��6�   $��21��6�   �� 5)   
   -   5        $ btnSortPropOwnerForm��5)      $��Select sort 
properties��6/   $
��Left=�6U   $��60��6p   $��158,259,0,0q�6|   $	��Top=�6�   $	��102��6�   ���	#FF5D7199$��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FF1E254B���	#FF299794$��1,1,3,3q�6,  $��2��6F  6V  5+      5,      