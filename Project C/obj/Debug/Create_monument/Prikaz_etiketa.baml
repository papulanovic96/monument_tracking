   M S B A M L   `   `   `  ����  	Project C.    (Project_C.Create_monument.Prikaz_etiketa   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Icon$W  QC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\IPlogo1.png��5   	    � Title$ Prikaz_etiketa��5   	   $	��450��6    $	��422��6-   ���	#FF252526 � 
ResizeMode$ NoResize=�6P    � 	Resources 5	       �� 
TargetType   FlatButtonStyle �� Property �� Value �� 
TargetType �� Triggers	 P� Property
 P� Value �� 
TargetName��%  &	        �� 5
   
   " ��6   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��1q�6/   ���	#FF686868#��z��6[   ._�5      �� $��Center=�6/   $��Center=�6L   5       5      P� 5      	 �@J�IsMouseOver
 . . �5   "   �� $ border��6)    � ��
 �����6S   �� 5   "    �@J�Opacity$
 0.91Q�6<   5      5      5      5      5      .��5      � $��20q�6    � RowDefinitions 5!   
   �� 5"       � ColumnDefinitions 5%   
   �� 5&      $	��431 �6   .+�5*   
   &   System.Windows.Controls.DataGrid  -   5          Name$ prikazDataGrid��5*         
IsReadOnly . $��0,0,57,0q�6a      SelectionMode$ Extended=�6s   ��. $
��Auto=�6�   $��Visible=�6�      AutoGenerateColumns .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�62  ���	#FF252526
���   ����	#FF0D3155$��Century Gothic)�6�  $��16(�6�  ��6+   ��  �� Path$ Prikaz�   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ Oznaka��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Oznaka_etiketa+6Z     5-      $
 Boja��6&      	CellStyle 5.      �� 5/      *  $System.Windows.Controls.DataGridCell"  6    .�51      ��  � �� 6;   �� *Boja_etiketa+52      54        55      $
 Opis��6%    63   �� *Opis_etiketa+6V   57      58      5:      