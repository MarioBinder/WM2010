   M S B A M L   `   `   `  ���� A  =WM2010, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WM2010.ConverterWM2010.Converter  #    WM2010.Controls.SpielErgebnis   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    /helperclr-namespace:WM2010.Converter      � 	Resources   �� 
TargetType �� Property �� Value%   WM2010.Converter.ImageConverter   imageConverter��%  '��       '�� m     &	  �     �� " ��.���  � ��
 �������  � ��$ Center=���  � ��$ 16(���  � ��$
 bold"��� " ��.���  � ��$ 25����  � ��$	 100����  � ��$ 16(���  � ��$
 bold"���  � ��$ Center=�  .��� -   $��gridErgebnis��$	��250��$	��Top=� � ColumnDefinitions �� ��  � RowDefinitions �� �� $��40 ��� �� �� �� �� �� .+��� $��Spielergebnis��$��0��$��2��
��� ���$	��Top=�$��18(��� $��0��$��1�� �� Orientation$ 
Horizontal=�$��Right=�$��0 0 5 0q�.+��� $��Center=�$��0 0 5 0q����� *Begegnung.Mannschaft1Name+�� $��32��$��32������  �� Path$  Begegnung.Mannschaft1Fahne� �� 	Converter# [  �� $��1��$��1��$ 
Horizontal=�$
��Left=�$��5 0 0 0q�.+��� $��32��$��32������ $  Begegnung.Mannschaft2Fahne�# [  �� $��Center=�$��5 0 0 0q����� *Begegnung.Mannschaft2Name+�� $��Halbzeitergebnis��$��2��$��2��$��Bottom=��� $��0��$��3��$��Right=�$��Normal"�$��Center=�$��Center=�$��0 0 5 0q����� *)'Begegnung.Spiel.ToreMannschaft1Halbzeit+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� $��1��$��3��$
��Left=�$��Normal"�$��Center=�$��Center=�$��5 0 0 0q����� *)'Begegnung.Spiel.ToreMannschaft2Halbzeit+$	 TwoWay=�$
 PropertyChanged=��� $��Endergebnis��$��4��$��2��$��Bottom=��� $��0��$��5��$��Right=�$��Center=�$��Center=�$�� 0 0 5 0q����� *!Begegnung.Spiel.ToreMannschaft1+$	 TwoWay=�$
 PropertyChanged=��� $��1��$��5��$
��Left=�$��Center=�$��Center=�$��5 0 0 0q����� *!Begegnung.Spiel.ToreMannschaft2+$	 TwoWay=�$
 PropertyChanged=��  � Minimum$ 0Q� � Maximum$	 100Q�$��10�� � IsIndeterminate . $��0��$��7��$��Center=�$��	10 0 10 0q�y��� *ProgressBarVisibility+$	 TwoWay=�$
 PropertyChanged=��� -     GruppenButton#���  $��1��$��6��$��2��$��Right=�$��Bottom=�.���� $
��None=�$&�� ..\Style\Images\speichernBtn.png��