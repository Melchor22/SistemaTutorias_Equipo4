   M S B A M L   `   `   `  ����Q  MClienteSistemaTutorias, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:ClienteSistemaTutorias.InterfacesUsuario(ClienteSistemaTutorias.InterfacesUsuario  5   	   L    FClienteSistemaTutorias.InterfacesUsuario.WindowRegistrarTutorAcademico   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Hlocal6clr-namespace:ClienteSistemaTutorias.InterfacesUsuario     5   	     � Title$  Registrar Tutor Academico��5   	   $	��450��6+   $	��800��68    � Icon$G A..\..\Resources/1200px-Logo_de_la_Universidad_Veracruzana.svg.png��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$ SingleBorderWindow=�5   	   .��5      � .+�5   
   �� $��	Password:��6   $
��Left=�6$   $��627,103,0,0q�6?   $	��Top=�6T   $	��100��6l   $��20(�6x   �� 5   
   -   5         ��Name$ 
tbPassword��5      $
��Left=�6&   $��564,157,0,0q�6A    �� TextWrapping$
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��226��6�   $��16(�6�   �� 5   
   -   5         ��Name$ btGuardarTutor��5      $��Guardar��6)   $
��Left=�6;   $��634,217,0,0q�6V   $	��Top=�6k   $��20(�6�   $��86��6�   $��47��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgAcademicos��5         AutoGenerateColumns$ False��6)   $��
0,38,266,0q�6E   	   CanUserAddRows$	 False��6Y   $��16(�6p   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Num Personal��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 108 6[      
IsReadOnly$
 True��6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *numPersonal+6g     5      $ Nombre��6%   $ * 6P   $
 True��6Z    65   �� *nombre+6Z     5      $ Apellido Paterno��6%   $ * 6c   $
 True��6m    6?   �� *apellidoPaterno+6m     5      $ Apellido Materno��6%   $ * 6c   $
 True��6m    6?   �� *apellidoMaterno+6m   5      �� 5   
   $��Académicos��6   $
��Left=�6%   $��
217,-4,0,0q�6@   $	��Top=�6T   $	��119��6l   $��20(�6x   5      5      