﻿using ClienteSistemaTutorias.InterfacesUsuario.CUs;
using ClienteSistemaTutorias.Modelo;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClienteSistemaTutorias.InterfacesUsuario
{
    /// <summary>
    /// Lógica de interacción para WindowSesionesTutoria.xaml
    /// </summary>
    public partial class WindowSesionesTutoria : Window
    {
        RolesAcademicos rolAcademico;
        Academicos academico;
        MensajeInicioSesion usuarioSesion;
        public WindowSesionesTutoria(MensajeInicioSesion usuario)
        {
            InitializeComponent();
            rolAcademico = usuario.usuarioRolAcademico;
            academico = usuario.usuarioAcademico;
            usuarioSesion = usuario;
            TutoriaAcademicaViewModel vmTutoriaAcademica = new TutoriaAcademicaViewModel(rolAcademico.IDRolAcademico);
            dgTutoriasAcademicas.ItemsSource = vmTutoriaAcademica.tutoriaViewModel;
        }

        private void btRegistrarSesion_Click(object sender, RoutedEventArgs e)
        {
            WindowRegistrarSesionTutoria ventanaRegistrarSesionTutoria = new WindowRegistrarSesionTutoria(usuarioSesion);
            ventanaRegistrarSesionTutoria.Show();
        }

        private async void btModificarSesion_Click(object sender, RoutedEventArgs e)
        {
            if (dgTutoriasAcademicas.SelectedItem != null)
            {
                DatosTutoria FilaSeleccionada = (DatosTutoria)dgTutoriasAcademicas.SelectedItem;

                int IDTutoria = FilaSeleccionada.idTutoria;

                using (var conexionServicios = new Service1Client())
                {
                    TutoriaPeriodo tutoriaObtenida = await conexionServicios.consultarTutoriaAcademicaAsync(IDTutoria);
                    WindowModificarSesionTutoria ventanaModificarSesionTutoria = new WindowModificarSesionTutoria(tutoriaObtenida, usuarioSesion);
                    ventanaModificarSesionTutoria.Show();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una tutoría académica para continuar.");
            }
        }

        private void btRegistrarReporte_Click(object sender, RoutedEventArgs e)
        {
            if (dgTutoriasAcademicas.SelectedItem != null)
            {
                DatosTutoria FilaSeleccionada = (DatosTutoria)dgTutoriasAcademicas.SelectedItem;

                int IDTutoria = FilaSeleccionada.idTutoria;
                int IDRolAcademico = rolAcademico.IDRolAcademico;

                WindowReporteTutoria ventanaReporteTutoria = new WindowReporteTutoria(IDRolAcademico, IDTutoria);
                ventanaReporteTutoria.Show();
            }
            else
            {
                MessageBox.Show("Seleccione una tutoría académica para continuar.");
            }
        }

        private async void btGestionProblematica_Click(object sender, RoutedEventArgs e)
        {

            if (dgTutoriasAcademicas.SelectedItem != null)
            {
                DatosTutoria FilaSeleccionada = (DatosTutoria)dgTutoriasAcademicas.SelectedItem;

                int IDTutoria = FilaSeleccionada.idTutoria;

                using (var conexionServicios = new Service1Client())
                {
                    TutoriaPeriodo tutoriaObtenida = await conexionServicios.consultarTutoriaAcademicaAsync(IDTutoria);
                    WindowProblematicaAcademica ventanaProblematicaAcademica = new WindowProblematicaAcademica(tutoriaObtenida, usuarioSesion);
                    ventanaProblematicaAcademica.Show();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una tutoría académica para continuar.");
            }
        }
    }
}
