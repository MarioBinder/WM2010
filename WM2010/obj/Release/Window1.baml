   M S B A M L   `   `   `  ���� 
  WM2010    WM2010.Window1   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    -     �Name$	  app�� � Title$/ )WM 2010 | by Mario Priebe - www.biggle.de��$
��1024��$
��1280�� � AllowsTransparency . 
������    ApplicationIcon � Icon# [   � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$% NavigationCommands.PreviousPage��  -   $! NavigationCommands.NextPage�� � Triggers :� 	 :� RoutedEvent$	 Window.Loaded��.[��� .���� .��W� 
 �� 
TargetName$	
 app�� �� TargetProperty$ Opacity� W� From$ 0X�	 W� To$ 1X� g� Duration$ 0:0:01D�:� $	 Window.Unloaded��.[��� .���� -    ��Name$ closeStoryBoard��.��W� $	
 app��$ Opacity�$ 1X�$ 0X�$ 0:0:01D�.��� .+���   ThemeBackground#���  �� -   $��canvas1��$��22,5.4,22.6,12q�.+��� -   $��lblDatum��$
��Bold"�$��10(�$��Verdana)�
��� ��� �� Left$	 170��
 �� Top$ 50���� -    ��Name$ Frames��  
FrameStyle#���  $	 150��$ 70�� �� SelectedIndex$ 0���� -   $*��$Style\Images\football-icon-small.png��$��Right=�$	��Top=� � ToolTip$ WM2010 Willkommen��$��0,6.75,14.5,0q�$ -0.75��$
 1195��$��16��$��16���� -	   $
��None=�$��Style\Images\minimize.png��$��Right=�$	��Top=�$ WM2010 minimieren��$��0,6.75,14.5,0q�$ -0.75��$
 1212��$��16��$��16���� -
   $
��None=�$��Style\Images\close.png��$��Right=�$	��Top=�$ WM2010 beenden��$��0,6.75,14.5,0q�$ -0.75��$
 1230��$��16��$��16���� -   $��
LeftButton��  	NavButton#���  $%��NavigationCommands.PreviousPage��$��1��$ 0�� �� Bottom$ 80��.���� $
��None=�$!��Style\Images\LeftButton.png���� -   $��RightButton��#���  $!��NavigationCommands.NextPage��$��2�� �� Right$ 0��$ 80��.���� $
��None=�$"��Style\Images\RightButton.png���� -   $ Pages��$	 140��$ 0��$ 0��