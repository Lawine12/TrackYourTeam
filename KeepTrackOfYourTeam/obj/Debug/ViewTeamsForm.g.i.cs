﻿#pragma checksum "..\..\ViewTeamsForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13C0E0EC7DA26FC2009E4533D78A4C31ADBB3874"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KeepTrackOfYourTeam;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace KeepTrackOfYourTeam {
    
    
    /// <summary>
    /// ViewTeamsForm
    /// </summary>
    public partial class ViewTeamsForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ViewTeamsForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridTeams;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ViewTeamsForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonAddATeam;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ViewTeamsForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonEditTeam;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ViewTeamsForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDeleteTeam;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KeepTrackOfYourTeam;component/viewteamsform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ViewTeamsForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dataGridTeams = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\ViewTeamsForm.xaml"
            this.dataGridTeams.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGridTeams_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.buttonAddATeam = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\ViewTeamsForm.xaml"
            this.buttonAddATeam.Click += new System.Windows.RoutedEventHandler(this.buttonAddATeam_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonEditTeam = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\ViewTeamsForm.xaml"
            this.buttonEditTeam.Click += new System.Windows.RoutedEventHandler(this.buttonEditTeam_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonDeleteTeam = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\ViewTeamsForm.xaml"
            this.buttonDeleteTeam.Click += new System.Windows.RoutedEventHandler(this.buttonDeleteTeam_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

