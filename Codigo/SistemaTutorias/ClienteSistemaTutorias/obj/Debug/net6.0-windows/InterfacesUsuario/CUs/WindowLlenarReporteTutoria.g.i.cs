﻿#pragma checksum "..\..\..\..\..\InterfacesUsuario\CUs\WindowLlenarReporteTutoria.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62A4681BB6311ECB164567639624885D2DF94A24"
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
    /// WindowLlenarReporteTutoria
    /// </summary>
    public partial class WindowLlenarReporteTutoria : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\InterfacesUsuario\CUs\WindowLlenarReporteTutoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbDescripcionReporte;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\InterfacesUsuario\CUs\WindowLlenarReporteTutoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPeriodoEscolar;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\InterfacesUsuario\CUs\WindowLlenarReporteTutoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbNumSesion;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\InterfacesUsuario\CUs\WindowLlenarReporteTutoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btRegistrar;
        
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
            System.Uri resourceLocater = new System.Uri("/ClienteSistemaTutorias;component/interfacesusuario/cus/windowllenarreportetutori" +
                    "a.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\InterfacesUsuario\CUs\WindowLlenarReporteTutoria.xaml"
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
            this.tbDescripcionReporte = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.cbPeriodoEscolar = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.cbNumSesion = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.btRegistrar = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\..\InterfacesUsuario\CUs\WindowLlenarReporteTutoria.xaml"
            this.btRegistrar.Click += new System.Windows.RoutedEventHandler(this.btRegistrar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

