   M S B A M L   `   `   `  ����Q  MClienteSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:ClienteSistemaTutorias.InterfacesUsuario(ClienteSistemaTutorias.InterfacesUsuario  5   	   K    EClienteSistemaTutorias.InterfacesUsuario.WindowReporteTutoriaPorTutor   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:ClienteSistemaTutorias.InterfacesUsuario     5   	     � Title$"  WindowReporteTutoriaPorTutor��5   	   $	��450��6.   $	��800��6;   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgTutores��5
         AutoGenerateColumns$ False��6&   $��	0,0,266,0q�6B      CanUserAddRows$ False��6U   $��14(�6l      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ NumPersonal��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Z      
IsReadOnly$
 True��6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *numPersonal+6d     5      $ Nombre��6%   $ 70 6P   $
 True��6[    65   �� *nombre+6[     5      $ Apellido Paterno��6%   $ * 6c   $
 True��6m    6?   �� *apellidoPaterno+6m     5      $ Apellido Materno��6%   $ * 6c   $
 True��6m    6?   �� *apellidoMaterno+6m   5      �� 5   
   $��No. de Sesión��6   $
��Left=�6(   $��
604,55,0,0q�6C   $	��Top=�6W   $��20(�6o   �� 5   
   -   5        	 ��Name$	 
tbNoSesion��5      $
��Left=�6&   $��
637,97,0,0q�6A   
 �� TextWrapping$

 Wrap=�6U   $�� ��6i   $	��Top=�6q   $��66��6�   $��20(�6�   �� 5   
   $��Periodo Escolar:��6   $
��Left=�6+   $��595,150,0,0q�6F   $	��Top=�6[   $��20(�6s   �� 5   
   -   5         ��Name$ cbPeriodoEscolar��5      $
��Left=�6-   $��	550,0,0,0q�6H   $��Center=�6[   $	��240��6v   $��16(�6�   �� 5   
   -   5         ��Name$ btBuscarReportePoTutor��5      $��Buscar��61   $
��Left=�6B   $��610,276,0,0q�6]   $	��Top=�6r   $��16(�6�   $	��120��6�   $��35��6�   6�   5      5      