   M S B A M L   `   `   `  ����A  =WM2010, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WM2010.ConverterWM2010.Converter  5          WM2010.Controls.Spiel   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      /helperclr-namespace:WM2010.Converter    5      $	��687��63     � 	Resources  5       �� 
TargetType   
labelStyle �� Property �� Value%   WM2010.Converter.ImageConverter  imageConverter��%c  &	        '�� �     &	 2    �� 5   
   " ��6   .�5	      ��  � ��$ Center=�62   �� 5
       � ��$ Center=�64   �� 5       � ��$
 bold"�6+   �� 5       � ��$ 16(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�62   �� 5       � ��$ Center=�64   5        5   
   6    5      .��5      � -   5        $��	gridSpiel��5       � ColumnDefinitions 5   
   �� 5      $	��69* �6   �� 5      $
��160* �6   �� 5      $
��114* �6   �� 5      $
��114* �6   �� 5      $
��160* �6   �� 5      $	��69* �6    � RowDefinitions 5"   
   �� 5#      $��85 �6   .+�5%      �� $
��None=�6   $��..\Style\Images\spiel.png��6#   $��6��6F   �� 5(   
   $��0��67   $��2��6G   
��� ���$
��Bold"�6o   $��	15 0 0 15q�6�   ��6   �� *Spiel.DatumUhrzeit+6�   �� 5)   
   $��4��67   $��2��6G   
��� ���$
��Bold"�6o   $��	0 0 15 15q�6�   $��Right=�6�   ��6   �� *Spiel.SpielOrt.Ort+6�   �� 5+   
   $��32��6   $��32��6   $��0��6|   $��Center=�6�   $��Center=�6�   ��6(   ��  �� Path$ Mannschaft1Fahne� �� 	Converter# [ 6�   �� 5,   
   #���   6   $��1��6Z   $
��Left=�6j   $��Center=�6�   ��69   �� *Mannschaft1Name+6�   �� 5.   
   $��2��6   .+�5/      �� #���   6   $��18(�6e   ��6>   �� *Spiel.ToreMannschaft1+6e   �� 50      #���   6   $��10(�6m   $��Light"�6{   ��6>   �� *Spiel.ToreMannschaft1Halbzeit+6{   52      �� 54   
   $��3��6   .+�55      �� #���   6   $��18(�6d   ��6=   �� *Spiel.ToreMannschaft2+6d   �� 56      #���   6   $��10(�6l   $��Light"�6z   ��6=   �� *Spiel.ToreMannschaft2Halbzeit+6z   58      �� 5:   
   #���   6   $��4��6Z   $��Right=�6j   $��Center=�6�   ��69   �� *Mannschaft2Name+6�   �� 5;   
   $��32��6   $��32��6   $��5��6|   $��Center=�6�   $��Center=�6�   ��6(   �� $ Mannschaft2Fahne�# [ 6�   5=      5>      