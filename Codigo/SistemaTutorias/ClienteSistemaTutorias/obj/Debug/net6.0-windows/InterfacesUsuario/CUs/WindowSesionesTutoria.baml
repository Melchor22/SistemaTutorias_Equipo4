   M S B A M L   `   `   `  ����Q  MClienteSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:ClienteSistemaTutorias.InterfacesUsuario(ClienteSistemaTutorias.InterfacesUsuario  5   	   D    >ClienteSistemaTutorias.InterfacesUsuario.WindowSesionesTutoria   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:ClienteSistemaTutorias.InterfacesUsuario     5   	     � Title$  Sesiones de Tutoria��5   	   $	��450��6%   $	��800��62    � Icon$G A..\..\Resources/1200px-Logo_de_la_Universidad_Veracruzana.svg.png��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$ SingleBorderWindow=�5   	   .��5      � .+�5   
   �� -   5         ��Name$ btRegistrarSesion��5      $��Nueva��6,   $
��Left=�6<   $��
550,65,0,0q�6W   $	��Top=�6k   $��16(�6�   $��80��6�   $��40��6�   6�   �� 5   
   -   5        $ btModificarSesion��5      $��	Modificar��6,   $
��Left=�6@   $��
650,65,0,0q�6[   $	��Top=�6o   $��16(�6�   $	��110��6�   $��40��6�    J� RenderTransformOrigin$ 0.545,0.258&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgTutoriasAcademicas��5         AutoGenerateColumns$ False��61   $��	0,0,266,0q�6M      CanUserAddRows$ False��6`   $��14(�6w   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Fecha��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6N      
IsReadOnly$
 True��6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *fecha+6X     5      $
 #Sesion��6%   $ 70 6T   $
 True��6_    66   �� *	numSesion+6_     5      $
 Periodo Escolar��6%   $ * 6a   $
 True��6k    6>   �� *periodoEscolar+6k     5      $
 Cierre Reporte��6%   $ * 6]   $
 True��6g    6=   �� *fechaCierre+6g   5      �� 5   
   $��Sesiones de Tutoría��6   $
��Left=�6.   $��
555,10,0,0q�6I   $	��Top=�6]   $��20(�6u   �� 5   
   $��Reporte de Tutoría��6   $
��Left=�6-   $��555,151,0,0q�6H   $	��Top=�6]   $��20(�6u   �� 5   
   -   5        $ btRegistrarReporte��5      $��Nuevo��6-   $
��Left=�6=   $��555,210,0,0q�6X   $	��Top=�6m   $��16(�6�   $��80��6�   $��40��6�   6�   �� 5   
   $��Problematica Académica��6   $
��Left=�61   $��550,291,0,0q�6L   $	��Top=�6a   $��20(�6y   �� 5   
   -   5        $ btGestionProblematica��5      $��Gestión Problematica��60   $
��Left=�6O   $��555,347,0,0q�6j   $	��Top=�6   $��16(�6�   $	��170��6�   $��40��6�   $ 0.545,0.258&�6�   5      5      