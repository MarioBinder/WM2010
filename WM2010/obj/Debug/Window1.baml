   M S B A M L   `   `   `  ����
  WM2010    WM2010.Window1   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      -   5          �Name$	  app��5   <    � Title$/ )WM 2010 | by Mario Priebe - www.biggle.de��5      $
��1024��67   $
��1280��6E    � AllowsTransparency . 
������    ApplicationIcon � Icon# [  6�    � WindowStyle$
 None=�5       � WindowStartupLocation$ CenterScreen=�6    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$% NavigationCommands.PreviousPage��5      6n     5	   
   -   5        $! NavigationCommands.NextPage��5	      6f    � Triggers 5      :� 5   
   	 :� RoutedEvent$	 Window.Loaded��6   .[�5      �� .��5      �� .��5      W� 
 �� 
TargetName$	
 app��6&    �� TargetProperty$ Opacity�5   "    W� From$ 0X�5   "   	 W� To$ 1X�6+    g� Duration$ 0:0:01D�62   5      5      5      :� 5   
   $	 Window.Unloaded��6   .[�5      �� .��5      �� -   5         ��Name$ closeStoryBoard��5      .��5      W� $	
 app��6&   $ Opacity�5   "   $ 1X�5   "   $ 0X�6+   $ 0:0:01D�62   5      5      5      .��5#      � .+�5$   
   ��   ThemeBackground#���  6   �� 5%   
   -   5        $��canvas1��5%   )   $��22,5.4,22.6,12q�6   .+�5(      �� -   5        $��lblDatum��5(      $
��Bold"�6$   $��10(�66   $��Verdana)�6D   
��� ��� �� Left$	 170��6m   
 �� Top$ 50��6   �� 5,      -   5         ��Name$ Frames��5,   r     
FrameStyle#���  6   $	 150��6>   $ 70��6P    �� SelectedIndex$ 0��6`   6r   �� 51      -   5        $*��$Style\Images\football-icon-small.png��51      $��Right=�6B   $	��Top=�6^    � ToolTip$ WM2010 Willkommen��6v   $��0,6.75,14.5,0q�52      $ -0.75��53      $
 1195��6   $��16��54   x   $��16��6�   �� 56      -	   5        $
��None=�56      $��Style\Images\minimize.png��6#   $��Right=�6F   $	��Top=�6b   $ WM2010 minimieren��6z   $��0,6.75,14.5,0q�57      $ -0.75��58      $
 1212��6   $��16��59   |   $��16��6�   �� 5;      -
   5        $
��None=�5;      $��Style\Images\close.png��6#   $��Right=�6C   $	��Top=�6_   $ WM2010 beenden��6w   $��0,6.75,14.5,0q�5<      $ -0.75��5=      $
 1230��6   $��16��5>   x   $��16��6�   �� 5B      -   5        $��
LeftButton��5B   [     	NavButton#���  5C      $%��NavigationCommands.PreviousPage��6*   $��1��6T   $ 0��6i    �� Bottom$ 80��6y   .��5D      �� $
��None=�6   $!��Style\Images\LeftButton.png��6'   5E      �� 5G      -   5        $��RightButton��5G   ]   #���  5H      $!��NavigationCommands.NextPage��6)   $��2��6O    �� Right$ 0��6d   $ 80��6u   .��5I      �� $
��None=�6   $"��Style\Images\RightButton.png��6'   5J      �� 5L      -   5        $ Pages��5L   O   $	 140��6   $ 0��6+   $ 0��6=   6O   5P      5Q      5R      