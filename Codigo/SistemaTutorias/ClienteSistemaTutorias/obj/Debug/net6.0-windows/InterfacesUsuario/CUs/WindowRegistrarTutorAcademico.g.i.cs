﻿#pragma checksum "..\..\..\..\..\InterfacesUsuario\CUs\WindowRegistrarTutorAcademico.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D2ABDCC55FA1909D20947C1B6EFDE61D2142F98"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ClienteSistemaTutorias.InterfacesUsuario.CUs;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ClienteSistemaTutorias.InterfacesUsuario.CUs {
    
    
    /// <summary>
    /// RegistrarTutorAcademico
    /// </summary>
    public partial class RegistrarTutorAcademico : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\..\InterfacesUsuario\CUs\WindowRegistrarTutorAcademico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNumPersonal;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\InterfacesUsuario\CUs\WindowRegistrarTutorAcademico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNombre;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\InterfacesUsuario\CUs\WindowRegistrarTutorAcademico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbApellidoPaterno;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\InterfacesUsuario\CUs\WindowRegistrarTutorAcademico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbApellidoMaterno;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\InterfacesUsuario\CUs\WindowRegistrarTutorAcademico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbEmail;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\InterfacesUsuario\CUs\WindowRegistrarTutorAcademico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTelefono;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\InterfacesUsuario\CUs\WindowRegistrarTutorAcademico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btGuardarEstudiante;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ClienteSistemaTutorias;component/interfacesusuario/cus/windowregistrartutoracade" +
                    "mico.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\InterfacesUsuario\CUs\WindowRegistrarTutorAcademico.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbNumPersonal = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbNombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbApellidoPaterno = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbApellidoMaterno = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbTelefono = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btGuardarEstudiante = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\..\InterfacesUsuario\CUs\WindowRegistrarTutorAcademico.xaml"
            this.btGuardarEstudiante.Click += new System.Windows.RoutedEventHandler(this.btGuardarTutor_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

