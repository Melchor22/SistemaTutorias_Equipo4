   M S B A M L   `   `   `  ����Q  MClienteSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:ClienteSistemaTutorias.InterfacesUsuario.CUs,ClienteSistemaTutorias.InterfacesUsuario.CUs  5   	   N    HClienteSistemaTutorias.InterfacesUsuario.CUs.WindowProblematicaAcademica   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:ClienteSistemaTutorias.InterfacesUsuario.CUs     5   	     � Title$  Problematicas Academicas��5   	   $	��450��6*   $	��800��67    � Icon$G A..\..\Resources/1200px-Logo_de_la_Universidad_Veracruzana.svg.png��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$ SingleBorderWindow=�5   	   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgProblematicasAcademicas��5         AutoGenerateColumns$ False��66   $��0,69,0,0q�6R      CanUserAddRows$ False��6d   $��14(�6{      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Estudiante��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 220 6X   
   
IsReadOnly$

 True��6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *
estudiante+6d     5      $ 
Categoría��6%   $	 * 6V   $

 True��6`    68   �� *	categoria+6`     5      $ Estado��6%   $	 * 6P   $

 True��6Z    65   �� *estado+6Z     5      $ Materia��6%   $	 60 6N   $

 True��6Y    66   �� *nrc+6Y     5      $ Descripción��6%   $		 200 6Z   $

 True��6f    6:   �� *descripcion+6f   5      �� 5   
   -   5         ��Name$ btRegistrarProblematica��5      $��Registrar Problematica��62   $
��Left=�6S   $��
277,15,0,0q�6n   $	��Top=�6�   $��16(�6�   $	��180��6�   $��40��6�   6�   �� 5   
   -   5        $ btVerSolucion��5      $��Ver Solucion��6(   $
��Left=�6?   $��
481,15,0,0q�6Z   $	��Top=�6n   $��16(�6�   $	��110��6�   $��40��6�   6�   �� 5   
   -   5        $ btRegistrarSolucion��5      $��Registrar Solucion��6.   $
��Left=�6K   $��
615,15,0,0q�6f   $	��Top=�6z   $��16(�6�   $	��145��6�   $��40��6�   6�   5      5      