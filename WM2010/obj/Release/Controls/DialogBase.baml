   M S B A M L   `   `   `  ���� 
  WM2010     WM2010.Controls.DialogBase   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    -   $��DialogBaseWin��$	��300��$	��500��  � Title$   �� � AllowsTransparency . 
������  � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � Triggers :�  :� RoutedEvent$ Window.Loaded��.[��� .���� .��W�  �� 
TargetName$ DialogBaseWin�� �� TargetProperty$ Opacity� W� From$ 0X�		 W� To$	 1X�
 g� Duration$
 0:0:0.5D�:� $ Window.Unloaded��.[��� .���� -    ��Name$ closeStoryBoard��.��W� $ DialogBaseWin��$ Opacity�$ 1X�$	 0X�$
 0:0:0.5D�.��� .+��� $
��None=�$"��..\Style\Images\dialogBg.png�� J� Opacity$	 0.8Q��� -   $��canvas1��.+��� -   $
��None=�$��../Style/Images/close.png��$��Right=�$	��Top=� � ToolTip$ 
schliessen��
 �� Top$ 10�� �� Left$	 475��� $ 30��$ 5��$	��280��$	��480��.+��� -   $��dialogContent��