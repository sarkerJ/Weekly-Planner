﻿#pragma checksum "..\..\..\CreateActivity.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "28FB93D7A280C6997473B6FE00FBD7C3382AD574"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Weekly_PlannerGUILayer;


namespace Weekly_PlannerGUILayer {
    
    
    /// <summary>
    /// CreateActivity
    /// </summary>
    public partial class CreateActivity : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\CreateActivity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TName;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\CreateActivity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TContent;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\CreateActivity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LDay;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\CreateActivity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LName;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\CreateActivity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LContent;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\CreateActivity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxDays;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\CreateActivity.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BAdd;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Weekly_PlannerGUILayer;component/createactivity.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CreateActivity.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TContent = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.LDay = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.LName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.LContent = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.ComboBoxDays = ((System.Windows.Controls.ComboBox)(target));
            
            #line 40 "..\..\..\CreateActivity.xaml"
            this.ComboBoxDays.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxDays_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BAdd = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\CreateActivity.xaml"
            this.BAdd.Click += new System.Windows.RoutedEventHandler(this.BAdd_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

