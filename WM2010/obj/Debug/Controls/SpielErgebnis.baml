   M S B A M L   `   `   `  ����A  =WM2010, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WM2010.ConverterWM2010.Converter  5      #    WM2010.Controls.SpielErgebnis   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      /helperclr-namespace:WM2010.Converter    5        � 	Resources  5       �� 
TargetType �� Property �� Value%   WM2010.Converter.ImageConverter   imageConverter��%�  '��       '�� �     &	  �    �� 5   
   " ��6   .�5	      ��  � ��
 �����6+   �� 5
       � ��$ Center=�64   �� 5       � ��$ 16(�6*   �� 5       � ��$
 bold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 25��6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 16(�6*   �� 5       � ��$
 bold"�6+   �� 5       � ��$ Center=�62   5        5   
   6    5      .��5      � -   5        $��gridErgebnis��5      $	��250��6   $	��Top=�6,    � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5       �� 5!      $��40 �6   �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      �� 5'      .+�5*   
   �� $��Spielergebnis��6   $��0��6*   $��2��67   
��� ���$	��Top=�6_   $��18(�6w   �� 5,   
   $��0��6   $��1��6%    �� Orientation$ 
Horizontal=�62   $��Right=�6K   $��0 0 5 0q�6g   .+�5-      �� $��Center=�6C   $��0 0 5 0q�6^   ��6   �� *Begegnung.Mannschaft1Name+6^   �� 5.      $��32��6   $��32��6   ��6,   ��  �� Path$  Begegnung.Mannschaft1Fahne� �� 	Converter# [  5/      �� 51   
   $��1��6   $��1��6%   $ 
Horizontal=�62   $
��Left=�6K   $��5 0 0 0q�6f   .+�52      �� $��32��6   $��32��6   ��6,   �� $  Begegnung.Mannschaft2Fahne�# [  �� 53      $��Center=�6C   $��5 0 0 0q�6^   ��6   �� *Begegnung.Mannschaft2Name+6^   54      �� 56   
   $��Halbzeitergebnis��6   $��2��6-   $��2��6:   $��Bottom=�6N   �� 57   
   $��0��6}   $��3��6�   $��Right=�6�   $��Normal"�6�   $��Center=�6�   $��Center=�6�   $��0 0 5 0q�6  ��6   �� *)'Begegnung.Spiel.ToreMannschaft1Halbzeit+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6  �� 58   
   $��1��6}   $��3��6�   $
��Left=�6�   $��Normal"�6�   $��Center=�6�   $��Center=�6�   $��5 0 0 0q�6  ��6   �� *)'Begegnung.Spiel.ToreMannschaft2Halbzeit+$	 TwoWay=�$
 PropertyChanged=�6  �� 5:   
   $��Endergebnis��6   $��4��6(   $��2��65   $��Bottom=�6I   �� 5;   
   $��0��6u   $��5��6�   $��Right=�6�   $��Center=�6�   $��Center=�6�   $�� 0 0 5 0q�6�   ��6   �� *!Begegnung.Spiel.ToreMannschaft1+$	 TwoWay=�$
 PropertyChanged=�6�   �� 5<   
   $��1��6u   $��5��6�   $
��Left=�6�   $��Center=�6�   $��Center=�6�   $��5 0 0 0q�6�   ��6   �� *!Begegnung.Spiel.ToreMannschaft2+$	 TwoWay=�$
 PropertyChanged=�6�   � 5?   
    � Minimum$ 0Q�6    � Maximum$	 100Q�6"   $��10��60    � IsIndeterminate . $��0��6�   $��7��6�   $��Center=�6�   $��	10 0 10 0q�6�   y�6U   �� *ProgressBarVisibility+$	 TwoWay=�$
 PropertyChanged=�6�   �� 5@   
   -   5          GruppenButton#���  5@   O   $��1��6�   $��6��6�   $��2��6�   $��Right=�6�   $��Bottom=�6�   .��5A      �� $
��None=�6   $&�� ..\Style\Images\speichernBtn.png��6#   5B      5E      5F      