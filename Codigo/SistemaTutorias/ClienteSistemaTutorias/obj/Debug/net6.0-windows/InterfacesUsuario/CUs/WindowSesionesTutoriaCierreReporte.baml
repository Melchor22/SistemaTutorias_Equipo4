   M S B A M L   `   `   `  ����Q  MClienteSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:ClienteSistemaTutorias.InterfacesUsuario(ClienteSistemaTutorias.InterfacesUsuario  5   	   Q    KClienteSistemaTutorias.InterfacesUsuario.WindowSesionesTutoriaCierreReporte   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:ClienteSistemaTutorias.InterfacesUsuario     5   	     � Title$$  Cierre de Reporte de Tutorías��5   	   $	��450��6/   $	��800��6<    � Icon$G A..\..\Resources/1200px-Logo_de_la_Universidad_Veracruzana.svg.png��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$ SingleBorderWindow=�5   	   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgSesionesTutoria��5         AutoGenerateColumns$ False��6.   $��	0,0,182,0q�6J      CanUserAddRows$ False��6]   $��16(�6t      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Fecha��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 120 6N   
   
IsReadOnly$

 True��6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *fecha+6Z     5      $ #Sesion��6%   $	 80 6T   $

 True��6_    66   �� *	numSesion+6_     5      $ Periodo Escolar��6%   $	 * 6a   $

 True��6k    6>   �� *periodoEscolar+6k     5      $ Fecha de Cierre��6%   $	 * 6^   $

 True��6h    6>   �� *fechaCierre+6h   5      �� 5   
   -   5         ��Name$ btModificarFechaCierre��5      $��Modificar Fecha Cierre ��61   $
��Left=�6S   $��624,217,0,0q�6n   $	��Top=�6�   $��16(�6�   $	��167��6�   $��52��6�    J� RenderTransformOrigin$ 0.545,0.258&�6�   �� 5   
   -   5         ��Name$ tbFechaCierreReporte��5      $
��Left=�60   $��
628,84,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��158��6�   $��20(�6�   �� 5   
   $��Fecha (DD/MM/YYYY)��6   $
��Left=�6-   $��
648,48,0,0q�6H   $	��Top=�6\   $��16(�6t   �� 5   
   $��Hora (HH:MM):��6   $
��Left=�6(   $��649,118,0,0q�6C   $	��Top=�6X   $��16(�6p   �� 5   
   -   5        $ tbHoraCierreReporte��5      $
��Left=�6/   $��628,149,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��158��6�   $��20(�6�   5      5      