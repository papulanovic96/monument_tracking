   M S B A M L   `   `   `  ����D  @Project C, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Project_C.Create_monumentProject_C.Create_monument  5   	   /clr-namespace:Project_C.HelpProject_C.Help  5   	   '    !Project_C.Create_monument.Etikete   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Project_C.Create_monument     5   	   *lclr-namespace:Project_C.Help     5   	     � Icon$W  QC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\IPlogo1.png��5	   	    � Title$ Etikete��5
   	   $��386.333��6   $	��700��6*   ���	#FF252526 � 
ResizeMode$ NoResize=�6M     Project_C.Help.HelpDavac   HelpKey$ EtiketaDialog��6c    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<    � 	Resources 5       �� 
TargetType   FlatButtonStyle �� Property	 �� Value
 �� 
TargetType �� Triggers P� Property P� Value �� 
TargetName��%  &	        �� 5   
   " ��6   .�5      ��  �@�OverridesDefaultStyle	 . 66   �� 5       �@�Cursor$
	 Hand��6'   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� $��border��6!   $��1q�6/   ���	#FF686868#��z��6[   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver . . �5   "   �� $ border��6)    � ��
	 �����6S   �� 5   "    �@J�Opacity$
	 0.91Q�6<   5      5      5       5!      5"      .��5$      � $��20q�6    � RowDefinitions 5&   
   �� 5'       � ColumnDefinitions 5*   
   �� 5+      $
��Auto �6   $	��295��6,   $	��295��6;   �� 5,      $	��859 �6   .+�50   
   &   System.Windows.Controls.DataGrid  -   5          Name$ etiketeDataGrid��50      $��
0,0,502,50q�6T      SelectionMode$ Extended=�6h   ��. $
��Auto=�6�   $��Visible=�6�      AutoGenerateColumns .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6'  $��1��6L  ���	#FF252526
���   ����	#FF0D3155$��Century Gothic)�6�  $��16(�6�  ��6,   ��  �� Path$ 
Etikete_oc�   Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Oznaka_etiketa+6Z     53      $
 Boja��6&      	CellStyle 54      �� 55      *  $System.Windows.Controls.DataGridCell"  6    .�57      ��  � ��	 6;   �� *Boja_etiketa+58      5:        5;      $
 Opis��6%    63   �� *Opis_etiketa+6V   5=      �� 5?   
   -   5         ��Name$ groupBox��5?      $��Etiketa��6%   $
��Left=�66   $	��Top=�6Q   $	��260��6i   $
��auto��6v   
�������$��Century Gothic)�6�   $��16(�6�   ���	#FF686868.��5@      � $��0��6   $��1��6#   $��2,0,-2,5q�6w    � DataContext 60   ��  �� ElementName$ etiketeDataGrid��$ SelectedItem� 5A      �� 5B      �� 5C      �� 5D      �� 5E      �� 5F      �� 5G      �� 5H      �� 5I      �� 5J      �� 5K       5N      �� 5O      $	��161 �6'   �� 5P      $	��115 �6'   .+�5T      �� $��0��6   $��0��6,   $��Right=�69   $��0,0,10,0q�6U   $��Century Gothic)�6g   
�������$��16(�6�   	Oznaka:6�   �� 5U      $��0��6   $��1��6,   $��Right=�69   $��0,0,10,0q�6U   $��Century Gothic)�6g   
�������$��Boja:��6�   $��16(�6�   �� 5V      $��0��6   $��2��6,   $��Right=�69   $��0,0,10,0q�6U   $��Century Gothic)�6g   
�������$��16(�6�   Opis:6�   �� 5Y      -   5         ��Name$ 	txtOznaka��5Y   9   $ oznaka��6   $��1��6L   $��0��6\   
����������	#FF252526 �� SelectionBrush �	#FF3E3E42���	#FF686868��6i   �� $ Oznaka_etiketa�6�   �� 5Z      -   5        $ txtColor��5Z   7   $
 boja��6   $��1��6I   $��1��6Y   
����������	#FF252526 �	#FF3E3E42���	#FF686868$��90,0,0,0q�6�   ��6�   �� $ Boja_etiketa�6�   �� 5[      -   5        $ txtOpis��5[   7   $
 opis��6   $��1��6H   $��2��6X   $��4��6f    �� TextWrapping$
 Wrap=�6w   
����������	#FF252526 �	#FF3E3E42���	#FF686868��6�   �� $ Opis_etiketa�6  �� 5\      -   5          ��Name$  izaberi_boju_btn��5\   B   #��[  6   $��1��6\   $��1��6l   $��0,0,25,0q�6y   .��6�   ...6�   �� 5^      -   5        $  nova_etiketa_btn��5^   B   #��[  6   $��7��6\   $��	10,0,75,0q�6i   $
��Nova��6}   $��23��6�   $	��Top=�6�   6�   �� 5_      -	   5        $  sacuvaj_etiketu_btn��5_   B   #��[  6   $��7��6_   $��100,0q�6l   $��Sačuvaj��6�   $��2��6�   �� 5`      -
   5        $  izmjeni_etiketu_btn��5`   B   #��[  6   $��Izmjeni��6_   $
��Left=�6q   $��29,0,0,0q�6�   $��7��6�   $	��Top=�6�   $��76��6�   $��23��6�   $��1��6�   �� 5a      -   5        $  obrisi_etiketu_btn��5a   B   #��[  6   $��Obriši��6^   $
��Left=�6o   $��	29,10,0,0q�6�   $��8��6�   $	��Top=�6�   $��76��6�   $��1��6�   $��22��6�   $��2��6
  5c      5d      �� 5e   
   -   5        $  dodaj_etiketu_btn��5e   :   #��[  6   $��Dodaj��6U   $
��Left=�6e   $��110,273,0,0q�6�   $	��Top=�6�   $��76��6�   $��27��6�   $��Century Gothic)�6�   
�������$��16(�6�   6  �� 5f   
   -   5        $  izadji_etikete_btn��5f   :   #��[  6   $��Izađi��6V   $
��Left=�6f   $��198,273,0,0q�6�   $	��Top=�6�   $��76��6�   $��27��6�   $��Century Gothic)�6�   
�������$��16(�6�   6  �� 5g   
   -   5        $  ucitaj_etikete_btn��5g   :   #��[  6   $��Učitaj��6V   $
��Left=�6g   $��273,273,0,0q�6�   $	��Top=�6�   $��76��6�   $��27��6�   $��Century Gothic)�6�   
�������$��16(�6�   $��1��6  6  �� 5h   
   -   5        $  sacuvaj_etikete_btn��5h   :   #��[  6   $��Sačuvaj��6W   $
��Left=�6i   $��187,273,0,0q�6�   $	��Top=�6�   $��76��6�   $��27��6�   $��Century Gothic)�6�   
�������$��16(�6�   $��1��6  6  5i      5k      