﻿#pragma checksum "..\..\..\..\..\InterfacesUsuario\CUs\WindowModificarSesionTutoria.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "838E3597898500E38FFA9C72FF578306B747BA90"
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
    /// WindowModificarSesionTutoria
    /// </summary>
    public partial class WindowModificarSesionTutoria : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\..\InterfacesUsuario\CUs\WindowModificarSesionTutoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFecha;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\InterfacesUsuario\CUs\WindowModificarSesionTutoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbHora;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\InterfacesUsuario\CUs\WindowModificarSesionTutoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbNumSesion;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\InterfacesUsuario\CUs\WindowModificarSesionTutoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btModificar;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\InterfacesUsuario\CUs\WindowModificarSesionTutoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPeriodoEscolar;
        
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
            System.Uri resourceLocater = new System.Uri("/ClienteSistemaTutorias;component/interfacesusuario/cus/windowmodificarsesiontuto" +
                    "ria.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\InterfacesUsuario\CUs\WindowModificarSesionTutoria.xaml"
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
            this.tbFecha = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbHora = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cbNumSesion = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.btModificar = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\..\InterfacesUsuario\CUs\WindowModificarSesionTutoria.xaml"
            this.btModificar.Click += new System.Windows.RoutedEventHandler(this.ButtonModificar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cbPeriodoEscolar = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

