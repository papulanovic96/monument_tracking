   M S B A M L   `   `   `  ����D  @Project C, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Project_C.HelpProject_C.Help  5   	   E'clr-namespace:Project_C.Create_monumentProject_C.Create_monument  5   	       Project_C.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *lclr-namespace:Project_C.Help     5   	   8tamo'clr-namespace:Project_C.Create_monument     5   	     � Icon$W  QC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\IPlogo1.png��5	   	    � Title$ Monument��5
   	    � 
ResizeMode$ NoResize=�6   $	��600��60   $
��1000��6=   ���	#FF252526$��20(�6a    J� SnapsToDevicePixels . $y�Visible=�6�   $��0q�6�     Project_C.Help.HelpDavac   HelpKey$ 
MejnWindow��6�    � 	Resources 5         MyImage  MyImage2  MyImage3  MyImage4  contMenu �� 
TargetType  FlatButtonStyle �� Property �� Value	 �� 
TargetType
 �� Triggers P� Property P� Value �� 
TargetName  	SmallIcon��%  &	        &	 p     &	 �     &	 J    &	 �    &	 ?    &	 H    �� 5   
   $\��VC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\add_monument.png��6    �� 5   
   $X��RC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\add_type.png��6!   �� 5   
   $Z��TC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\add_ticket.png��6!   �� 5   
   $T��NC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\save.png��6!   �� 5   
   .@�5      m� $��Obriši sa mape��6   m� 5      $(��"Obriši iz baze podataka i sa mape��6   �� 5      5      �� 5   
   " ��6   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5       �� $��border��6!   $��0q�6/   ���	#FF686868#��z��6[   ._�5!      �� $��Center=�6/   $��Center=�6L   5"      
 5$      P� 5%       �@J�IsMouseOver . . �5&   "   �� $ border��6)    � ��
 �����6S   �� 5'   "    �@J�Opacity$
 0.91Q�6<   5(      5*      5,      5-      �� 5.   
   " ��6"   .�5/      ��  � ��$ 16��6)   �� 50       � ��$ 16��6*   �� 51       � ��$ 1q�6'   52      53       J� CommandBindings 55      )  #System.Windows.Input.CommandBinding  56   
   -   5           Command$ ApplicationCommands.Help��56      6<   .��59      � $��Bottom=�6   $��Stretch=�6#   $��Stretch=�6?   .+�5;   
   ]� $��	0,0,0,490q�6   .+�5<      o� $	��Top=�6   
����������	#FF252526$��24(�6X   $��Century Gothic)�6f   $��38��6�   ��5=      �� 5>      .R�5?      ]� $��Stretch=�6$   $��50��6B   5@      .@�5B      m� $��_File��6   ���	#00000000$��0,0,0,17q�6A   .@�5C      m� $��_Novi��6   $��40,0,0,0q�6.   .@�5D      m� -   5        $��	_Spomenik��5D   #   $��29,0,0,0q�6K    m� Icon 5E      �� 5F   "   $\��VC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\add_monument.png��6(   6�   5H      m� 5I      -   5        $
��_Tip��5I   #   $��29,0,0,0q�6B    5J      �� 5K   "   $X��RC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\add_type.png��6(   6�   5N      m� 5O      -   5        $��_Etiketa��5O   #   $��32,0,0,0q�6G    5P      �� 5Q   "   $Z��TC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\add_ticket.png��6(   6�   5S      5T      m� 5V      -   5        $��_Sačuvaj mapu��5V      $��40,0,0,0q�6P    5X      �� 5Y      $T��NC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\save.png��6$   6~   5\      �� 5]      6"   m� 5^      -   5        $��_Izađi��5^      $��40,0,0,0q�6C   6X   5_      m� 5`      -   5        $��Pomoć��5`      $��Right=�6*   $��0,0,0,12q�6X   $	��101��6j   6x   5a      o� 5c      ���	#FF6E6E7E$��	0,5,0,-11q�6*   .@�5d      �� -   5        #��[ 5d      #��[  6W   ���	#FF6E6E7E$��34��6�   $��60��6�    � ToolTip 5e      �� 5f       �� Orientation$ 
Horizontal=�6%   .+�5g      �� $��5q�6$   $\��VC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\add_monument.png��6/   6�   �� 5h      $��5q�6(   $
��Wrap=�63   $	��100��6G   Rad sa spomenicima.5j      5k      5m      �� 5n      -	   5        #��[ 5n      #��[ 6S   ���	#FF6E6E7E$��34��6�   $��60��6�    5o      �� 5p      $ 
Horizontal=�6%   .+�5q      �� $��5q�6$   $X��RC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\add_type.png��6/   6�   �� 5r      $��5q�6(   $
��Wrap=�63   $	��100��6G   Rad sa tipovima spomenika.5t      5u      5w      �� 5x      -
   5        #��[ 5x      #��[ 6T   ���	#FF6E6E7E$��34��6�   $��60��6�    5y      �� 5z      $ 
Horizontal=�6%   .+�5{      �� $��5q�6$   $Z��TC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\add_ticket.png��6/   6�   �� 5|      $��5q�6(   $
��Wrap=�63   $	��100��6G   Rad sa etiketama.5~      5      5�      �� 5�      -   5        #��[ 5�      #��[ 6\   ���	#FF6E6E7E$��34��6�   $��60��6�    5�      �� 5�      $ 
Horizontal=�6%   .+�5�      �� $��5q�6$   $T��NC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\save.png��6/   6�   �� 5�      $��5q�6(   $
��Wrap=�63   $	��100��6G   Čuvanje mape spomenika.5�      5�      5�      5�      5�      �� 5�   
   -   5         ��Name$ 
canvas_map��5�   \    J� 	AllowDrop . $��206,121,1,10q�6p   .+�5�      �� -   5         ��Name$ slikaa��5�      $S��MC:\Users\Papulanovic\Desktop\Project C\Project C\Project C\bin\images\map.png��6$   $	��441��6{   $	��787��6�   5�      �� 5�   
   -   5         ��Name$ listaSpomenika��5�      $��10,121,793,10q�6�   $��Disabled=�6�   ���	#FF252526��6+   �� *Spomen+��5�      �� 5�      .R�5�      �� $ Horizontal =�6!    6;   �� *Naziv+.+�5�      �� $��32��6    $��32��6+   $��0,0,10,0q�67   ��6I   �� *	Ikonica+6f   �� 5�      
���������6$   �� *Naziv+6Q   5�      5�      5�      �� 5�   
   -   5         ��Name$ 
search_box��5�   \   $ Search��6   $
��Left=�6�   $��29��6�   $��	10,87,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $��15(�6�   $	��Top=�6�   $	��181��6   ��6p   ��  �� Path$ Naziv�6   5�      5�      