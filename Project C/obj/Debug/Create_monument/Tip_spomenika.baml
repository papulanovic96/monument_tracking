   M S B A M L   `   `   `  ����D  @Project C, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Project_C.Create_monumentProject_C.Create_monument  5   	   /clr-namespace:Project_C.HelpProject_C.Help  5   	   -    'Project_C.Create_monument.Tip_spomenika   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Project_C.Create_monument     5   	   *lclr-namespace:Project_C.Help     5   	     � Icon$W  QC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\IPlogo1.png��5	   	    � Title$ Tip_spomenika��5
   	   $	��397��6   $	��700��6,   ���	#F8282935 � 
ResizeMode$ NoResize=�6O     Project_C.Help.HelpDavac   HelpKey$ 	TipDialog��6e    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Help��5      6<    � 	Resources 5       �� 
TargetType   FlatButtonStyle �� Property	 �� Value
 �� 
TargetType �� Triggers P� Property P� Value �� 
TargetName��%  &	        �� 5   
   " ��6   .�5      ��  �@�OverridesDefaultStyle	 . 66   �� 5       �@�Cursor$
	 Hand��6'   �� 5       � ��	 5      �� 5      "
 ��6&   .R�5      �� $��border��6!   $��1q�6/   ���	#FF686868#��z��6[   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5       �@J�IsMouseOver . . �5   "   �� $ border��6)    � ��
	 �����6S   �� 5   "    �@J�Opacity$
	 0.91Q�6<   5      5       5"      5#      5$      .��5&      � $��20q�6    � RowDefinitions 5(   
   �� 5)       � ColumnDefinitions 5,   
   �� 5-      $	��175 �6   �� 5.      $	��120 �6   �� 5/      $	��855 �6   $	��855��6+   .+�52   
   &   System.Windows.Controls.DataGrid  -   5          Name$ tipoviDataGrid��52      ��. $
��Auto=�6�   $��Visible=�6�   $��14,10,502,60q�6�      AutoGenerateColumns .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6  $��2��6>  ���	#FF252526
���   ����	#FF0D3155$��Century Gothic)�6�  $��16(�6�  ��6+   ��  �� Path$ Tipovi� �� Mode$ TwoWay=�   Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Oznaka_Tipa+6W     55      $	 Ime��6%    62   �� *
Ime_Tipa+6Q   4  .System.Windows.Controls.DataGridTemplateColumn  56      $ Ikonica��6)      CellEditingTemplate 57      �� 58      .R�59      �� $��20��6=   $��20��6I   ��6$   �� *Slika+6V   5:      5<        5=      $
 Opis��6%    63   �� *	Opis_Tipa+6S   5?      �� 5A   
   -   5         ��Name$ groupBox��5A      $��Tip spomenika��6%   $
��Left=�6<   $	��Top=�6W   $	��265��6o   $	��288��6|   
�������$��Century Gothic)�6�   $��16(�6�   ���	#FF686868$��7,4,0,0q�6�   $��2��6�   .��5B      � $��0��6   $��1��6#   $��2,0,-2,5q�6v    � DataContext 60   ��  �� ElementName$ tipoviDataGrid��$ SelectedItem� 5C      �� 5D      �� 5E      �� 5F      �� 5G      �� 5H      �� 5I      �� 5J      �� 5K      �� 5L      �� 5M       5P      �� 5Q      $	��161 �6'   �� 5R      $	��115 �6'   .+�5V      �� $��0��6   $��0��6,   $��Right=�69   $��0,0,10,0q�6U   $��Century Gothic)�6g   
�������	Oznaka:6�   �� 5W      $��0��6   $��2��6,   $��Right=�69   $��0,0,10,0q�6U   $��Century Gothic)�6g   
�������$��Ikonica:��6�   �� 5X      $��0��6   $��3��6,   $��Right=�69   $��0,0,10,0q�6U   $��Century Gothic)�6g   
�������Opis:6�   �� 5Y      $��0��6   $��1��6,   $��Right=�69   $��0,0,10,0q�6U   $��Century Gothic)�6g   
�������Ime:6�   �� 5[      -   5         ��Name$ 	txtOznaka��5[   9   $ oznaka��6   $��1��6L   $��0��6\   
����������	#FF252526 �� SelectionBrush �	#FF3E3E42���	#FF686868��6i   �� $ Oznaka_Tipa�6�   �� 5\      -   5        $ txtIme��5\   8   $ naziv��6   $��1��6H   $��1��6X   
����������	#FF252526 �	#FF3E3E42���	#FF686868��6e   �� $ Ime_Tipa�6�   �� 5]      -   5         ��Name$ 
imgPreview��5]      $��1��6,   $��2��6<   $��82,0,0,0q�6b   ��6I   �� *Slika+6x   �� 5^      -   5        $ txtOpis��5^   7   $
 opis��6   $��1��6H   $��3��6X   $��3��6f     �� TextWrapping$
  Wrap=�6w   
����������	#FF252526 �	#FF3E3E42���	#FF686868��6�   �� $ 	Opis_Tipa�6
  �� 5`      -   5        ! ��Name$! izaberi_ikonicu_tipa_btn��5`   B   #��[  6   $��1��6e   $��2��6u   $��1,0,32,0q�6�   .��6�   ...6�   �� 5a      -	   5        $! izmjena_tipa_btn��5a   h   #��[  6   " � ToolTip$!" Izmjena selektovanog tipova��6B   $��Izmjeni��6�   $
��Left=�6�   $��26,0,0,0q�6�   $��7��6�   $��79��6�   $��1��6�   �� 5b      -
   5        $! brisanje_tipa_btn��5b   g   #��[  6   $ " Brisanje selektovanog tipa��6B   $��Obriši��6�   $
��Left=�6�   $��	26,10,0,0q�6�   $��8��6�   $	��Top=�6�   $��79��6�   $��24��6�   $��1��6  $��2��6-  �� 5c      -   5        $! novi_tip_btn��5c   U   #��[  6   $" Novi tip��6B   $��7��6k   $��	10,0,72,0q�6x   $
��Novi��6�   6�   �� 5d      -   5        $! cuvanje_tipa_btn��5d   _   #��[  6   $" Čuvanje novog tipa��6B   $��7��6y   $��	99,0,98,0q�6�   $��Sačuvaj��6�   $��2��6�   6�   5g      5h      �� 5i   
   -   5        $! 
ucitaj_btn��5i   [   #��[  6   $" Učitavanje iz datoteke��6:   $��Učitaj��6o   $
��Left=�6�   $��273,293,0,0q�6�   $	��Top=�6�   $��76��6�   $��2��6�   $��26��6�   $��Century Gothic)�6	  $��16(�6%  
�������63  �� 5j   
   -   5        $! sacuvaj_btn��5j   W   #��[  6   $" Čuvanje u datoteku��6:   $��Sačuvaj��6l   $
��Left=�6~   $��176,293,0,0q�6�   $	��Top=�6�   $��76��6�   $��2��6�   $��26��6�   $��Century Gothic)�6  $��16(�6#  
�������61  �� 5k   
   -   5        $! 	izlaz_btn��5k   W   #��[  6   $" Izlazak iz prozora��6:   $��Izađi��6j   $
��Left=�6z   $��
28,293,0,0q�6�   $	��Top=�6�   $��76��6�   $��1��6�   $��26��6�   $��Century Gothic)�6   $��16(�6  
�������6*  �� 5l   
   -   5        $! dodaj_tip_btn��5l   j   #��[  6   $+" %Dodavanje tipa selektovanom spomeniku��6:   $��	Dodaj tip��6�   $
��Left=�6�   $��114,293,0,0q�6�   $	��Top=�6�   $��76��6�   $��26��6�   $��Century Gothic)�6  $��16(�6.  
�������$��2��6O  5n      5o      