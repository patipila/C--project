   M S B A M L   `   `   `  ����>  :WYD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WYDWYD  5   	       WYD.AppWalkersForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:WYD     5   	     � SizeToContent$  WidthAndHeight=�5   	    � 
ResizeMode$ CanMinimize=�5	   	    � Title$ AppWalkersForm��5
   	   $	��450��6    $	��800��6-    � 	Resources 5         	BoolToVis��%   &	        �� 5   
   6'   5      .��5      � ���	#FFBAC0CC.+�5   
   �� -   5         ��Name$ AppName_lbl��5      $��  WALK YOUR 
        DOG��6%   $��
0,0,27,322q�6L    J� RenderTransformOrigin$ 0.5,0.5&�6`   $��Franklin Gothic Heavy)�6�   $��18(�6�   $
��Bold"�6�   ���	#FF239C99$��Italic$�6�   
���   �$��3,3,3,3q�6  $��Right=�6  $	��140��67  $��55��6C  $��Bottom=�6O  ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF141C48��6#   	 � Offset$	 0.136Q�65   � 5      $ 	#FF62769E��6#   $	 1Q�65   5      z�5      V� 5      .~�5      �� �� 5      
 �� AngleY$
 -5.955Q�6$   �� 5      T� 5       T� Y$ -41.723Q�6)   5      5      �� 5    
   -   5         ��Name$ btnBackAppWalkersForm��5       $
��Back��61   $��27��6@   $��10,397,739,0q�6L   $	��Top=�6b   ���	#FF5D7199���	#FF249B98$��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FF171F49$��1,1,3,3q�6�   6  �� 5!   
   -   5        $ lblAppWalkersForm��5!      $9��3Hello Dog Owner! Find the best walker for your dog!��6+   $
��Left=�6i   $��32��6�   $��	100,0,0,0q�6�   $	��Top=�6�   $	��514��6�   ���	#FFBAC0CC$��Franklin Gothic Heavy)�6�   $��20(�6  ���	#FF171F496  �� 5#   
   -   5        $��lsbAppWalkersForm��5#      $��68,95,154,52q�6,    �� View 5$      �� 5%      .P�5&      �� $��Id��6%    �� Width$ 40��61    �� DisplayMemberBinding 6<   �� *
WalkerId+�� 5'      $
��Name��6%   $	 100��63    6?   �� *
WalkerName+�� 5(      $��Surname��6%   $	 100��66    6B   �� *WalkerSurname+�� 5)      $��DateOfBirth��6%   $ 90��6:    6E   �� *WalkerDateOfBirth+�� 5*      $��Email��6%   $	 150��64    6@   �� *WalkerEmail+�� 5+      $��Phone Number��6%   $ 90��6;    6F   �� *WalkerPhone+5,      5.      �� 52   
   -   5         ��Name$ txtAppWalkersFormFilter��52        textboxSearch#��[ 6b   $��68,47,462,0q�6�   $	��Top=�6�   $��43��6�   6�   �� 54   
   -   5        $��cbxAppWalkersFormSortBy��54      $y�Hidden=�62    �� SelectedIndex$ 0��6F   $	��120��6X   $��659,294,21,114q�6d   �� 55   
   -   5        $$��cbxAppWalkersFormSortDiraction��55      $y�Hidden=�69   $ 0��6M   $	��120��6_   $��659,325,21,83q�6k   �� 56   
   -   5        $ lblSearchAppWalkerForm��56      $��144,53,536,342q�60   $��14                (�6H   $��Search here ...��57      $y�Visible=�6-   $ 0.5,0.5&�6B   z�58      V� 59      .~�5:      �� �� 5;      �� 5<       �� Angle$ -0.234Q�6&   T� 5=      5>      5@      �� 5A   
   -	   5        $ btnSortPropAppWalkerForm��5A      $��Select sort 
properties��63   $
��Left=�6Y   $��42��6t   $��659,243,0,0q�6�   $	��Top=�6�   $	��120��6�   ���	#FF5D7199$��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FF1E254B���	#FF299794$��1,1,3,3q�60  6J  �� 5B   
   -
   5        $ btnDeleteAppWalkerForm��5B      $��Delete��61   $
��Left=�6B   $��44��6]   $��659,182,0,0q�6i   $	��Top=�6~   $	��120��6�   ���	#FF5D7199���	#FF249B98$��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FF171F49$��1,1,3,3q�6  63  �� 5C   
   -   5        $ lblInfoAppWalkersForm��5C      $8��2Double click on 
interesting walker 
to know more!��6/   $
��Left=�6t   $��58��6�   $��666,119,0,0q�6�   $	��Top=�6�   $	��106��6�   ���	#FFBAC0CC$��Franklin Gothic Heavy)�6�   $��11(�6  ���	#FF171F496  5F      5I      