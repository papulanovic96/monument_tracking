   M S B A M L   `   `   `  ����D  @Project C, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Project_C.Create_monumentProject_C.Create_monument  5   	   -    'Project_C.Create_monument.Prikaz_tipova   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Project_C.Create_monument     5   	     � Icon$W  QC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\IPlogo1.png��5   	    � Title$	 Tip��5	   	   $	��217��6   $	��450��6"   ���	#FF252526 � 
ResizeMode$ NoResize=�6E   .��5
      � $��20,23,20,20q�6    � RowDefinitions 5   
   �� 5       � ColumnDefinitions 5   
   �� 5      $	��380 �6   $	��380��6+   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ prikazTipovaDataGrid��5         
IsReadOnly . ��. $
��Auto=�6�   $��Visible=�6�   $��10,0,0,1q�6�      AutoGenerateColumns .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�6$  ���	#FF252526
���   ����	#FF0D3155$��Century Gothic)�6�  $��16(�6�  	 J� RenderTransformOrigin$	 0.5,0.5&�6�  $
��Left=�6�  $	��369��6�  ��61   �� 
 �� Path$
 Prikaz_tipa�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Oznaka_Tipa+6W     5      $	 Ime��6%    62   �� *
Ime_Tipa+6Q   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Ikonica��6)      CellEditingTemplate 5      �� 5      .R�5      �� ��6$   �� *Slika+6?   5      5        5       $
 Opis��6%    63   �� *	Opis_Tipa+6S   5"      5#      5$      