   M S B A M L   `   `   `  ����>  :WYD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WYDWYD  5   	       WYD.AdvertAppForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:WYD     5   	     � SizeToContent$  WidthAndHeight=�5   	    � 
ResizeMode$ CanMinimize=�5	   	    � Title$ AdvertAppForm��5
   	   $��600         ��6   $	��800��5      .��5      � -   5         �Name$ AdvertAppForm1��5      ���	#FFBAC0CC.+�5   
   �� -   5         ��Name$ AppName_lbl��5      $��  WALK YOUR 
        DOG��6%   $��648,52,12,470q�6L    J� RenderTransformOrigin$ 0.5,0.5&�6c   $��Franklin Gothic Heavy)�6�   $��18(�6�   $
��Bold"�6�   ���	#FF239C99$��Italic$�6�   
���   �$��3,3,3,3q�6  ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FF141C48��6#   	 � Offset$	 0.136Q�65   � 5      $ 	#FF62769E��6#   $	 1Q�65   5      z�5      V� 5      .~�5      �� �� 5      
 �� AngleY$
 -5.955Q�6$   �� 5      T� 5       T� Y$ -41.723Q�6)   5      5      �� 5   
   -   5        $ lblCreateAdvertAppForm��5      $��Create new advert!��60   $��63,24,259,372q�6M   $��Franklin Gothic Heavy)�6d   $��20(�6�   ���	#FF1A224D6�   �� 5   
   -   5        $ lblTitleAdvertAppForm��5      $��Title:��6/   $
��Left=�6@   $��27��6[   $��	63,67,0,0q�6g   $	��Top=�6z   $��84��6�   $��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FFBAC0CC���	#FF171F496�   �� 5   
   -   5         ��Name$ txtTitleAdvertAppForm��5      $
��Left=�61   $��28��6L   $��
211,67,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $��Title��6�   $	��Top=�6�   $	��417��6�   ���	#FF239C99$��1,1,3,3q�6�   6�   �� 5    
   -   5        $! txtAdvertPrizeAdvertAppForm��5       $
��Left=�67   $��28��6R   $��211,167,0,0q�6^   $
 Wrap=�6s   $��0��6�   $	��Top=�6�   $	��417��6�   ���	#FF239C99$��1,1,3,3q�6�   6�   �� 5!   
   -   5        $! lblAdvertPrizeAdvertAppForm��5!      $��Advert Prize:��65   $
��Left=�6M   $��27��6h   $��
63,167,0,0q�6t   $	��Top=�6�   $	��114��6�   $��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FFBAC0CC���	#FF171F496�   �� 5"   
   -   5        $# lblChooseTheDateAdvertAppForm��5"      $��Choose the date:��67   $
��Left=�6R   $��27��6m   $��
63,259,0,0q�6y   $	��Top=�6�   $	��148��6�   $��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FFBAC0CC���	#FF171F496�   �� 5#   
   -	   5        $! txtWalkingTimeAdvertAppForm��5#      $
��Left=�67   $��28��6R   $��211,206,0,0q�6^   $
 Wrap=�6s   $��0��6�   $	��Top=�6�   $	��417��6�   ���	#FF239C99$��1,1,3,3q�6�   6�   �� 5$   
   -
   5        $! lblWalkingTimeAdvertAppForm��5$      $��Walking time:��65   $
��Left=�6M   $��27��6h   $��
63,206,0,0q�6t   $	��Top=�6�   $	��114��6�   $��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FFBAC0CC���	#FF171F496�   &   System.Windows.Controls.Calendar  5%   
   -   5          Name$ calemdar��5%      $
��Left=�6%   $	��177��6@   $��262,258,0,0q�6M   $	��Top=�6b   $	��294��6z   6�   �� 5&   
   -   5        $ lblOwnerAdvertAppForm��5&      $��Owner:��6/   $
��Left=�6@   $��27��6[   $��
63,103,0,0q�6g   $	��Top=�6{   $��84��6�   $��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FFBAC0CC���	#FF171F496�   �� 5'   
   -   5        $ lblDogAdvertAppForm��5'      $
��Dog:��6-   $
��Left=�6<   $��27��6W   $��
63,135,0,0q�6c   $	��Top=�6w   $��84��6�   $��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FFBAC0CC���	#FF171F496�   �� 5(   
   -   5        $ txtOwnerAdvertAppForm��5(      $��Label��6/   $
��Left=�6?   $��27��6Z   $��211,103,0,0q�6f   $	��Top=�6{   $	��395��6�   �� 5)   
   -   5        $ txtDogAdvertAppForm��5)      $��Label��6-   $
��Left=�6=   $��27��6X   $��211,135,0,0q�6d   $	��Top=�6y   $	��395��6�   �� 5*   
   -   5         ��Name$ btnAddAdvertAdvertAppForm��5*      $��
Add advert��64   $
��Left=�6I   $��56��6d   $��666,102,0,0q�6p   $	��Top=�6�   $��98��6�   ���	#FF5D7199���	#FF249B98$��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FF171F49$��1,1,3,3q�6  69  �� 5+   
   -   5        $ btnCleanAdvertAppForm��5+      $��Clean��60   $
��Left=�6@   $��56��6[   $��666,177,0,0q�6g   $	��Top=�6|   $��98��6�   ���	#FF5D7199���	#FF249B98$��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FF171F49$��1,1,3,3q�6  60  �� 5,   
   -   5        $  btnAllAdvertsAdvertAppForm��5,      $��All adverts��66   $
��Left=�6L   $��56��6g   $��666,253,0,0q�6s   $	��Top=�6�   $��98��6�   ���	#FF5D7199���	#FF249B98$��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FF171F49$��1,1,3,3q�6"  6<  �� 5-   
   -   5        $ lblContentAdvertAppForm��5-      $��Content:��61   $
��Left=�6D   $��27��6_   $��
63,440,0,0q�6k   $	��Top=�6   $	��148��6�   $��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FFBAC0CC���	#FF171F496�   �� 5.   
   -   5        $ txtContentAdvertAppForm��5.      $
��Left=�63   $	��134��6N   $��168,440,0,0q�6[   $
 Wrap=�6p   $��Content��6�   $	��Top=�6�   $	��596��6�   ���	#FF239C99$��1,1,3,3q�6�   6�   �� 5/   
   -   5        $ btnBackAdvertAppForm��5/      $
��Back��60   $��27��6?   $��10,547,739,0q�6K   $	��Top=�6a   ���	#FF5D7199���	#FF249B98$��Franklin Gothic Heavy)�6�   $��16(�6�   ���	#FF171F49$��1,1,3,3q�6�   6
  51      52      