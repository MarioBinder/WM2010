   M S B A M L   `   `   `  ����
  WM2010     WM2010.Controls.DialogBase   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      -   5        $��DialogBaseWin��5   <   $	��300��5   	   $	��500��6     � Title$   ��6"    � AllowsTransparency . 
������  � WindowStyle$
 None=�5       � WindowStartupLocation$ CenterScreen=�6    � Triggers 5      :� 5	   
    :� RoutedEvent$ Window.Loaded��6   .[�5
      �� .��5      �� .��5      W�  �� 
TargetName$ DialogBaseWin��6&    �� TargetProperty$ Opacity�5   "    W� From$ 0X�5   "   		 W� To$	 1X�6+   
 g� Duration$
 0:0:0.5D�62   5      5      5      :� 5   
   $ Window.Unloaded��6   .[�5      �� .��5      �� -   5         ��Name$ closeStoryBoard��5      .��5      W� $ DialogBaseWin��6&   $ Opacity�5   "   $ 1X�5   "   $	 0X�6+   $
 0:0:0.5D�62   5      5      5      .��5      � .+�5   
   �� $
��None=�6   $"��..\Style\Images\dialogBg.png��6    J� Opacity$	 0.8Q�6E   �� 5   
   -   5        $��canvas1��5      .+�5       �� -   5        $
��None=�5       $��../Style/Images/close.png��6#   $��Right=�6F   $	��Top=�6b    � ToolTip$ 
schliessen��6z   
 �� Top$ 10��5!       �� Left$	 475��6   5"   C   � 5$      $ 30��6   $ 5��6#   $	��280��63   $	��480��6@   .+�5%      �� -   5        $��dialogContent��5%   !   5&      5'      5(      5)      