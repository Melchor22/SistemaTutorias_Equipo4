   M S B A M L   `   `   `  ����Q  MClienteSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:ClienteSistemaTutorias.InterfacesUsuario(ClienteSistemaTutorias.InterfacesUsuario  5   	   @    :ClienteSistemaTutorias.InterfacesUsuario.WindowEstudiantes   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:ClienteSistemaTutorias.InterfacesUsuario     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$ SingleBorderWindow=�5	   	    � Title$ Estudiantes��5
   	   $	��450��6   $	��800��6*    � Icon$G A..\..\Resources/1200px-Logo_de_la_Universidad_Veracruzana.svg.png��66   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgEstudiantes��5         AutoGenerateColumns$ False��6*   $��
0,38,160,0q�6F      CanUserAddRows$ False��6Z   $��16(�6q      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Matricula��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 108 6V   
   
IsReadOnly$

 True��6b   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *	matricula+6b     5      $ Nombre��6%   $	 * 6P   $

 True��6Z    65   �� *nombre+6Z     5      $ Apellido Paterno��6%   $	 * 6c   $

 True��6m    6?   �� *apellidoPaterno+6m     5      $ Apellido Materno��6%   $	 * 6c   $

 True��6m    6?   �� *apellidoMaterno+6m   5      �� 5   
   -   5         ��Name$ btRegistrarEstudiante��5      $��Nuevo Estudiante��60   $
��Left=�6K   $��655,136,0,0q�6f   $	��Top=�6{   $��16(�6�   $��41��6�   $	��135��6�   6�   �� 5   
   -   5        $ btAsignarTutor��5      $��Asignar Tutor��6)   $
��Left=�6A   $��	655,0,0,0q�6\   $��Center=�6o   $��16(�6�   $��41��6�   $	��135��6�   6�   �� 5   
   $��Estudiantes��6   $
��Left=�6&   $��	270,4,0,0q�6A   $	��Top=�6T   $��18(�6l   5      5      