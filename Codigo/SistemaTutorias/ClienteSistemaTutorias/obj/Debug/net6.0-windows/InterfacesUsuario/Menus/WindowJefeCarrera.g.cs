﻿#pragma checksum "..\..\..\..\..\InterfacesUsuario\Menus\WindowJefeCarrera.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EE42FD54DF066247D1C503AC96653BCB3EB36566"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ClienteSistemaTutorias.InterfacesUsuario;
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


namespace ClienteSistemaTutorias.InterfacesUsuario {
    
    
    /// <summary>
    /// WindowJefeCarrera
    /// </summary>
    public partial class WindowJefeCarrera : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\InterfacesUsuario\Menus\WindowJefeCarrera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbBienvenido;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\InterfacesUsuario\Menus\WindowJefeCarrera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btReporteTutoria;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\InterfacesUsuario\Menus\WindowJefeCarrera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btProblematica;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\InterfacesUsuario\Menus\WindowJefeCarrera.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCerrarSesion;
        
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
            System.Uri resourceLocater = new System.Uri("/ClienteSistemaTutorias;component/interfacesusuario/menus/windowjefecarrera.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\InterfacesUsuario\Menus\WindowJefeCarrera.xaml"
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
            this.lbBienvenido = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.btReporteTutoria = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\..\InterfacesUsuario\Menus\WindowJefeCarrera.xaml"
            this.btReporteTutoria.Click += new System.Windows.RoutedEventHandler(this.btReporteTutoria_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btProblematica = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\..\InterfacesUsuario\Menus\WindowJefeCarrera.xaml"
            this.btProblematica.Click += new System.Windows.RoutedEventHandler(this.btProblematica_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btCerrarSesion = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\..\InterfacesUsuario\Menus\WindowJefeCarrera.xaml"
            this.btCerrarSesion.Click += new System.Windows.RoutedEventHandler(this.btCerrarSesion_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

