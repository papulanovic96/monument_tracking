   M S B A M L   `   `   `  ����D  @Project C, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Project_C.Create_monumentProject_C.Create_monument  5   	   8    2Project_C.Create_monument.Prikaz_spomenika_na_mapi   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Project_C.Create_monument     5   	     � Icon$W  QC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\IPlogo1.png��5   	    � Title$ Prikaz_spomenika_na_mapi��5	   	   $	��450��6*   $	��500��67   ���	#FF252526
������� � WindowStyle$
 None=�6r    � 	Resources 5
       �� 
TargetType   FlatButtonStyle �� Property �� Value �� 
TargetType �� Triggers	 P� Property
 P� Value �� 
TargetName��%  &	        �� 5   
   " ��6   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��1q�6/   ���	#FF686868#��z��6[   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5      	 �@J�IsMouseOver
 . . �5   "   �� $ border��6)    � ��
 �����6S   �� 5   "    �@J�Opacity$
 0.91Q�6<   5      5      5      5      5      .��5!      � $��20,43,20,20q�6    � RowDefinitions 5"   
   �� 5#      .+�5&   
   &   System.Windows.Controls.DataGrid  -   5          Name$ spomeniciMapaDataGrid��5&   !   $��16(�6   ���	#FF252526   AutoGenerateColumns .  $��
1,-1,0,287q�6�   ��6s   �� *Spomen+   Columns 5(      4  .System.Windows.Controls.DataGridTemplateColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6)      CellTemplate 5+      �� 5,      .R�5-      ��  �� Orientation$ 
Horizontal=�6)   .+�5.   "   �� ��6,   �� *Oznaka+5/      50      52      0  *System.Windows.Controls.DataGridTextColumn  54      $ Naziv��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Naziv+6P     55      $	 Tip��6%    62   �� *Tip_return_string+6Z     56      $	 Era��6%    62   �� *Era+6L     57      $ Ikonica��6)      CellEditingTemplate 58      �� 59      .R�5:      �� ��6$   �� *	Ikonica+6A   5;      5=        5>      $ Arheoloski obradjen��6%    6B   �� *Arheoloski_obradjen+6l     5?      $ UNESCO��6%    65   �� *UNESCO+6R     5@      $ Naseljeni region��6%    6?   �� *Naseljeni_region+6f     5A      $ Turisticki status��6%    6@   �� *Turisticki_status+6h     5B      $ Turisticki prihod��6%    6@   �� *Turisticki_prihod+6h     5C      $ Datum otkrivanja��6%    6?   �� *Datum_otkrivanja+6f     5D      $
 Opis��6%    63   �� *Opis+6N     5F      $ Etiketa��6&      	CellStyle 5H      �� 5I      *  $System.Windows.Controls.DataGridCell"  6    .�5J      ��  � �� 6;   �� *Etiketa_return_string+5K      5N      5S        5T   
   -   5        $ prikazTipovaDataGrid��5T         
IsReadOnly . ��. $
��Auto=�6�   $��Visible=�6�   $��
0,131,0,10q�6�    .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6&  ���	#FF252526
���   ����	#FF0D3155$��Century Gothic)�6�  $��16(�6�   J� RenderTransformOrigin$ 0.5,0.5&�6�  $
��Left=�6�  $	��230��6�  ��61   ��  �� Path$ Prikaz_tipa� 5U        5W      $ Oznaka��6%    65   �� *Oznaka_Tipa+6W     5X      $	 Ime��6%    62   �� *
Ime_Tipa+6Q     5Y      $ Ikonica��6)    5Z      �� 5[      .R�5\      �� ��6$   �� *Slika+6?   5]      5_        5`      $
 Opis��6%    63   �� *	Opis_Tipa+6S   5b        5d   
   -   5        $ prikazDataGrid��5d       . $��235,131,0,10q�6a      SelectionMode$ Extended=�6w   ��. $
��Auto=�6�   $��Visible=�6�    .  $
 TrueY�66  ���	#FF252526
���   ����	#FF0D3155$��Century Gothic)�6�  $��16(�6�  ��6+   �� $ Prikaz� 5e        5f      $ Oznaka��6%    65   �� *Oznaka_etiketa+6Z     5g      $
 Boja��6&    5h      �� 5i      "  6    .�5k      ��  � �� 6;   �� *Boja_etiketa+5l      5n        5o      $
 Opis��6%    63   �� *Opis_etiketa+6V   5q      �� 5r   
   $
��Left=�6   $��	0,105,0,0q�6/   $
��Wrap=�6B   $��TIP Spomenika��6V   $	��Top=�6k   $��21��6�   $	��230��6�   �� 5s   
   $
��Left=�6   $��235,105,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��21��6p   $	��217��6|   �� 6�   $�ETIKETE��6�   �� 6�   $�
 Spomenika��6�   6�   �� 5t   
   -   5        #��[  5t      $��X��6:   $
��Left=�6F   $��437,-37,-14,0q�6a   $	��Top=�6x   $��29��6�   6�   5u      5w      