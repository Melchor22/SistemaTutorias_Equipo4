﻿#pragma checksum "..\..\..\..\..\InterfacesUsuario\CUs\WindowReporteTutoriaPorTutor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5E077813B2EA9BFF2F85838B63E294E9FD3344DE"
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
    /// WindowReporteTutoriaPorTutor
    /// </summary>
    public partial class WindowReporteTutoriaPorTutor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\InterfacesUsuario\CUs\WindowReporteTutoriaPorTutor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgTutores;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\InterfacesUsuario\CUs\WindowReporteTutoriaPorTutor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNoSesion;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\InterfacesUsuario\CUs\WindowReporteTutoriaPorTutor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPeriodoEscolar;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\InterfacesUsuario\CUs\WindowReporteTutoriaPorTutor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btBuscarReportePoTutor;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ClienteSistemaTutorias;V1.0.0.0;component/interfacesusuario/cus/windowreportetut" +
                    "oriaportutor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\InterfacesUsuario\CUs\WindowReporteTutoriaPorTutor.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dgTutores = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.tbNoSesion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cbPeriodoEscolar = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.btBuscarReportePoTutor = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\..\InterfacesUsuario\CUs\WindowReporteTutoriaPorTutor.xaml"
            this.btBuscarReportePoTutor.Click += new System.Windows.RoutedEventHandler(this.btBuscarReportePorTutor_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

